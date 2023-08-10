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
    public partial class Form3 : Form
    {

        
        string strConnectionString = @"Data Source=LAPTOP-4L6TNGKF\HUYNHTRONGSON;Initial Catalog=DATM;Integrated Security=True";
        SqlConnection conn = null;
        // chuỗi kết nối 

        // đối tượng đưa dữ liệu vào dataTable, dtTableName
        SqlDataAdapter daTableName = null;

        // Đối tượng hiển thị dữ liệu lên form
        DataTable dtTableName = null;

        public Form3()
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
            dtgv.DataSource = dtTableName;
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            conn.Open(); // mở kết nối

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO DangKy([hovaten],[tendangnhap],[matkhau],[xnmatkhau],[gmail])" +
                    "VALUES(@hovaten,@tendangnhap,@matkhau,@xnmatkhau,@gmail)");

                cmd.Parameters.AddWithValue("@hovaten", tb_hovaten.Text);
                cmd.Parameters.AddWithValue("@tendangnhap", tb_tendangnhap.Text);
                cmd.Parameters.AddWithValue("@matkhau", tb_matkhau.Text);
                cmd.Parameters.AddWithValue("@xnmatkhau", tb_xnmatkhau.Text);
                cmd.Parameters.AddWithValue("@gmail", tb_gmail.Text);
              
            

                cmd.Connection = conn;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
              
                loaddata();
                clearData();
            }
            
            catch (SqlException)
            {

                MessageBox.Show("Không lưu được, Lỗi rồi !");
            }

            conn.Close();
           
        }
        private void clearData()
        {
            tb_hovaten.Text = "";
            tb_tendangnhap.Text = "";
            tb_matkhau.Text = "";
            tb_xnmatkhau.Text = "";
            tb_gmail.Text = "";
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
