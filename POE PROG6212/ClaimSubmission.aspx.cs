using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POE_PROG6212
{
    public partial class AddClaims : Page
    {
        // Static list to hold the claims (shared with the ViewClaims page)
        public static List<Claim> CurrentClaims = new List<Claim>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the year dropdown list
                for (int year = DateTime.Now.Year; year >= DateTime.Now.Year - 5; year--)
                {
                    Year.Items.Add(new ListItem(year.ToString(), year.ToString()));
                }
                BindClaimsGrid();
            }
        }

        protected void btnSubmitAllClaims_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(LecturerName.Text) || string.IsNullOrWhiteSpace(EmployeeNo.Text) ||
                string.IsNullOrWhiteSpace(LecturerNo.Text) || string.IsNullOrWhiteSpace(ProgramCode.Text) ||
                string.IsNullOrWhiteSpace(Module.Text) || HoursWorked.SelectedValue == "0")
            {
                lblErrorMessage.Text = "Please fill in all required fields.";
                lblErrorMessage.Visible = true;
                return;
            }

            // Create a new claim object
            var newClaim = new Claim
            {
                LecturerName = LecturerName.Text,
                EmployeeNo = EmployeeNo.Text,
                LecturerNo = LecturerNo.Text,
                Month = Month.SelectedValue,
                Year = Year.SelectedValue,
                HourlyRate = HourlyRate.SelectedValue,
                HoursWorked = HoursWorked.SelectedValue,
                ProgramCode = ProgramCode.Text,
                Module = Module.Text,
                SupportDocument = SupportDocument.FileName
            };

            // Save the claim to the static list
            CurrentClaims.Add(newClaim);

            lblMessage.Text = "Current claim submitted successfully!";
            lblMessage.Visible = true;
            lblErrorMessage.Visible = false;

            // Clear the input fields
            ClearCurrentClaimFields();

            // Bind the updated list to the grid
            BindClaimsGrid();
        }

        private void BindClaimsGrid()
        {
            if (CurrentClaims.Count > 0)
            {
                gvClaims.Visible = true;
                gvClaims.DataSource = CurrentClaims;
                gvClaims.DataBind();
            }
            else
            {
                gvClaims.Visible = false;
            }
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
}
