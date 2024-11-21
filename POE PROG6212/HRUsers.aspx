<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HR.aspx.cs" Inherits="PROGPOE.HR" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HR Users</title>
    <style>
        body {
            background-color: #ffb6c1; /* Updated background color */
            font-family: Arial, sans-serif;
        }
        .form-container {
            margin: 50px auto;
            width: 80%;
            background-color: #E6E6FA;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        table {
            width: 100%;
            border-collapse: collapse;
        }
        td {
            padding: 10px;
            vertical-align: top;
        }
        label {
            display: block;
            margin-bottom: 5px;
        }
        input[type="text"], input[type="file"], select {
            width: 90%;
            padding: 5px;
            margin-top: 5px;
        }
        .button-container {
            text-align: center;
            margin-top: 20px;
        }
        .button-container button {
            margin-right: 10px;
            padding: 10px 20px;
            background-color: #D3D3D3;
            border: none;
            font-size: 16px;
            cursor: pointer;
        }
        .button-container button:hover {
            background-color: #FF877C94;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="ClaimSubmission.aspx">Lecture</a></li>
                <li><a href="ViewClaims.aspx">ProgrammeCoordinator.</a></li>
                <li><a href="ClaimTracking.aspx"> Manager</a></li>
                <li><a href="HRUsers.aspx">HR</a></li>
            </ul>
            <h2>HR Users</h2>
            <asp:GridView ID="gvClaims" runat="server" AutoGenerateColumns="False" 
    OnRowEditing="gvClaims_RowEditing" OnRowUpdating="gvClaims_RowUpdating" 
    OnRowCancelingEdit="gvClaims_RowCancelingEdit" DataKeyNames="ClaimNo">
    <Columns>
        <asp:BoundField DataField="ClaimNo" HeaderText="Claim No" ReadOnly="true" SortExpression="ClaimNo" />
        <asp:BoundField DataField="LecturerName" HeaderText="Lecturer Name" SortExpression="LecturerName" />
        <asp:BoundField DataField="ProgramCode" HeaderText="Program Code" SortExpression="ProgramCode" />
        <asp:BoundField DataField="ModuleCode" HeaderText="Module Code" SortExpression="ModuleCode" />
        <asp:BoundField DataField="Rate" HeaderText="Rate/hr" SortExpression="Rate" />
        <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" />
        <asp:BoundField DataField="ClaimAmount" HeaderText="Claim Amount" SortExpression="ClaimAmount" />
        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
        <asp:CommandField ShowEditButton="True" ShowCancelButton="True" />
    </Columns>
</asp:GridView>

            <asp:Button ID="btnExport" runat="server" Text="Export as Invoice" CssClass="button" OnClick="btnExport_Click" />
        </div>
    </form>
</body>
</html>
