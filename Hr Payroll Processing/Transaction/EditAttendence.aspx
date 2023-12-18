<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="EditAttendence.aspx.cs" Inherits="Hr_Payroll_Processing.Transaction.EditAttendence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Stylesheets/Employee.css">
    <%--<style type="text/css">
        #loading {
            display:none;
            position:fixed;
            left:0;
            top:0;
            width:100%;
            height:100%;
            background-color:rgba(255,255,255,0.7);
            text-align:center;
            padding-top:25%;
            z-index:1000;
        }
        #loading img {
            width:50px;
            height:50px;
        }
    </style>--%>

   <%-- <script type="text/javascript">
        $(document).ready(function () {
            $('#loading').show();

            setTimeout(function () {
                $('#loading').hide();
            }, 400);
        });
        $(window).on('load', function () {
            $('#loading').hide();

        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div id="loading">
        <img src="../Images/loading.gif" alt="loading" />
        <p>Loading</p>
    </div>--%>
    <div class="mainBox">
    <br />
    
    <div class="backButton"><button id="btnBack" runat="server" class="btn btn-dark" onserverclick="btnAddEmployee_ServerClick"><i class="fa fa-chevron-circle-left">&nbsp</i>Back</button></div>
       
    <div class="row g-3" style="margin-left:50px;"> 
             <div class="col-md-4">
                <asp:Label ID="lblEmpNo" runat="server" Text="Employee No : "></asp:Label>
                <asp:TextBox ID="txtEmpNo" runat="server" CssClass="form-control" ReadOnly="true" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblAbsent" runat="server" Text="Absent days : "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtAbsent" runat="server" CssClass="form-control" TextMode="Number" onKeyDown="if(this.value.length==2 && event.keyCode!=8) return false;" OnTextChanged="calculatePresentDays" AutoPostBack="true" style="text-align:right;"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3"
                    ErrorMessage="Required field" ControlToValidate="txtAbsent" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
                ControlToValidate="txtAbsent" ErrorMessage="Value must be a Number" ForeColor="Red" Font-Size="Small" ValidationGroup="save" />
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblPresent" runat="server" Text="Present days : "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtPresent" runat="server" CssClass="form-control" ReadOnly="true" style="text-align:right;" Enabled="false"></asp:TextBox>
            </div>
        
         </div>
    <center><asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="btn btn-dark" OnClick="btnSave_Click" ValidationGroup="save"/></center>
           
        
         
     </div>   
</asp:Content>
