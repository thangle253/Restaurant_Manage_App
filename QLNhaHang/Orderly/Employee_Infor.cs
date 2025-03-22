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
    public partial class Employee_Infor : Form
    {
        private int employeeID;
        public Employee_Infor(int empID)
        {
            InitializeComponent();
            this.employeeID = empID;
        }

        private void Employee_Infor_Load(object sender, EventArgs e)
        {
            // Tạo thư mục Employee_Images nếu chưa tồn tại
            string imageFolder = Path.Combine(Application.StartupPath, "Employee_Images");
            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }
            LoadEmployeeInfo();

        }
        private void LoadEmployeeInfo()
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = "SELECT Username, FullName, PhoneNumber, Address, DateOfBirth, BaseSalary, TotalWorkHours, ProfilePicture FROM Employees WHERE EmployeeID = @EmployeeID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", Session.EmployeeID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtUserName.Text = reader["Username"].ToString();
                            txtFullName.Text = reader["FullName"].ToString();
                            txtPhone.Text = reader["PhoneNumber"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                            dtpDateOfBirth.Value = Convert.ToDateTime(reader["DateOfBirth"]);
                            txtBaseSalary.Text = reader["BaseSalary"].ToString() + " VND";
                            txtTotalWorkHours.Text = reader["TotalWorkHours"].ToString() + " Hours";

                            // Load ảnh từ đường dẫn
                            string imagePath = reader["ProfilePicture"].ToString();
                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                pbProfilePicture.Image = Image.FromFile(imagePath);
                            }
                            else
                            {
                                pbProfilePicture.Image = Image.FromFile("Emloyee_Images/default.jpg"); // Ảnh mặc định nếu không có ảnh
                            }
                        }
                    }
                }
            }
        }

        private void SaveImagePathToDatabase(string imagePath)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = "UPDATE Employees SET ProfilePicture = @ProfilePicture WHERE EmployeeID = @EmployeeID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProfilePicture", imagePath);
                    cmd.Parameters.AddWithValue("@EmployeeID", this.employeeID); // Make sure 'this.employeeID' is set properly
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = "UPDATE Employees SET FullName=@FullName, PhoneNumber=@PhoneNumber, Address=@Address, DateOfBirth=@DateOfBirth WHERE EmployeeID=@EmployeeID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dtpDateOfBirth.Value);
                    cmd.Parameters.AddWithValue("@EmployeeID", Session.EmployeeID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Thông tin nhân viên đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUploadImage_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Chọn ảnh nhân viên",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName; // Đường dẫn gốc của ảnh
                string imageFolder = Path.Combine(Application.StartupPath, "Employee_Images");

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(imageFolder))
                {
                    Directory.CreateDirectory(imageFolder);
                }

                // Đặt tên file mới theo EmployeeID để tránh trùng lặp
                string newFileName = $"employee_{Session.EmployeeID}{Path.GetExtension(selectedFilePath)}";
                string destinationPath = Path.Combine(imageFolder, newFileName);

                // Copy ảnh vào thư mục chung
                File.Copy(selectedFilePath, destinationPath, true);

                // Hiển thị ảnh trên PictureBox
                pbProfilePicture.Image = Image.FromFile(destinationPath);

                // Lưu đường dẫn ảnh vào database
                SaveImagePathToDatabase(destinationPath);
            }
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
