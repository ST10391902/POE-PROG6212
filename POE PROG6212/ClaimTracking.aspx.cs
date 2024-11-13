using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contract_Monthly_Claim_System_2
{
    public partial class ClaimTracking : Page
    {
        private static List<Claim> claims;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSampleClaims();
                BindClaimsGrid();
            }
        }

        private void LoadSampleClaims()
        {
            claims = new List<Claim>
            {
                new Claim { ClaimId = 1, LecturerName = "John Doe", DateOfWork = "01/09/2024", HoursWorked = 5, HourlyRate = 50, TotalAmount = 250, Status = "Pending" },
                new Claim { ClaimId = 2, LecturerName = "Jane Smith", DateOfWork = "02/09/2024", HoursWorked = 8, HourlyRate = 60, TotalAmount = 480, Status = "Pending" }
            };
        }

        private void BindClaimsGrid()
        {
            ClaimsGridView.DataSource = claims;
            ClaimsGridView.DataBind();
        }

        protected void ClaimsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Customize row appearance or behavior as needed.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Example: Change the background color based on the claim status
                var status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                if (status == "Pending")
                {
                    e.Row.BackColor = System.Drawing.Color.LightYellow;
                }
                else if (status == "Approved")
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                }
                else if (status == "Rejected")
                {
                    e.Row.BackColor = System.Drawing.Color.LightCoral;
                }
            }
        }

        protected void ApproveClaim_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int claimId = Convert.ToInt32(btn.CommandArgument);
            Claim claim = claims.Find(c => c.ClaimId == claimId);

            if (claim != null)
            {
                claim.Status = "Approved";
                BindClaimsGrid();
            }
        }

        protected void RejectClaim_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int claimId = Convert.ToInt32(btn.CommandArgument);
            Claim claim = claims.Find(c => c.ClaimId == claimId);

            if (claim != null)
            {
                claim.Status = "Rejected";
                BindClaimsGrid();
            }
        }
    }

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
