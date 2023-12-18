<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hr_Payroll_Processing.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="/Stylesheets/Login.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
     <script type="text/javascript">
         function showSuccessMessage(pMessgae) {
             Swal.fire({
                 icon: 'success',
                 text: pMessgae,
             });
         }
         function showErrorMessage(pMessgae) {
             Swal.fire({
                 icon: 'error',
                 text: pMessgae,
             });
         }
         </script>
</head>
<body>
   
        <section class="vh-100">
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100" >
      <div class="col-md-9 col-lg-6 col-xl-5">
        <img src="Images/login_image.png"  class="img-fluid"/>        
      </div>
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
        <form id="form1" runat="server">
          <div class="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
            <p class="lead fw-normal mb-3 me-3 fw-bold mt-1" style="font-size:x-large">Login Here!</p>           
          </div>       

          <!-- Email input -->
          <div class="form-outline mb-3">
              <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
              <asp:TextBox ID="txtUsername" runat="server" class="form-control " MaxLength="15" placeholder="Enter Username"></asp:TextBox>
              <asp:RequiredFieldValidator runat="server" ID="valUsername"
               ErrorMessage="Username is required" ControlToValidate="txtUsername" ForeColor="Red" Font-Size="Small">
              </asp:RequiredFieldValidator>
          </div>

          <!-- Password input -->
          <div class="form-outline mb-3">
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" class="form-control" runat="server" placeholder="Enter Password" MaxLength="15" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="valPassword"
             ErrorMessage="Password is required" ControlToValidate="txtPassword" ForeColor="Red" Font-Size="Small">
            </asp:RequiredFieldValidator>
          </div>
            <center>
          <div class="form-outline mb-3 text-center text-lg-start mt-1 pt-2">
              <asp:Button ID="btnLogin" CssClass="btn btn-dark float-none" runat="server" Text="Login" Style="border-radius: 2px; width: 300px; font-weight:600" OnClick="btnLogin_Click" />
              </div>
                </center>
        </form>
      </div>
    </div>
  </div>
            </section>







        <%--<div class="container">
            <div class="row">
                <div class="col-sm-8">
                    <img src="Images/login_image.png"  class="img-fluid"/>

                </div>
                <div class="col-sm-4" style="margin-top:200px;>           
                    <div class="container">
                        <h2 style="margin-top:90px;">Login Here!</h2>
                        <div class="form-group">
                                <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
                                <asp:TextBox ID="txtUsername" runat="server" class="form-control" MaxLength="15"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="valUsername"
                                    ErrorMessage="Username is required" ControlToValidate="txtUsername" ForeColor="Red" Font-Size="Small">
                                </asp:RequiredFieldValidator>
                           
                        </div>
                        <div class="form-group">
                                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                                <asp:TextBox ID="txtPassword" class="form-control" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="valPassword"
                                    ErrorMessage="Password is required" ControlToValidate="txtPassword" ForeColor="Red" Font-Size="Small">
                                </asp:RequiredFieldValidator>
                            
                    </div>
            <asp:Button ID="btnLogin" CssClass="btn btn-dark" runat="server" Text="Login" Style="border-radius: 0px; width: 100px; margin-left: 95px;" OnClick="btnLogin_Click" />
        </div>
                </div>
                    
            </div>
        </div>--%>
   
               

</body>
<footer class="bg-light text-center text-lg-start fixed-bottom">
    <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.2);">
        © 2023 Copyright:Hr Payroll Processing System
                        <a class="text-dark"></a>
    </div>

</footer>
</html>
