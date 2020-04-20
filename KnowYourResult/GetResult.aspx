<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetResult.aspx.cs" Inherits="KnowYourResult.GetResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Result</title>
    <meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="css/bootstrap.min.css">
    <style>
        .container {
        margin-top:100px;
        margin-left:auto;

        }
    </style>
</head>
<body style="background-image:url('cabackground-green.jpg');">
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <h1 class="text-center login-title" style="font-family: 'MV Boli'; color: #00CCFF;">Result Generator</h1>
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <label for="Select a Result pdf from above">Select a Result pdf from above</label><asp:ListBox ID="ListBox1" runat="server" Width="300px"></asp:ListBox> 
                            </div>
                        <div class=" form-group">
                            <label for="Enter Starting Seat No.">Enter Starting Seat No.</label>
                                <asp:TextBox ID="Starting" class="form-control" runat="server" placeholder="Enter Starting Seat No." />
                            </div>
                        <div class="form-group">
                            <label for="Enter Last Seat No.">Enter Last Seat No.</label>
                            <asp:TextBox ID="Last" class="form-control" runat="server"  placeholder="Enter Last Seat No." />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="Button1" runat="server"  class="btn btn-primary" Text="Generate Marksheet " OnClick="Button1_Click1" />     
                        </div>
                     </form>
             </div>
         </div>
    </div>
</body>
</html>
