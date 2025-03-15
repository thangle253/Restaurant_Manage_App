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
            this.employeeID = empID;
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (Session.EmployeeID <= 0) // 🛑 Kiểm tra EmployeeID trước khi check-in
            {
                MessageBox.Show("Invalid EmployeeID. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();

                // 🔍 **Kiểm tra xem nhân viên đã check-in hôm nay chưa**
                string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE EmployeeID = @empID AND CAST(TimeCheckIn AS DATE) = CAST(GETDATE() AS DATE)";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@empID", Session.EmployeeID);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("You have already checked in today!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // ✅ **Thực hiện Check-in**
                string insertQuery = "INSERT INTO Attendance (EmployeeID, TimeCheckIn) VALUES (@empID, GETDATE())";
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@empID", Session.EmployeeID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Check-in successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadAttendanceHistory();
        }

        private void fAttendance_Load(object sender, EventArgs e)
        {
            LoadEmployeeInfo();  // Hiển thị thông tin nhân viên
            LoadAttendanceHistory(); // Hiển thị lịch sử check-in/out
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
                            lblFullName.Text = reader["FullName"].ToString();
                            lblPhone.Text = reader["PhoneNumber"].ToString();
                            lblAddress.Text = reader["Address"].ToString();
                            lblBaseSalary.Text = $"Base Salary: {reader["BaseSalary"]} VND";
                        }
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
                double hoursWorked = duration.TotalHours;
                decimal hourlyRate = GetHourlyRate(employeeID);
                decimal salaryEarned = (decimal)hoursWorked * hourlyRate;

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
           
        }


    }
}
