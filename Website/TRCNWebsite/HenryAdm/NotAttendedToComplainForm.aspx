<%@ Page Title="" Language="C#" MasterPageFile="~/TrcnMaster.master" AutoEventWireup="true" CodeFile="NotAttendedToComplainForm.aspx.cs" Inherits="HenryAdm_NotAttendedToComplainForm" ValidateRequest ="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="teacherRegistrationInformation" runat="server">
        <div class="row breadcrumbs-top">
            <div class="breadcrumb-wrapper col-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="Admin">Administrator</a>
                    </li>

                    <li class="breadcrumb-item active">Complain Form Not Attended To
                    </li>
                </ol>
            </div>
        </div>

        <div class=" card" style="font-size: 11px">
            <div class="card-header">
                <h4 class="card-title"><i class=" la la-user "></i>&nbsp Complain Form</h4>
                <a class="heading-elements-toggle"><i class="la la-ellipsis-h font-medium-3"></i></a>

                <div class="heading-elements">
                    <ul class="list-inline mb-0">
                        <asp:Label ID="lblCheck" Visible="false" runat="server"></asp:Label>
                        <button type="button" class="btn btn-success text-white  dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Action
                        </button>
                        <li>
                            <div class="dropdown-menu arrow" x-placement="bottom-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 40px, 0px);">

                                <asp:LinkButton ID="lnkExportToWord" Visible ="false"  runat="server" OnClick="mavigateToKnew" CssClass="dropdown-item"><i class="la la-plus"></i>&nbsp Add New Record</asp:LinkButton>
                                <div class="dropdown-divider" id="div" runat="server" visible="false"></div>
                                <asp:LinkButton ID="lnkExportToPdf" Visible="true" runat="server" OnClick="ExportToExcel_Click" CssClass="dropdown-item"><i class=" la la-print"></i>&nbsp Export To Excel</asp:LinkButton>
                                <div class="dropdown-divider"></div>
                                <asp:LinkButton ID="lnkCheck" runat="server" OnClick="checkAll" CssClass="dropdown-item"><i class=" la la-check"></i>&nbsp Check</asp:LinkButton>
                                <div class="dropdown-divider"></div>
                                <asp:LinkButton ID="lnkDeleteByRange" runat="server" OnClick="deleteCheckedRows" CssClass="dropdown-item"><i class=" la la-trash"></i>&nbsp Delete checked Rows</asp:LinkButton>
                                <div class="dropdown-divider"></div>
                                <asp:LinkButton ID="lnkDeleteAll" runat="server" OnClick="deleteAllRecords" CssClass="dropdown-item"><i class=" la la-trash-o"></i>&nbsp Delete All</asp:LinkButton>
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
                        <label>Training Centre</label>
                    </div>
                    <div class="col-md-4" runat="server" visible="false">
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
                <hr />
                <div class="row" runat="server" visible="false">
                    <div class="col-md-2">
                        &nbsp
                    </div>
                    <div class="col-md-8">
                        <div class="form-group">

                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <asp:DropDownList ID="ddlschoolType" CssClass="input-group-text" runat="server">
                                        <asp:ListItem Value="PRIMARY">PRIMARY</asp:ListItem>
                                        <asp:ListItem Value="SECONDARY">SECONDARY</asp:ListItem>
                                        <asp:ListItem Value="TERTIARY">TERTIARY</asp:ListItem>
                                        <asp:ListItem Value="OTHERS">OTHERS</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:FileUpload ID="FileUpload3" CssClass="form-control" runat="server" />
                                <div class="input-group-append">
                                    <button id="btnUpload" runat="server" onserverclick="offlineUpload" class="btn btn-sm btn-success white"><i class="la la-download "></i>&nbsp Upload Record</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                        &nbsp
                    </div>
                </div>
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
                                    <button id="btnSearch" runat="server" onserverclick="searchIntelligence" class="btn btn-sm btn-success white"><i class="la la-search "></i></button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                        &nbsp
                    </div>
                </div>
                <div class="container">
                    <asp:HiddenField ID="hdValue" runat="server" />
                    <div class="card">
                        <div class="card-body">
                            <div class="row" style="overflow: auto" runat="server" id="divContent">
                                <asp:Image ID="Image1" runat="server" />
                                <asp:GridView ID="gvList" runat="server" Font-Size="10px" AllowPaging="true" PageSize="100" OnPageIndexChanging="ABIACHANGING"
                                    CssClass="table table-striped table-bordered dataex-res-configuration " AutoGenerateColumns="true" AllowCustomPaging="false"
                                    OnSelectedIndexChanged="ABIACHANGED" OnRowDeleting="ABIADELETE"
                                    EmptyDataText="There is no record for the selected item">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="7%" HeaderStyle-CssClass=" thead-default" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="14px" CssClass="btn btn-sm btn-outline-danger"
                                                    CausesValidation="False" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>'>
                                                    <i class=" fa fa-trash-o " style="color:red"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="5%" HeaderText="" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton5" Font-Size="14px" runat="server" CssClass="btn btn-sm btn-outline-success"
                                                    CausesValidation="False" CommandName="Select" CommandArgument='<%# Container.DataItemIndex %>'>
                                                    <i class="fa fa-edit " ></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="7%" HeaderText=" Check Row(S) to Delete" HeaderStyle-CssClass=" thead-default" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>

                                                <asp:CheckBox ID="chkcheck" CssClass="text-white " runat="server" />


                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
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
        <div class="tab-pane fade" id="offlineUpload" role="tabpanel">
            <div class="row">
                <div class="col-lg-12 form-group-sm">
                    <asp:LinkButton ID="lnkExportFile" Font-Size="10px" CssClass="btn btn-success fa-pull-right " runat="server" OnClick="downloadExcelTemplate"><i class="fa fa-download text-white"></i>&nbsp Download Sample Offline Excel Template </asp:LinkButton>
                </div>
            </div>
            <br />
            <hr />
            <div class="row">
                <div class="col-sm-4 form-group">
                    <label>Upload Offline Record to state ID :</label>
                </div>
                <div class="col-lg-8 form-group">
                    <asp:DropDownList ID="ddlstate" runat="server" CssClass="select2"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="input-group">
                    <label>Upload Excel File</label>
                    <asp:FileUpload ID="FileUpload4" runat="server" Visible="true" CssClass="col-sm-8 noboder"></asp:FileUpload>
                    <div class="input-group-append">
                        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-success" runat="server" OnClick="offlineUpload" ToolTip="Upload New Records"><i class="fa fa-upload text-white"></i></asp:LinkButton>
                    </div>
                    <i class="form-group__bar"></i>
                </div>
            </div>
        </div>
        <div class="modal animated shake" id="modalDeletes" tabindex="-1">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header" style="padding-bottom: 10px">

                        <h5 class="modal-title pull-left"><i class="fa fa-user"></i>&nbsp Delete User </h5>
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
        <div class="modal animated shake" id="modalExport" tabindex="-1">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header" style="padding-bottom: 10px">

                        <h5 class="modal-title pull-left"><i class="fa fa-user"></i>&nbsp Import Data to Database </h5>
                        <asp:LinkButton ID="LinkButton7" class=" pull-right text-danger" data-dismiss="modal" runat="server"><i class="fa fa-close text-danger"></i></asp:LinkButton>

                    </div>
                    <div class="modal-body">

                        <div class="form-body">
                            <div class=" form-element-list">
                                <div class="row">
                                    <div class="col-lg-12 form-group-sm">
                                        <asp:LinkButton ID="LinkButton9" Font-Size="10px" CssClass="btn btn-success text-white fa-pull-right " runat="server" OnClick="downloadExcelTemplate"><i class="fa fa-download"></i>&nbsp Download Sample Offline Excel Template </asp:LinkButton>
                                    </div>
                                </div>
                                <br />
                                <hr />
                                <div class="row">
                                    <div class="col-md-3">
                                        <label>School Type</label>
                                    </div>
                                    <div class="col-md-9">
                                    </div>
                                </div>

                                <div class="row">
                                    <label style="font-size: 10px">Upload Excel File</label>
                                    <div class="input-group">

                                        <asp:FileUpload ID="FileUpload1" Style="font-size: 10px" runat="server" Visible="true" CssClass="col-sm-8 noboder"></asp:FileUpload>
                                        <div class="input-group-append">
                                            <asp:LinkButton ID="LinkButton10" CssClass="btn btn-success text-white" runat="server" OnClick="offlineUpload" ToolTip="Upload New Records"><i class="fa fa-upload text-white"></i></asp:LinkButton>
                                        </div>
                                        <i class="form-group__bar"></i>
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
    </div>
    <div id="TeacherForm" runat="server">
        <div class="row breadcrumbs-top">
            <div class="breadcrumb-wrapper col-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="administrator">Administrator</a>
                    </li>

                    <li class="breadcrumb-item active">Complain  Form
                    </li>
                </ol>
            </div>
        </div>
        <div class=" card">
            <div class="card-header">
                <h4 class="card-title"><i class=" la la-user "></i>&nbsp Complain Form Not Attendd To </h4>
                <a class="heading-elements-toggle"><i class="la la-ellipsis-h font-medium-3"></i></a>
                <div class="heading-elements">
                    <ul class="list-inline mb-0">
                        <asp:Label ID="Label1" Visible="false" runat="server"></asp:Label>
                        <button type="button" class="btn btn-success text-white  dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Action
                        </button>
                        <li>
                            <div class="dropdown-menu arrow" x-placement="bottom-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 40px, 0px);">

                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="goBacks" CssClass="dropdown-item"><i class=" la la-arrow-circle-left"></i>&nbsp Go Back</asp:LinkButton>

                            </div>
                        </li>
                        <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                        <%-- <li><a data-action="expand"><i class="ft-maximize"></i></a></li>--%>
                        <li><a data-action="close"><i class="ft-x"></i></a></li>
                    </ul>
                </div>
            </div>
            <div class=" card-body" style="font-size: 10px">
                <asp:Panel ID="pnlComplainform" runat="server">
                    <asp:HiddenField ID="hdRegName" runat="server" />
                    <asp:HiddenField ID="hdStateName" runat="server" />
                    <asp:HiddenField ID="rec_id" runat="server" />
                    <asp:HiddenField ID="passport_photo" runat="server" />
                    <asp:HiddenField ID="date_of_registration" runat="server" />
                    <asp:HiddenField ID="admin_attend" runat="server" />
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-element-list">
                                    <div class="basic-tb-hd">
                                        <h2 class="text-danger ">Passport Photograph</h2>
                                        <p>

                                            <img id="imgTeacherPhoto" runat="server" class=" user__img teacherPhoto" style="height: 12em; width: 15em" />

                                        </p>
                                        <p>
                                            <asp:FileUpload ID="FileUpload2" Visible ="false"  CssClass="btn btn-info btn-sm hec-button border-info" Style="width: 25%; height: 25%" runat="server" />

                                        </p>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Surname</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="surname" runat="server" placeholder="Surname" CssClass="form-control "></asp:TextBox>

                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Othernames</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="othernames" runat="server" placeholder="Othernames" CssClass="form-control "></asp:TextBox>

                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>TRCN Registration No.</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="registration_no" runat="server" placeholder="Registration Number" CssClass="form-control "></asp:TextBox>

                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>TRCN Form No.</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="form_no" runat="server" placeholder="Form Number" CssClass="form-control "></asp:TextBox>

                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Date of Birth</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="dob" runat="server" CssClass="form-control " data-mask="99/99/9999" placeholder="dd/mm/yyyy"></asp:TextBox>

                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Gender</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="sex" runat="server" CssClass=" form-control ">
                                                <asp:ListItem Value="MALE">MALE</asp:ListItem>
                                                <asp:ListItem Value="FEMALE">FEMALE</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <asp:HiddenField ID="state_of_origin" runat="server" />
                                        <asp:HiddenField ID="lga_id" runat="server" />
                                    </div>


                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="lnkGetLga" EventName="Click" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <h5>State of Origin</h5>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlStateofOrigin" AutoPostBack="true" OnSelectedIndexChanged="getLgaByStateofOrigin" runat="server" CssClass="  form-control     "></asp:DropDownList>
                                                    <asp:LinkButton ID="lnkGetLga" Visible="false" OnClick="getLgaByStateofOrigin" CssClass="btn btn-sm btn-primary " runat="server"><i class="fa fa-search text-white "></i>&nbsp Get LGA</asp:LinkButton>

                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <h5>L.G.A. of Origin</h5>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlLga0fOrigin"  runat="server" CssClass="  form-control     "></asp:DropDownList>




                                                    <asp:LinkButton ID="LinkButton1" Visible="false"  CssClass="btn btn-sm btn-primary " runat="server"><i class="fa fa-search text-white "></i>&nbsp Get LGA</asp:LinkButton>

                                                </div>
                                            </div>

                                        </ContentTemplate>

                                    </asp:UpdatePanel>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Nationality</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="nationality" runat="server" CssClass=" form-control  ">
                                                <asp:ListItem Value="Nigeria">Nigeria</asp:ListItem>


                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>NIN Number</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="nin_no" runat="server" CssClass="form-control" placeholder=" NIN Number"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Office Address</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="office_address" runat="server" CssClass="form-control" placeholder="Office Address"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Current Employer</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="current_employer" runat="server" CssClass="form-control" placeholder="Current Employer"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Institution Name</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="institution_name" runat="server" CssClass="form-control" placeholder="Institution Name"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Qualification</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="qualification" runat="server" CssClass="form-control" placeholder="Qualification"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Qualification Date from</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="qualification_date_from" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Qualification Date To</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="qualification_date_to" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Area of Specialisation</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="area_of_specialization" runat="server" CssClass="form-control" placeholder="Area of specialization"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Phone Number</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="phone_no" runat="server" CssClass="form-control decimal" placeholder="Telephone Number"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Nature of Complain with Evidence</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="nature_of_complain" runat="server" CssClass="form-control " Rows="3" TextMode="MultiLine" placeholder="Nature of Complain"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Evidence of Original Payment</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="input-group">
                                                <asp:TextBox ID="original_evidence_payment" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>

                                                <div class="input-append-group">
                                                    <asp:LinkButton ID="lnkOriginalEvidencePayment" OnClick="lnk_SettingsClicked" CssClass="btn btn-sm btn-outline-info" runat="server"><i class="fa fa-upload text-white"></i>&nbsp Download Original Evidence Payment</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Other Credentials</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="input-group">
                                                <asp:TextBox ID="other_credentials" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>

                                                <div class="input-append-group">
                                                    <asp:LinkButton ID="lnkOtherCredentials" OnClick="lnk_SettingsClicked" CssClass="btn btn-sm btn-outline-info" runat="server"><i class="fa fa-upload text-white"></i>&nbsp Download Other Credentials</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Official Complain Letter</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="input-group">

                                                <asp:TextBox ID="official_complain_letter" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>

                                                <div class="input-append-group">
                                                    <asp:LinkButton ID="lnkOfficialComplainLetter" OnClick="lnk_SettingsClicked" CssClass="btn btn-sm btn-outline-info" runat="server"><i class="fa fa-upload text-white"></i>&nbsp Download Official Complain Letter</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Signature</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="input-group">
                                                <asp:TextBox ID="signature" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>

                                                <div class="input-append-group">
                                                    <asp:LinkButton ID="lnkSignature" OnClick="lnk_SettingsClicked" CssClass="btn btn-sm btn-outline-info" runat="server"><i class="fa fa-upload text-white"></i>&nbsp Download Signature</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>

                                    </div>




                                </div>
                            </div>
                        </div>
                        <p></p>

                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-element-list mg-t-30">
                                    <br />
                                    <div class="row">
                                        <div class="col-md-3">
                                            &nbsp
                                        </div>

                                        <div class=" col-md-7">

                                            <div class="form-group ic-cmp-int">
                                                <div class="form-ic-cmp">
                                                </div>
                                                <div class="nk-int-st">
                                                    <asp:LinkButton ID="lnkSave" runat="server" OnClick="saveChanges" CssClass="btn btn-sm btn-info pull-right white  "><i class="fa fa-floppy-o "></i>&nbsp Save Changes (Attended To)</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            &nbsp
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>


                </asp:Panel>
            </div>
        </div>
        <script src="assets/Scripts/jquery-3.2.1.min.js"></script>
        <%--    <script src="https://code.highcharts.com/highcharts.js"></script> 
    <script src="https://code.highcharts.com/modules/exporting.js"></script>
    <script src="https://code.highcharts.com/modules/export-data.js"></script>--%>
        <script src="assets/highChart.js"></script>
        <script src="assets/exportData.js"></script>
        <script src="assets/exporting.js"></script>
        <script src="assets/jQuery3D.js"></script>

        <div class="modal animated slideInLeft text-left" id="modalCaution" role="dialog">
            <div class="modal-dialog modals-default nk-red">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <h2>Security Alert Notification</h2>
                        <p>You are about to change your Teaching Location. Changing your Location will result to total deletion of your previous records in your previous state and that will result to illegal disposal without the concept of the Administrator. It is advise not to edit your state under the TRCN Registration Menu except been authorized by the Administrator.</p>
                        <p>Do you want to Continue?</p>


                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" runat="server" data-dismiss="modal"><i class="fa fa-user-secret"></i>&nbsp Yes I want to Continue</button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <%-- modal Delete --%>
        <div class="modal animated slideInLeft text-left" id="modalDelete" role="dialog" tabindex="-1" aria-labelledby="myModalseven" aria-hidden="true">
            <div class="modal-dialog modals-default">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <h2><i class="fa fa fa-trash-o"></i>&nbsp Delete Record</h2>
                        <p>Are you sure that you want to delete this record?</p>
                        <p>
                            <asp:Label ID="lblQualification" runat="server" Text=""></asp:Label>
                        </p>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" runat="server"><i class="fa fa-trash-o ">&nbsp Delete Record</i></button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal animated slideInLeft text-left" id="modalDeleteSchool" role="dialog" tabindex="-1" aria-labelledby="myModalseven" aria-hidden="true">
            <div class="modal-dialog modals-default">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <h2><i class="fa fa fa-trash-o"></i>&nbsp Delete Record</h2>
                        <p>Are you sure that you want to delete this record?</p>
                        <p>
                            <asp:Label ID="lblSchoolRecord" runat="server" Text=""></asp:Label>
                        </p>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" runat="server"><i class="fa fa-trash-o ">&nbsp Delete Record</i></button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <%-- Modal add QualificATION --%>
    </div>
    <script src="../assets/Scripts/jquery-3.2.1.min.js"></script>
    <script>
        function showRegistration() {
            $('#modalRegistration').modal('show')
        }
    </script>
    <script>
        function exportData() {
            $('#modalExport').modal('show')
        }
    </script>

    <script>
        function showDelete() {
            $('#modalDelete').modal('show')
        }
    </script>
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
    <script type="text/javascript">
        $(document).on('change', '#<%= FileUpload2.ClientID%>', function (e) {
            var tmpTeacher = URL.createObjectURL(e.target.files[0]);
            $(".teacherPhoto").attr('src', tmpTeacher);

        });

    </script>
    <script>
        $(document).load(function () {
            alert("window load occurred!");
        });

    </script>

    <script>
        function deleteRecord() {
            $('#modalDeletes').modal('show')
        }
    </script>
    <script>
        function showInternational() {
            $('#modalInternational').modal('show')
        }
    </script>
    <script>
        function showCaution() {
            $('#modalCaution').modal('show')
        }
    </script>
    <script>
        function deleteSchoolRecord() {
            $('#modalDeleteSchool').modal('show')
        }
    </script>
    <script>
        function showQualification() {
            $('#myModalfour').modal('show')
        }
    </script>
    <script>
        function showSchool() {
            $('#modalSchool').modal('show')
        }
    </script>
</asp:Content>

