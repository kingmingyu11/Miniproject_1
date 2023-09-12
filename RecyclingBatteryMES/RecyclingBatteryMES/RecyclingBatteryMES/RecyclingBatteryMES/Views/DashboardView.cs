using Oracle.ManagedDataAccess.Client;
using RecyclingBatteryMES.Models;
using RecyclingBatteryMES.Presenters;
using RecyclingBatteryMES.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using RecyclingBatteryMES.Views;



namespace RecyclingBatteryMES.Views
{
    public partial class DashboardView : Form
    {
        public event EventHandler OnDisplay;
        const int GOALPRODUC = 30;
        


        //데이터베이스 객체 선언
        static string strConn = ConfigurationManager.AppSettings["DBConnection"];
        static OracleConnection conn = new OracleConnection(strConn);

        //DB 찾기용 메소드
        private void SelectCompound(object sender, EventArgs e)
        {
            /*데이터베이스 연결*/
            conn.Open();

            //데이터베이스 조회
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            
            try
            {
                cmd.CommandText = "SELECT 화합물이름, 무게 FROM BRCOMPOUND";     // 현재 오늘까지 생산량
                OracleDataReader rdr = cmd.ExecuteReader();


                int i = 0;
                //int[] ID = new int[9];
                int[] Weight = new int[9];
                string[] Name = new string[9];
                while (rdr.Read())
                {
                    //ID[i] = int.Parse(rdr["화합물_ID"].ToString());
                    Weight[i] = int.Parse(rdr["무게"].ToString());
                    Name[i] = rdr["화합물이름"].ToString();
                    i++;
                }

                DrawPieChart(chart1, Weight[0], GOALPRODUC - Weight[0]);
                DrawPieChart(chart2, Weight[1], GOALPRODUC - Weight[1]);
                DrawPieChart(chart3, Weight[2], GOALPRODUC - Weight[2]);
                DrawPieChart(chart4, Weight[3], GOALPRODUC - Weight[3]);
                DrawPieChart(chart5, Weight[4], GOALPRODUC - Weight[4]);
                DrawPieChart(chart6, Weight[5], GOALPRODUC - Weight[5]);
                DrawPieChart(chart7, Weight[6], GOALPRODUC - Weight[6]);
                DrawPieChart(chart10, Weight[7], GOALPRODUC - Weight[7]);
                DrawPieChart(chart9, Weight[8], GOALPRODUC - Weight[8]);
                lbl_dayCapa1.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa2.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa2.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa2.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa2.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa2.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa2.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa2.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa2.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa2.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa2.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa2.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa3.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa2.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa4.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa5.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa6.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa7.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa8.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayCapa9.Text = GOALPRODUC.ToString() + " kg";
                lbl_dayNow1.Text = Weight[0].ToString() + " kg";
                lbl_dayNow2.Text = Weight[0].ToString() + " kg";
                lbl_dayNow3.Text = Weight[0].ToString() + " kg";
                lbl_dayNow4.Text = Weight[0].ToString() + " kg";
                lbl_dayNow5.Text = Weight[0].ToString() + " kg";
                lbl_dayNow6.Text = Weight[0].ToString() + " kg";
                lbl_dayNow7.Text = Weight[0].ToString() + " kg";
                lbl_dayNow8.Text = Weight[0].ToString() + " kg";
                lbl_dayNow9.Text = Weight[0].ToString() + " kg";
          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            /*데이터베이스 종료*/
            conn.Close();
        }

        //파이 그리기 메소드1
        private void DrawPieChart(Chart chart, int value1, int value2)
        {
            chart.Series[0].Points.Clear(); 
            chart.Series[0].Points.AddXY("추가필요", value1);
            chart.Series[0].Points.AddXY("현재", value2);
        }
      
        public DashboardView()
        {
            InitializeComponent();
        }

        
       

        

        private void DashboardView_Load_1(object sender, EventArgs e)
        {
            SelectCompound(sender, e);
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

        private void lblDelivery_Click(object sender, EventArgs e)
        {
            DeliveryView view = new DeliveryView();
            this.Visible = false;
            view.Show();

        }
    }
}
