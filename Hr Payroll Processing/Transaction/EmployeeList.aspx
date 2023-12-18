<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="Hr_Payroll_Processing.Transaction.EmployeeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="/Stylesheets/Employee.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainBox">
    <div class="btnreverse"><button id="btnBack" runat="server" class="btn btn-dark" onserverclick="btnBack_ServerClick" style="margin-left:50px; margin-top:20px;"><i class="fa fa-chevron-circle-left">&nbsp</i>Back</button></div>
    <div class="addButton"><button id="btnAddEmployee" runat="server" class="btn btn-dark" onserverclick="btnAddEmployee_ServerClick"><i class="fa fa-plus">&nbsp</i>Add Employee</button></div>
    <center><h2 >Employee List</h2></center>         
        <hr style="margin-left:50px; margin-right:50px;" />
        <div class="employeeList">
            <div class="searchArea float-start">
                <asp:TextBox ID="txtSearchEmp" runat="server" TextMode="search" placeholder="Search Employee Name or Emp No" MaxLength="12" CssClass="form-control" Style="border-radius: 3px; width: 300px;"></asp:TextBox>

                <button id="btnSearch" runat="server" class="btn btn-warning" onserverclick="btnSearch_ServerClick" validationgroup="search"><i class="fa fa-search" aria-hidden="true"></i>&nbsp;Search</button>
                <asp:Button runat="server" ID="btnClear" CssClass="btn btn-secondary" Text="Clear" OnClick="btnClear_Click" />
            </div>
            <div class="float-end" style="display:flex">
                <p><i class="fa fa-filter" aria-hidden="true" style="font-size:large"></i>
                <asp:Label ID="lblSortEmp" Text="Sort By:" runat="server"></asp:Label>&nbsp;</p>
                <asp:DropDownList ID="ddlSortEmployees" runat="server" CssClass="form-control form-select" style="width:200px; border-radius: 3px; " OnTextChanged="ddlSortEmployees_TextChanged" AutoPostBack="true">
                    <asp:ListItem Text="All" Value="All"></asp:ListItem>                   
                    <asp:ListItem Text="Managers" Value="Managers"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <%-- <asp:Label ID="lblNotFound" runat="server" Text="Sorry! No Results Found!!!" style="margin-left:520px; font-size:large" Visible="false"></asp:Label><br />--%>
            <asp:Image ID="imgNotFound" runat="server" ImageUrl="~/Images/Animation - 1699525804667.gif" Style="width: 200px; height: 200px; margin-left: 550px; margin-top: 0px;" Visible="false" />
            <div class="EmployeeListGrid">


                <asp:GridView ID="gvEmployeeGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvEmployeeGrid_PageIndexChanging" AllowSorting="true" Style="width: 100%; margin-top:30px; border-radius: 10px;" CssClass="table table-striped table-bordered table-condensed table-hover" HeaderStyle-BackColor="#99ccff">
                    <Columns>
                        <asp:TemplateField HeaderText="Employee No" HeaderStyle-CssClass="table-primary">
                            <ItemTemplate>
                                <asp:Label ID="lblEmpNo" runat="server" Text='<%# Eval("EMP_NO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="table-primary">
                            <ItemTemplate>
                                <asp:Label ID="lblEmpName" runat="server" Text='<%# Eval("EMP_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dob" HeaderStyle-CssClass="table-primary">
                            <ItemTemplate>
                                <asp:Label ID="lblEmpDob" runat="server" Text='<%# Eval("EMP_DOB", "{0:dd/MMM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Join Date" HeaderStyle-CssClass="table-primary">
                            <ItemTemplate>
                                <asp:Label ID="lblEmpJoinDate" runat="server" Text='<%# Eval("EMP_JOIN_DATE", "{0:dd/MMM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Salary" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="table-primary">
                            <ItemTemplate>
                                <asp:Label ID="lblEmpSalary" runat="server" Text='<%# Eval("EMP_SALARY","{0:N2}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Department" HeaderStyle-CssClass="table-primary">
                            <ItemTemplate>
                                <asp:Label ID="lblEmpDeptNo" runat="server" Text='<%# Eval("DEPT_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Manager No" HeaderStyle-CssClass="table-primary">
                            <ItemTemplate>
                                <asp:Label ID="lblMgrNo" runat="server" Text='<%# Eval("EMP_MGRNO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="table-primary">
                            <ItemTemplate>
                                <asp:Label ID="lblEmpStatus" runat="server" Text='<%# Eval("STATUS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Active" HeaderStyle-CssClass="table-primary">
                            <ItemTemplate>
                                <asp:Label ID="lblActive" runat="server" Text='<%# Eval("EMP_ACTIVE_YN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="table-primary">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("EMP_NO") %>' OnClick="lnkEdit_Click">
                                <i class="fa fa-edit" style="color:green;" title="Edit"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="table-primary">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("EMP_NO") %>' OnClientClick="return confirm('Do you want to delete?')" OnClick="lnkDelete_Click">
                               <i class="material-icons" style="color: red;" data-toggle="tooltip" title="Delete">&#xE872;</i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                    <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="<<" LastPageText=">>" />
                </asp:GridView>
            </div>
        </div>
        </div>
</asp:Content>
