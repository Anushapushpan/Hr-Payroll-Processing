<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="CodesMaster.aspx.cs" Inherits="Hr_Payroll_Processing.Master.CodesMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="/Stylesheets/CodeMaster.css">
     <link rel="stylesheet" type="text/css" href="/Stylesheets/Employee.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainBox">
    <div class="main">
        <div class="btnreverse"><button id="btnBack" runat="server" class="btn btn-dark" onserverclick="btnBack_ServerClick"><i class="fa fa-chevron-circle-left">&nbsp</i>Back</button></div>
        <center><h3>CODES MASTER</h3></center><hr />
     <center><asp:Label ID="lblAlert" runat="server" style="color:red;"></asp:Label></center>
     <div class="row g-3">
        <div class="col-md-4">
            <asp:Label ID="lnlCmCode" runat="server" Text="CM CODE: "></asp:Label><font color="red">*</font>
            <asp:TextBox ID="txtxCmCode" runat="server" CssClass="form-control"  MaxLength="12" OnTextChanged="txtcmType_TextChanged" AutoPostBack="true"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4"
                    ErrorMessage="Required" ControlToValidate="txtxCmCode" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
        </div>
         <div class="col-md-4">
            <asp:Label ID="lblCmType" runat="server" Text="CM TYPE: "></asp:Label><font color="red">*</font>
            <asp:TextBox ID="txtcmType" runat="server" CssClass="form-control"  MaxLength="12" OnTextChanged="txtcmType_TextChanged" AutoPostBack="true"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5"
                    ErrorMessage="Required" ControlToValidate="txtcmType" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblCmDesc" runat="server" Text="CM DESC: "></asp:Label><font color="red">*</font>
            <asp:TextBox ID="txtCmDesc" runat="server" CssClass="form-control"  MaxLength="12"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6"
                    ErrorMessage="Required" ControlToValidate="txtCmDesc" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
        </div>
       </div>
    <div class="row g-3">
         <div class="col-md-4">
            <asp:Label ID="lblCmValue" runat="server" Text="CM VALUE: "></asp:Label><font color="red">*</font>
            <asp:TextBox ID="txtCmValue" runat="server" CssClass="form-control" TextMode="Number"  onKeyDown="if(this.value.length==12 && event.keyCode!=8) return false;" MaxLength="12" style="text-align:right;"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7"
                    ErrorMessage="Required" ControlToValidate="txtCmValue" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
             <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
                ControlToValidate="txtCmValue" ErrorMessage="Value must be a Number" ForeColor="Red" Font-Size="Small" ValidationGroup="save" />
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblCmActive" runat="server" Text="CM ACTIVE Y/N: "></asp:Label><font color="red">*</font><br>
            <asp:CheckBox ID="chkCmActive" Checked="true" runat="server" />           
        </div>
        </div>
        </div>
  
    <div class="button-container">
    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-dark" runat="server" ValidationGroup="save" OnClick="btnSave_Click"/>
        <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-warning" runat="server" ValidationGroup="save" Visible="false" OnClick="btnUpdate_Click"/>
    <asp:Button ID="btnCancel" Text="Cancel" CssClass="btn btn-secondary" runat="server" OnClick="btnCancel_Click"/>
        </div>

    <div class="CheckAttendence">
    <asp:GridView ID="gvCodesmaster" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvCodesmaster_PageIndexChanging" PageSize="10" AllowSorting="true" style="width:100%" CssClass="table table-striped table-bordered table-condensed table-hover" HeaderStyle-BackColor="#99ccff">
                <Columns>
                    <asp:TemplateField HeaderText="CM CODE" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblDeptNo" runat="server"  Text='<%# Eval("CM_CODE") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="CM TYPE" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblCmType" runat="server"  Text='<%# Eval("CM_TYPE") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CM DESC" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblCmDesc" runat="server"  Text='<%# Eval("CM_DESC") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CM VALUE" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblCmValue" runat="server"  Text='<%# Eval("CM_VALUE") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="CM ACTIVE Y/N" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblCmActive" runat="server"  Text='<%# Eval("CM_ACTIVE_YN") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="table-primary" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                           <asp:LinkButton ID="lnkEdit" runat="server" CommandName='<%# Eval("CM_TYPE") %>' CommandArgument='<%# Eval("CM_CODE") %>' OnClick="lnkEdit_Click">
                              <i class="fa fa-edit" style="color:green;" title="Edit"></i>
                           </asp:LinkButton>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="table-primary" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                           <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("CM_CODE") %>' OnClientClick="return confirm('Do you want to delete?')" OnClick="lnkDelete_Click" >
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
