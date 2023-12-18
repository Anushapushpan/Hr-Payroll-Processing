<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="EmployeeHrHistory.aspx.cs" Inherits="Hr_Payroll_Processing.Transaction.EmployeeHrHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="/Stylesheets/Employee.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainBox">
    <div class="btnreverse"><button id="btnBack" runat="server" class="btn btn-dark" onserverclick="btnBack_ServerClick" style="margin-left:50px;"><i class="fa fa-chevron-circle-left">&nbsp</i>Back</button></div>
    <div class="CheckAttendence">
        <center><h2>Allowance History</h2></center>
        <hr />
         <div class="searchArea">
        <asp:TextBox ID="txtSearchEmp" runat="server" TextMode="Search" placeholder="Search Emp No" CssClass="form-control" MaxLength="12" style="border-radius:3px; width:250px;" ValidationGroup="search"></asp:TextBox>            
        <button id="btnSearch" runat="server" class="btn btn-warning" ValidationGroup="search" style="margin-left:10px;" onserverclick="btnSearch_ServerClick"><i class="fa fa-search" aria-hidden="true"></i>&nbsp;Search</button> 
             <asp:Button runat="server" ID="btnClear" CssClass="btn btn-secondary" Text="Clear" style="margin-left:10px;" OnClick="btnClear_Click" />
        </div><br />
        <asp:Image ID="imgNotFound" runat="server" ImageUrl="~/Images/Animation - 1699525804667.gif" style="width:200px;height:200px; margin-left:550px; margin-top:0px;" Visible="false" />
    <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10"  OnPageIndexChanging="gvHistory_PageIndexChanging" AllowSorting="true" style="width:100%" CssClass="table table-striped table-bordered table-condensed table-hover" HeaderStyle-BackColor="#99ccff">
                <Columns>
                    <asp:TemplateField HeaderText="Employee No" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblYrMonth" runat="server"  Text='<%# Eval("EH_EMP_NO") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DESIGNATION" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrEmpNo" runat="server"  Text='<%# Eval("EH_DESIGNATION") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GRADE" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrDesignation" runat="server" Text='<%# Eval("EH_GRADE") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BASIC" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrDaysPresent" runat="server" Text='<%# Eval("EH_BASIC","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="HRA" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrDaysAbsent" runat="server" Text='<%# Eval("EH_HRA","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="CONV" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblBasic" runat="server" Text='<%# Eval("EH_CONV","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="DA" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrHra" runat="server" Text='<%# Eval("EH_DA","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="TDS" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrConv" runat="server" Text='<%# Eval("EH_TDS","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="ESI" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrDa" runat="server" Text='<%# Eval("EH_ESI","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="ACTION TYPE" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrTds" runat="server" Text='<%# Eval("EH_ACTION_TYPES") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="ACTION SRL" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblPrEsi" runat="server" Text='<%# Eval("EH_ACTION_SRL") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                              
                </Columns>
        <PagerStyle HorizontalAlign = "Right" CssClass = "GridPager"/>
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4"  FirstPageText="<<" LastPageText=">>"/>
            </asp:GridView>
         </div>
        </div>
</asp:Content>
