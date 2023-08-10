using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Đồ_án_thầy_Mỹ
{
    public partial class Form1 : Form
    {
        string strConnectionString = @"Data Source=LAPTOP-4L6TNGKF\HUYNHTRONGSON;Initial Catalog=DATM;Integrated Security=True";
        SqlConnection conn = null;
        // chuỗi kết nối 

        // đối tượng đưa dữ liệu vào dataTable, dtTableName
        SqlDataAdapter daTableName = null;

        // Đối tượng hiển thị dữ liệu lên form
        DataTable dtTableName = null;

        public Form1()
        {
            InitializeComponent();
            loaddata();
        }
        private void loaddata()
        {
            conn = new SqlConnection(strConnectionString);
            daTableName = new SqlDataAdapter("select *from DangKy", conn);
            dtTableName = new DataTable();
            daTableName.Fill(dtTableName);
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-4L6TNGKF\HUYNHTRONGSON;Initial Catalog=DATM;Integrated Security=True");
            try
            {
                conn.Open();
                String tk = tb_tk.Text;
                String mk = tb_mk.Text;
                
                
                String Sql = "select *from DangKy where tendangnhap = '" + tk + "' and matkhau ='" + mk + "'  ";
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    quản_lý_trọ_sinh_viên f4 = new quản_lý_trọ_sinh_viên();
                    f4.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("tài khoản hay mật khẩu đã sai !", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
               

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Form3 f3 = new Form3();
            f3.ShowDialog();
            this.Show();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("bạn có chắc là muốn đóng hay không ?", "thông báo ", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void tb_mqtc_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_mk_TextChanged(object sender, EventArgs e)
        {
            this.tb_mk.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
