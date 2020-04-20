<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="KnowYourResult.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <style>
        body {
          margin: 0;
          padding: 0;
          background-color: #17a2b8;
          height: 100vh;
        }
        #login .container #login-row #login-column #login-box {
          margin-top: 80px;
          max-width: 600px;
          height: 320px;
          border: 1px solid #9C9C9C;
          background-color: #EAEAEA;
          margin-left:300px;
        }
        #login .container #login-row #login-column #login-box #login_form {
          padding: 20px;
        }
        #login .container #login-row #login-column #login-box #login_form #register-link {
          margin-top: -85px;
          
        }
    </style>
</head>
<body>
    <div id="login">
        <h3 class="text-center text-white pt-5" style="font-family: 'MV Boli'; font-size:50px; text-transform: uppercase; color: #FFFFFF;">Result Generator</h3>
        <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">
                        <form id="login_form" class="form" method="post" runat="server">
                            <h3 class="text-center text-info">Login</h3>
                            <div class="form-group">
                                <label for="username" class="text-info">Username:</label><br/>
                                <asp:TextBox type="text" name="username" id="username" class="form-control" runat="server"/>
                            </div>
                            <div class="form-group">
                                <label for="password" class="text-info">Password:</label><br>
                                <asp:TextBox type="text" name="password" id="password" class="form-control" runat="server"/>
                            </div>
                            <div class="form-group">
                                <asp:Button type="submit" name="submit" class="btn btn-info btn-md" TEXT="submit" runat="server" OnClick="login_Click"/>
                            </div>
                       </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
