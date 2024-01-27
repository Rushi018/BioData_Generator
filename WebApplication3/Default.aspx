<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />

    <style>
        /* Your existing styles */
        .form-group label {
            font-weight: 500;
            text-transform: uppercase;
            letter-spacing: .2em;
        }

        .form-control {
            border-radius: 0;
            font-weight: 500;
            width: 100%; /* Adjust this value as needed */
            margin: 0 auto; /* Centers the textbox */
        }

        .btn-primary {
            background-color: #4285F4;
            border-color: #4285F4;
            text-transform: uppercase;
        }

        .btn-success {
            background-color: #28a745;
            border-color: #28a745;
            text-transform: uppercase;
        }

        

        /* New CSS */
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: 'Open Sans', sans-serif;
        }

        body {
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 0 10px;
            min-height: 100vh;
            background: #1BB295;
        }

        form {
            padding: 25px;
            background: #fff;
            max-width: 500px;
            width: 100%;
            border-radius: 7px;
            box-shadow: 0 10px 15px rgba(0, 0, 0, 0.05);
            background: linear-gradient(45deg, rgba(66, 183, 245, 0.8) 0%, rgba(66, 245, 189, 0.4) 100%);
            width: 600px;
            left: 200px;
            
        }

        form h2 {
            font-size: 27px;
            text-align: center;
            margin: 0px 0 30px;
        }

        form .form-group {
            margin-bottom: 15px;
            position: relative;
        }

        form label {
            display: block;
            font-size: 15px;
            margin-bottom: 7px;
        }

        form input,
        form select {
            height: 45px;
            padding: 10px;
            width: 100%;
            font-size: 15px;
            outline: none;
            background: #fff;
            border-radius: 3px;
            border: 1px solid #bfbfbf;
        }

        form input:focus,
        form select:focus {
            border-color: #9a9a9a;
        }

        form input.error,
        form select.error {
            border-color: #f91919;
            background: #f9f0f1;
        }

        form small {
            font-size: 14px;
            margin-top: 5px;
            display: block;
            color: #f91919;
        }

        form .password i {
            position: absolute;
            right: 0px;
            height: 45px;
            top: 28px;
            font-size: 13px;
            line-height: 45px;
            width: 45px;
            cursor: pointer;
            color: #939393;
            text-align: center;
        }

        .submit-btn {
            margin-top: 30px;
        }

        .submit-btn input {
            color: white;
            border: none;
            height: auto;
            font-size: 16px;
            padding: 13px 0;
            border-radius: 5px;
            cursor: pointer;
            font-weight: 500;
            text-align: center;
            background: #1BB295;
            transition: 0.2s ease;
        }

        .submit-btn input:hover {
            background: #179b81;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-3">
            <div class="card">
                <div class="card-body">
                    <h1 class="text-center">Registration Page</h1>
                    <br />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    <br />
                    <br />
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Enter ID" CssClass="control-label"></asp:Label>
                        <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Enter Name" CssClass="control-label"></asp:Label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Enter Email" CssClass="control-label"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="^[^@]+@[^@]+\.[^@]+$">*</asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Enter Mobile" CssClass="control-label"></asp:Label>
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile" ErrorMessage="(+91) Required" ForeColor="Red" ValidationExpression="^(\+91)?\d{10}$">*</asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Select City" CssClass="control-label"></asp:Label>
                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AutoPostBack="True">
                            <asp:ListItem>Nagpur</asp:ListItem>
                            <asp:ListItem>Pune</asp:ListItem>
                            <asp:ListItem>Mumbai</asp:ListItem>
                            <asp:ListItem>Bhopal</asp:ListItem>
                            <asp:ListItem>Indore</asp:ListItem>
                            <asp:ListItem>Thane</asp:ListItem>
                            <asp:ListItem>Delhi</asp:ListItem>
                            <asp:ListItem>Noida</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Enter Address" CssClass="control-label"></asp:Label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <asp:Label ID="Label7" runat="server" Text="Enter Pincode" CssClass="control-label"></asp:Label>
                        <asp:TextBox ID="txtPin" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Upload Image" CssClass="control-label"></asp:Label>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="btn btn-primary" />
                        <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Next" CssClass="btn btn-success" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
