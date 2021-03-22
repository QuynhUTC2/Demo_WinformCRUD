using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_WinformCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-KGK9Q2TK\SQLEXPRESS;Initial Catalog=DemoCRUDwinform;Integrated Security=True");
        public int StudentID;
        private void GetStudentsRecord()
        {

            SqlCommand cmd = new SqlCommand("Select * from StudentsTB", conn);
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private bool IsValidData()
        {
            if (txtTen.Text == string.Empty
                || txtHo.Text == string.Empty
                || txtDiaChi.Text == string.Empty
                || string.IsNullOrEmpty(txtSDT.Text)
                || string.IsNullOrEmpty(txtSobd.Text))
            {
                MessageBox.Show("Có chỗ chưa nhập dữ liệu!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentsTB values " + "(@Name, @Fathername, @RollNumber, @Address, @Number)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtHo.Text);
                cmd.Parameters.AddWithValue("@Fathername", txtTen.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtSobd.Text);
                cmd.Parameters.AddWithValue("@Address", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Number", txtSDT.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                GetStudentsRecord();
            }
        }

       
        private void btnCnhat_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                SqlCommand cmd = new SqlCommand("update StudentsTB set" + 
                    " Name = @Name,Fathername = @Fathername,"+
                    " RollNumber = @RollNumber, Address = @Address, " +
                    " Number = @Number where StudentID = @id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtTen.Text);
                cmd.Parameters.AddWithValue("@Fathername", txtHo.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtSobd.Text);
                cmd.Parameters.AddWithValue("@Address", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Number", txtSDT.Text);
                cmd.Parameters.AddWithValue("@id", this.StudentID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                GetStudentsRecord();
                ResetData();
            }
            else
            {
                MessageBox.Show("Cập nhật bị lỗi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ResetData()
        {
            txtDiaChi.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtHo.Text = string.Empty;
            txtSobd.Text = string.Empty;
            txtTen.Text = string.Empty;
        }
        private void btnsua_Click(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                SqlCommand cmd = new SqlCommand("delete from StudentsTB where StudentID = @id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", this.StudentID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                GetStudentsRecord();
                ResetData();
            }
            else
            {
                MessageBox.Show("Xóa bị lỗi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentID = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
            txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtHo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSobd.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
