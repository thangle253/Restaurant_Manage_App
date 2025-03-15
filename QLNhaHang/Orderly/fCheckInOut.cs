using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Orderly
{
    public partial class fCheckInOut : Form
    {
        public fCheckInOut()
        {
            InitializeComponent();
        }

        private string GetSelectedShift()
        {
            if (rdoMorningShift.Checked) return "Morning Shift";
            if (rdoAfternoonShift.Checked) return "Afternoon Shift";
            if (rdoEveningShift.Checked) return "Evening Shift";
            return null;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string username = Session.CurrentUsername;
            string shift = GetSelectedShift();

            if (shift == null)
            {
                MessageBox.Show("Please select a work shift before checking in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Do you want to check in?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM EmployeeAttendance WHERE Username = @username AND CAST(CheckInTime AS DATE) = CAST(GETDATE() AS DATE)";
                using (SqlCommand cmd = new SqlCommand(checkQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("You have already checked in today!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string insertQuery = "INSERT INTO EmployeeAttendance (Username, Shift, CheckInTime) VALUES (@username, @shift, GETDATE())";
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@shift", shift);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Check-in successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Lưu trạng thái Check-in vào Session
            Session.CheckInTime = DateTime.Now;
            StartWorkTimer();
            UpdateWorkingTime(); // Hiển thị ngay thời gian làm việc
            LoadAttendanceHistory();
        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (Session.CheckInTime == DateTime.MinValue)
            {
                MessageBox.Show("You have not checked in yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to check out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.No) return;

            string username = Session.CurrentUsername;

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();

                string getCheckInQuery = "SELECT CheckInTime FROM EmployeeAttendance WHERE Username = @username AND CheckOutTime IS NULL";
                using (SqlCommand cmd = new SqlCommand(getCheckInQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("You have not checked in or have already checked out!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Session.CheckInTime = Convert.ToDateTime(result);
                }

                DateTime checkOutTime = DateTime.Now;
                TimeSpan duration = checkOutTime - Session.CheckInTime;
                hoursWorked = duration.TotalHours;  // Gán giá trị vào biến toàn cục

                string workStatus = hoursWorked >= 4 ? "Met" : "Not Met";

                string updateQuery = "UPDATE EmployeeAttendance SET CheckOutTime = @checkout, WorkStatus = @status WHERE Username = @username AND CheckOutTime IS NULL";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@checkout", checkOutTime);
                    cmd.Parameters.AddWithValue("@status", workStatus);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Check-out successful! You worked {hoursWorked:F2} hours. Status: {workStatus}.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Session.WorkTimer?.Stop();
            lblWorkingTime.Text = "Shift Ended";

            // Tính toán lương dựa trên số giờ làm
            double hourlyRate = 5.0;
            double totalSalary = hoursWorked * hourlyRate;
            lblSalary.Text = $"Today's Salary: ${totalSalary:F2}";

            LoadAttendanceHistory();
        }


        private void LoadAttendanceHistory()
        {
            string username = Session.CurrentUsername;

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = @"
                SELECT Shift AS 'Work Shift',
                       CheckInTime AS 'Check-in Time',
                       CheckOutTime AS 'Check-out Time',
                       WorkStatus AS 'Work Status'
                FROM EmployeeAttendance
                WHERE Username = @username
                ORDER BY CheckInTime DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvAttendanceHistory.DataSource = dt;
                    }
                }
            }
        }

        private double hoursWorked = 0;
        private void fCheckInOut_Load(object sender, EventArgs e)
        {
            LoadAttendanceHistory();

            if (Session.CheckInTime != DateTime.MinValue)
            {
                StartWorkTimer();
                UpdateWorkingTime(); // ✅ Hiển thị ngay số giờ làm khi mở lại Form
            }
        }
        private void StartWorkTimer()
        {
            if (Session.WorkTimer == null)
            {
                Session.WorkTimer = new System.Windows.Forms.Timer();
                Session.WorkTimer.Interval = 1000;
                Session.WorkTimer.Tick += WorkTimer_Tick;
            }

            if (!Session.WorkTimer.Enabled)
            {
                Session.WorkTimer.Start(); // Đảm bảo Timer luôn chạy
            }
        }
        private void WorkTimer_Tick(object sender, EventArgs e)
        {
            UpdateWorkingTime();
        }
        private void UpdateWorkingTime()
        {
            if (Session.CheckInTime != DateTime.MinValue)
            {
                TimeSpan elapsed = DateTime.Now - Session.CheckInTime;
                lblWorkingTime.Text = $"Working Time: {elapsed.Hours}h {elapsed.Minutes}m {elapsed.Seconds}s";
            }
        }
    }
}
