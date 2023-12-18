<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrystalReport.aspx.cs" Inherits="Hr_Payroll_Processing.Transaction.CrystalReport" %>
<%@ Register Assembly="CrystalDecisions.Web" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divCR" runat="server">
            <CR:CrystalReportViewer ID="crvGIR001" runat="server" Visible="false" />
        </div>
    </form>
</body>
</html>
