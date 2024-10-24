using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POE_PROG6212
{
    public partial class AddClaims : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Populate the year dropdown list on first page load
            if (!IsPostBack)
            {
                for (int year = DateTime.Now.Year; year >= DateTime.Now.Year - 5; year--)
                {
                    Year.Items.Add(new ListItem(year.ToString(), year.ToString()));
                }
            }
        }

        protected void btnSubmitAllClaims_Click(object sender, EventArgs e)
        {
            // Validate inputs (add your validation logic here)
            if (string.IsNullOrWhiteSpace(LecturerName.Text) || string.IsNullOrWhiteSpace(EmployeeNo.Text) ||
                string.IsNullOrWhiteSpace(LecturerNo.Text) || string.IsNullOrWhiteSpace(ProgramCode.Text) ||
                string.IsNullOrWhiteSpace(Module.Text) || HoursWorked.SelectedValue == "0")
            {
                lblErrorMessage.Text = "Please fill in all required fields.";
                lblErrorMessage.Visible = true;
                return;
            }

            // Save current claim logic (add your data storage logic here)
            // Example: SaveClaim(LecturerName.Text, EmployeeNo.Text, LecturerNo.Text, Month.SelectedValue, Year.SelectedValue, HourlyRate.SelectedValue, HoursWorked.SelectedValue, ProgramCode.Text, Module.Text, SupportDocument);

            lblMessage.Text = "Current claim submitted successfully!";
            lblMessage.Visible = true;
            lblErrorMessage.Visible = false;

            // Clear fields after submission (if needed)
            ClearCurrentClaimFields();
        }

        protected void btnRemoveClaim_Click(object sender, EventArgs e)
        {
            // Remove current claim logic (add your claim removal logic here)
            // Example: RemoveClaim(LecturerNo.Text);

            lblMessage.Text = "Current claim removed successfully!";
            lblMessage.Visible = true;
            lblErrorMessage.Visible = false;

            // Optionally, clear fields
            ClearCurrentClaimFields();
        }

        protected void btnAddHistoricalClaim_Click(object sender, EventArgs e)
        {
            // Validate historical claim inputs
            if (string.IsNullOrWhiteSpace(ClaimNo.Text) || string.IsNullOrWhiteSpace(ProgramCode2.Text) ||
                string.IsNullOrWhiteSpace(ModuleCode.Text) || string.IsNullOrWhiteSpace(RatePerHour.Text) ||
                string.IsNullOrWhiteSpace(ClaimAmount.Text) || string.IsNullOrWhiteSpace(Status.Text) ||
                string.IsNullOrWhiteSpace(TotalClaimAmount.Text))
            {
                lblErrorMessage.Text = "Please fill in all required fields.";
                lblErrorMessage.Visible = true;
                return;
            }

            // Add historical claim logic (add your data storage logic here)
            // Example: AddHistoricalClaim(ClaimNo.Text, ProgramCode2.Text, ModuleCode.Text, RatePerHour.Text, Hours.SelectedValue, ClaimAmount.Text, Status.Text, TotalClaimAmount.Text, AttachedDocument);

            lblMessage.Text = "Historical claim added successfully!";
            lblMessage.Visible = true;
            lblErrorMessage.Visible = false;

            // Optionally, clear fields
            ClearHistoricalClaimFields();
        }

        private void ClearCurrentClaimFields()
        {
            LecturerName.Text = string.Empty;
            EmployeeNo.Text = string.Empty;
            LecturerNo.Text = string.Empty;
            Month.SelectedIndex = -1;
            Year.SelectedIndex = -1;
            HourlyRate.SelectedIndex = -1;
            HoursWorked.SelectedIndex = -1;
            ProgramCode.Text = string.Empty;
            Module.Text = string.Empty;
            SupportDocument.Attributes.Clear(); // Clear uploaded file
        }

        private void ClearHistoricalClaimFields()
        {
            ClaimNo.Text = string.Empty;
            ProgramCode2.Text = string.Empty;
            ModuleCode.Text = string.Empty;
            RatePerHour.Text = string.Empty;
            ClaimAmount.Text = string.Empty;
            Status.Text = string.Empty;
            TotalClaimAmount.Text = string.Empty;
            AttachedDocument.Attributes.Clear(); // Clear uploaded file
        }
    }
}
