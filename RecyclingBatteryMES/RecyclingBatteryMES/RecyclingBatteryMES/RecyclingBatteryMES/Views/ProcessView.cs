using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecyclingBatteryMES.Views
{
    public partial class ProcessView : Form
    {
       
        private bool Pause = false;
        private CancellationTokenSource cts = new CancellationTokenSource();

        public ProcessView()
        {
            InitializeComponent();
            panel1.SendToBack();
        }

        private void ProcessView_Load(object sender, EventArgs e)
        {
            pictureBox11.Visible = true;
            pictureBox12.Visible = true;
            Picture13.Visible = true;
            pictureBox14.Visible = true;
            pictureBox15.Visible = true;
            pictureBox16.Visible = true;
            pictureBox17.Visible = true;
            pictureBox18.Visible = true;
            pictureBox19.Visible = true;

            //공정과정 gif 숨기기
            //pictureBox1.Visible = true;
            //pictureBox1.Visible = false;
            pictureBox11.Visible = true;
            //pictureBox11.Visible = false;
            //화살표 jpg 나타내기

            arrow10.Visible = true;
            arrow11.Visible = true;
            arrow12.Visible = true;
            arrow13.Visible = true;
            arrow14.Visible = true;
            arrow15.Visible = true;
            arrow16.Visible = true;
            arrow17.Visible = true;

        }

        private async Task PerformTaskAsync(System.Windows.Forms.ProgressBar progressBar, int maxValue)
        {
            // 비동기 작업 실행
            for (int i = 0; i <= maxValue; i += 25)
            {
                await Task.Delay(50); // 작업 시뮬레이션을 위한 딜레이
                progressBar.Value = i;
                progressBar.Update();
            }
        }

        private void ProgressBarRun(int select)
        {
            switch (select)
            {
                case 1:
                    Task.Run(async () =>
                    {
                        for (int i = 0; i <= 100; i += 25)
                        {
                            if (cts.Token.IsCancellationRequested)
                                return;
                            progressBar1.Value = i;
                            //progressBar1.Update();
                            await Task.Delay(50);
                        }
                    });
                    break;
                case 2:
                    Task.Run(async () =>
                    {
                        for (int i = 0; i <= 100; i += 25)
                        {
                            if (cts.Token.IsCancellationRequested)
                                return;
                            progressBar2.Value = i;
                            //progressBar2.Update();
                            await Task.Delay(50);
                        }
                    });
                    break;
                case 3:
                    Task.Run(async () =>
                    {
                        for (int i = 0; i <= 100; i += 25)
                        {
                            if (cts.Token.IsCancellationRequested)
                                return;
                            progressBar3.Value = i;
                            //progressBar3.Update();
                            await Task.Delay(50);
                        }
                    });
                    break;
                case 4:
                    Task.Run(async () =>
                    {
                        for (int i = 0; i <= 100; i += 25)
                        {
                            if (cts.Token.IsCancellationRequested)
                                return;
                            progressBar4.Value = i;
                            //progressBar4.Update();
                            await Task.Delay(50);
                        }
                    });
                    break;
                case 5:
                    Task.Run(async () =>
                    {
                        for (int i = 0; i <= 100; i += 25)
                        {
                            if (cts.Token.IsCancellationRequested)
                                return;
                            progressBar5.Value = i;
                            //progressBar5.Update();
                            await Task.Delay(50);
                        }
                    });
                    break;
                case 6:
                    Task.Run(async () =>
                    {
                        for (int i = 0; i <= 100; i += 25)
                        {
                            if (cts.Token.IsCancellationRequested)
                                return;
                            progressBar6.Value = i;
                            //progressBar6.Update();
                            await Task.Delay(50);
                        }
                    });
                    break;
                case 7:
                    Task.Run(async () =>
                    {
                        for (int i = 0; i <= 100; i += 25)
                        {
                            if (cts.Token.IsCancellationRequested)
                                return;
                            progressBar7.Value = i;
                            //progressBar7.Update();
                            await Task.Delay(50);
                        }
                    });
                    break;
                case 8:
                    Task.Run(async () =>
                    {
                        for (int i = 0; i <= 100; i += 25)
                        {
                            if (cts.Token.IsCancellationRequested)
                                return;
                            progressBar8.Value = i;
                            //progressBar8.Update();
                            await Task.Delay(50);
                        }
                    });
                    break;
                case 9:
                    Task.Run(async () =>
                    {
                        for (int i = 0; i <= 100; i += 25)
                        {
                            if (cts.Token.IsCancellationRequested)
                                return;
                            progressBar9.Value = i;
                            //progressBar9.Update();
                            await Task.Delay(50);
                        }
                    });
                    break;
            }
        }


        private void btnStart_Click_1(object sender, EventArgs e)
        {
            cts.Cancel();
            cts = new CancellationTokenSource();

            // pictureBox10.Visible = true;
            pictureBox11.Visible = true;
            pictureBox12.Visible = true;
            Picture13.Visible = true;
            pictureBox14.Visible = true;
            pictureBox15.Visible = true;
            pictureBox16.Visible = true;
            pictureBox17.Visible = true;
            pictureBox18.Visible = true;
            pictureBox19.Visible = true;

            pictureBox13.Visible = false;
            pictureBox20.Visible = false;
            arrow18.Visible = false;
            arrow19.Visible = false;
            arrow20.Visible = false;
            arrow21.Visible = false;
            arrow22.Visible = false;
            arrow23.Visible = false;
            arrow24.Visible = false;


            arrow10.Visible = true;
            arrow11.Visible = true;
            arrow12.Visible = true;
            arrow13.Visible = true;
            arrow14.Visible = true;
            arrow15.Visible = true;
            arrow16.Visible = true;
            arrow17.Visible = true;

            arrow18.Visible = false;
            arrow19.Visible = false;
            arrow20.Visible = false;
            arrow21.Visible = false;
            arrow22.Visible = false;
            arrow23.Visible = false;
            arrow24.Visible = false;
            arrow25.Visible = false;

            string[] atest = new string[30];
            atest[0] = @"./오른쪽화살표 gif.gif";
            atest[1] = @"./방전 gif22.gif";
            atest[2] = @"./해체gif.gif";
            atest[3] = @"./열처리.gif";
            atest[4] = @"./아래쪽화살표 gif.gif";
            atest[5] = @"./파쇄및분리 gif.gif";
            atest[6] = @"./왼쪽화살표gif.gif";
            atest[7] = @"./배터리파우더.gif";
            atest[8] = @"./침출.gif";
            atest[9] = @"./여과 및 저장.gif";
            atest[10] = @"./용매추출.gif";
            atest[11] = @"./리튬전지.jpg";

            atest[12] = @"./오른쪽화살표 jpg.PNG";
            atest[13] = @"./방전 jpg.PNG";
            atest[14] = @"./해체jpg2.jpg";
            atest[15] = @"./열처리 jpg.PNG";
            atest[16] = @"./아래쪽화살표 jpg.PNG";
            atest[17] = @"./파쇄및 분리 jpg.PNG";
            atest[18] = @"./왼쪽화살표 jpg.PNG";
            atest[19] = @"./배터리파우더 jpg.PNG";
            atest[20] = @"./침출jpg.PNG";
            atest[21] = @"./여과및저장jpg.PNG";
            atest[22] = @"./용매추출 jpg.PNG";

            Task.Run(async () =>
            {
                BatteryUpdateDB();
                await Task.Delay(50);

                await AppendTextAsync(" 폐배터리개수가 10개 줄어들었습니다...\r\n");
                Delay(1000);

                // Invoke((Action)(async () => { await PerformTaskAsync(progressBar1, 100); }));
                await AppendTextAsync(" 이차전지스크랩 작업이 완료되었습니다..\r\n");
                ProgressBarRun(1);
                Delay(3000);
                if (cts.Token.IsCancellationRequested)
                    return;


                //Invoke((Action)(async () => { await PerformTaskAsync(progressBar2, 100); }));
                arrow10.Load(atest[0]);
                pictureBox12.Load(atest[1]);
                ProgressBarRun(2);
                await AppendTextAsync(" 방전 작업이 완료되었습니다..\r\n");
                Delay(3000);
                pictureBox12.Image = null;
                pictureBox12.Load(atest[13]);
                arrow10.Image = null;
                arrow10.Load(atest[12]);
                if (cts.Token.IsCancellationRequested)
                    return;
                //  Invoke((Action)(async () => { await PerformTaskAsync(progressBar3, 100); }));

                arrow11.Load(atest[0]);
                Picture13.Load(atest[2]);
                ProgressBarRun(3);
                await AppendTextAsync(" 해체작업이 완료되었습니다..\r\n");
                Delay(3000);
                Picture13.Image = null;
                Picture13.Load(atest[14]);
                arrow11.Image = null;
                arrow11.Load(atest[12]);
                if (cts.Token.IsCancellationRequested)
                    return;

                // Invoke((Action)(async () => { await PerformTaskAsync(progressBar4, 100); }));
                arrow12.Load(atest[0]);
                pictureBox14.Load(atest[3]);
                ProgressBarRun(4);
                await AppendTextAsync(" 열처리 작업이 완료되었습니다..\r\n");
                Delay(3000);
                pictureBox14.Image = null;
                pictureBox14.Load(atest[15]);
                arrow12.Image = null;
                arrow12.Load(atest[12]);
                if (cts.Token.IsCancellationRequested)
                    return;

                // Invoke((Action)(async () => { await PerformTaskAsync(progressBar5, 100); }));
                arrow13.Load(atest[4]);
                pictureBox15.Load(atest[5]);
                ProgressBarRun(5);
                await AppendTextAsync(" 파쇄 및 분리 작업이 완료되었습니다..\r\n");
                Delay(3000);
                pictureBox15.Image = null;
                pictureBox15.Load(atest[17]);
                arrow13.Image = null;
                arrow13.Load(atest[16]);
                if (cts.Token.IsCancellationRequested)
                    return;

                //Invoke((Action)(async () => { await PerformTaskAsync(progressBar6, 100); }));
                arrow14.Load(atest[6]);
                pictureBox16.Load(atest[7]);
                ProgressBarRun(6);
                await AppendTextAsync(" 배터리파우더 작업이 완료되었습니다..\r\n");
                Delay(3000);
                pictureBox16.Image = null;
                pictureBox16.Load(atest[19]);
                arrow14.Image = null;
                arrow14.Load(atest[18]);
                if (cts.Token.IsCancellationRequested)
                    return;

                //Invoke((Action)(async () => { await PerformTaskAsync(progressBar7, 100); }));
                arrow15.Load(atest[6]);
                pictureBox17.Load(atest[8]);
                ProgressBarRun(7);
                await AppendTextAsync(" 침출 작업이 완료되었습니다..\r\n");
                Delay(2000);
                pictureBox17.Image = null;
                pictureBox17.Load(atest[20]);
                arrow15.Image = null;
                arrow15.Load(atest[18]);
                if (cts.Token.IsCancellationRequested)
                    return;

                //Invoke((Action)(async () => { await PerformTaskAsync(progressBar8, 100); }));
                arrow16.Load(atest[6]);
                pictureBox18.Load(atest[9]);
                ProgressBarRun(8);
                await AppendTextAsync(" 여과 및 저장 작업이 완료되었습니다..\r\n");
                Delay(2000);
                pictureBox18.Image = null;
                pictureBox18.Load(atest[21]);
                arrow16.Image = null;
                arrow16.Load(atest[12]);
                if (cts.Token.IsCancellationRequested)
                    return;


                // Invoke((Action)(async () => { await PerformTaskAsync(progressBar9, 100); }));
                arrow17.Load(atest[4]);
                pictureBox19.Load(atest[10]);
                ProgressBarRun(9);
                await AppendTextAsync(" 용매추출 작업이 완료되었습니다..\r\n");

                pictureBox19.Image = null;
                pictureBox19.Load(atest[22]);
                arrow17.Image = null;
                arrow17.Load(atest[16]);
                if (cts.Token.IsCancellationRequested)
                    return;

                UpdateDB();
            });
        }
        private void UpdateDB()
        {
            //데이터 베이스 연결
            string strConn = ConfigurationManager.AppSettings["DBConnection"];
            OracleConnection conn = new OracleConnection(strConn);

            //데이터베이스 연결
            conn.Open();

            //데이터베이스 조회할 cmd
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            //데이터베이스 받아오기
            cmd.CommandText = "UPDATE BRCOMPOUND SET 무게 = 무게+10";
            OracleDataReader rdr = cmd.ExecuteReader();
            cmd.CommandText = "UPDATE BRDAY SET 무게 = 무게+10";
            rdr = cmd.ExecuteReader();
            //cmd.CommandText = "UPDATE BRFIRM SET 폐배터리개수 = 폐배터리개수 -10 WHERE 업체명 = 'ANU'";
            //rdr = cmd.ExecuteReader();

            /*데이터베이스 종료*/
            conn.Close();
        }

        private void BatteryUpdateDB()
        {
            //데이터 베이스 연결
            string strConn = ConfigurationManager.AppSettings["DBConnection"];
            OracleConnection conn = new OracleConnection(strConn);

            //데이터베이스 연결
            conn.Open();

            //데이터베이스 조회할 cmd
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "UPDATE BRFIRM SET 폐배터리개수 = 폐배터리개수 -10 WHERE 업체명 = 'ANU'";
            OracleDataReader rdr = cmd.ExecuteReader();

            /*데이터베이스 종료*/
            conn.Close();
        }



        private void btnStop_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();

            cts.Cancel();

            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;
            progressBar5.Value = 0;
            progressBar6.Value = 0;
            progressBar7.Value = 0;
            progressBar8.Value = 0;
            progressBar9.Value = 0;

            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            Picture13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;


            pictureBox13.Visible = true;
            pictureBox20.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            pictureBox10.Visible = true;

            arrow10.Visible = false;
            arrow11.Visible = false;
            arrow12.Visible = false;
            arrow13.Visible = false;
            arrow14.Visible = false;
            arrow15.Visible = false;
            arrow16.Visible = false;
            arrow17.Visible = false;

            arrow18.Visible = true;
            arrow19.Visible = true;
            arrow20.Visible = true;
            arrow21.Visible = true;
            arrow22.Visible = true;
            arrow23.Visible = true;
            arrow24.Visible = true;
            arrow25.Visible = true;

        }
        private async Task AppendTextAsync(string text) //텍스트 박스에 텍스트 여러줄 추가하기위해 사용했습니다.
        {
            await Task.Run(() =>
            {
                if (textBox1.InvokeRequired)
                {
                    textBox1.Invoke((Action)(() => textBox1.AppendText(text)));
                }
                else
                {
                    textBox1.AppendText(text);
                }
            });
        }

        private static DateTime Delay(int MS)  //딜레이 함수
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void lblDashBoard_Click(object sender, EventArgs e)
        {
            DashboardView view = new DashboardView();
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
