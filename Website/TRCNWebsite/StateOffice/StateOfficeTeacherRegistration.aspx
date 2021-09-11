<%@ Page Title="" Language="C#" MasterPageFile="~/TrcnMaster.master" AutoEventWireup="true" CodeFile="StateOfficeTeacherRegistration.aspx.cs" Inherits="StateOffice_StateOfficeTeacherRegistration" ValidateRequest ="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="teacherRegistrationInformation" runat="server">
        <div class="row breadcrumbs-top">
            <div class="breadcrumb-wrapper col-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="#">State Office</a>
                    </li>

                    <li class="breadcrumb-item active">Teachers' Registration
                    </li>
                </ol>
            </div>
        </div>
        <asp:Panel ID="LICENSED" runat="server">
            <asp:HiddenField ID="rec_id___" runat="server" />
            <asp:HiddenField ID="registration_no___" runat="server" />
            <asp:HiddenField ID="fullname" runat="server" />
            <asp:HiddenField ID="licensed_bank_name_" runat="server" />
            <asp:HiddenField ID="licensed_paid_" runat="server" />
            <asp:HiddenField ID="licensed_date_paid" runat="server" />
            <asp:HiddenField ID="licensed_expiring_date" runat="server" />
            <asp:HiddenField ID="annual_expiring_date" runat="server" />
            <asp:HiddenField ID="annual_due_amount_" runat="server" />
            <asp:HiddenField ID="annual_bank_name_" runat="server" />
            <asp:HiddenField ID="annual_bank_teller" runat="server" />
            <asp:HiddenField ID="annual_paid_date_" runat="server" />
            <asp:HiddenField ID="licensed_status" runat="server" />
            <asp:HiddenField ID="licensed_number" runat="server" />
            <asp:HiddenField ID="category_" runat="server" />
            <asp:HiddenField ID="phone_no_" runat="server" />
            <asp:HiddenField ID="email_" runat="server" />
            <asp:HiddenField ID="state_id_" runat="server" />
            <asp:HiddenField ID="school_type_" runat="server" />
            <asp:HiddenField ID="pqe_number_" runat="server" />
            <asp:HiddenField ID="nin_no_" runat="server" />
        </asp:Panel>
        <%-- licensed --%>
        <div class=" card" style="font-size: 11px">
            <div class="card-header">
                <h4 class="card-title"><i class=" la la-user "></i>&nbsp Teacher Registration</h4>
                <a class="heading-elements-toggle"><i class="la la-ellipsis-h font-medium-3"></i></a>

                <div class="heading-elements">
                    <ul class="list-inline mb-0">
                        <asp:Label ID="lblCheck" Visible="false" runat="server"></asp:Label>
                        <button type="button" class="btn btn-success text-white  dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Action
                        </button>
                        <li>
                            <div class="dropdown-menu arrow" x-placement="bottom-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 40px, 0px);">

                                <asp:LinkButton ID="lnkExportToWord" runat="server" OnClick="mavigateToKnew" CssClass="dropdown-item"><i class="la la-plus"></i>&nbsp Add New Record</asp:LinkButton>
                                <div class="dropdown-divider" id="div" runat="server" visible="true"></div>
                                <asp:LinkButton ID="lnkExportToPdf" Visible="true" runat="server" OnClick="ExportToExcel_Click" CssClass="dropdown-item"><i class=" la la-print"></i>&nbsp Export To Excel</asp:LinkButton>
                                <div class="dropdown-divider"></div>
                                <asp:LinkButton ID="LinkButton4" Visible="true" runat="server" OnClick="downloadExcelTemplate" CssClass="dropdown-item"><i class=" la la-download"></i>&nbsp Download Template</asp:LinkButton>
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
                <div class="row">
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
                                <asp:GridView ID="gvList" runat="server" Font-Size="10px" AllowPaging="true" PageSize="1000" OnPageIndexChanging="ABIACHANGING"
                                    CssClass="table table-striped table-bordered dataex-res-configuration " AutoGenerateColumns="true" AllowCustomPaging="false"
                                    OnSelectedIndexChanged="ABIACHANGED" OnRowDeleting="ABIADELETE"
                                    EmptyDataText="There is no record for the selected item">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="7%" Visible="false" HeaderStyle-CssClass=" thead-default" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
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
        <div class="modal animated shake" id="modalDelete" tabindex="-1">
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
                    <li class="breadcrumb-item"><a href="LicensedDocument">Documentation</a>
                    </li>
                    <li class="breadcrumb-item"><a href="LicensedRegistration">Teacher Registration</a>
                    </li>
                    <li class="breadcrumb-item active">Teacher Profile
                    </li>
                </ol>
            </div>
        </div>
        <div class=" card">
            <div class="card-header">
                <h4 class="card-title"><i class=" la la-user "></i>&nbsp Teacher Profile</h4>
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
            <div class=" card-body">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:HiddenField ID="rec_id" runat="server" />
                    <asp:HiddenField ID="pic_filename" runat="server" />
                    <asp:HiddenField ID="teacher_signature" runat="server" />
                    <div class="container" style="font-size: 10px">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div style="font-size: 10px">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <h2 class="text-danger ">My full profile details</h2>
                                            <p>

                                                <img id="imgTeacherPhoto" runat="server" class=" user__img teacherPhoto" style="height: 12em; width: 15em" />

                                            </p>
                                            <p>
                                                <asp:FileUpload ID="FileUpload2" CssClass="btn btn-success btn-sm hec-button border-success" Style="width: 25%; height: 25%" runat="server" />

                                            </p>

                                        </div>
                                        <div class="col-md-6">

                                            <h2 class="text-danger ">Teacher's Signature</h2>
                                            <div class="row">
                                                <img id="img1" runat="server" class=" user__img teacherSignature pull-right" style="height: 12em; width: 15em" />

                                            </div>
                                            <p></p>
                                            <div class="row text-right">

                                                <asp:FileUpload ID="FileUploadSignature" CssClass="btn btn-success btn-sm hec-button border-success pull-right" Style="width: 25%; height: 25%" runat="server" />

                                            </div>

                                        </div>
                                    </div>
                                    <div class="cmp-tb-hd bcs-hd">
                                        <h2 class="text-danger ">BIO DATA</h2>

                                    </div>
                                    <hr />
                                    <div class="row">

                                        <div class="col-md-3">
                                            <h5>Title</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="title" runat="server" CssClass=" form-control  ">
                                                <asp:ListItem Value="Mr">Mr</asp:ListItem>
                                                <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                                <asp:ListItem Value="Miss">Miss</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>First Name</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="firstname" runat="server" placeholder="firstname" CssClass="form-control "></asp:TextBox>

                                        </div>

                                    </div>
                                    <asp:HiddenField ID="registration_date" runat="server" />
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Middle Name</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="middlename" runat="server" placeholder="Middlename" CssClass="form-control "></asp:TextBox>

                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Last Name</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="surname" runat="server" placeholder="Last Name" CssClass="form-control "></asp:TextBox>

                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Gender</h5>
                                        </div>
                                        <asp:HiddenField ID="sex" runat="server" />
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="sexs" runat="server" CssClass=" form-control   ">
                                                <asp:ListItem Value="MALE">MALE</asp:ListItem>
                                                <asp:ListItem Value="FEMALE">FEMALE</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Date of Birth</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="dob" runat="server" CssClass="form-control dates" placeholder="yyyy/mm/dd"></asp:TextBox>

                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Marital Status</h5>
                                        </div>

                                        <div class="col-md-7">
                                            <asp:DropDownList ID="marital_status" runat="server" CssClass=" form-control ">
                                                <asp:ListItem Value="SINGLE">SINGLE</asp:ListItem>
                                                <asp:ListItem Value="MARRIED">MARRIED</asp:ListItem>

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
                                    <asp:HiddenField ID="nationality" runat="server" />
                                    <div class="row">

                                        <div class="col-md-3">
                                            <h5>Nationality</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="nationalityS" runat="server" CssClass="form-control">
                                            </asp:DropDownList>

                                        </div>

                                    </div>

                                    <div class="row">
                                        <asp:HiddenField ID="state_of_origin" runat="server" />
                                        <asp:HiddenField ID="lga_origin" runat="server" />
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
                                                    <asp:DropDownList ID="ddlLga0fOrigin" runat="server" CssClass="  form-control     "></asp:DropDownList>




                                                    <asp:LinkButton ID="LinkButton1" Visible="false" OnClick="getLgaByStateofOrigin" CssClass="btn btn-sm btn-primary " runat="server"><i class="fa fa-search text-white "></i>&nbsp Get LGA</asp:LinkButton>

                                                </div>
                                            </div>

                                        </ContentTemplate>

                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <p></p>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-element-list mg-t-30">
                                    <div class="cmp-tb-hd">
                                        <h2 class="text-danger ">QUALIFICATION</h2>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class=" col-md-3">
                                            <h5>Qualifications</h5>
                                        </div>
                                        <div class=" col-md-7">
                                            <asp:TextBox ID="education_level" runat="server" CssClass="form-control   " placeholder="Education Level"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row" runat="server" visible="false">

                                        <div class="col-md-3">
                                            <h5>Highest Qualification(s)</h5>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:CheckBox ID="chknce" runat="server" Text="NCE" />
                                        </div>
                                        <div class="col-md-1">
                                            <asp:CheckBox ID="chkbed" runat="server" Text="B.ED" />
                                        </div>
                                        <div class="col-md-1">
                                            <asp:CheckBox ID="chkmed" runat="server" Text="M.ED" />
                                        </div>

                                        <div class="col-md-1">
                                            <asp:CheckBox ID="chkpede" runat="server" Text="PEDE" />
                                        </div>
                                        <div class="col-md-1">
                                            <asp:CheckBox ID="chkpde" runat="server" Text="PDE" />
                                        </div>
                                        <div class="col-md-1">
                                            <asp:CheckBox ID="chkpdde" runat="server" Text="PDDE" />
                                        </div>
                                        <div class="col-md-1">
                                            <asp:CheckBox ID="chkPHD" runat="server" Text="P.HD" />
                                        </div>

                                    </div>
                                    <asp:HiddenField ID="teacher_names" runat="server" />
                                    <div class="row">
                                        <div class=" col-md-3">
                                            <h5>Institution Attended</h5>
                                        </div>
                                        <div class=" col-md-7">
                                            <asp:TextBox ID="institution_attended" runat="server" CssClass="form-control   " placeholder="Institution Attended"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class=" col-md-3">
                                            <h5>Year Obtained</h5>
                                        </div>
                                        <div class=" col-md-7">
                                            <asp:TextBox ID="year_obtained" runat="server" CssClass="form-control decimal  " placeholder="Year Obtained"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Area of discipline</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="area_of_discipline" runat="server" CssClass="form-control " placeholder="Area of Discipline"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Years of Experience</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="years_of_Experience" runat="server" CssClass="form-control decimal " placeholder="Years of experience"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class=" col-md-3">
                                            <h5>Do you have educational Qualification?</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="any_qualification_in_education" runat="server" CssClass=" form-control  ">
                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="row" runat="server" visible="true">
                                        <div class="col-lg-12">
                                            <asp:LinkButton ID="lnkAddOtherQualification" CssClass="btn btn-sm btn-outline-success box-shadow-2  round btn-min-width pull-left " runat="server" data-toggle="modal" data-target="#myModalfour"><i class="fa fa-institution text-white " ></i>&nbsp Add Other Qualification</asp:LinkButton>
                                        </div>
                                    </div>
                                    <p></p>
                                    <div class="row" runat="server" visible="true">
                                        <div class="col-lg-12" style="overflow: auto">


                                            <asp:GridView ID="gvQualification" runat="server" Font-Size="10px"
                                                CssClass="table table-striped table-bordered dataex-res-configuration" AutoGenerateColumns="true"
                                                OnSelectedIndexChanged="gvList_SelectedIndexChanged" OnRowDeleting="gvList_OnRowDeleting"
                                                EmptyDataText="There is previous Qualification Record for the selected item">

                                                <Columns>

                                                    <asp:TemplateField HeaderStyle-Width="7%" HeaderStyle-CssClass=" thead-default" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbDelete" runat="server" Font-Size="14px"
                                                                CausesValidation="False" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>'>
                                                    <i class=" la la-trash-o text-danger" ></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbSelect" runat="server"
                                                                CausesValidation="False" CommandName="Select" CommandArgument='<%# Container.DataItemIndex %>'>
                                                            <i class=" la la-edit text-info"></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-element-list mg-t-30">
                                    <div class="cmp-tb-hd">
                                        <h2 class="text-danger ">TRCN LICENSED REGISTRATION</h2>

                                    </div>
                                    <hr />
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="lnkGetID" EventName="Click" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class=" col-md-3">
                                                    <h5>State</h5>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlStateID_" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="changeLga" CssClass=" form-control  ">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="lnkGetID" Visible="false" OnClick="changeLga" Enabled="false" runat="server" CssClass="btn btn-sm btn-primary"><i class="fa fa-search text-white "></i>&nbsp Get ID</asp:LinkButton>

                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class=" col-md-3">
                                                    <h5>L.G.A. School Location</h5>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlLga_" runat="server" CssClass=" form-control  ">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <h5>Level</h5>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="school_types" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="getQueryIdentity">
                                                        <asp:ListItem Value="PRIMARY">PRIMARY</asp:ListItem>
                                                        <asp:ListItem Value="SECONDARY">SECONDARY</asp:ListItem>
                                                        <asp:ListItem Value="TERTIARY">TERTIARY</asp:ListItem>
                                                        <asp:ListItem Value="OTHERS">OTHERS</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <h5>TRCN Registration No.</h5>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="registration_nos" Enabled="false" runat="server" CssClass="form-control " placeholder="Registration Number"></asp:TextBox>

                                                </div>
                                            </div>


                                        </ContentTemplate>

                                    </asp:UpdatePanel>
                                    <asp:HiddenField ID="school_type" runat="server" />
                                    <asp:HiddenField ID="registration_no" runat="server" />

                                    <asp:HiddenField ID="state_id" runat="server" />
                                    <asp:HiddenField ID="lga_id" runat="server" />
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>PQE Number</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="pqe_number" runat="server" CssClass="form-control " placeholder="PQE Number"></asp:TextBox>

                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Form Number</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="form_no" runat="server" CssClass="form-control " placeholder="Form Number"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>License Amount</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="licensed_paid" runat="server" CssClass="form-control " placeholder="Licensed Paid"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Date of Licensed Payment</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="licensed_date" runat="server" CssClass="form-control " placeholder="yyyy/mm/dd"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Licensed Bank Name</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="licensed_bank_name" runat="server" CssClass="form-control " placeholder="Licensed Bank Name"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Licensed RRR Number</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="licensed_bank_teller" runat="server" CssClass="form-control " placeholder="Licensed Bank Teller Number"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Annual Due Amount</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="annual_due_amount" runat="server" CssClass="form-control " placeholder="Annual Due Amount"></asp:TextBox>

                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Annual Due Bank Name</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="annual_bank_name" runat="server" CssClass="form-control " placeholder="Annual Due Bank Name"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Annual RRR Number</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="annual_bank_teller_" runat="server" CssClass="form-control " placeholder="Annual Due Bank Teller Number"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Annual Due Date Paid</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="annual_paid_date" runat="server" CssClass="form-control " placeholder="yyyy/mm/dd"></asp:TextBox>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Category</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="category" runat="server" CssClass="form-control " placeholder="Category"></asp:TextBox>

                                        </div>
                                    </div>


                                    <%--                                <div class="row">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="nk-int-mk">
                                            <h5>RRR Number</h5>
                                        </div>
                                        <div class="form-group ic-cmp-int">
                                            <div class="form-ic-cmp">
                                            </div>
                                            <div class="nk-int-st">
                                               
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="nk-int-mk">
                                            <h5>Category</h5>
                                        </div>
                                        <div class="form-group ic-cmp-int">
                                            <div class="form-ic-cmp">
                                            </div>
                                            <div class="nk-int-st">
                                                <asp:TextBox ID="category" runat="server" CssClass="form-control " placeholder="License Type/Category"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                 <%--   <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="nk-int-mk">
                                            <h5>License Due Payment</h5>
                                        </div>
                                        <div class="form-group ic-cmp-int">
                                            <div class="form-ic-cmp">
                                            </div>
                                            <div class="nk-int-st">
                                                <asp:TextBox ID="amount_paid" runat="server" CssClass="form-control decimal" placeholder="Currency"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="nk-int-mk">
                                            <h5>Date Paid</h5>
                                        </div>
                                        <div class="form-group ic-cmp-int">
                                            <div class="form-ic-cmp">
                                            </div>
                                            <div class="nk-int-st">

                                                <asp:TextBox ID="date_paid" runat="server" CssClass="form-control " data-mask="99/99/9999" placeholder="dd/mm/yyyy"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>--%>


                                    <%--     <div class="row">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="nk-int-mk">
                                            <h5>Bank Teller</h5>
                                        </div>
                                        <div class="form-group ic-cmp-int">
                                            <div class="form-ic-cmp">
                                            </div>
                                            <div class="nk-int-st">

                                                <asp:TextBox ID="bank_teller" runat="server" CssClass="form-control " placeholder="Bank Teller"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="nk-int-mk">
                                            <h5>Bank Name</h5>
                                        </div>
                                        <div class="form-group ic-cmp-int">
                                            <div class="form-ic-cmp">
                                            </div>
                                            <div class="nk-int-st">

                                                <asp:TextBox ID="bank_name" runat="server" CssClass="form-control " placeholder="Bank Teller"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-element-list mg-t-30">
                                    <div class="cmp-tb-hd">
                                        <h2 class="text-danger ">CURRENT WORK DETAILS</h2>

                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class=" col-md-3">
                                            <h5>Current School</h5>
                                        </div>
                                        <div class=" col-md-7">
                                            <asp:TextBox ID="school_one" runat="server" CssClass="form-control " placeholder="Current work Place"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class=" col-md-3">
                                            <h5>Employment Date</h5>
                                        </div>
                                        <div class=" col-md-7">
                                            <asp:TextBox ID="employment_date" runat="server" CssClass="form-control " placeholder="yyyy/mm/dd"></asp:TextBox>

                                        </div>
                                    </div>
                                    <asp:HiddenField ID="registration_status" runat="server" />
                                    <asp:HiddenField ID="printing_status" runat="server" />
                                    <asp:HiddenField ID="licensed_expiring_date_" runat="server" />
                                    <asp:HiddenField ID="annual_expiring_date_" runat="server" />
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Are you an Admin Staff?</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="are_you_an_admin_staff" runat="server" CssClass=" form-control ">
                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Current Employer</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="current_employer" CssClass="form-control " placeholder="Current Employer" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>When did your teaching career start?</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="application_date" runat="server" CssClass="form-control " data-mask="99/99/9999" placeholder="yyyy/mm/dd"></asp:TextBox>

                                        </div>
                                    </div>


                                    <div class="row" runat="server" visible="true">
                                        <div class="col-lg-12">
                                            <asp:LinkButton ID="lnkAddOtherWorkExperience" CssClass="btn btn-sm btn-outline-success box-shadow-2  round btn-min-width pull-left  " runat="server" data-toggle="modal" data-target="#modalSchool"><i class="fa fa-book text-white "></i>&nbsp Add Other Work Experience</asp:LinkButton>
                                        </div>
                                    </div>
                                    <p></p>
                                    <div class="row" runat="server" visible="true">
                                        <div class="col-lg-12" style="overflow: auto">


                                            <asp:GridView ID="gvSchool" runat="server" Font-Size="10px"
                                                CssClass="table table-striped table-bordered dataex-res-configuration" AutoGenerateColumns="true"
                                                OnSelectedIndexChanged="gvSchool_SelectedIndexChanged" OnRowDeleting="gvSchool_OnRowDeleting"
                                                EmptyDataText="There is no Qualification Record for the selected item">

                                                <Columns>

                                                    <asp:TemplateField HeaderStyle-Width="7%" HeaderStyle-CssClass=" thead-default" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbDelete" runat="server" Font-Size="14px"
                                                                CausesValidation="False" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>'>
                                                    <i class=" la la-trash-o text-danger" ></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbSelect" runat="server"
                                                                CausesValidation="False" CommandName="Select" CommandArgument='<%# Container.DataItemIndex %>'>
                                                            <i class=" la la-edit text-info"></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-element-list mg-t-30">
                                    <div class="cmp-tb-hd">
                                        <h2 class="text-danger ">CONTACT DETAILS</h2>

                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Mobile Number</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="phone_no" data-mask="(999) 9999-9999" placeholder="Phone Number" runat="server" CssClass="form-control decimal "></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row" runat="server" visible="false">
                                        <div class="col-md-3">
                                            <h5>Mobile Number 2</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="phone_no2" data-mask="(999) 9999-9999" placeholder="Phone Number" runat="server" CssClass="form-control decimal"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Email</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="email" placeholder="Email" runat="server" CssClass="form-control "></asp:TextBox>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-3">
                                            <h5>Office Address</h5>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="address" placeholder="Address" runat="server" CssClass="form-control "></asp:TextBox>

                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>

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
                                                    <asp:LinkButton ID="lnkSave" runat="server" OnClick="saveChanges" CssClass="btn btn-sm btn-success pull-right white GetFile  "><i class="fa fa-floppy-o "></i>&nbsp Save Changes</asp:LinkButton>
                                                    <asp:LinkButton ID="lnkUpdate" runat="server" OnClick="Update" CssClass="btn btn-sm btn-success pull-right white GetFile  "><i class="fa fa-floppy-o "></i>&nbsp Update Changes</asp:LinkButton>
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
                        <button type="button" class="btn btn-danger" runat="server" onserverclick="ifCaution" data-dismiss="modal"><i class="fa fa-user-secret"></i>&nbsp Yes I want to Continue</button>
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
                        <button type="button" class="btn btn-danger" runat="server" onserverclick="deleteQualification"><i class="fa fa-trash-o ">&nbsp Delete Record</i></button>
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
                        <button type="button" class="btn btn-danger" runat="server" onserverclick="deleteSchool"><i class="fa fa-trash-o ">&nbsp Delete Record</i></button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <%-- Modal add QualificATION --%>
        <div class="modal animated slideInLeft text-left" id="myModalfour" role="dialog" tabindex="-1" aria-labelledby="myModalfour" aria-hidden="true">
            <div class="modal-dialog modals-default modal-lg ">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">

                        <asp:Panel ID="pnlQualification" runat="server">
                            <asp:HiddenField ID="rec_id_" runat="server" />
                            <asp:HiddenField ID="registration_no_" runat="server" />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="nk-int-mk">
                                        <h6>Highest Qualification(s)</h6>
                                    </div>
                                    <div class="bootstrap-select fm-cmp-mg" runat="server">
                                        <asp:TextBox ID="qualification" runat="server" CssClass="form-control"></asp:TextBox>

                                        <div class="input-group " runat="server" visible="false">
                                            <asp:DropDownList ID="qualifications" runat="server" CssClass=" form-control  ">
                                                <asp:ListItem Value="NCE">NCE</asp:ListItem>
                                                <asp:ListItem Value="M.ED">M.ED</asp:ListItem>
                                                <asp:ListItem Value="B.ED">B.ED</asp:ListItem>
                                                <asp:ListItem Value="PEDE">PEDE</asp:ListItem>
                                                <asp:ListItem Value="PDE">PDE</asp:ListItem>
                                                <asp:ListItem Value="PDDE">PDDE</asp:ListItem>


                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="nk-int-mk">
                                        <h6>Year Obtained</h6>
                                    </div>
                                    <div class="form-group ic-cmp-int">
                                        <div class="form-ic-cmp">
                                        </div>
                                        <div class="nk-int-st">
                                            <asp:TextBox ID="year_obtained_" runat="server" CssClass="form-control decimal " placeholder="Year obtained"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="nk-int-mk">
                                        <h5>Area of Specialization</h5>
                                    </div>
                                    <div class="form-group ic-cmp-int">
                                        <div class="form-ic-cmp">
                                        </div>
                                        <div class="nk-int-st">
                                            <asp:TextBox ID="area_of_specialisation" runat="server" CssClass="form-control " placeholder="Area of Discipline"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="nk-int-mk">
                                        <h5>Have Any Educational Qualification?</h5>
                                    </div>
                                    <div class="bootstrap-select fm-cmp-mg">

                                        <div class="input-group ">
                                            <asp:DropDownList ID="have_any_educational_qualification" runat="server" CssClass=" form-control  ">
                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                    </div>
                    <p></p>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" runat="server" onserverclick="saveQualification"><i class="fa fa-floppy-o "></i>&nbsp  Save changes</button>
                        <button type="button" class="btn btn-danger  " data-dismiss="modal"><i class="fa fa-close "></i>&nbsp Close</button>
                    </div>
                </div>
            </div>
        </div>
        <%-- modal Add Experience --%>
        <div class="modal animated slideInLeft text-left" id="modalSchool" role="dialog">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body" style="font-size: 10px">

                        <h6>Add Work experience</h6>
                        <hr />
                        <asp:Panel ID="pnlSchool" runat="server">
                            <asp:HiddenField ID="rec_id__" runat="server" />
                            <asp:HiddenField ID="registration_no__" runat="server" />


                            <div class="row">
                                <div class="col-md-5">
                                    <label>School Name</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="school" placeholder="Name of Previous School" runat="server" CssClass="form-control "></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-5">
                                    <label>School Location</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="state_location" runat="server" CssClass=" form-control" placeholder="School Location"></asp:TextBox>
                                </div>
                                <div class="col-md-7" runat="server" visible="false">
                                    <div class=" input-group ">
                                        <asp:DropDownList ID="ddlStateLocation" AutoPostBack="true" OnSelectedIndexChanged="getLgaLocation" CssClass=" form-control " runat="server"></asp:DropDownList>
                                        <asp:LinkButton ID="lnkGetLgaLocation" Visible="false" OnClick="getLgaLocation" runat="server">LinkButton</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class=" col-md-5">
                                    <label>L.G.A. Location</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="lga_location" runat="server" CssClass="form-control" placeholder="L.G.A. Location"></asp:TextBox>
                                </div>
                                <div class="col-md-7" runat="server" visible="false">
                                    <asp:DropDownList ID="ddllgaLocation" CssClass=" form-control " runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-5">
                                    <label>When did you start teaching in Sch.?</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="when_did_your_teaching_career_start" data-mask="99/99/9999" placeholder="yyyy/mm/dd" runat="server" CssClass="form-control "></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-5">
                                    <label>When did you leave the school?</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="when_did_you_leave_the_school" data-mask="99/99/9999" placeholder="yyyy/mm/dd" runat="server" CssClass="form-control  "></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-5">
                                    <label>Reason for leaving</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="reasons_for_leaving" placeholder="Explain your reason for leaving" Rows="3" TextMode="MultiLine" runat="server" CssClass="form-control "></asp:TextBox>

                                </div>
                            </div>
                        </asp:Panel>


                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" runat="server" onserverclick="savePreviousSchool" data-dismiss="modal"><i class="fa fa-floppy-o text-white"></i>&nbsp Save Changes</button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-close text-white"></i>&nbsp Close</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal animated slideInLeft text-left" id="modalInternational" role="dialog">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body" style="font-size: 10px">

                        <h6>Add International Details</h6>
                        <hr />
                        <asp:Panel ID="Panel2" runat="server">

                            <div class="row">
                                <div class="col-md-5">
                                    <label>Country</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtCountry" placeholder="Enter Country" runat="server" CssClass="form-control "></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-5">
                                    <label>State</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtState" runat="server" CssClass=" form-control" placeholder="Enter State"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row">
                                <div class=" col-md-5">
                                    <label>City</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtlga" runat="server" CssClass="form-control" placeholder="Enter City"></asp:TextBox>
                                </div>

                            </div>
                        </asp:Panel>


                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-success" runat="server" data-dismiss="modal"><i class="fa fa-floppy-o text-white"></i>&nbsp Save Changes</button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-close text-white"></i>&nbsp Close</button>
                    </div>
                </div>
            </div>
        </div>

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
    <script type="text/javascript">
        $(document).on('change', '#<%= FileUploadSignature.ClientID%>', function (e) {
            var tmpTeacher = URL.createObjectURL(e.target.files[0]);
            $(".teacherSignature").attr('src', tmpTeacher);

        });

    </script>
    <script>
        $(document).load(function () {
            alert("window load occurred!");
        });

    </script>

    <script>
        function deleteRecord() {
            $('#modalDelete').modal('show')
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


