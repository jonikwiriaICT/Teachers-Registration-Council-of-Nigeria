<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Teachers'Registration Council of Nigeria" />
    <meta name="author" content="Johnwendy">
    <title>Teachers'Registration Council of Nigeria</title>

    <!-- Favicons-->
    <link rel="shortcut icon" href="trcn.png" type="image/x-icon" />
    <link rel="apple-touch-icon" type="image/x-icon" href="trcn.png" />
    <link rel="apple-touch-icon" type="image/x-icon" sizes="72x72" href="trcn.png" />
    <link rel="apple-touch-icon" type="image/x-icon" sizes="114x114" href="trcn.png" />
    <link rel="apple-touch-icon" type="image/x-icon" sizes="144x144" href="trcn.png">

    <!-- BASE CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link href="css/vendors.css" rel="stylesheet">
    <link href="css/icon_fonts/css/all_icons.min.css" rel="stylesheet">

    <!-- YOUR CUSTOM CSS -->
    <link href="css/custom.css" rel="stylesheet">
    <link href="css/chatBot.css" rel="stylesheet" type="text/css" />

    <!-- Modernizr -->
    <script src="js/modernizr.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="preloader">
            <div data-loader="circle-side"></div>
        </div>
        <!-- End Preload -->

        <header class="header fadeInDown">
            <div id="logo">
                <a href="index">
                    <img src="trcn.png" width="80" height="42" data-retina="true" alt=""></a>
            </div>
            <ul id="top_menu">
                <li class="hidden_tablet">
                    <asp:LinkButton ID="lnkSignIn" OnClick="NavigateClicked" CssClass="rounded btn-success btn" runat="server">Sign in</asp:LinkButton>



                </li>

                <li>
                    <div class="hamburger hamburger--spin">
                        <div class="hamburger-box">
                            <div class="hamburger-inner"></div>
                        </div>
                    </div>
                </li>
            </ul>
            <div class="search-overlay-menu">
                <span class="search-overlay-close"><span class="closebt"><i class="ti-close"></i></span></span>
                <form role="search" id="searchform" method="get">
                    <input value="" name="q" type="search" placeholder="Search..." />
                    <button type="submit">
                        <i class="icon_search"></i>
                    </button>
                </form>
            </div>
            <!-- End Search Menu -->
            <!-- /top_menu -->
        </header>

        <main>
            <section class="header-video">
                <div id="hero_video">
                    <div>
                        <h3><strong>Teachers's</strong><br>
                            Registration Council of Nigeria</h3>
                        <p>This is for Teachers' Licensed web Application <strong>made for  &nbsp</strong>TRCN Staffs.</p>
                    </div>
                </div>
                <img src="img/video_fix.png" alt="" class="header-video--media" data-video-src="video/vid" data-teaser-source="video/vid" data-provider="" data-video-width="1920" data-video-height="960">
            </section>
            <!-- /header-video -->

            <!--/grid_home -->


            <!--/call_section-->
        </main>
        <!-- /main -->

        <footer>
            <div class="container margin_120_95">


                <div class="row">
                    <div class="col-md-8">
                        <ul id="additional_links">
                            <li><a href="#0">Terms and conditions</a></li>
                            <li><a href="#0">Privacy</a></li>
                        </ul>
                    </div>
                    <div class="col-md-4">
                        <div id="copy">© <%=DateTime .UtcNow .Year  %> Teachers' Registration Council of Nigeria</div>
                    </div>
                </div>
            </div>
        </footer>
        <!--/footer-->
        <div class="chat-screen">
            <div class="chat-header">
                <div class="chat-header-title">
                    Let’s chat? - We're online
                </div>
                <div class="chat-header-option hide">
                    <span class="dropdown custom-dropdown">
                        <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLink1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-more-horizontal">
                                <circle cx="12" cy="12" r="1"></circle><circle cx="19" cy="12" r="1"></circle><circle cx="5" cy="12" r="1"></circle></svg>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuLink1" style="will-change: transform;">
                            <a class="dropdown-item" href="javascript:void(0);">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="#bc32ef" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-file-text">
                                    <path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"></path><polyline points="14 2 14 8 20 8"></polyline><line x1="16" y1="13" x2="8" y2="13"></line><line x1="16" y1="17" x2="8" y2="17"></line><polyline points="10 9 9 9 8 9"></polyline></svg>
                                Send Transcriptions
                            </a>
                            <a class="dropdown-item end-chat" href="javascript:void(0);">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="#bc32ef" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-power">
                                    <path d="M18.36 6.64a9 9 0 1 1-12.73 0"></path><line x1="12" y1="2" x2="12" y2="12"></line></svg>
                                End Chat
                            </a>
                        </div>
                    </span>
                </div>
            </div>
            <div class="chat-mail">
                <div class="chat-body pre-scrollable" style="outline: outset">
                    <div class="chat-bubble you"><%=ChatWelcome %></div>
                </div>


                <div class="chat-input ">
                    <input type="text" id="data" placeholder="Type a message..." />
                    <div class="input-action-icon">
                        <button type="button" id="send-btn" class="btn btn-success btn-flat">
                            Send
                  <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-send">
                      <line x1="22" y1="2" x2="11" y2="13"></line><polygon points="22 2 15 22 11 13 2 9 22 2"></polygon></svg>

                        </button>

                    </div>
                </div>

            </div>

        </div>
        <div class="chat-bot-icon">
            <img src="img/we-are-here.svg" />
            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-message-square animate">
                <path d="M21 15a2 2 0 0 1-2 2H7l-4 4V5a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2z"></path></svg>
            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-x ">
                <line x1="18" y1="6" x2="6" y2="18"></line><line x1="6" y1="6" x2="18" y2="18"></line></svg>
        </div>
        <!-- Search Menu -->

        <!-- COMMON SCRIPTS -->
        <script src="js/jquery-2.2.4.min.js"></script>
        <script src="js/common_scripts.js"></script>
        <script src="js/main.js"></script>
        <script src="assets/validate.js"></script>

        <!-- SPECIFIC SCRIPTS -->
        <script src="js/video_header.js"></script>
        <script>
            HeaderVideo.init({
                container: $('.header-video'),
                header: $('.header-video--media'),
                videoTrigger: $("#video-trigger"),
                autoPlayVideo: true
            });
        </script>


        <script>
            $(document).ready(function () {
                //Toggle fullscreen
                $(".chat-bot-icon").click(function (e) {
                    $(this).children('img').toggleClass('hide');
                    $(this).children('svg').toggleClass('animate');
                    $('.chat-screen').toggleClass('show-chat');
                });
                //$('.chat-mail button').click(function () {
                //    $('.chat-mail').addClass('hide');
                //    $('.chat-body').removeClass('hide');
                //    $('.chat-input').removeClass('hide');
                //    $('.chat-header-option').removeClass('hide');
                //});
                //$('.end-chat').click(function () {
                //    $('.chat-body').addClass('hide');
                //    $('.chat-input').addClass('hide');
                //    $('.chat-session-end').removeClass('hide');
                //    $('.chat-header-option').addClass('hide');
                //});
            });

        </script>
        <script>
            $(document).ready(function () {

                $("#send-btn").on("click", function () {
                    ShowTestMessage();

                }
                );
            });
            $("#data").keyup(function (event) {
                if (event.keyCode === 13) {

                    $("#send-btn").click();
                    $("#data").val('');
                }
            });
            function ShowTestMessage() {
                $value = $("#data").val();
                $msg = '<div class="chat-bubble me">' + $value + '</div>';
                var recognition = new webkitSpeechRecognition();
                recognition.continuous = true;
                //recognition.interimResults = true;

                $(".chat-body ").append($msg);
                $("#data").val('');
                var obj = {};
                obj.text = $value;
                $.ajax({
                    url: "Chat.asmx/IntelligentBotChat",

                    type: "POST",
                    data: JSON.stringify(obj),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess

                });
            }
            function OnSuccess(response) {
                $Value = document.getElementById("divData").innerHTML = response.d;
                $replay = '<div class="chat-bubble you">' + $Value + '</div>';
                $(".chat-body").append($replay);
                let speaknow = new SpeechSynthesisUtterance($replay);
                window.speechSynthesis.speak(speaknow);
                //// when chat goes down the scroll bar automatically comes to the bottom
                $(".pre-scrollable").scrollTop($(".pre-scrollable")[0].scrollHeight);
                //$('#divData').hide();
            }
        </script>



    </form>
</body>
</html>
