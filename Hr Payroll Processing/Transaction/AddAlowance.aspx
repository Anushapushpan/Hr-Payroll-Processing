<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="AddAlowance.aspx.cs" Inherits="Hr_Payroll_Processing.Transaction.AddAlowance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="/Stylesheets/Employee.css">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainBox">
    <div class="main">
        <div class="btnreverse"><button id="btnBack" runat="server" class="btn btn-dark" onserverclick="btnBack_ServerClick"><i class="fa fa-chevron-circle-left">&nbsp</i>Back</button></div>
        <center><h2>Allowance Details</h2></center>
        <hr />
    <div class="row g-3">     
            <div class="col-md-4">
                <asp:Label ID="lblEmpNo" runat="server" Text="EMPLOYEE NO : "></asp:Label>
                <asp:TextBox ID="txtEmpNo" runat="server" CssClass="form-control" ReadOnly="true" MaxLength="12" Enabled="false"></asp:TextBox>          
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblDesignation" runat="server" Text="DESIGNATION: "></asp:Label><font color="red">*</font>
                 <asp:DropDownList runat="server" ID="ddlDesignation" CssClass="form-control form-select" ></asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator7" Display="Dynamic"
                    ValidationGroup="save" runat="server" ControlToValidate="ddlDesignation"
                    Text="Required" ErrorMessage="ErrorMessage" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblGrade" runat="server" Text="GRADE: "></asp:Label><font color="red">*</font>
                <asp:DropDownList runat="server" ID="ddlGrade" CssClass="form-control form-select" ></asp:DropDownList>  
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator8" Display="Dynamic"
                    ValidationGroup="save" runat="server" ControlToValidate="ddlGrade"
                    Text="Required" ErrorMessage="ErrorMessage" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
            </div>
     </div>

    <div class="row g-3">
        <div class="col-md-4">
                <asp:Label ID="lblBasic" runat="server" Text="BASIC: "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtBasic" runat="server" TextMode="Number" step="0.01" onKeyDown="if(this.value.length==12 && event.keyCode!=8) return false;" CssClass="form-control" min="0" style="text-align:right;"></asp:TextBox>
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" 
                ControlToValidate="txtBasic" ErrorMessage="Value must be a Number" ForeColor="Red" Font-Size="Small" ValidationGroup="save" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                        ErrorMessage="Required" ControlToValidate="txtBasic" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                        </asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
                <asp:Label ID="lblHra" runat="server" Text="HRA: "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtHra" runat="server" CssClass="form-control"
                    TextMode="Number" step="0.01" onKeyDown="if(this.value.length==12 && event.keyCode!=8) return false;" min="0"  MaxLength="12" style="text-align:right;"></asp:TextBox>
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" 
                ControlToValidate="txtHra" ErrorMessage="Value must be a Number" ForeColor="Red" Font-Size="Small" ValidationGroup="save" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2"
                        ErrorMessage="Required" ControlToValidate="txtHra" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                        </asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
                <asp:Label ID="lblConv" runat="server" Text="CONV: "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtConv" runat="server" CssClass="form-control" TextMode="Number" step="0.01" onKeyDown="if(this.value.length==12 && event.keyCode!=8) return false;" min="0" style="text-align:right;"></asp:TextBox> 
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" 
                ControlToValidate="txtConv" ErrorMessage="Value must be a Number" ForeColor="Red" Font-Size="Small" ValidationGroup="save" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3"
                        ErrorMessage="Required" ControlToValidate="txtConv" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                        </asp:RequiredFieldValidator>
            </div>
    </div>

    <div class="row g-3">
        <div class="col-md-4">
                <asp:Label ID="lblDa" runat="server" Text="DA: "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtDa" runat="server" CssClass="form-control" TextMode="Number" step="0.01" onKeyDown="if(this.value.length==12 && event.keyCode!=8) return false;"  min="0" style="text-align:right;"></asp:TextBox>
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" 
                ControlToValidate="txtDa" ErrorMessage="Value must be a Number" ForeColor="Red" Font-Size="Small" ValidationGroup="save" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4"
                        ErrorMessage="Required" ControlToValidate="txtDa" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                        </asp:RequiredFieldValidator>
            </div>
        <div class="col-md-4">
                <asp:Label ID="lblTds" runat="server" Text="TDS: "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtTds" runat="server" CssClass="form-control" TextMode="Number" step="0.01" onKeyDown="if(this.value.length==12 && event.keyCode!=8) return false;" min="0" style="text-align:right;"></asp:TextBox>  
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" 
                ControlToValidate="txtTds" ErrorMessage="Value must be a Number" ForeColor="Red" Font-Size="Small" ValidationGroup="save" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5"
                        ErrorMessage="Required" ControlToValidate="txtTds" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                        </asp:RequiredFieldValidator>
            </div>
        <div class="col-md-4">
                <asp:Label ID="lblEsi" runat="server" Text="ESI: "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtEsi" runat="server" CssClass="form-control" TextMode="Number" step="0.01" onKeyDown="if(this.value.length==12 && event.keyCode!=8) return false;" min="0" style="text-align:right;"></asp:TextBox>   
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" 
                ControlToValidate="txtEsi" ErrorMessage="Value must be a Number" ForeColor="Red" Font-Size="Small" ValidationGroup="save" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6"
                        ErrorMessage="Required" ControlToValidate="txtEsi" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                        </asp:RequiredFieldValidator>
            </div>
    </div>
        <div class="submitButtons">
            <center>
            <asp:Button ID="btnSaveDept" runat="server" CssClass="btn btn-dark" Text="SAVE" ValidationGroup="save" OnClick="btnSaveAllowance_Click" />
                <asp:Button ID="btnUpdateDept" runat="server" CssClass="btn btn-success" Text="Update" ValidationGroup="save" OnClick="btnSaveAllowance_Click" Visible="false"/>
             </center> 
            </div>
        </div>
    </div>
</asp:Content>
