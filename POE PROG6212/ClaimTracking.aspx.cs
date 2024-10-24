using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contract_Monthly_Claim_System_2
{
    public partial class ClaimTracking : Page
    {
        // List to store claims
        private static List<Claim> claims; // Changed to static to maintain state across postbacks

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialize claims (sample data for demonstration purposes)
                claims = new List<Claim>
                {
                    new Claim { ClaimId = 1, LecturerName = "John Doe", DateOfWork = "01/09/2024", HoursWorked = 5, HourlyRate = 50, TotalAmount = 250, Status = "Pending" },
                    new Claim { ClaimId = 2, LecturerName = "Jane Smith", DateOfWork = "02/09/2024", HoursWorked = 8, HourlyRate = 60, TotalAmount = 480, Status = "Pending" }
                };

                ClaimsGridView.DataSource = claims; // Bind claims to the grid
                ClaimsGridView.DataBind();
            }
        }

        // Approve claim button click event
        protected void ApproveClaim_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int claimId = Convert.ToInt32(btn.CommandArgument);
            Claim claim = claims.Find(c => c.ClaimId == claimId);

            if (claim != null)
            {
                claim.Status = "Approved";
                ClaimsGridView.DataSource = claims; // Re-bind the grid after approval
                ClaimsGridView.DataBind(); // Refresh the grid
            }
        }

        // Reject claim button click event
        protected void RejectClaim_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int claimId = Convert.ToInt32(btn.CommandArgument);
            Claim claim = claims.Find(c => c.ClaimId == claimId);

            if (claim != null)
            {
                claim.Status = "Rejected";
                ClaimsGridView.DataSource = claims; // Re-bind the grid after rejection
                ClaimsGridView.DataBind(); // Refresh the grid
            }
        }
    }

    // Class to represent a claim
    public class Claim
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
