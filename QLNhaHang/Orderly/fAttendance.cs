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

namespace Orderly
{
    public partial class fAttendance : Form
    {
        private int employeeID; 
        public fAttendance(int empID)
        {
            InitializeComponent();
            this.employeeID = empID; // Lưu EmployeeID vào biến instance
        }   

        

        private void fAttendance_Load(object sender, EventArgs e)
        {
            LoadEmployeeInfo();  // Hiển thị thông tin nhân viên
            LoadAttendanceHistory(); // Hiển thị lịch sử check-in/out
            CalculateTotalSalary(); // Gọi phương thức để cập nhật tổng lương
        }
        private void LoadEmployeeInfo()
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = "SELECT FullName, PhoneNumber, Address, BaseSalary FROM Employees WHERE EmployeeID = @EmployeeID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFullName.Text = reader["FullName"].ToString();
                            txtPhone.Text = reader["PhoneNumber"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                            txtBaseSalary.Text = reader["BaseSalary"].ToString() + " VND";
                        }
                    }
                }
            }
        }
        private void CalculateTotalSalary()
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = "SELECT SUM(SalaryEarned) FROM Attendance WHERE EmployeeID = @EmployeeID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        decimal totalSalary = Convert.ToDecimal(result);
                        txtTotalSalary.Text = totalSalary.ToString("N0") + " VND"; // Hiển thị với định dạng tiền tệ
                    }
                    else
                    {
                        txtTotalSalary.Text = "0 VND";
                    }
                }
            }
        }

        private void LoadAttendanceHistory()
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = "SELECT TimeCheckIn AS 'Check-in Time', TimeCheckOut AS 'Check-out Time', HoursWorked AS 'Hours Worked', SalaryEarned AS 'Salary Earned' FROM Attendance WHERE EmployeeID = @EmployeeID ORDER BY TimeCheckIn DESC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvAttendance.DataSource = dt;
                    }
                }
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();

                string getCheckInQuery = "SELECT TimeCheckIn FROM Attendance WHERE EmployeeID = @EmployeeID AND TimeCheckOut IS NULL";
                DateTime checkInTime;

                using (SqlCommand cmd = new SqlCommand(getCheckInQuery, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("You have not checked in or have already checked out!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    checkInTime = Convert.ToDateTime(result);
                }

                DateTime checkOutTime = DateTime.Now;
                TimeSpan duration = checkOutTime - checkInTime;
                double hoursWorked = duration.TotalHours; // Chuyển khoảng thời gian thành số giờ bao gồm phần thập phân
                decimal hourlyRate = GetHourlyRate(employeeID); // Lấy mức lương cơ bản của nhân viên theo giờ trong bảng Employees
                decimal salaryEarned = (decimal)hoursWorked * hourlyRate; // Lấy lương theo số giờ làm việc * số giờ làm việc => Lương kiếm được trong ngày hôm đó

                string updateQuery = "UPDATE Attendance SET TimeCheckOut = @TimeCheckOut, HoursWorked = @HoursWorked, SalaryEarned = @SalaryEarned WHERE EmployeeID = @EmployeeID AND TimeCheckOut IS NULL";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmd.Parameters.AddWithValue("@TimeCheckOut", checkOutTime);
                    cmd.Parameters.AddWithValue("@HoursWorked", hoursWorked);
                    cmd.Parameters.AddWithValue("@SalaryEarned", salaryEarned);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Check-out successful! You worked {hoursWorked:F2} hours. Salary Earned: {salaryEarned} VND", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CalculateTotalSalary(); // Cập nhật lại tổng lương sau khi check-out
            LoadAttendanceHistory();
        }
        private decimal GetHourlyRate(int employeeID)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = "SELECT BaseSalary FROM Employees WHERE EmployeeID = @EmployeeID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        decimal baseSalary = Convert.ToDecimal(result);
                        return baseSalary / 160; // Giả sử nhân viên làm việc 160 giờ/tháng
                    }
                }
            }
            return 0;
        }
        private void btnViewInfo_Click(object sender, EventArgs e)
        {
            LoadEmployeeInfo();    //Hiển thị lại thông tin nhân viên
            LoadAttendanceHistory(); //Hiển thị lịch sử check-in/out
            MessageBox.Show("Thông tin nhân viên và lịch sử chấm công đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCheckIn_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra EmployeeID hợp lệ trước khi check-in
            if (employeeID <= 0)
            {
                MessageBox.Show("Invalid EmployeeID. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();

                // Kiểm tra xem nhân viên đã check-in hôm nay chưa
                string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE EmployeeID = @empID AND CAST(TimeCheckIn AS DATE) = CAST(GETDATE() AS DATE)";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@empID", employeeID);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("You have already checked in today!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Thực hiện Check-in
                string insertQuery = "INSERT INTO Attendance (EmployeeID, TimeCheckIn) VALUES (@empID, GETDATE())";
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@empID", employeeID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Check-in successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadAttendanceHistory();
        }
    }
}
