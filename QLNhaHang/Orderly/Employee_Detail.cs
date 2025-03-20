using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orderly
{
    public partial class Employee_Detail : Form
    {
        private string username;
        public Employee_Detail(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        public Employee_Detail()
        {
            InitializeComponent();
        }

        private void LoadEmployeeDetails()
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = "SELECT e.Username, e.FullName, e.PhoneNumber, e.Address, e.DateOfBirth, e.BaseSalary, e.TotalWorkHours, e.ProfilePicture, l.Password " +
                               "FROM Employees e " +
                               "JOIN Login l ON e.Username = l.Username " +
                               "WHERE e.Username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", this.username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtUsername.Text = reader["Username"].ToString();
                            txtFullName.Text = reader["FullName"].ToString();
                            txtPhone.Text = reader["PhoneNumber"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                            dtpkDateOfBirth.Value = Convert.ToDateTime(reader["DateOfBirth"]);
                            txtBaseSalary.Text = reader["BaseSalary"].ToString() + " VND";
                            txtTotalWorkHours.Text = reader["TotalWorkHours"].ToString() + " Hours";
                            txtPassword.Text = reader["Password"].ToString();

                            // Load ảnh từ đường dẫn
                            string imagePath = reader["ProfilePicture"].ToString();
                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                pbProfilePicture.Image = LoadImage(imagePath);
                            }
                            else
                            {
                                pbProfilePicture.Image = LoadImage("Employee_Images/default.jpg");
                            }
                        }
                    }
                }
            }
        }
        private Image LoadImage(string imagePath)
        {
            try
            {
                if (!File.Exists(imagePath))
                {
                    return Image.FromFile("Employee_Images/default.jpg"); // Trả về ảnh mặc định nếu không có ảnh
                }

                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    return Image.FromStream(fs);
                }
            }
            catch (Exception ex)    
            {
                MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
                return null;
            }
        }



        private void Employee_Detail_Load(object sender, EventArgs e)
        {
            LoadEmployeeDetails();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = "UPDATE Employees SET FullName=@FullName, PhoneNumber=@PhoneNumber, Address=@Address, DateOfBirth=@DateOfBirth WHERE Username=@Username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dtpkDateOfBirth.Value);
                    cmd.Parameters.AddWithValue("@Username", this.username);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Thông tin nhân viên đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Chọn ảnh nhân viên",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                string imageFolder = Path.Combine(Application.StartupPath, "Employee_Images");

                if (!Directory.Exists(imageFolder))
                {
                    Directory.CreateDirectory(imageFolder);
                }

                string newFileName = $"employee_{this.username}{Path.GetExtension(selectedFilePath)}";
                string destinationPath = Path.Combine(imageFolder, newFileName);

                File.Copy(selectedFilePath, destinationPath, true);

                pbProfilePicture.Image = Image.FromFile(destinationPath);

                SaveImagePathToDatabase(destinationPath);
            }
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveImagePathToDatabase(string imagePath)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = "UPDATE Employees SET ProfilePicture = @ProfilePicture WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProfilePicture", imagePath);
                    cmd.Parameters.AddWithValue("@Username", this.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
