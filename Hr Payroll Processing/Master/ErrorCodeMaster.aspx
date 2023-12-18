<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="ErrorCodeMaster.aspx.cs" Inherits="Hr_Payroll_Processing.Master.ErrorCodeMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Stylesheets/CodeMaster.css">
     <link rel="stylesheet" type="text/css" href="/Stylesheets/Employee.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainBox">
    <div class="main">
        <div class="btnreverse"><button id="btnBack" runat="server" class="btn btn-dark" onserverclick="btnBack_ServerClick"><i class="fa fa-chevron-circle-left">&nbsp</i>Back</button></div>
         <center><h3>ERROR CODE MASTER</h3></center><hr />
   
     <div class="row g-3">
        <div class="col-md-4">
            <asp:Label ID="lblErrCode" runat="server" Text="ERROR CODE "></asp:Label><font color="red">*</font>
            <asp:TextBox ID="txtErrCode" runat="server" CssClass="form-control"  MaxLength="12" OnTextChanged="txtErrCode_TextChanged" AutoPostBack="true"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                    ErrorMessage="Required Field" ControlToValidate="txtErrCode" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
            <asp:Label runat="server" ID="lblAlert" ForeColor="Red"></asp:Label>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblErrType" runat="server" Text="ERROR TYPE: "></asp:Label><font color="red">*</font>
            <asp:TextBox ID="txtErrType" runat="server" CssClass="form-control" MaxLength="12" style="text-transform: uppercase;"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2"
                    ErrorMessage="Required Field" ControlToValidate="txtErrType" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
        </div>  
         <div class="col-md-4">
            <asp:Label ID="lblErrDesc" runat="server" Text="ERROR DESCRIPTION: "></asp:Label><font color="red">*</font>
            <asp:TextBox ID="txtErrDesc" runat="server" CssClass="form-control" MaxLength="240"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3"
                    ErrorMessage="Required Field" ControlToValidate="txtErrDesc" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
        </div>  
        <center>
            <asp:Button ID="btnSaveErrorMaster" runat="server" CssClass="btn btn-dark" Text="Save" ValidationGroup="save" OnClick="btnSaveErrorMaster_Click"  />
             <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-warning" Text="Update" ValidationGroup="save" Visible="false" OnClick="btnUpdate_Click"/>
            <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn-secondary" Text="Cancel" OnClick="btnRefresh_Click"/>
            </center>
    </div>
 </div>
    <%--GRID VIEW--%>

    <div class="CheckAttendence">
    <asp:GridView ID="gvErrorMaster" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true" style="width:100%" CssClass="table table-striped table-bordered table-condensed table-hover" HeaderStyle-BackColor="#99ccff">
                <Columns>
                    <asp:TemplateField HeaderText="ERR CODE" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblDeptNo" runat="server"  Text='<%# Eval("ERR_CODE") %>' style="text-transform: uppercase;"></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="ERR TYPE" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblErrType" runat="server"  Text='<%# Eval("ERR_TYPE") %>' style="text-transform: uppercase;"></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>  
                    
                    <asp:TemplateField HeaderText="ERR DESC" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblErrDesc" runat="server"  Text='<%# Eval("ERR_DESC") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="table-primary" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                           <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("ERR_CODE") %>' OnClick="lnkEdit_Click" >
                              <i class="fa fa-edit" style="color:green;" title="Edit"></i>
                           </asp:LinkButton>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="table-primary" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                           <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("ERR_CODE") %>' OnClientClick="return confirm('Do you want to delete?')" OnClick="lnkDelete_Click">
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
