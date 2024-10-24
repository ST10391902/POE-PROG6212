<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewClaims.aspx.cs" Inherits="POE_PROG6212.ViewClaims" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Claims</title>
    <style>
        body {
            background-color: #c0b7d5;
            font-family: Arial, sans-serif;
        }

        .container {
            width: 80%;
            margin: 50px auto;
            background-color: #E6E6FA;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        th, td {
            padding: 10px;
            border: 1px solid #ccc;
        }

        th {
            background-color: #D3D3D3;
        }

        .buttons {
            margin-top: 20px;
        }

        input[type="button"] {
            padding: 10px;
            background-color: #D3D3D3;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
            margin-right: 10px;
        }

        input[type="button"]:hover {
            background-color: #FF877C94;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>View Claims</h2>
            <asp:GridView ID="ClaimsGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ClaimId" OnSelectedIndexChanged="ClaimsGridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ClaimId" HeaderText="Claim ID" />
                    <asp:BoundField DataField="LecturerName" HeaderText="Lecturer" />
                    <asp:BoundField DataField="DateOfWork" HeaderText="Date of Work" />
                    <asp:BoundField DataField="HoursWorked" HeaderText="Hours Worked" />
                    <asp:BoundField DataField="HourlyRate" HeaderText="Hourly Rate" />
                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:CommandField ShowSelectButton="True" SelectText="Select" />
                </Columns>
            </asp:GridView>

            <div class="buttons">
                <asp:Button ID="ApproveButton" runat="server" Text="Approve" OnClick="ApproveButton_Click" />
                <asp:Button ID="RejectButton" runat="server" Text="Reject" OnClick="RejectButton_Click" />
                <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitClaims_Click" />
            </div>
        </div>
    </form>
</body>
</html>
