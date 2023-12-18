<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="AttendenceDetails.aspx.cs" Inherits="Hr_Payroll_Processing.Transaction.Attendence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Stylesheets/Employee.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainBox">
     <div class="btnreverse"><button id="btnBack" runat="server" class="btn btn-dark" onserverclick="btnBack_ServerClick" style="margin-left:50px;"><i class="fa fa-chevron-circle-left">&nbsp</i>Back</button></div>
    <center><h2>Attendence Details</h2></center>
    <hr style="margin-left:50px; margin-right:50px;" />
    <center>
    <div class="attendence">
    <asp:Label ID="lblMonth" Text="Month: " runat="server"></asp:Label>
    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control form-select"  OnTextChanged="ddlyear_TextChanged" AutoPostBack="true">
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
    <asp:DropDownList ID="ddlyear" runat="server" CssClass="form-control form-select"  OnTextChanged="ddlyear_TextChanged" AutoPostBack="true">
        <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
        <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
        <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
        <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
    </asp:DropDownList>
        </div>
        </center>
    <div class="btnProceed">
        <center><asp:Button ID="btnProceed" runat="server" CssClass="btn btn-dark" Text="Check Payroll" OnClick="btnProceed_Click" ValidationGroup="save"/></center>
    </div>
    

    <div class="CheckAttendence">
        
            <asp:GridView ID="gvAttendence" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowDataBound="gvAttendence_RowDataBound" OnPageIndexChanging="gvAttendence_PageIndexChanging" AllowSorting="true" style="width:100%" CssClass="table table-striped table-bordered table-condensed table-hover" HeaderStyle-BackColor="#99ccff">
                <Columns>
                    <asp:TemplateField HeaderText="Employee No" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblEmpNo" runat="server"  Text='<%# Eval("EMP_NO") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Absent Days" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblEmpName" runat="server" Text='<%# Eval("ABSENT") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Present Days" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblEmpDob" runat="server" Text='<%# Eval("PRESENT") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>                 
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("EMP_NO") %>' OnClick="lnkEdit_Click">
                             <i class="fa fa-edit" style="color:green;" title="Edit"></i>
                           </asp:LinkButton>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>               
                </Columns>
                 <PagerStyle HorizontalAlign = "Right" CssClass = "GridPager"/>
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="4"  FirstPageText="First" LastPageText="Last"/>
            </asp:GridView>
       
         <div class="btnProccess">
             <center>
        <asp:Button ID="btnProcessAttendence" runat="server" CssClass="btn btn-dark" Enabled="false" Text="Process Attendence" OnClick="btnProcessAttendence_Click" style="margin-left:0px;"/>
       </center>
                 </div>
        <br />
        <hr />

<%--        <div class="row g-3"> 
             <div class="col-md-4">
                 <asp:Label ID="lblEmpNo" runat="server" Text="EMPLOYEE NO : "></asp:Label><font color="red">*</font>
                 <asp:DropDownList runat="server" ID="ddlEmpNo" CssClass="form-control form-select" >                                 
                 </asp:DropDownList>
             </div>
            <div class="col-md-4">
                <asp:Label ID="lblAbsent" runat="server" Text="Absent days : "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtAbsent" runat="server" CssClass="form-control"  OnTextChanged="calculatePresentDays" AutoPostBack="true"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3"
                    ErrorMessage="Required field" ControlToValidate="txtAbsent" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                    </asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblPresent" runat="server" Text="Present days : "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtPresent" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
            </div>
         </div>
        <asp:Button ID="btnDisplayPresentdays" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnDisplayPresentdays_Click" />--%>
    </div>
        </div>
</asp:Content>
