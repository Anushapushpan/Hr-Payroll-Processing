<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="UserMaster.aspx.cs" Inherits="Hr_Payroll_Processing.Master.UserMaster1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="/Stylesheets/CodeMaster.css">
     <link rel="stylesheet" type="text/css" href="/Stylesheets/Employee.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainBox">
    <div class="main">
        <div class="btnreverse"><button id="btnBack" runat="server" class="btn btn-dark" onserverclick="btnBack_ServerClick"><i class="fa fa-chevron-circle-left">&nbsp</i>Back</button></div>
        <center><h3>USER MASTER</h3></center><hr />
     <center><asp:Label ID="lblAlert" runat="server" style="color:red;"></asp:Label></center>
     <div class="row g-3">
        <div class="col-md-4">
            <asp:Label ID="lblUserId" runat="server" Text="USER ID: "></asp:Label><font color="red">*</font>
            <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control"  MaxLength="12" OnTextChanged="txtUserId_TextChanged" AutoPostBack="true"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4"
                    ErrorMessage="Required" ControlToValidate="txtUserId" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
            <asp:Label runat="server" ID="lblUniqueConstraintAlert" ForeColor="Red"></asp:Label>
        </div>
         <div class="col-md-4">
            <asp:Label ID="lblUserName" runat="server" Text="USERNAME: "></asp:Label><font color="red">*</font>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"  MaxLength="12"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5"
                    ErrorMessage="Required" ControlToValidate="txtUserName" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblUserPwd" runat="server" Text="PASSWORD: "></asp:Label><font color="red">*</font>
            <asp:TextBox ID="txtUserPwd" runat="server" CssClass="form-control" MaxLength="12" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6"
                    ErrorMessage="Required" ControlToValidate="txtUserPwd" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
        </div>
       </div>
    <div class="row g-3">       
        <div class="col-md-4">
            <asp:Label ID="lblUserActive" runat="server" Text="ACTIVE Y/N: "></asp:Label><font color="red">*</font><br>
            <asp:CheckBox ID="chkUserActive" Checked="true" runat="server" />           
        </div>
        </div>
        <center>
        <asp:Button ID="btnSaveUser" runat="server" CssClass="btn btn-dark" Text="Save" ValidationGroup="save" OnClick="btnSaveUser_Click" />
            <asp:Button ID="btnUpdateUser" runat="server" CssClass="btn btn-warning" Text="Update" ValidationGroup="save" Visible="false" OnClick="btnUpdateUser_Click" />
            <asp:Button ID="btnCancelDept" runat="server" CssClass="btn btn-secondary" Text="Cancel" OnClick="btnCancelDept_Click"/>
        </div>
    </center>

    <div class="CheckAttendence">
    <asp:GridView ID="gvUserMaster" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvUserMaster_PageIndexChanging" PageSize="10" AllowSorting="true" style="width:100%" CssClass="table table-striped table-bordered table-condensed table-hover" HeaderStyle-BackColor="#99ccff">
                <Columns>
                    <asp:TemplateField HeaderText="USER ID" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblDeptNo" runat="server"  Text='<%# Eval("USER_ID") %>' style="text-transform: uppercase;"></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="USERNAME" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblCmType" runat="server"  Text='<%# Eval("USER_NAME") %>' style="text-transform: uppercase;"></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="USER PASSWORD" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblCmDesc" runat="server" Text='<%# HidePassword(Eval("USER_PASSWORD").ToString()) %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="USER ACTIVE Y/N" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblCmValue" runat="server"  Text='<%# Eval("USER_ACTIVE_YN") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="table-primary" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                           <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("USER_ID") %>' OnClick="lnkEdit_Click">
                              <i class="fa fa-edit" style="color:green;" title="Edit"></i>
                           </asp:LinkButton>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="table-primary" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                           <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("USER_ID") %>' OnClientClick="return confirm('Do you want to delete?')" OnClick="lnkDelete_Click">
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
