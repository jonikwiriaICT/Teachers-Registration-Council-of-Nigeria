<%@ Page Title="" Language="C#" MasterPageFile="~/TrcnMaster.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="HenryAdm_UserManagement" ValidateRequest ="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row breadcrumbs-top">
        <div class="breadcrumb-wrapper col-12">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="#">Administrator</a>
                </li>
                <li class="breadcrumb-item active">User management
                </li>
            </ol>
        </div>
    </div>
    <div class="content-body">
        <div class="card">
            <asp:HiddenField ID="hdValue" runat="server" />
            <div class="card-header">
                <h4 class="card-title"><i class=" la la-users "></i>&nbsp User Management</h4>
                <a class="heading-elements-toggle"><i class="la la-ellipsis-h font-medium-3"></i></a>

                <div class="heading-elements">
                    <ul class="list-inline mb-0">

                        <button type="button" class="btn btn-success text-white  dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Action
                        </button>
                        <li>
                            <div class="dropdown-menu arrow" x-placement="bottom-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 40px, 0px);">

                                <asp:LinkButton ID="lnkExportToWord" runat="server" OnClick="openNewTrcn" CssClass="dropdown-item"><i class="la la-plus"></i>&nbsp Add New User</asp:LinkButton>
                                <div class="dropdown-divider" id="div" runat="server" visible="true"></div>
                                <asp:LinkButton ID="lnkExportToPdf" Visible="true" runat="server" OnClick="ExportToExcel_Click" CssClass="dropdown-item"><i class=" la la-download"></i>&nbsp Export To Excel</asp:LinkButton>
                                <div class="dropdown-divider"></div>
                                <asp:LinkButton ID="lnkExportToExcel" runat="server" OnClick="checkDelete" CssClass="dropdown-item"><i class=" la la-trash-o"></i>&nbsp Delete Checked Rows</asp:LinkButton>

                            </div>
                        </li>
                        <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                        <%-- <li><a data-action="expand"><i class="ft-maximize"></i></a></li>--%>
                        <li><a data-action="close"><i class="ft-x"></i></a></li>
                    </ul>
                </div>
            </div>
            <hr />

            <div class=" card-body" style="overflow: auto">

                <asp:GridView ID="gvuserManagement" runat="server" Font-Size="10px" AllowPaging="true" PageSize="20" OnPageIndexChanging="ABIACHANGING"
                    CssClass="table table-striped table-bordered gv " AutoGenerateColumns="true"
                    OnSelectedIndexChanged="gvList_SelectedIndexChanged" OnRowDeleting="gvList_OnRowDeleting"
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
                        <asp:TemplateField HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbSelect" Font-Size="14px" runat="server" CssClass="btn btn-sm btn-outline-success"
                                    CausesValidation="False" CommandName="Select" CommandArgument='<%# Container.DataItemIndex %>'>
                                                    <i class="fa fa-edit " ></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="7%" HeaderText="Delete Row" HeaderStyle-CssClass=" thead-default" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                            <ItemTemplate>


                                <asp:CheckBox ID="chkDel" CssClass="text-white " runat="server" />


                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>

    <div class="modal animated shake" id="modalRegistration" tabindex="-1">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5><i class="fa fa-users"></i>&nbsp User Management</h5>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">



                    <asp:Panel ID="pnlUsermanagement" runat="server">
                        <asp:HiddenField ID="rec_id" runat="server" />
                        <asp:HiddenField ID="record_manager" runat="server" />
                        <asp:HiddenField ID="directorate" runat="server" />
                        <asp:HiddenField ID="administrator" runat="server" />
                        <asp:HiddenField ID="account" runat="server" />
                        <asp:HiddenField ID="account_head" runat="server" />
                        <asp:HiddenField ID="certification" runat="server" />
                        <asp:HiddenField ID="licensed" runat="server" />
                        <asp:HiddenField ID="state" runat="server" />
                        <div class="row">
                            <div class="col-md-2">
                                <label>Surname</label>
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="surname" runat="server" CssClass="form-control "></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <label>Othernames</label>
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="othernames" runat="server" CssClass="form-control "></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <label>Username</label>
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="username" runat="server" CssClass="form-control "></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <label>Password</label>
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control "></asp:TextBox>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <label>Email</label>
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="email" runat="server" CssClass="form-control "></asp:TextBox>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <label>State</label>
                            </div>
                            <div class="col-md-10">
                                <asp:DropDownList CssClass=" form-control" ID="state_id" runat="server"></asp:DropDownList>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2">
                                <label>User Role</label>
                            </div>
                            <div class="col-md-9">
                                <div class="accordion-area ">
                                    <div class="accordion-wn-wp">
                                        <div class="accordion-hd">
                                            <div class="accordion-stn sm-res-mg-t-30">
                                                <div class="panel-group" data-collapse-color="nk-red" id="accordionRedss" role="tablist" aria-multiselectable="true">
                                                    <div class="panel panel-collapse notika-accrodion-cus">
                                                        <div class="panel-heading" role="tab">
                                                            <h4 class="panel-title">
                                                                <a data-toggle="collapse" data-parent="#accordionRedss" href="#accordionRed-oness" aria-expanded="false">
                                                                    <i class=""></i>&nbsp Click on select
                                                                </a>
                                                            </h4>
                                                        </div>
                                                        <div id="accordionRed-oness" class="collapse" role="tabpanel">
                                                            <div class="panel-body">

                                                                <div class="row">
                                                                    <div class="col-sm-12 form-group">


                                                                        <label class="btn bg-light-blue text-sm">
                                                                            Record Manager
                                                                    <asp:RadioButton ID="recordmanager" GroupName="inlineRadioOptions" runat="server" /></label>
                                                                        <label class="btn bg-teal text-sm">Directorate<asp:RadioButton ID="chkDirectorate" GroupName="inlineRadioOptions" runat="server" /></label>
                                                                        <label class="btn bg-red text-sm">Administrator<asp:RadioButton ID="chkAdministrator" GroupName="inlineRadioOptions" runat="server" /></label>
                                                                        <label class="btn bg-purple text-sm">
                                                                            Account 
                                                                    <asp:RadioButton ID="chkAccount" GroupName="inlineRadioOptions" runat="server" /></label>
                                                                        <label class="btn bg-amber text-sm">Account Head<asp:RadioButton ID="chkAccountHead" GroupName="inlineRadioOptions" runat="server" /></label>
                                                                        <label class="btn bg-cyan text-sm">
                                                                            Certification
                                                                    <asp:RadioButton ID="chkCertification" GroupName="inlineRadioOptions" runat="server" /></label>
                                                                        <label class="btn bg-white text-sm">
                                                                            State Office
                                                                    <asp:RadioButton ID="chkStateOffice" GroupName="inlineRadioOptions" runat="server" /></label>
                                                                        <label class="btn bg-success text-sm">
                                                                            Licensed
                                                                    <asp:RadioButton ID="chkLicensed" GroupName="inlineRadioOptions" runat="server" /></label>

                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>


                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 form-group">
                                <asp:LinkButton ID="lnkSaveModal" OnClick="saveTrcn" CssClass=" btn btn-sm btn-success pull-right " runat="server"><i class="fa fa-floppy-o text-white "></i>&nbsp Save Changes</asp:LinkButton>
                            </div>
                        </div>



                    </asp:Panel>


                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
    <div class="modal animated shake" id="modalDelete" tabindex="-1">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header" style="padding-bottom: 10px">

                    <h5 class="modal-title pull-left"><i class="fa fa-user"></i>&nbsp Delete User </h5>
                    <asp:LinkButton ID="LinkButton2" class=" pull-right text-danger" data-dismiss="modal" runat="server"><i class="fa fa-close text-danger"></i></asp:LinkButton>

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

    <script src="assets/Scripts/jquery-3.2.1.min.js"></script>
    <script>
        function showDelete() {
            $('#modalDelete').modal('show')
        }
    </script>
    <script>
        function showTrcn() {
            $('#modalRegistration').modal('show')
        }
    </script>


</asp:Content>


