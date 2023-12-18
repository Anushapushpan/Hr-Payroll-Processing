<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="DepartmentMaster.aspx.cs" Inherits="Hr_Payroll_Processing.Master.DepartmentMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link rel="stylesheet" type="text/css" href="/Stylesheets/CodeMaster.css">
     <link rel="stylesheet" type="text/css" href="/Stylesheets/Employee.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainBox">
   <div class="main">
       <div class="btnreverse"><button id="btnBack" runat="server" class="btn btn-dark" onserverclick="btnBack_ServerClick"><i class="fa fa-chevron-circle-left">&nbsp</i>Back</button></div>
        <center><h3>DEPARTMENT MASTER</h3></center><hr />
    <div class="row g-3">
        <div class="col-md-4">
            <asp:Label ID="lblDeptNo" runat="server" Text="Dept No: "></asp:Label><font color="red">*</font>
            <asp:TextBox ID="txtDeptNo" runat="server" CssClass="form-control"  MaxLength="12" OnTextChanged="txtDeptNo_TextChanged" AutoPostBack="true"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                    ErrorMessage="Dept No is required" ControlToValidate="txtDeptNo" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
            <asp:Label runat="server" ID="lblAlert" ForeColor="Red"></asp:Label>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblDeptName" runat="server" Text="Dept Name: "></asp:Label><font color="red">*</font>
            <asp:TextBox ID="txtDeptName" runat="server" CssClass="form-control" MaxLength="12"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2"
                    ErrorMessage="Dept Name is required" ControlToValidate="txtDeptName" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
        </div>       
            <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-warning" runat="server" ValidationGroup="save" Visible="false" OnClick="btnUpdate_Click"/>
            <asp:Button ID="btnSaveDept" runat="server" CssClass="btn btn-dark" Text="Save" ValidationGroup="save" OnClick="btnSaveDept_Click" />
            <asp:Button ID="btnCancelDept" runat="server" CssClass="btn btn-secondary" Text="Cancel" OnClick="btnCancelDept_Click"/>
    </div>
       </div>
    <div class="CheckAttendence">
    <asp:GridView ID="gvDepartment" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true" style="width:100%" CssClass="table table-striped table-bordered table-condensed table-hover" HeaderStyle-BackColor="#99ccff">
                <Columns>
                    <asp:TemplateField HeaderText="Department No" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblDeptNo" runat="server"  Text='<%# Eval("DEPT_NO") %>' style="text-transform: uppercase;"></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="DESIGNATION" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblDesignation" runat="server"  Text='<%# Eval("DEPT_NAME") %>' style="text-transform: uppercase;"></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>     
                    
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="table-primary" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                           <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("DEPT_NO") %>' OnClick="lnkEdit_Click">
                              <i class="fa fa-edit" style="color:green;" title="Edit"></i>
                           </asp:LinkButton>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="table-primary" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                           <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("DEPT_NO") %>' OnClientClick="return confirm('Do you want to delete?')" OnClick="lnkDelete_Click" >
                               <i class="material-icons" style="color: red;" data-toggle="tooltip" title="Delete">&#xE872;</i>
                           </asp:LinkButton>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                </Columns>
         <PagerStyle HorizontalAlign = "Right" CssClass = "GridPager"/>
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4"  FirstPageText="First" LastPageText="Last"/>
            </asp:GridView>
        </div>
        </div>
</asp:Content>
