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


namespace Orderly
{
    public partial class frmProFile : Form
    {
        private string username;
        public frmProFile(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void frmProFile_Load(object sender, EventArgs e)
        {
            LoadProfileData();
        }
        private void LoadProfileData()
        {
            string connectionString = "Data Source=DESKTOP-ETDHM2T\\SQLSEVER;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT TOP 1 ID, Username, SessionTime FROM UserSession WHERE Username = @username ORDER BY SessionTime DESC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtID.Text = reader["ID"].ToString();
                            txtUser.Text = reader["Username"].ToString();
                            txtTime.Text = Convert.ToDateTime(reader["SessionTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu cho người dùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void lblThoat_Click(object sender, EventArgs e)
        {
            // Đóng form Profile hoàn toàn
            this.Close();
        }
    }
}
