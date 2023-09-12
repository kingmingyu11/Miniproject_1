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
using System.Windows.Forms.DataVisualization.Charting;

namespace RecyclingBatteryMES.Views
{
    public partial class DeliveryView : Form
    {
        //데이터베이스 객체 선언
        static string strConn = ConfigurationManager.AppSettings["DBConnection"];
        static OracleConnection conn = new OracleConnection(strConn);

        public DeliveryView()
        {
            InitializeComponent();
        }

        private void DeliveryView_Load(object sender, EventArgs e)
        {
            //처음 원그래프 조회하기
            SelectCompound();

            /*
            //리스트 박스 설정
            listView1.View = View.Details;

            listView1.Columns.Add("주문날짜", 10);
            listView1.Columns.Add("화합물", 30);
            listView1.Columns.Add("무게", 10);
            */
        }

        private void SelectCompound()
        {
            /*데이터베이스 연결*/
            conn.Open();

            //데이터베이스 조회
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            try
            {
                cmd.CommandText = "SELECT * FROM BRCOMPOUND";
                OracleDataReader rdr = cmd.ExecuteReader();


                int i = 0;
                //int[] ID = new int[9];
                int[] Weight = new int[9];
                while (rdr.Read())
                {
                    //ID[i] = int.Parse(rdr["화합물_ID"].ToString());
                    Weight[i] = int.Parse(rdr["무게"].ToString());
                    i++;
                }


                DrawPieChart(chart1, Weight[0], Weight[1], Weight[2], Weight[3]);
                DrawPieChart(chart2, Weight[4], Weight[5], Weight[6]);
                DrawPieChart(chart3, Weight[7], Weight[8]);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            /*데이터베이스 종료*/
            conn.Close();
        }

        private void DrawPieChart(Chart chart, int value1, int value2, int value3, int value4)
        {
            chart.Series[0].Points.Clear();

            chart.Series[0].Points.AddXY("1", value1);
            chart.Series[0].Points.AddXY("2", value2);
            chart.Series[0].Points.AddXY("3", value3);
            chart.Series[0].Points.AddXY("4", value4);
        }

        private void DrawPieChart(Chart chart, int value1, int value2, int value3)
        {
            chart.Series[0].Points.Clear();

            chart.Series[0].Points.AddXY("1", value1);
            chart.Series[0].Points.AddXY("2", value2);
            chart.Series[0].Points.AddXY("3", value3);
        }

        private void DrawPieChart(Chart chart, int value1, int value2)
        {
            chart.Series[0].Points.Clear();

            chart.Series[0].Points.AddXY("1", value1);
            chart.Series[0].Points.AddXY("2", value2);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            //데이터베이스 연결
            conn.Open();

            //데이터베이스 조회
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT * FROM BRORDER WHERE 납부여부 = 'X'";
            OracleDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                string[] cmdstr = new string[3];
                cmdstr[0] = rdr.GetDateTime(rdr.GetOrdinal("날짜")).ToString("yy-MM-dd");
                cmdstr[1] = rdr["화합물이름"].ToString();
                cmdstr[2] = rdr["무게"].ToString();

                string resultlist = $"{cmdstr[0],-10}:{cmdstr[1],-30}:{cmdstr[2],-10}";
                listBox1.Items.Add(resultlist);
                //listView1.Items.Add(new ListViewItem(new[] { cmdstr[0], cmdstr[1], cmdstr[2] }));
            }

            //데이터베이스 종료
            conn.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] focusList = listBox1.Text.Replace(" ", "").Split(':');
            //listBox1.Items.Add(focusList[1]);
            //listBox1.Items.Add(focusList[2]);
            //UpdateOrderCompound(sender, e, focusList[1], focusList[2]);
        }

        private void UpdateOrderCompound(object sender, EventArgs e, string items, string weight)
        {
            //데이터베이스 연결
            conn.Open();

            //데이터베이스 조회
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            OracleDataReader rdr;

            try
            {
                //compound 개수를 업데이트 한다!
                cmd.CommandText = "UPDATE BRCOMPOUND SET 무게 = 무게 - " + weight + " WHERE 화합물이름 = " + items;
                rdr = cmd.ExecuteReader();
                //compound 개수를 업데이트 한 후 파이를 다시 한다.
                //SelectCompound();
                //그리고 order에서 Y로 바꾸어 준다.
                //cmd.CommandText = "UPDATE BRORDER SET 납부여부 = 'O' WHERE 화합물이름 = " + items;
                //rdr = cmd.ExecuteReader();
                //그 다음 조회하기를 해준다.
                //btnSelect_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //데이터베이스 종료
            conn.Close();
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

        private void lblOrder_Click(object sender, EventArgs e)
        {
            OrderView view = new OrderView();
            this.Visible = false;
            view.Show();
        }
    }
}
