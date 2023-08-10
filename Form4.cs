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
    public partial class quản_lý_trọ_sinh_viên : Form
    {
        string strConnectionString = @"Data Source=LAPTOP-4L6TNGKF\HUYNHTRONGSON;Initial Catalog=DATM;Integrated Security=True";
        SqlConnection conn = null;
       

        // đối tượng đưa dữ liệu vào dataTable, dtTableName
        SqlDataAdapter daTableName = null;

        // Đối tượng hiển thị dữ liệu lên form
        DataTable dtTableName = null;

        public quản_lý_trọ_sinh_viên()
        {
            InitializeComponent();
            loaddata();
        }
        private void loaddata()
        {
            conn = new SqlConnection(strConnectionString);
            daTableName = new SqlDataAdapter("select *from QLSV", conn);
            dtTableName = new DataTable();
            daTableName.Fill(dtTableName);
            dtgv.DataSource = dtTableName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open(); // mở kết nối
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO QLSV([Tensv],[Lop],[Nganh],[Quequan],[MSSV],[Tenct],[Sdtct],[Diachitro],[Tientro])" +
                    "VALUES(@tensv,@lop,@nganh,@qq,@mssv,@tenct,@sdtct,@diachitro,@tientro)");
                cmd.Parameters.AddWithValue("@tensv", tensv.Text);
                cmd.Parameters.AddWithValue("@lop", lop.Text);
                cmd.Parameters.AddWithValue("@nganh", nganh.Text);
                cmd.Parameters.AddWithValue("@qq", qq.Text);
                cmd.Parameters.AddWithValue("@mssv", mssv.Text);
                cmd.Parameters.AddWithValue("@tenct", tenct.Text);
                cmd.Parameters.AddWithValue("@sdtct", sdtct.Text);
                cmd.Parameters.AddWithValue("@diachitro", diachitro.Text);
                cmd.Parameters.AddWithValue("@tientro", tientro.Text);
                cmd.Connection = conn;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();

                loaddata();
                clearData();
            }
            catch (Exception)
            {

                MessageBox.Show("Không lưu được, Lỗi rồi !");
            }
            conn.Close();
         }
        private void clearData()
        {
            tensv.Text = "";
            nganh.Text = "";
            qq.Text = "";
            mssv.Text = "";
            lop.Text = "";
            tenct.Text = "";
            diachitro.Text = "";
            sdtct.Text = "";
            tientro.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");
            int r = dtgv.CurrentCell.RowIndex;
            tensv.Text = dtgv.Rows[r].Cells[1].Value.ToString();
            lop.Text = dtgv.Rows[r].Cells[2].Value.ToString();
            nganh.Text = dtgv.Rows[r].Cells[3].Value.ToString();
            qq.Text = dtgv.Rows[r].Cells[4].Value.ToString();
            mssv.Text = dtgv.Rows[r].Cells[0].Value.ToString();
            tenct.Text = dtgv.Rows[r].Cells[5].Value.ToString();
            sdtct.Text = dtgv.Rows[r].Cells[6].Value.ToString();
            diachitro.Text = dtgv.Rows[r].Cells[7].Value.ToString();
            tientro.Text = dtgv.Rows[r].Cells[8].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            conn.Open(); // mở kết nối
            try
            {
                SqlCommand cmd = new SqlCommand("update QLSV set [Tensv] = @tensv,[Lop] = @lop,[Nganh] = @nganh,[Quequan] = @qq,[Tenct]= @tenct,[Sdtct]= @sdtct,[Diachitro]= @diachitro,[Tientro]= @tientro where [MSSV] = @mssv");
                cmd.Parameters.AddWithValue("@tensv", tensv.Text);
                cmd.Parameters.AddWithValue("@lop", lop.Text);
                cmd.Parameters.AddWithValue("@nganh", nganh.Text);
                cmd.Parameters.AddWithValue("@qq", qq.Text);
                cmd.Parameters.AddWithValue("@mssv", mssv.Text);
                cmd.Parameters.AddWithValue("@tenct", tenct.Text);
                cmd.Parameters.AddWithValue("@sdtct", sdtct.Text);
                cmd.Parameters.AddWithValue("@diachitro", diachitro.Text);
                cmd.Parameters.AddWithValue("@tientro", tientro.Text);
                cmd.Connection = conn;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();

                loaddata();
                clearData();
            }
            catch (Exception)
            {

                MessageBox.Show("Không lưu được, Lỗi rồi !");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open(); // mở kết nối

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;


                int row = dtgv.CurrentCell.RowIndex;
               

                string strmssv = dtgv.Rows[row].Cells[0].Value.ToString();
               
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("delete from QLSV where mssv ='" + strmssv + "'");
               
               

                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();

                loaddata();
                clearData();
            }
            catch (SqlException)
            {

                MessageBox.Show("Không xóa được, Lỗi rồi !");
            }
           
            
              
               
           
            conn.Close(); // đóng kết nối
        }

        private void quản_lý_trọ_sinh_viên_Load(object sender, EventArgs e)
        {

        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            string search = tb_timkiem.Text;
            // Khởi động kết nối
            conn = new SqlConnection(strConnectionString);

            // Vận chuyển dữ liệu lên DataTable dtTableName
            daTableName = new SqlDataAdapter("select * from QLSV where MSSV =N'" + search + "'", conn);

            dtTableName = new DataTable();

            daTableName.Fill(dtTableName);

            dtgv1.DataSource = dtTableName;
            System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");
            int r = dtgv1.CurrentCell.RowIndex;
            tensv.Text = dtgv1.Rows[r].Cells[1].Value.ToString();
            lop.Text = dtgv1.Rows[r].Cells[2].Value.ToString();
            nganh.Text = dtgv1.Rows[r].Cells[3].Value.ToString();
            qq.Text = dtgv1.Rows[r].Cells[4].Value.ToString();
            mssv.Text = dtgv1.Rows[r].Cells[0].Value.ToString();
            tenct.Text = dtgv1.Rows[r].Cells[5].Value.ToString();
            sdtct.Text = dtgv1.Rows[r].Cells[6].Value.ToString();
            diachitro.Text = dtgv1.Rows[r].Cells[7].Value.ToString();
            tientro.Text = dtgv1.Rows[r].Cells[8].Value.ToString();
        }

        private void dtgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
