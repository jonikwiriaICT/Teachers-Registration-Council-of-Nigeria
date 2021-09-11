<%@ Page Title="" Language="C#" MasterPageFile="~/TrcnMaster.master" AutoEventWireup="true" CodeFile="UploadResult.aspx.cs" Inherits="HenryAdm_UploadResult" ValidateRequest ="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row breadcrumbs-top">
        <div class="breadcrumb-wrapper col-12">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Admin">Administrator</a>
                </li>
                <li class="breadcrumb-item active">Upload Teacher Result
                    <asp:Label ID="lblCheck" runat="server" Visible="false"></asp:Label>
                </li>
            </ol>
        </div>
    </div>
    <div class=" card" style="font-size: 11px">
        <div class="card-header">
            <h4 class="card-title"><i class=" la la-anchor "></i>&nbsp Upload Teacher Result</h4>
            <a class="heading-elements-toggle"><i class="la la-ellipsis-h font-medium-3"></i></a>

            <div class="heading-elements">
                <ul class="list-inline mb-0">
                    <asp:Label ID="Label1" Visible="false" runat="server"></asp:Label>
                    <button type="button" class="btn btn-success text-white  dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Action
                    </button>
                    <li>
                        <div class="dropdown-menu arrow" x-placement="bottom-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 40px, 0px);">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="NewResult_Clicked" CssClass="dropdown-item"><i class=" la la-plus"></i>&nbsp Add Result</asp:LinkButton>
                            <div class="dropdown-divider" id="div1" runat="server" visible="true"></div>
                            <asp:LinkButton ID="LinkButton6" runat="server" OnClick="checkAll" CssClass="dropdown-item"><i class=" la la-check"></i>&nbsp Check All</asp:LinkButton>
                            <div class="dropdown-divider" id="div2" runat="server" visible="true"></div>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="downloadResultTemplate" CssClass="dropdown-item"><i class=" la la-download"></i>&nbsp Download Result Template</asp:LinkButton>
                            <div class="dropdown-divider" id="div" runat="server" visible="true"></div>
                            <asp:LinkButton ID="lnkExportToPdf" Visible="true" runat="server" OnClick="ExportToExcel_Click" CssClass="dropdown-item"><i class=" la la-upload"></i>&nbsp Export To Excel</asp:LinkButton>
                            <div class="dropdown-divider"></div>
                            <asp:LinkButton ID="lnkExportToExcel" runat="server" OnClick="InsertExcelRecords" CssClass="dropdown-item"><i class=" la la-floppy-o"></i>&nbsp Upload Result</asp:LinkButton>
                            <div class="dropdown-divider"></div>
                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="checkDelete" CssClass="dropdown-item"><i class=" la la-trash-o"></i>&nbsp Delete Checked Rows</asp:LinkButton>
                            <div class="dropdown-divider"></div>
                            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="Migration" CssClass="dropdown-item"><i class=" la la-bus"></i>&nbsp Migrate Pass Results' Records</asp:LinkButton>
                        </div>
                    </li>
                    <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                    <%-- <li><a data-action="expand"><i class="ft-maximize"></i></a></li>--%>
                    <li><a data-action="close"><i class="ft-x"></i></a></li>
                </ul>
            </div>
        </div>
        <div class=" card-body" style="overflow: auto">
            <div class="row">

                <div class="col-md-1" runat="server" visible="false">
                    <label>Category</label>
                </div>
                <div class="col-md-3" runat="server" visible="false">
                    <div class="input-group">
                        <div class="input-group-append ">
                            <asp:DropDownList ID="category" runat="server" AutoPostBack="true" CssClass=" form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                
                <div class="col-md-3">
                         <label>Exam Type</label>
                    <div class="input-group">

                        <div class="input-group-append ">
                            <asp:DropDownList ID="examType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="query" CssClass=" form-control  ">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                
                <div class="col-md-3">
                      <label>State</label>
                    <asp:DropDownList ID="ddlStateID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="query" CssClass=" form-control  ">
                    </asp:DropDownList>

                </div>
           
                <div class="col-md-3">
                     <label>Upload</label>
                    <div class="input-group">
                        <div class="input-group-append">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:LinkButton ID="lnkUpload" runat="server" OnClick="InsertExcelRecords" CssClass="btn btn-sm btn-success round white"><i class="la la-upload"></i></asp:LinkButton>
                        </div>
                    </div>

                </div>
            </div>
            <div class="row">
            </div>
            <div class="row" runat="server" visible="false">
                <div class="col-md-1">
                    <label>State</label>
                </div>
                <div class="col-md-4">
                    <div class="input-group">
                        <asp:DropDownList ID="ddlLga" runat="server" AutoPostBack="true" Style="border-right: none; border-left: none; border-top: none" CssClass=" form-control  ">
                        </asp:DropDownList>
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
                                <span class="input-group-text">Search</span>
                            </div>
                            <input type="text" class="form-control" placeholder="Search" id="Search" runat="server" name="rateperhour" />
                            <div class="input-group-append">
                                <button id="btnSearch" runat="server" onserverclick="intelligentSearch" class="btn btn-sm btn-success white"><i class="la la-search "></i></button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    &nbsp
                </div>
            </div>
            <div class="container">
                <div class=" form-element-list " style="overflow: auto">
                    <div class="form-body">
                        <asp:HiddenField ID="hdValue" runat="server" />

                        <div class="divContent" id="divContent" runat="server">
                            <asp:GridView ID="result" runat="server" Font-Size="10px"
                                CssClass="table table-striped table-bordered dataex-res-configuration " AutoGenerateColumns="true" AllowPaging="true" PageSize="1000" OnPageIndexChanging="gvResultChanging"
                                OnRowDeleting="gvResultDelete"
                                EmptyDataText="There is no record for the selected item">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Width="7%" HeaderStyle-CssClass=" thead-default" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDelete" runat="server" Font-Size="14px" CssClass="btn btn-sm btn-outline-danger"
                                                CausesValidation="False" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>'>
                                                    <i class=" fa fa-trash-o " style="color:red"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-Width="7%" HeaderText=" Checked Row(S)" HeaderStyle-CssClass=" thead-default" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>

                                            <asp:CheckBox ID="CHKANAMBRA" CssClass="text-white " runat="server" />

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </div>

                        <%--                        <div class="row" runat="server" id="allbuttons">
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
                        </div>--%>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div class="modal animated shake" id="modalDelete" tabindex="-1">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header" style="padding-bottom: 10px">

                    <h5 class="modal-title pull-left"><i class="fa fa-user"></i>&nbsp Delete </h5>
                    <asp:LinkButton ID="LinkButton5" class=" pull-right text-danger" data-dismiss="modal" runat="server"><i class="fa fa-close text-danger"></i></asp:LinkButton>

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


    <div class="modal animated slideInLeft text-left" id="modalSchool" role="dialog">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body" style="font-size: 10px">

                    <h6><i class="la la-floppy-o "></i>&nbsp  Add Result</h6>
                    <hr />
                    <asp:Panel ID="pnlResult" runat="server">
                        <asp:HiddenField ID="rec_id__" runat="server" />
                        <div class="row">
                            <div class="col-md-5">
                                <label>Teacher Names</label>
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="names" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-5">
                                <label>State</label>
                            </div>
                            <div class="col-md-7">
                                <asp:DropDownList ID="state_id" runat="server" CssClass=" form-control "></asp:DropDownList>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-5">
                                <label>PQE Number</label>
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="pqe_number" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-5">
                                <label>Category</label>
                            </div>
                            <div class="col-md-7">
                                <asp:DropDownList ID="category_" runat="server" CssClass=" form-control "></asp:DropDownList>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-5">
                                <label>Exam Type</label>
                            </div>
                            <div class="col-md-7">
                                <asp:DropDownList ID="exam_type" runat="server" CssClass=" form-control "></asp:DropDownList>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-5">
                                <label>Institution Name</label>
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="institution_name" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-5">
                                <label>NIN Number</label>
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="nin_no" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-5">
                                <label>Year</label>
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="year" runat="server" CssClass="form-control decimal"></asp:TextBox>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-5">
                                <label>Status</label>
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="statue" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-5">
                                <label>Gender</label>
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="gender" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>

                    </asp:Panel>


                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="lnkSaveButton" runat="server" OnClick="saveResultNew" CssClass="btn btn-sm btn-success round white"><i class="la la-floppy-o"></i>&nbsp Save Changes</asp:LinkButton>
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-close text-white"></i>&nbsp Close</button>
                </div>
            </div>
        </div>
    </div>

    <script src="../assets/Scripts/jquery-3.2.1.min.js"></script>
    <script>
        function isNumber(evt, element) {

            var charCode = (evt.which) ? evt.which : event.keyCode

            if (
                (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
                (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
                (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>

    <script>
        $('.decimal').keypress(function (event) {
            return isNumber(event, this)
        });
    </script>
    <script>
        function showDelete() {
            $('#modalDelete').modal('show')
        }
    </script>
    <script>
        function showTeacher() {
            $('#modalSchool').modal('show')
        }
    </script>
</asp:Content>


