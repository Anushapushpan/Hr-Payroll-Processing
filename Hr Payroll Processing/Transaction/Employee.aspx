<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Hr_Payroll_Processing.Transaction.Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Stylesheets/Employee.css">
   
<script src="https://code.jquery.com/jquery-3.6.0.js"></script>
<script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
<link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">

    <script>
        $(function () {
            var jqu = jQuery.noConflict();
        $("#ContentPlaceHolder1_txtEmpDob").datepicker({
            dateFormat: 'dd/mm/yy',
            changeYear: true,
            changeMonth: true,
            minDate: "-65Y",
            maxDate: "-18Y",
            yearRange: "1958:2099",
            

        });
        var date = new Date();
        var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());

        $("#ContentPlaceHolder1_txtJoinDate").datepicker({
            minDate: subtractMonths(new Date(), 1),
            maxDate: AddMonths(new Date(), 1),
            dateFormat: 'dd/mm/yy',
            beforeShowDay: disableSunday,
            
        });
            $("#ContentPlaceHolder1_txtJoinDate").attr("readonly", "readonly");
            $("#ContentPlaceHolder1_txtEmpDob").attr("readonly", "readonly");
            function disableSunday(sunday) {
                var calenderday = sunday.getDay();
                return [(calenderday > 0)];
            };
            function subtractMonths(date, months) {
                date.setMonth(date.getMonth() - months);
                return date;
            }
            function AddMonths(date, months) {
                date.setMonth(date.getMonth() + months);
                return date;
            }
        });

       
</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainBox">

    <div class="main">
        <center><h2>Add Employee </h2></center>

        <hr />

        <div class="btnreverse">
            <button id="btnBack" runat="server" class="btn btn-dark" onserverclick="btnBack_ServerClick"><i class="fa fa-chevron-circle-left">&nbsp</i>Back</button></div>
        <div class="btnBack">
            <button id="Button1" runat="server" class="btn btn-dark" onserverclick="btnAddEmployee_ServerClick"><i class="fa fa-plus">&nbsp</i>Add Employee</button></div>
        <div class="row g-3">
            <div class="col-md-4">
                <asp:Label ID="lblEmpNo" runat="server" Text="EMPLOYEE NO : "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtEmpNo" runat="server" CssClass="form-control" ReadOnly="true" Enabled="false"></asp:TextBox>

            </div>
            <div class="col-md-4">
                <asp:Label ID="lblEmpName" runat="server" Text="EMPLOYEE NAME : "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control" MaxLength="120"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                    ErrorMessage="Required" ControlToValidate="txtEmpName" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                </asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblEmpDob" runat="server" Text="DOB : "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtEmpDob" runat="server" CssClass="form-control" placeholder="Select Your DOB"></asp:TextBox>

                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2"
                    ErrorMessage="Required" ControlToValidate="txtEmpDob" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row g-3">
            <div class="col-md-4">
                <asp:Label ID="lblJoinDate" runat="server" Text="JOIN DATE : "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtJoinDate" runat="server" CssClass="form-control" placeholder="Select Join Date"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5"
                    ErrorMessage="Required" ControlToValidate="txtJoinDate" ForeColor="Red" Font-Size="Small" ValidationGroup="save">
                </asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblSalary" runat="server" Text="SALARY : "></asp:Label><font color="red">*</font>
                <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" ReadOnly="true" Style="text-align: right;" Enabled="false"></asp:TextBox>

            </div>
            <div class="col-md-4">
                <asp:Label ID="lblDeptNo" runat="server" Text="DEPARTMENT NO: "></asp:Label><font color="red">*</font>
                <asp:DropDownList runat="server" ID="ddldeptNo" CssClass="form-control form-select">
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4" Display="Dynamic"
                    ValidationGroup="save" runat="server" ControlToValidate="ddldeptNo"
                    Text="Required" ErrorMessage="ErrorMessage" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row g-3">
            <div class="col-md-4">
                <asp:Label ID="lblManagerNo" runat="server" Text="MANAGER NO: "></asp:Label><font color="red">*</font>
                <asp:DropDownList runat="server" ID="ddlManagerNo" CssClass="form-control form-select">
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" Display="Dynamic"
                    ValidationGroup="save" runat="server" ControlToValidate="ddlManagerNo"
                    Text="Required" ErrorMessage="ErrorMessage" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblEmpStatus" runat="server" Text="EMPLOYEE STATUS: "></asp:Label><font color="red">*</font>
                <asp:DropDownList runat="server" ID="ddlEmpStatus" CssClass="form-control form-select">
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic"
                    ValidationGroup="save" runat="server" ControlToValidate="ddlEmpStatus"
                    Text="Required" ErrorMessage="ErrorMessage" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-4">
                <asp:Label ID="lblEmpActive" runat="server" Text="ACTIVE Y/N:  "></asp:Label><font color="red">*</font><br />
                <asp:CheckBox ID="chkCmActive" Checked="true" runat="server" />
            </div>

        </div>
        <div class="submitButtons">
            <center>
            <asp:Button ID="btnSaveDept" runat="server" CssClass="btn btn-dark" Text="Save" ValidationGroup="save" OnClick="btnSaveDept_Click" />   
                     <asp:Button ID="BtnUpdateEmp" runat="server" CssClass="btn btn-success" Text="Update" ValidationGroup="save" Visible="false" OnClick="BtnUpdateEmp_Click" />                   
                 <asp:Button ID="btnCancelDept" runat="server" CssClass="btn btn-secondary" Text="Cancel" OnClick="btnCancelDept_Click" />
                    
                 </center>
        </div>
    </div>

    <div class="allowance">

        <asp:Label ID="lblAllowanceHeading" runat="server" Text="Allowance" style="font-size:xx-large; margin-left:550px;" Visible="false"></asp:Label>
         <button id="btnUpdateAlloowance" runat="server" class="btn btn-warning" onserverclick="btnUpdateAlloowance_Click" style="width:150px; margin-left:1100px;" Visible="false"><i class="fa fa-plus">&nbsp</i>Add Allowance</button>
        <hr />
       
        <div class="allowanceGrid">
            <asp:GridView ID="gvAllowance" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" style="width:100%" CssClass="table table-striped table-bordered table-condensed">
                <Columns>
                    <asp:TemplateField HeaderText="Designation" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblDesignation" runat="server"  Text='<%# Eval("EH_DESIGNATION") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grade" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblGrade" runat="server"  Text='<%# Eval("EH_GRADE") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Basic" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblBasic" runat="server"  Text='<%# Eval("EH_BASIC","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="HRA" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblHra" runat="server"  Text='<%# Eval("EH_HRA","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CONV" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblConv" runat="server"  Text='<%# Eval("EH_CONV","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DA" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblDa" runat="server"  Text='<%# Eval("EH_DA","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="TDS" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblTds" runat="server"  Text='<%# Eval("EH_TDS","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ESI" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:Label ID="lblEsi" runat="server"  Text='<%# Eval("EH_ESI","{0:N2}") %>'></asp:Label>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-primary">
                       <ItemTemplate>
                           <asp:LinkButton ID="lnkEdit" runat="server"  Text="Edit" CommandArgument='<%# Eval("EH_EMP_NO")%>' OnClick="lnkEdit_Click">
                               <i class="fa fa-edit" style="color:green;" title="Edit"></i>
                           </asp:LinkButton>
                       </ItemTemplate>                                                 
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    
     </div>
</asp:Content>
