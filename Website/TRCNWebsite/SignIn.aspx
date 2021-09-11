<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" ValidateRequest ="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content="Teachers' Registration Council of Nigeria"/>
    <meta name="author" content="Johnwendy"/>
    <title>Teachers' Registration Council of Nigeria</title>

    <!-- Favicons-->
    <link rel="shortcut icon" href="trcn.png" type="image/x-icon"/>
    <link rel="apple-touch-icon" type="image/x-icon" href="trcn.png">
    <link rel="apple-touch-icon" type="image/x-icon" sizes="72x72" href="trcn.png">
    <link rel="apple-touch-icon" type="image/x-icon" sizes="114x114" href="trcn.png">
    <link rel="apple-touch-icon" type="image/x-icon" sizes="144x144" href="trcn.png">

    <!-- BASE CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link href="css/vendors.css" rel="stylesheet">
    <link href="css/icon_fonts/css/all_icons.min.css" rel="stylesheet">

    <!-- SPECIFIC CSS -->
    <link href="css/skins/square/grey.css" rel="stylesheet">
    <link href="css/wizard.css" rel="stylesheet">

    <!-- YOUR CUSTOM CSS -->
    <link href="css/custom.css" rel="stylesheet">
</head>
<body id="admission_bg" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div id="preloader">
            <div data-loader="circle-side"></div>
        </div>
        <!-- End Preload -->

        <div id="form_container" class="clearfix">
            <figure>
                <a href="index">
                    <img src="trcn.png" width="80" height="42" data-retina="true" alt=""></a>
            </figure>
            <div id="wizard_container">
                <div id="top-wizard">
                    <div id="progressbar"></div>
                </div>
                <!-- /top-wizard -->
                <div name="example-1" id="wrapped">

                    <!-- Leave for security protection, read docs for details -->
                    <div id="middle-wizard">


                        <div class="step">
                            <asp:Panel ID="pnlAlert" runat="server" CssClass="alert alert-danger" Visible="false">
                                <button type="button" class="close" data-dismiss="alert">×</button>
                                <span id="spIcon" runat="server"></span>
                                <asp:Label ID="lblMsg" CssClass="text-white " runat="server" Text=""></asp:Label>
                            </asp:Panel>
                            <h3 class="main_question"><strong></strong>Staff Login</h3>
                            <div class="form-group">
                                <input type="text" name="firstname" id="username" runat ="server"  class="form-control required" placeholder="Username" />
                            </div>
                            <div class="form-group">
                                <input type="password" name="lastname" id="password" runat="server" class="form-control required" placeholder="Password" />
                            </div>

                        </div>
                        <!-- /step-->


                        <!-- /step-->

                        <div class="submit step">
                        </div>
                        <!-- /step-->
                    </div>
                    <!-- /middle-wizard -->
                    <div id="bottom-wizard">

                         <button type="button" name="forward" runat="server" onserverclick ="loginClick" class="forward">Login</button>
                     
                    </div>
                    <!-- /bottom-wizard -->
                </div>
            </div>
            <!-- /Wizard container -->
        </div>
        <script src="js/jquery-2.2.4.min.js"></script>
        <script src="js/common_scripts.js"></script>
        <script src="js/main.js"></script>
        <script src="assets/validate.js"></script>

        <!-- SPECIFIC SCRIPTS -->
        <script src="js/jquery-ui-1.8.22.min.js"></script>
        <script src="js/jquery.wizard.js"></script>
        <script src="js/jquery.validate.js"></script>
        <script src="js/admission_func.js"></script>
    </form>
</body>
</html>

