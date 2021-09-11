<%@ Page Title="" Language="C#" MasterPageFile="~/TrcnMaster.master" AutoEventWireup="true" CodeFile="CertificateNotPrinted.aspx.cs" Inherits="Certificate_CertificateNotPrinted" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row breadcrumbs-top">
        <div class="breadcrumb-wrapper col-12">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="#">Certification</a>
                </li>
                <li class="breadcrumb-item"><a href="#">Not Printed Certificate</a>
                </li>
                <li class="breadcrumb-item active">Printed Certificates
                </li>
            </ol>
        </div>
    </div>
    <div class=" content-body">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title"><i class=" la la-certificate "></i>&nbsp  Printed Certificate</h4>
                <a class="heading-elements-toggle"><i class="la la-ellipsis-h font-medium-3"></i></a>

                <div class="heading-elements">
                    <ul class="list-inline mb-0">
                        <asp:Label ID="lblCheck" Visible="false" runat="server"></asp:Label>
                        <button type="button" class="btn btn-success text-white  dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Action
                        </button>
                        <li>
                            <div class="dropdown-menu arrow" x-placement="bottom-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 40px, 0px);">
                                <asp:LinkButton ID="lnkExportToWord" runat="server" OnClick="checkAll" CssClass="dropdown-item"><i class="la la-plus"></i>&nbsp Check All</asp:LinkButton>
                                <div class="dropdown-divider" id="div" runat="server" visible="true"></div>
                                <asp:LinkButton ID="lnkExportToPdf" Visible="true" runat="server" OnClick="ExportToExcel_Click" CssClass="dropdown-item"><i class=" la la-download"></i>&nbsp Export To Excel</asp:LinkButton>
                                <div class="dropdown-divider"></div>
                                <asp:LinkButton ID="lnkExportToExcel" runat="server" OnClick="chkVerified" CssClass="dropdown-item"><i class=" la la-floppy-o"></i>&nbsp Print Checked Rows</asp:LinkButton>

                            </div>
                        </li>
                        <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                        <%-- <li><a data-action="expand"><i class="ft-maximize"></i></a></li>--%>
                        <li><a data-action="close"><i class="ft-x"></i></a></li>
                    </ul>
                </div>
            </div>
            <div class="card-body" style="font-size: 11px">
                <div class="row">
                    <div class="col-md-1">
                        <label>State</label>
                    </div>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlStateID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="viewState" CssClass=" form-control  ">
                        </asp:DropDownList>

                    </div>
                    <div class="col-md-1">
                        <label>Teacher ID</label>
                    </div>
                    <div class="col-md-4">
                        <div class="input-group">

                            <div class="input-group-append ">
                                <asp:TextBox ID="teacherID" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:LinkButton ID="lnkSearchTeacherID" runat="server" CssClass=" btn btn-sm btn-success round white " OnClick="searchTeacher"><i class=" text-white   fa fa-search "></i>&nbsp </asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" runat="server" visible="false">
                    <div class="col-md-1">
                        <label>State</label>
                    </div>
                    <div class="col-md-4">
                        <div class="input-group">
                            <asp:DropDownList ID="ddlLga" runat="server" AutoPostBack="true" OnSelectedIndexChanged="viewState" Style="border-right: none; border-left: none; border-top: none" CssClass=" form-control  ">
                            </asp:DropDownList>
                        </div>
                    </div>


                </div>
                <div class="row" runat="server">
                </div>
                <div class="row">
                    <div class="col-md-1">
                        <label>Range</label>
                    </div>
                    <div class="col-md-4">
                        <div class="input-group">
                            <asp:TextBox ID="RangeFrom" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-md-1">
                        <label>To</label>
                    </div>
                    <div class="col-md-4">
                        <div class="input-group">
                            <div class=" input-group-append">

                                <asp:TextBox ID="RangeTo" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:LinkButton ID="lnkGetRange" CssClass="btn btn-sm btn-success white " OnClick=" viewByRange" runat="server"><i class="fa fa-search text-white"></i></asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-md-2">
                        &nbsp
                    </div>
                    <div class="col-md-8">
                        <div class="form-group">

                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Search Teacher</span>
                                </div>
                                <input type="text" class="form-control" placeholder="All Search" id="Search" runat="server" name="rateperhour" />
                                <div class="input-group-append">
                                    <button id="btnSearch" runat="server" onserverclick="intelligentQuery" class="btn btn-sm btn-success white"><i class="la la-search "></i></button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                        &nbsp
                    </div>
                </div>

                <div class=" form-element-list " style="overflow: auto">

                    <div class="form-body">
                        <asp:HiddenField ID="hdValue" runat="server" />


                        <div class=" table-responsive-sm" id="divContent" runat="server">
                            <asp:GridView ID="ABIA" runat="server" Font-Size="10px" AllowPaging="true" PageSize="100" OnPageIndexChanging="ABIACHANGING"
                                CssClass="table table-striped table-bordered dataex-res-configuration " AutoGenerateColumns="true"
                                OnSelectedIndexChanged="ABIACHANGED" OnRowDeleting="ABIADELETE"
                                EmptyDataText="There is no record for the selected item">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Width="7%" Visible="false" HeaderStyle-CssClass=" thead-default" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDelete" runat="server" Font-Size="14px" CssClass="btn btn-sm btn-danger"
                                                CausesValidation="False" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>'>
                                                    <i class=" fa fa-trash-o text-white" style="color:red"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Print Certificate" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSelect" Font-Size="14px" runat="server" CssClass="btn btn-sm btn-outline-success"
                                                CausesValidation="False" CommandName="Select" CommandArgument='<%# Container.DataItemIndex %>'>
                                                    <i class="fa fa-print " ></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="7%" Visible="true" HeaderText="Print checked certificate(s)" HeaderStyle-CssClass=" thead-default" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>

                                            <asp:CheckBox ID="CHKABIA" CssClass="text-white " runat="server" />

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>


                            <div class="row" runat="server" id="allbuttons">
                                <div class="col-xs-4 form-group">
                                    <label style="color: transparent">ubhfuhf</label>
                                </div>
                                <div class="col-xs-1 form-group">
                                    <asp:LinkButton ID="btnFirst" CssClass="btn btn-sm btn-default " OnClick="btnfirst_Click" runat="server"><i class="fa fa-first-order text-success "></i>&nbsp First</asp:LinkButton>
                                </div>
                                <div class="col-xs-1 form-group">
                                    <asp:LinkButton ID="btnNext" CssClass="btn btn-sm btn-default " OnClick="btnnext_Click" runat="server"><i class="fa fa-arrow-right text-success "></i>&nbsp Next</asp:LinkButton>
                                </div>
                                <div class="col-xs-1 form-group">
                                    <asp:LinkButton ID="btnPrevious" CssClass="btn btn-sm btn-default " OnClick="btnprevious_Click" runat="server"><i class="fa fa-arrow-left text-success "></i>&nbsp Previous</asp:LinkButton>
                                </div>
                                <div class="col-xs-1 form-group">
                                    <asp:LinkButton ID="btnLast" CssClass="btn btn-sm btn-default " OnClick="btnlast_Click" runat="server"><i class="fa fa-lastfm-square text-success "></i>&nbsp Last</asp:LinkButton>
                                </div>
                                <div class="col-xs-4 form-group">
                                    <label style="color: transparent">ubhfuhf</label>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>


    </div>
    <div class="modal animated shake" id="modalDelete" tabindex="-1">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header" style="padding-bottom: 10px">

                    <h5 class="modal-title pull-left"><i class="fa fa-user"></i>&nbsp Delete User </h5>
                    <asp:LinkButton ID="LinkButton73" class=" pull-right text-danger" data-dismiss="modal" runat="server"><i class="fa fa-close text-danger"></i></asp:LinkButton>

                </div>
                <div class="modal-body">

                    <div class="form-body">
                        <div class=" form-element-list">
                            <div class="row">
                                <div class="col-lg-12 ">
                                    <asp:Label ID="lblTransID" runat="server" Text=""></asp:Label>
                                </div>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col-lg-12 form-group">
                                <asp:LinkButton ID="lnkDeleteUser" OnClick="lbDeleteYes_Click" CssClass=" btn btn-sm btn-danger pull-right " runat="server"><i class="fa fa-trash-o text-white "></i>&nbsp Delete User</asp:LinkButton>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>

    <div tabindex="-1" class="modal animated shake" id="TeacherPrint" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header panel-default" style="padding-bottom: 10px; border-bottom: 1px solid #808080">
                    <h5 class="modal-title pull-left"><i class="fa  fa-user"></i>&nbsp Cerificates</h5>
                    <asp:LinkButton ID="LinkButton74" CssClass=" pull-right text-danger" data-dismiss="modal" runat="server"><i class="fa fa-close text-danger"></i></asp:LinkButton>

                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 form-group-sm">
                            <asp:LinkButton ID="lnkPrintRecord" CssClass=" pull-right text-success" runat="server"><i class="fa fa-print "></i>&nbsp Print Certificate</asp:LinkButton>

                        </div>
                    </div>
                    <hr />
                    <div id="divPreviewContent">
                        <asp:DataList ID="dtPrint" Style="width: 100%; border: none" BorderColor="white" runat="server" EnableTheming="False" RepeatColumns="1" BorderStyle="None" CellPadding="1" ForeColor="White" GridLines="Horizontal">
                            <ItemTemplate>
                                <div class="row" runat="server" style="margin-top: 135px; text-align: right">
                                    <asp:ImageButton ID="imgBarCode" runat="server" Style="margin-right: 110px" CssClass=" img-fluid" Height="80px" Width="80px" ImageUrl='<%#Eval("identity") %>' />
                                    <asp:Label ID="Label3" Visible="false" ForeColor="Black" Style="margin-left: 230px" runat="server" Text='<%#Eval("pqe_number") %>'></asp:Label>
                                </div>

                                <div class="row" style="margin-top: 235px; text-align: center">
                                    <font size="16px" style="font-family: Edwardian Script ITC; font-weight: bold">
                                        <asp:Label ID="lblTeacherName" Style="padding-top: 430px;" ForeColor="Black" runat="server" Text='<%#Eval("Names") %>'></asp:Label>
                                    </font>
                                </div>
                                <div class="row  text-center" style="margin-top: 85px; text-align: center">
                                    <b><font size="5">
                                        <asp:Label ID="lblRegistrationNumber" runat="server" ForeColor="Black" Text='<%#Eval("registration_nos")%>'></asp:Label>
                                    </font></b>
                                </div>
                                <div class="row" style="margin-top: 167px;">
                                    <div style="width: 100%">
                                        <table>
                                            <tr>
                                                <td style="float: left; margin-left: 210px">
                                                    <font size="5">
                                                        <asp:Label ID="lblDates" runat="server" Text='<%#:DateTime .Now.Day %>'></asp:Label>
                                                    </font>
                                                    <font size="5">
                                                        <asp:Label ID="lblDate" runat="server" ForeColor="Black" Text='<%#(DateTime.Now.Day % 10 == 1 && DateTime.Now.Day != 11) ? "st" : (DateTime.Now.Day % 10 == 2 && DateTime.Now.Day != 12) ? "nd" : (DateTime.Now.Day % 10 == 3 && DateTime.Now.Day != 13) ? "rd" : "th" %>'></asp:Label>
                                                    </font>
                                                </td>
                                                <td style="float: right; margin-left: 200px">
                                                    <font size="5">
                                                        <asp:Label ID="lblMonthYear" runat="server" ForeColor="Black" Text='<%#:DateTime.Now.ToString("MMMM") + " " + "," + DateTime .Now.Year  %>'></asp:Label>
                                                    </font>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                    </div>
                                </div>
                                <div style="margin-top: 36px; margin-left: 250px">
                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Text=""></asp:Label>
                                    <asp:Image ID="imgAdminSignaturess" runat="server" Width="180px" Height="50px" ImageUrl='<%#Eval("adminSignature") %>' />
                                </div>

                                <div style="page-break-before: always">
                                    <label style="color: transparent">sdfbhdbf</label>
                                </div>
                            </ItemTemplate>
                            <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal animated shake" id="modalDel" tabindex="-1">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header" style="padding-bottom: 10px">

                    <h5 class="modal-title pull-left"><i class="fa fa-certificate"></i>&nbsp Print Certificate </h5>
                    <asp:LinkButton ID="LinkButton75" class=" pull-right text-danger" data-dismiss="modal" runat="server"><i class="fa fa-close text-danger"></i></asp:LinkButton>

                </div>
                <div class="modal-body">
                    <div class=" form-element-list ">
                        <div class="form-body">
                            <div class="row text-sm text-left form-group">
                                <div class="col-lg-12 ">
                                    <asp:Label ID="Label2" runat="server" Text="Print Record"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 form-group">
                                    <asp:LinkButton ID="LinkButton76" OnClick="printByCheck" CssClass=" btn btn-sm btn-success pull-right btnPrint " runat="server"><i class=" fa fa-print  "></i>&nbsp Print Certificate</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>



    <script src="assets/Scripts/jquery-3.2.1.min.js"></script>
    <script>
        function showDelete() {
            $('#modalDelete').modal('show')
        }
    </script>
    <script>
        function modDelete() {
            $('#modalDel').modal('show')
        }
    </script>
    <%--<script>
        function printRecord() {
            var divToPrint = document.getElementById("dvPrintContent");
            newWin = window.open("");
            newWin.document.write(dvPrintContent.outerHTML);
            newWin.print();
            newWin.close();
        }
    </script>--%>

    <script type="text/javascript">
        $(function printRecord() {
            $(".btnPrint").click(function (event) {
                event.preventDefault();
                var contents = $("#divPreviewContent").html();
                var frame1 = $('<iframe />');
                frame1[0].name = "frame1";
                frame1.css({ "position": "absolute", "top": "-1000000px" });
                $("body").append(frame1);
                var frameDoc = frame1[0].contentWindow ? frame1[0].contentWindow : frame1[0].contentDocument.document ? frame1[0].contentDocument.document : frame1[0].contentDocument;
                frameDoc.document.open();
                //Create a new HTML document.
                frameDoc.document.write('<html><head><title></title>');
                frameDoc.document.write('</head><body>');
                //Append the external CSS file.
                frameDoc.document.write(' <link href="printCss.css" rel="stylesheet" />');
                //Append the DIV contents.
                frameDoc.document.write(contents);
                frameDoc.document.write('</body></html>');
                frameDoc.document.close();
                setTimeout(function () {
                    window.frames["frame1"].focus();
                    window.frames["frame1"].print();
                    frame1.remove();
                }, 500);
                //window.location.href = 'subdirectory/cash';
            });
        });
    </script>
</asp:Content>


