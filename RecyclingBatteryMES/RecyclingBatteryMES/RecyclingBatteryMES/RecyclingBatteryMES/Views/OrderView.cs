using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecyclingBatteryMES.Views
{
    public partial class OrderView : Form
    {

        /*데이터 베이스 연결*/
        static string strConn = ConfigurationManager.AppSettings["DBConnection"];
        static OracleConnection conn = new OracleConnection(strConn);
        public OrderView()
        {
            InitializeComponent();
        }

        private void OrderView_Load(object sender, EventArgs e)
        {
            /*데이터베이스 연결*/
            conn.Open();

            /*협력업체 개수 초기화*/
            lblAFirmPayCnt.Text = "0개";
            lblBFirmPayCnt.Text = "0개";
            lblCFirmPayCnt.Text = "0개";
            lblDFirmPayCnt.Text = "0개";


            //데이터베이스 조회
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT * FROM BRFIRM";
            OracleDataReader rdr = cmd.ExecuteReader();

            int[] wasteBCnt = new int[10];
            string[] FirmName = new string[10];
            int i = 0;

            while (rdr.Read())
            {
                wasteBCnt[i] = int.Parse(rdr["폐배터리개수"].ToString());
                FirmName[i] = rdr["업체명"].ToString();
                i++;
            }
            lblAFirmBatteryCnt.Text = wasteBCnt[0].ToString() + "개";
            lblBFirmBatteryCnt.Text = wasteBCnt[1].ToString() + "개";
            lblCFirmBatteryCnt.Text = wasteBCnt[2].ToString() + "개";
            lblDFirmBatteryCnt.Text = wasteBCnt[3].ToString() + "개";

            lblAFirmName.Text = FirmName[0];
            lblBFirmName.Text = FirmName[1];
            lblCFirmName.Text = FirmName[2];
            lblDFirmName.Text = FirmName[3];

            /*현재 배터리 주문 현황 작동 비활성화*/
            pnlFirstOrderState.Visible = false;
            pnlSecondOrderState.Visible = false;

            /*주문 현황 날짜, 개수, 퍼센트 초기화*/
            lblFirstDate.Text = "주문일:" + DateTime.Now.ToString("yy-MM-dd");
            lblSecondDate.Text = "주문일:" + DateTime.Now.ToString("yy-MM-dd");
            lblFirstOrderCnt.Text = "주문 개수:0개";
            lblSecondOrderCnt.Text = "주문 개수:0개";
            lblFirstPayCnt.Text = "납입 개수:0개";
            lblSecondPayCnt.Text = "납입 개수:0개";
            pgbFirstRatio.Value = 0;
            pgbSecondRatio.Value = 0;
            lblFirstPercent.Text = "0%";
            lblSecondPercent.Text = "0%";

            /*데이터베이스 종료*/
            conn.Close();
        }

        private void OracleDBUpdate(object sender, EventArgs e, int Cnt)
        {
            //작업하기 위해서 수량만 따오는 곳
            string[] BatteryCnt = new string[4];
            BatteryCnt[0] = lblAFirmBatteryCnt.Text.Replace("개", "");
            BatteryCnt[1] = lblBFirmBatteryCnt.Text.Replace("개", "");
            BatteryCnt[2] = lblCFirmBatteryCnt.Text.Replace("개", "");
            BatteryCnt[3] = lblDFirmBatteryCnt.Text.Replace("개", "");

            //데이터베이스 시작
            conn.Open();

            //실험
            OracleCommand cmd = conn.CreateCommand();
            OracleTransaction transaction = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            cmd.Transaction = transaction;

            //추가를 위한 select 
            cmd.CommandText = "SELECT 폐배터리개수 FROM BRFIRM WHERE ID = 5";
            OracleDataReader rdr = cmd.ExecuteReader();

            string ANUBetteryCnt = string.Empty;
            while (rdr.Read())
            {
                ANUBetteryCnt = rdr["폐배터리개수"].ToString();
            }

            Cnt = Cnt + int.Parse(ANUBetteryCnt);

            //update
            try
            {
                string[] cmdArray = new string[5];
                cmdArray[0] = "UPDATE BRFIRM SET 폐배터리개수=" + BatteryCnt[0] + " WHERE ID=1;";
                cmdArray[1] = "UPDATE BRFIRM SET 폐배터리개수=" + BatteryCnt[1] + " WHERE ID=2;";
                cmdArray[2] = "UPDATE BRFIRM SET 폐배터리개수=" + BatteryCnt[2] + " WHERE ID=3;";
                cmdArray[3] = "UPDATE BRFIRM SET 폐배터리개수=" + BatteryCnt[3] + " WHERE ID=4;";
                cmdArray[4] = "UPDATE BRFIRM SET 폐배터리개수=" + Cnt.ToString() + " WHERE ID=5;";

                string combinedQuery = "BEGIN " + cmdArray[0] + cmdArray[1] + cmdArray[2] + cmdArray[3] + cmdArray[4] + " END;";

                cmd.CommandText = combinedQuery;
                cmd.ExecuteNonQuery();

                // 모든 쿼리가 성공하면 트랜잭션 커밋
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // 에러가 발생하면 롤백
                transaction.Rollback();
                MessageBox.Show(ex.ToString());
            }
            //리소스 반환
            conn.Close();
        }

        /*주문 시 작업에 들어가는 것*/
        private void OrderList_Order(object sender, EventArgs e, int Cnt, string Firm)
        {
            /*첫번째 현재 진행 추가*/
            if (pnlFirstOrderState.Visible == false)
            {
                /*작동시작, 초기화*/
                pnlFirstOrderState.Visible = true;
                lblFirstOrderCnt.Text = "주문 개수:" + Cnt + "개";
                pgbFirstRatio.Value = 0;
                lblFirstPayCnt.Text = "납입 개수:0개";
                lblFirstPercent.Text = "0%";
                lblFirstName.Text = Firm;

                pgbFirstRatio.Maximum = Cnt;

                /*작업 중*/
                Task.Run(() =>
                {
                    for (int i = 0; i <= Cnt; i++)
                    {
                        int percent = (int)((double)i / Cnt * 100);

                        pgbFirstRatio.Value = i;
                        lblFirstPayCnt.Text = "납입 개수:" + i.ToString() + "개";
                        lblFirstPercent.Text = percent.ToString() + "%";
                        Task.Delay(1000).Wait();
                    }

                    Task.Delay(1000).Wait();

                    /*작업 끝*/
                    switch (Firm)
                    {
                        case "민규전자":
                            lblAFirmPayCnt.Text = (int.Parse(lblAFirmPayCnt.Text.Replace("개", "")) - Cnt).ToString() + "개";
                            break;
                        case "성일하이텍":
                            lblBFirmPayCnt.Text = (int.Parse(lblBFirmPayCnt.Text.Replace("개", "")) - Cnt).ToString() + "개";
                            break;
                        case "세빗켐":
                            lblCFirmPayCnt.Text = (int.Parse(lblCFirmPayCnt.Text.Replace("개", "")) - Cnt).ToString() + "개";
                            break;
                        case "고려아연":
                            lblDFirmPayCnt.Text = (int.Parse(lblDFirmPayCnt.Text.Replace("개", "")) - Cnt).ToString() + "개";
                            break;
                    }

                    pnlFirstOrderState.Visible = false;
                });

                /*데이터베이스 반영*/
                OracleDBUpdate(sender, e, Cnt);
            }
            else if (pnlSecondOrderState.Visible == false)
            {
                /*작동시작, 초기화*/
                pnlSecondOrderState.Visible = true;
                lblSecondOrderCnt.Text = "주문 개수:" + Cnt + "개";
                pgbSecondRatio.Value = 0;
                lblSecondPayCnt.Text = "납입 개수:0개";
                lblSecondPercent.Text = "0%";
                lblSecondName.Text = Firm;

                pgbSecondRatio.Maximum = Cnt;

                /*작업 중*/
                Task.Run(() =>
                {
                    for (int i = 0; i <= Cnt; i++)
                    {
                        int percent = (int)((double)i / Cnt * 100);

                        pgbSecondRatio.Value = i;
                        lblSecondPayCnt.Text = "납입 개수:" + i.ToString() + "개";
                        lblSecondPercent.Text = percent.ToString() + "%";
                        Task.Delay(1000).Wait();
                    }

                    Task.Delay(1000).Wait();

                    /*작업 끝*/
                    switch (Firm)
                    {
                        case "민규전자":
                            lblAFirmPayCnt.Text = (int.Parse(lblAFirmPayCnt.Text.Replace("개", "")) - Cnt).ToString() + "개";
                            break;
                        case "성일하이텍":
                            lblBFirmPayCnt.Text = (int.Parse(lblBFirmPayCnt.Text.Replace("개", "")) - Cnt).ToString() + "개";
                            break;
                        case "세빗켐":
                            lblCFirmPayCnt.Text = (int.Parse(lblCFirmPayCnt.Text.Replace("개", "")) - Cnt).ToString() + "개";
                            break;
                        case "고려아연":
                            lblDFirmPayCnt.Text = (int.Parse(lblDFirmPayCnt.Text.Replace("개", "")) - Cnt).ToString() + "개";
                            break;
                    }

                    pnlSecondOrderState.Visible = false;
                });

                /*데이터베이스 반영*/
                OracleDBUpdate(sender, e, Cnt);
            }
        }



        private void btnAFirmOrder_Click(object sender, EventArgs e)
        {
            if (txtAFirmOrder.Text == "")
            {
                MessageBox.Show("수량을 입력하시오");
            }
            else
            {
                /*확인 용도*/
                string wasteA = lblAFirmBatteryCnt.Text;
                wasteA = wasteA.Replace("개", "");
                string orderA = lblAFirmPayCnt.Text;
                orderA = orderA.Replace("개", "");

                if (int.Parse(wasteA) >= int.Parse(txtAFirmOrder.Text))
                {
                    if (pnlFirstOrderState.Visible == false || pnlSecondOrderState.Visible == false)
                    {
                        lblAFirmBatteryCnt.Text = (int.Parse(wasteA) - int.Parse(txtAFirmOrder.Text)).ToString() + "개";
                        lblAFirmPayCnt.Text = (int.Parse(orderA) + int.Parse(txtAFirmOrder.Text)).ToString() + "개";
                        OrderList_Order(sender, e, int.Parse(txtAFirmOrder.Text), lblAFirmName.Text);
                    }
                }
                else
                {
                    MessageBox.Show("너무 많습니다.");
                }
            }
        }
    

        private void btnBFirmOrder_Click(object sender, EventArgs e)
        {
            if (txtBFirmOrder.Text == "")
            {
                MessageBox.Show("수량을 입력하시오");
            }
            else
            {
                /*확인 용도*/
                string wasteB = lblBFirmBatteryCnt.Text;
                wasteB = wasteB.Replace("개", "");
                string orderB = lblBFirmPayCnt.Text;
                orderB = orderB.Replace("개", "");

                if (int.Parse(wasteB) >= int.Parse(txtBFirmOrder.Text))
                {
                    if (pnlFirstOrderState.Visible == false || pnlSecondOrderState.Visible == false)
                    {
                        lblBFirmBatteryCnt.Text = (int.Parse(wasteB) - int.Parse(txtBFirmOrder.Text)).ToString() + "개";
                        lblBFirmPayCnt.Text = (int.Parse(orderB) + int.Parse(txtBFirmOrder.Text)).ToString() + "개";
                        OrderList_Order(sender, e, int.Parse(txtBFirmOrder.Text), lblBFirmName.Text);
                    }
                }
                else
                {
                    MessageBox.Show("너무 많습니다.");
                }
            }
        }

        private void btnCFirmOrder_Click(object sender, EventArgs e)
        {
            if (txtCFirmOrder.Text == "")
            {
                MessageBox.Show("수량을 입력하시오");
            }
            else
            {
                /*확인 용도*/
                string wasteC = lblCFirmBatteryCnt.Text;
                wasteC = wasteC.Replace("개", "");
                string orderC = lblCFirmPayCnt.Text;
                orderC = orderC.Replace("개", "");

                if (int.Parse(wasteC) >= int.Parse(txtCFirmOrder.Text))
                {
                    if (pnlFirstOrderState.Visible == false || pnlSecondOrderState.Visible == false)
                    {
                        lblCFirmBatteryCnt.Text = (int.Parse(wasteC) - int.Parse(txtCFirmOrder.Text)).ToString() + "개";
                        lblCFirmPayCnt.Text = (int.Parse(orderC) + int.Parse(txtCFirmOrder.Text)).ToString() + "개";
                        OrderList_Order(sender, e, int.Parse(txtCFirmOrder.Text), lblCFirmName.Text);
                    }
                }
                else
                {
                    MessageBox.Show("너무 많습니다.");
                }
            }
        }

        private void btnDFirmOrder_Click(object sender, EventArgs e)
        {
            if (txtDFirmOrder.Text == "")
            {
                MessageBox.Show("수량을 입력하시오");
            }
            else
            {
                /*확인 용도*/
                string wasteD = lblDFirmBatteryCnt.Text;
                wasteD = wasteD.Replace("개", "");
                string orderD = lblDFirmPayCnt.Text;
                orderD = orderD.Replace("개", "");

                if (int.Parse(wasteD) >= int.Parse(txtDFirmOrder.Text))
                {
                    if (pnlFirstOrderState.Visible == false || pnlSecondOrderState.Visible == false)
                    {
                        lblDFirmBatteryCnt.Text = (int.Parse(wasteD) - int.Parse(txtDFirmOrder.Text)).ToString() + "개";
                        lblDFirmPayCnt.Text = (int.Parse(orderD) + int.Parse(txtDFirmOrder.Text)).ToString() + "개";
                        OrderList_Order(sender, e, int.Parse(txtDFirmOrder.Text), lblDFirmName.Text);
                    }
                }
                else
                {
                    MessageBox.Show("너무 많습니다.");
                }
            }
        }

        private void lblDashBoard_Click(object sender, EventArgs e)
        {
            DashboardView view = new DashboardView();
            this.Visible = false;
            view.Show();
        }

        private void lblProcess_Click(object sender, EventArgs e)
        {
            ProcessView view = new ProcessView();
            this.Visible = false;
            view.Show();
        }

        private void lblDelivery_Click(object sender, EventArgs e)
        {
            DeliveryView view = new DeliveryView();
            this.Visible = false;
            view.Show();
        }
    }
}
