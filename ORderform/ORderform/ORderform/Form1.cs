using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

namespace ORderform
{
    public partial class Form1 : Form
    {

        int num = 5;
        string selectedIndex;
        string selectedIndex2;
        int weight;
        public Form1()
        {
            InitializeComponent();

        }

        private void OrderOracle(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.AppSettings["DBConnection"];
            OracleConnection conn = new OracleConnection(strConn);

            //데이터베이스 연결
            conn.Open();

            //데이터베이스 조회할 cmd
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            //데이터베이스 받아오기

            //weight = int.Parse(textBox1.Text);

            string[] testA = listBox1.Text.Replace(" ", "").Split(',');
            listBox1.Items.Add(testA[1] + testA[3] + testA[5]);

            num++;


            /*cmd.CommandText = "INSERT INTO BRORDER(주문번호, 날짜, 업체종류, 화합물이름, 무게, 납부여부) " +
                                      $"VALUES({orderNum}, SYSDATE, '{selectedIndex}', '{selectedIndex2}', {textBox1.Text}, 'X')";*/
            /*cmd.CommandText = "INSERT INTO BRORDER(주문번호, 날짜, 업체종류, 화합물이름, 무게, 납부여부) " +
                                      $"VALUES(33 ,sysdate,'{selectedIndex}','{selectedIndex2}',90,'X')";*/

            cmd.CommandText = "INSERT INTO BRORDER VALUES(" + num.ToString() + ", SYSDATE, '" + testA[1] + "','" + testA[3] + "'," + testA[5] + ", 'X')";


            OracleDataReader rdr = cmd.ExecuteReader();

            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("민규전자");
            comboBox1.Items.Add("성일하이텍");
            comboBox1.Items.Add("세빗캠");
            comboBox1.Items.Add("고려아연");
            comboBox1.Items.Add("ANU");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {


            selectedIndex = comboBox1.SelectedItem.ToString();
            selectedIndex2 = comboBox2.SelectedItem.ToString();


            if (comboBox1.SelectedIndex != -1)
            {

                if (comboBox2.SelectedIndex != -1)
                {
                    listBox1.Items.Add($"업체명:, {selectedIndex}  ,주문상품 : ,{selectedIndex2},  무게:  ,{textBox1.Text}");


                }
            }






        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);

            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                if (listBox1.SelectedIndex != -1)
                {
                    foreach (var input_items in listBox1.Items)
                    {
                        result += string.Format("{0}\r\n", input_items);
                    }
                    if (MessageBox.Show($"선택하신 품목이\r\n{result}\r\n맞으십니까?", "주문 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(result);

                        MessageBox.Show($"{result}\r\n주문 완료되었습니다.", "주문 완료");
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("물건이 추가되지 않았거나 물건이 없습니다.", "주문 실패");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("서버 상태가 불안정합니다.", "주문 실패");
            }
            OrderOracle(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }
    }

}



