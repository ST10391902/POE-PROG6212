using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourNamespace
{
    public partial class HRUsers : Page
    {
        private static DataTable usersTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeDataTable();
                BindGrid();
            }
        }

        private void InitializeDataTable()
        {
            if (usersTable == null)
            {
                usersTable = new DataTable();
                usersTable.Columns.Add("UserId", typeof(int));
                usersTable.Columns.Add("UserName", typeof(string));
                usersTable.Columns.Add("UserEmail", typeof(string));
                usersTable.Columns.Add("UserRole", typeof(string));
            }
        }

        private void BindGrid()
        {
            UsersGridView.DataSource = usersTable;
            UsersGridView.DataBind();
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            DataRow newRow = usersTable.NewRow();
            newRow["UserId"] = usersTable.Rows.Count + 1;
            newRow["UserName"] = UserName.Text;
            newRow["UserEmail"] = UserEmail.Text;
            newRow["UserRole"] = UserRole.SelectedValue;
            usersTable.Rows.Add(newRow);

            BindGrid();
            ClearFields();
        }

        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (int.TryParse(UserId.Text, out int userId))
            {
                DataRow row = usersTable.Select($"UserId = {userId}").FirstOrDefault();
                if (row != null)
                {
                    row["UserName"] = UserName.Text;
                    row["UserEmail"] = UserEmail.Text;
                    row["UserRole"] = UserRole.SelectedValue;
                    BindGrid();
                    ClearFields();
                }
            }
        }

        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (int.TryParse(UserId.Text, out int userId))
            {
                DataRow row = usersTable.Select($"UserId = {userId}").FirstOrDefault();
                if (row != null)
                {
                    usersTable.Rows.Remove(row);
                    BindGrid();
                    ClearFields();
                }
            }
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Data Submitted Successfully');</script>");
            BindGrid();
            ClearFields();
        }

        protected void UsersGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = UsersGridView.SelectedRow;
            UserId.Text = row.Cells[0].Text;
            UserName.Text = row.Cells[1].Text;
            UserEmail.Text = row.Cells[2].Text;
            UserRole.SelectedValue = row.Cells[3].Text;
        }

        private void ClearFields()
        {
            UserId.Text = "";
            UserName.Text = "";
            UserEmail.Text = "";
            UserRole.SelectedIndex = 0;
        }
    }
}
