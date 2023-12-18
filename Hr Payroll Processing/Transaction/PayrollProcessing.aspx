<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="PayrollProcessing.aspx.cs" Inherits="Hr_Payroll_Processing.Transaction.PayrollProcessing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="/Stylesheets/Employee.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="mainBox" >

                
    <center><h2>Payroll Processing</h2></center>
     <div class="btnreverse"><button id="btnBack" runat="server" class="btn btn-dark" onserverclick="btnBack_ServerClick1" style="margin-left:50px;"><i class="fa fa-chevron-circle-left">&nbsp</i>Back</button></div>
    <div class="report">
        <asp:Button ID="btnReport" runat="server" Text="Report" CssClass="btn btn-dark" OnClick="btnReport_Click" style="margin-right:50px;"/>
    </div>
    <hr style="margin-left:50px; margin-right:50px;" />
    <center>
    <div class="attendence">
    <asp:Label ID="lblMonth" Text="Month: " runat="server"></asp:Label>
    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control form-select" OnTextChanged="ddlMonth_TextChanged" AutoPostBack="true">
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
    <asp:DropDownList ID="ddlyear" runat="server" CssClass="form-control form-select" OnTextChanged="ddlMonth_TextChanged" AutoPostBack="true">
        <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
        <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
        <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
        <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
    </asp:DropDownList>
        </div>
        </center>
    <div class="btnProceed">
        <center><asp:Button ID="btnPayroll" runat="server" CssClass="btn btn-dark" Text="Process Payroll" OnClick="btnPayroll_Click" ValidationGroup="save"/></center>
    </div>
     <div class="CheckAttendence">
    <asp:GridView ID="gvPayroll" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" AllowSorting="true" OnPageIndexChanging="gvPayroll_PageIndexChanging" style="width:100%" CssClass="table table-striped table-bordered table-condensed table-hover" HeaderStyle-BackColor="#99ccff">
                <Columns>
                    <asp:TemplateField HeaderText="YYYYMM" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblYrMonth" runat="server"  Text='<%# Eval("PR_YYYMM") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Employee No" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrEmpNo" runat="server"  Text='<%# Eval("PR_EMP_NO") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DESIGNATION" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrDesignation" runat="server" Text='<%# Eval("PR_DESIGNATION") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRESENT DAYS" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrDaysPresent" runat="server" Text='<%# Eval("PR_DAYS_PRESENT") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="ABSENT DAYS" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrDaysAbsent" runat="server" Text='<%# Eval("PR_DAYS_ABSENT") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="BASIC" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblBasic" runat="server" Text='<%# Eval("PR_BASIC","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="HRA" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrHra" runat="server" Text='<%# Eval("PR_HRA","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="CONV" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrConv" runat="server" Text='<%# Eval("PR_CONV","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="DA" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrDa" runat="server" Text='<%# Eval("PR_DA","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="TDS" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrTds" runat="server" Text='<%# Eval("PR_TDS","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="ESI" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrEsi" runat="server" Text='<%# Eval("PR_ESI","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TOTAL EARNINGS" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblTotEarnings" runat="server" Text='<%# Eval("PR_TOT_EARNINGS","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TOTAL DEDUCTION" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblTotDeductions" runat="server" Text='<%# Eval("PR_TOT_DEDU","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NET PAYABLE" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrNetPayable" runat="server" Text='<%# Eval("PR_NET_PAYABLE","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>             
                </Columns>
            </asp:GridView>
         </div>
        </div>
</asp:Content>
