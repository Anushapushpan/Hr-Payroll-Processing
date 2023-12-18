<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Hr_Payroll_Processing.Transaction.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="/Stylesheets/Employee.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainBox" style="margin-left:50px; margin-right:50px;">
     <div class="btnBack"><button id="btnBack" runat="server" class="btn btn-dark" onserverclick="btnBack_ServerClick"><i class="fa fa-chevron-circle-left">&nbsp</i>Back</button></div>
     <%--<div class="report">
        <button id="btnExcel" runat="server"  class="btn btn-dark" style="margin-right:50px; width:100px;" title="Overall Report"><i class="fa fa-download" aria-hidden="true"></i>&nbsp;&nbsp;Excel</button>
    </div>--%>
        <center><h2>Report</h2><hr /></center>
   <center>
        <div class="reportdropdown">
         
    <asp:Label ID="lblMonth" Text="Month: " runat="server"></asp:Label>
    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnTextChanged="ddlMonth_TextChanged">
        <asp:ListItem Text="January" Value="01"></asp:ListItem>
        <asp:ListItem Text="February" Value="02"></asp:ListItem>
        <asp:ListItem Text="March" Value="03"></asp:ListItem>
        <asp:ListItem Text="April" Value="04"></asp:ListItem>
        <asp:ListItem Text="May" Value="05"></asp:ListItem>
        <asp:ListItem Text="June" Value="06"></asp:ListItem>
        <asp:ListItem Text="July" Value="07"></asp:ListItem>
        <asp:ListItem Text="August" Value="08"></asp:ListItem>
        <asp:ListItem Text="September" Value="09"></asp:ListItem>
        <asp:ListItem Text="October" Value="10"></asp:ListItem>
        <asp:ListItem Text="November" Value="11"></asp:ListItem>
        <asp:ListItem Text="December" Value="12"></asp:ListItem>
    </asp:DropDownList>
      &nbsp; &nbsp; &nbsp;
    <asp:Label ID="lblYear" Text="Year: " runat="server"></asp:Label>
    <asp:DropDownList ID="ddlyear" runat="server" CssClass="form-control form-select" AutoPostBack="true"  OnTextChanged="ddlMonth_TextChanged">
        <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
        <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
        <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
        <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
    </asp:DropDownList>
             &nbsp; &nbsp; &nbsp;
            <asp:Label ID="lblEmp" Text="Employee No: " runat="server"></asp:Label>
    <asp:DropDownList ID="ddlEmpNo" runat="server" CssClass="form-control form-select">

    </asp:DropDownList>
            
       </div>
       
       </center>
       <center>
    <div class="btnProceed">
       <button id="btnReport" runat="server" class="btn btn-dark" onserverclick="btnReport_ServerClick" ><i class="fa fa-download" aria-hidden="true">&nbsp&nbsp&nbsp</i>Payroll</button>
    </div>
           </center>
        <center>
        <div class="sort">          
           <asp:Label ID="lblSort" runat="server" Text="Sort By: "></asp:Label>&nbsp; &nbsp;
           <asp:DropDownList ID="ddlSort" runat="server" CssClass="form-control form-select" OnTextChanged="ddlSort_TextChanged" AutoPostBack="true">
            <asp:ListItem Text="All" Value="All"></asp:ListItem>
            <asp:ListItem Text="Month" Value="Month"></asp:ListItem>
            <asp:ListItem Text="Year" Value="Year"></asp:ListItem>
           </asp:DropDownList> &nbsp; &nbsp; &nbsp;
           <asp:Label ID="lblMonthSort" Text="Month: " runat="server" Visible="false"></asp:Label>&nbsp; &nbsp;
        <asp:DropDownList ID="ddlMonthSort" runat="server" Visible="false" CssClass="form-control form-select" AutoPostBack="true" OnTextChanged="ddlMonth_TextChanged">
        <asp:ListItem Text="January" Value="01"></asp:ListItem>
        <asp:ListItem Text="February" Value="02"></asp:ListItem>
        <asp:ListItem Text="March" Value="03"></asp:ListItem>
        <asp:ListItem Text="April" Value="04"></asp:ListItem>
        <asp:ListItem Text="May" Value="05"></asp:ListItem>
        <asp:ListItem Text="June" Value="06"></asp:ListItem>
        <asp:ListItem Text="July" Value="07"></asp:ListItem>
        <asp:ListItem Text="August" Value="08"></asp:ListItem>
        <asp:ListItem Text="September" Value="09"></asp:ListItem>
        <asp:ListItem Text="October" Value="10"></asp:ListItem>
        <asp:ListItem Text="November" Value="11"></asp:ListItem>
        <asp:ListItem Text="December" Value="12"></asp:ListItem>
    </asp:DropDownList> &nbsp; &nbsp; &nbsp;
    <asp:Label ID="lblsortYear" Text="Year: " runat="server" Visible="false"></asp:Label>&nbsp; &nbsp;
    <asp:DropDownList ID="ddlSortYear" runat="server" Visible="false" CssClass="form-control form-select" AutoPostBack="true"  OnTextChanged="ddlMonth_TextChanged">
        
    </asp:DropDownList>
                
       </div>
            </center>
        <center>
    <div class="btnProceed">
       <button id="btnExcelAll" title="Sort by all" runat="server" onserverclick="btnExcel_ServerClick" class="btn btn-dark" style="width:100px;"><i class="fa fa-download" aria-hidden="true">&nbsp&nbsp&nbsp</i>Excel</button>
    </div>
            <div class="btnProceed">
       <button id="btnExcelMonth" title="Sort by month" runat="server" onserverclick="btnExcelMonth_ServerClick" Visible="false" class="btn btn-dark" style="width:100px;"><i class="fa fa-download" aria-hidden="true">&nbsp&nbsp&nbsp</i>Excel</button>
    </div>
            <div class="btnProceed">
       <button id="btnExcelYear" title="Sort by year" runat="server" Visible="false" onserverclick="btnExcelYear_ServerClick" class="btn btn-dark" style="width:100px;"><i class="fa fa-download" aria-hidden="true">&nbsp&nbsp&nbsp</i>Excel</button>
    </div>
           </center>
        </div>
</asp:Content>
