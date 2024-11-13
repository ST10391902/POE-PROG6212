<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClaimSubmission.aspx.cs" Inherits="POE_PROG6212.AddClaims" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Claim</title>
    <style>
        body {
            background-color: #c0b7d5;
            font-family: Arial, sans-serif;
        }

        .form-container {
            background-color: #e6e1f0;
            padding: 20px;
            border-radius: 8px;
            width: 80%;
            margin: auto;
        }

        label {
            display: inline-block;
            width: 150px;
            font-weight: bold;
        }

        select, input[type="text"], input[type="number"] {
            width: 200px;
        }

        .button-container {
            margin-top: 20px;
        }

        .button-container input {
            margin-right: 10px;
        }

        .success-message {
            color: green;
            margin-top: 20px;
            font-weight: bold;
        }

        .error-message {
            color: red;
            margin-top: 20px;
            font-weight: bold;
        }

        table {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }

        table, th, td {
            border: 1px solid black;
        }

        th, td {
            padding: 8px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Add Current Claim</h2>

            <label>Lecturer Name:</label>
            <asp:TextBox ID="LecturerName" runat="server"></asp:TextBox><br /><br />

            <label>Employee No:</label>
            <asp:TextBox ID="EmployeeNo" runat="server"></asp:TextBox><br /><br />

            <label>Lecturer No:</label>
            <asp:TextBox ID="LecturerNo" runat="server"></asp:TextBox><br /><br />

            <label>Month:</label>
            <asp:DropDownList ID="Month" runat="server">
                <asp:ListItem Text="January" Value="January"></asp:ListItem>
                <asp:ListItem Text="February" Value="February"></asp:ListItem>
                <asp:ListItem Text="March" Value="March"></asp:ListItem>
                <asp:ListItem Text="April" Value="April"></asp:ListItem>
                <asp:ListItem Text="May" Value="May"></asp:ListItem>
                <asp:ListItem Text="June" Value="June"></asp:ListItem>
                <asp:ListItem Text="July" Value="July"></asp:ListItem>
                <asp:ListItem Text="August" Value="August"></asp:ListItem>
                <asp:ListItem Text="September" Value="September"></asp:ListItem>
                <asp:ListItem Text="October" Value="October"></asp:ListItem>
                <asp:ListItem Text="November" Value="November"></asp:ListItem>
                <asp:ListItem Text="December" Value="December"></asp:ListItem>
            </asp:DropDownList><br /><br />

            <label>Year:</label>
            <asp:DropDownList ID="Year" runat="server"></asp:DropDownList><br /><br />

            <label>Role/Hourly Rate:</label>
            <asp:DropDownList ID="HourlyRate" runat="server">
                <asp:ListItem Text="R100" Value="100"></asp:ListItem>
                <asp:ListItem Text="R200" Value="200"></asp:ListItem>
                <asp:ListItem Text="R300" Value="300"></asp:ListItem>
            </asp:DropDownList><br /><br />

            <label>Hours Worked:</label>
            <asp:DropDownList ID="HoursWorked" runat="server">
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                <asp:ListItem Text="4" Value="4"></asp:ListItem>
            </asp:DropDownList><br /><br />

            <label>Program Code:</label>
            <asp:TextBox ID="ProgramCode" runat="server"></asp:TextBox><br /><br />

            <label>Module:</label>
            <asp:TextBox ID="Module" runat="server"></asp:TextBox><br /><br />

            <label>Support Document:</label>
            <asp:FileUpload ID="SupportDocument" runat="server" /><br /><br />

            <div class="button-container">
                <asp:Button ID="btnSubmitAllClaims" runat="server" Text="Submit Current Claim" OnClick="btnSubmitAllClaims_Click" />
            </div>

            <asp:Label ID="lblMessage" runat="server" CssClass="success-message" Visible="false"></asp:Label>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="false"></asp:Label>

            <hr />

            <h2>Current Claims (Program Coordinator/Manager View)</h2>

            <asp:GridView ID="gvClaims" runat="server" AutoGenerateColumns="true" Visible="false" CssClass="table">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
