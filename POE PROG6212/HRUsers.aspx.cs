using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROGPOE
{
    public partial class HR : Page
    {
        private DataTable claimsTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialize claims data
                claimsTable = new DataTable();
                claimsTable.Columns.Add("ClaimNo");
                claimsTable.Columns.Add("LecturerName");
                claimsTable.Columns.Add("ProgramCode");
                claimsTable.Columns.Add("ModuleCode");
                claimsTable.Columns.Add("Rate", typeof(decimal));
                claimsTable.Columns.Add("Hours", typeof(int));
                claimsTable.Columns.Add("ClaimAmount", typeof(decimal));
                claimsTable.Columns.Add("Document");
                claimsTable.Columns.Add("Status");

                // Sample data
                claimsTable.Rows.Add("C001", "Siyanqoba", "PROG6212", "Programming 2A", 110, 10, 1000, "doc1.pdf", "APPROVED");
                claimsTable.Rows.Add("C002", "Asanda", "HCIN6212", "Human Computer Interaction", 150, 5, 750, "doc2.pdf", "REJECT");
                claimsTable.Rows.Add("C003", "Landile", "DATA622", "Database (Intermediate)", 120, 8, 960, "doc3.pdf", "APPROVED");
                claimsTable.Rows.Add("C004", "Wandile", "IPMA6212", "IT Project Management", 150, 12, 1320, "doc4.pdf", "REJECT");

                ViewState["Claims"] = claimsTable;
                BindGrid();
            }
            else
            {
                claimsTable = (DataTable)ViewState["Claims"];
            }
        }
        
        private void BindGrid()
        {
            gvClaims.DataSource = claimsTable;
            gvClaims.DataBind();
        }

        protected void gvClaims_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvClaims.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvClaims_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Retrieve updated values
            GridViewRow row = gvClaims.Rows[e.RowIndex];
            string claimNo = gvClaims.DataKeys[e.RowIndex].Value.ToString();  // Now it should work

            // Find the corresponding row in the DataTable
            DataRow[] rows = claimsTable.Select($"ClaimNo = '{claimNo}'");

            if (rows.Length > 0)
            {
                // Update the fields
                rows[0]["ProgramCode"] = ((TextBox)row.Cells[2].Controls[0]).Text;
                rows[0]["ModuleCode"] = ((TextBox)row.Cells[3].Controls[0]).Text;
                rows[0]["Rate"] = Convert.ToDecimal(((TextBox)row.Cells[4].Controls[0]).Text);
                rows[0]["Hours"] = Convert.ToInt32(((TextBox)row.Cells[5].Controls[0]).Text);
                rows[0]["ClaimAmount"] = Convert.ToDecimal(rows[0]["Rate"]) * Convert.ToInt32(rows[0]["Hours"]);
                rows[0]["Status"] = ((TextBox)row.Cells[7].Controls[0]).Text;

                // Rebind the data
                ViewState["Claims"] = claimsTable;
                gvClaims.EditIndex = -1;
                BindGrid();
            }
        }


        protected void gvClaims_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvClaims.EditIndex = -1;
            BindGrid();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            // Generate an invoice as HTML
            StringWriter sw = new StringWriter();
            sw.WriteLine("<html><body>");
            sw.WriteLine("<h2>Lecturer Claims Invoice</h2>");
            sw.WriteLine("<table border='1'><tr><th>Claim No</th><th>Lecturer Name</th><th>Program Code</th><th>Module Code</th><th>Rate/hr</th><th>Hours</th><th>Claim Amount</th><th>Status</th></tr>");

            foreach (DataRow row in claimsTable.Rows)
            {
                sw.WriteLine("<tr>");
                foreach (var item in row.ItemArray)
                {
                    sw.WriteLine($"<td>{item}</td>");
                }
                sw.WriteLine("</tr>");
            }

            sw.WriteLine("</table></body></html>");

            // Export as a file
            string fileName = "LecturerClaimsInvoice.html";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", $"attachment;filename={fileName}");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Required for export to work
        }
    }
}
