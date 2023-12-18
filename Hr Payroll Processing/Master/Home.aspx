<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Hr_Payroll_Processing.Master.UserMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../Stylesheets/User.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://pixinvent.com/stack-responsive-bootstrap-4-admin-template/app-assets/fonts/simple-line-icons/style.min.css">
    <link rel="stylesheet" type="text/css" href="https://pixinvent.com/stack-responsive-bootstrap-4-admin-template/app-assets/css/colors.min.css">
   
   
        <%--<script>
            var showChangePasswordModal = true; 

            $(document).ready(function () {
                if (showChangePasswordModal) {
                    $('#changePasswordModal').modal('show');
                }
            });

    </script>--%>
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainBox" style="margin-right:40px; margin-left:40px;">
        <div class="background mt-5 ">
        </div>

        <div class="row">
            <div class="col-sm-3 mb-3 mb-sm-0">
                <div class="card text-white" style="background-color:darkgreen">
                    <div class="card-body">
                        <p>Total Employees</p>
                        <asp:Label ID="lblTotalEmployee" runat="server" CssClass="totEmployee" style="font-size:30px; font-weight:700"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-sm-3  mb-3 mb-sm-0">
                <div class="card text-white" style="background-color:crimson">
                    <div class="card-body">
                        <p>Active Employees</p>
                        <asp:Label ID="lblActiveEmp" runat="server" CssClass="totEmployee" style="font-size:30px; font-weight:700"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="col-sm-3  mb-3 mb-sm-0 ">
                <div class="card text-white" style="background-color:indigo">
                    <div class="card-body">
                        <p>Total Managers</p>
                        <asp:Label ID="lblTotalManagers" runat="server" CssClass="totEmployee" style="font-size:30px; font-weight:700"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-sm-3  mb-3 mb-sm-0">
                <div class="card text-white" style="background-color:darkorange">
                    <div class="card-body">
                        <p>Active Managers</p>
                        <asp:Label ID="lblActiveManagers" runat="server" CssClass="totEmployee" style="font-size:30px; font-weight:700"></asp:Label>
                    </div>
                </div>
            </div>



        </div>
        <div class="row mt-5">

            <div class="col-sm-9 mb-3 mb-sm-0 ">
                <div class="card bg-primary text-white p-2" style="height: 218px;">
                    <div class="card-header">
                        <div class="row">
                            <div class="col sm-4">
                                <p style="font-size: smaller">LATEST</p>
                                &nbsp;<br />
                                <asp:Label ID="lblMonthAndYear" runat="server" Style="position: absolute; top: 40px; font-size: 20px;"></asp:Label>
                            </div>
                            <div class="col sm-4">
                                <p style="font-size: smaller">CALENDER DAYS</p>
                                &nbsp;<br />
                                <asp:Label ID="lblCalenderDays" runat="server" Style="position: absolute; top: 40px; font-size: 20px;"></asp:Label>
                            </div>
                            <div class="col sm-4">
                                <p style="font-size: smaller">EMPLOYEES</p>
                                &nbsp;<br />
                                <asp:Label ID="lblEmpCount" runat="server" Style="position: absolute; top: 40px; font-size: 20px;"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col">

                                <p style="font-size: smaller">TOTAL PAYROLL COST</p>
                                &nbsp;
                         <i class="fa fa-inr" aria-hidden="true" style="font-size: large"></i>&nbsp;<asp:Label ID="lblTotPayrollCost" runat="server" Style="font-size: 20px;"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-3">
                <%--SCROLLING NEWS--%>
                <div class="ds" style="width: 248px;">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="d-flex justify-content-between align-items-center breaking-news bg-white">
                                <div class="d-flex flex-row flex-grow-1 flex-fill justify-content-center bg-secondary py-2 text-white px-1 news" style="width: 100px; height: 20px; border-radius: 3px;"><span class="d-flex align-items-center">&nbsp;New Updates</span></div>
                            </div>
                            <marquee class="news-scroll" behavior="scroll" direction="left">
                    <asp:Label ID="lblMaxMonth" runat="server" ForeColor="red" ></asp:Label>
                    
                </marquee>
                        </div>
                    </div>
                </div>

                

                <%--SHOWING CALENDER--%>

                <div class="calender">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="white" BorderColor="Black"
                        BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="#663399" ShowGridLines="True" Style="width: 248px;">

                        <SelectedDayStyle BackColor="Black" Font-Bold="True" />
                        <SelectorStyle BackColor="white" />
                        <TodayDayStyle BackColor="#33ccff" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#66ccff" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="White" />
                        <DayHeaderStyle BackColor="white" Font-Bold="True" Height="1px" />
                        <TitleStyle BackColor="#000000" Font-Bold="True" Font-Size="9pt" ForeColor="white" />
                    </asp:Calendar>
                </div>
            </div>
        </div>      
    </div>

    
</asp:Content>
