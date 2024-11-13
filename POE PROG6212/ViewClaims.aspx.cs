using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Web.UI;

namespace POE_PROG6212
{
    public partial class ViewClaims : Page
    {
        // List to hold the claims
        private static List<ClaimRecord> claims;
        private static int SelectedClaimId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadClaims();
            }
        }

        private void LoadClaims()
        {
            // Sample data for the claims
            claims = new List<ClaimRecord>
            {
                new ClaimRecord { ClaimId = 1, LecturerName = "Olwethu Cwele", DateOfWork = "01/09/2024", HoursWorked = 5, HourlyRate = 50, TotalAmount = 250, Status = "Pending" },
                new ClaimRecord { ClaimId = 2, LecturerName = "Libongwe Cwele", DateOfWork = "02/09/2024", HoursWorked = 8, HourlyRate = 60, TotalAmount = 480, Status = "Pending" },
                new ClaimRecord { ClaimId = 3, LecturerName = "Siyanqoba Zuma", DateOfWork = "03/09/2024", HoursWorked = 7, HourlyRate = 55, TotalAmount = 385, Status = "Pending" },
                new ClaimRecord { ClaimId = 4, LecturerName = "Luyanda Zuma", DateOfWork = "04/09/2024", HoursWorked = 6, HourlyRate = 52, TotalAmount = 312, Status = "Pending" }
            };

            // Bind the claims data to the GridView
            ClaimsGridView.DataSource = claims;
            ClaimsGridView.DataBind();
        }

        protected void ClaimsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected claim's ID
            SelectedClaimId = Convert.ToInt32(ClaimsGridView.SelectedDataKey.Value);
        }

        protected void ApproveButton_Click(object sender, EventArgs e)
        {
            if (SelectedClaimId != 0)
            {
                // Update the selected claim's status to "Approved"
                var claim = claims.Find(c => c.ClaimId == SelectedClaimId);
                if (claim != null)
                {
                    claim.Status = "Approved";
                }

                // Rebind the GridView to refresh the data
                ClaimsGridView.DataSource = claims;
                ClaimsGridView.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SelectMessage", "alert('Please select a claim to approve.');", true);
            }
        }

        protected void RejectButton_Click(object sender, EventArgs e)
        {
            if (SelectedClaimId != 0)
            {
                // Update the selected claim's status to "Rejected"
                var claim = claims.Find(c => c.ClaimId == SelectedClaimId);
                if (claim != null)
                {
                    claim.Status = "Rejected";
                }

                // Rebind the GridView to refresh the data
                ClaimsGridView.DataSource = claims;
                ClaimsGridView.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SelectMessage", "alert('Please select a claim to reject.');", true);
            }
        }

        protected void SubmitClaims_Click(object sender, EventArgs e)
        {
            // Logic to submit the claims (e.g., save to database)
            ScriptManager.RegisterStartupScript(this, GetType(), "SubmitMessage", "alert('Claims submitted successfully.');", true);
        }
    }

    // ClaimRecord class representing the claim structure
    public class ClaimRecord
    {
        public int ClaimId { get; set; }
        public string LecturerName { get; set; }
        public string DateOfWork { get; set; }
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
    }
}



    // Unified Claim class to store claim data
    public class Claim
{
    public string LecturerName { get; set; }
    public string EmployeeNo { get; set; }
    public string LecturerNo { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }
    public string HourlyRate { get; set; }
    public string HoursWorked { get; set; }
    public string ProgramCode { get; set; }
    public string Module { get; set; }
    public string SupportDocument { get; set; }
}
