﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClaimTracking.aspx.cs" Inherits="Contract_Monthly_Claim_System_2.ClaimTracking" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Track Claims</title>
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
        <ul>
    <li><a href="ClaimSubmission.aspx">Lecture</a></li>
    <li><a href="ViewClaims.aspx">ProgrammeCoordinator.</a></li>
    <li><a href="ClaimTracking.aspx"> Manager</a></li>
    <li><a href="HRUsers.aspx">HR</a></li>
</ul>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Track Claims</h2>
            <asp:GridView ID="ClaimsGridView" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="ClaimsGridView_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="Claim ID" DataField="ClaimId" SortExpression="ClaimId" />
                    <asp:BoundField HeaderText="Lecturer Name" DataField="LecturerName" SortExpression="LecturerName" />
                    <asp:BoundField HeaderText="Date of Work" DataField="DateOfWork" SortExpression="DateOfWork" />
                    <asp:BoundField HeaderText="Hours Worked" DataField="HoursWorked" SortExpression="HoursWorked" />
                    <asp:BoundField HeaderText="Hourly Rate" DataField="HourlyRate" SortExpression="HourlyRate" />
                    <asp:BoundField HeaderText="Total Amount" DataField="TotalAmount" SortExpression="TotalAmount" />
                    <asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnApprove" runat="server" Text="Approve" CommandName="Approve" CommandArgument='<%# Eval("ClaimId") %>' OnClick="ApproveClaim_Click" />
                            <asp:Button ID="btnReject" runat="server" Text="Reject" CommandName="Reject" CommandArgument='<%# Eval("ClaimId") %>' OnClick="RejectClaim_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
