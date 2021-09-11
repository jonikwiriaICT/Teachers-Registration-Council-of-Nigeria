<%@ Page Title="" Language="C#" MasterPageFile="~/TrcnMaster.master" AutoEventWireup="true" CodeFile="AuditTrail.aspx.cs" Inherits="HenryAdm_AuditTrail" ValidateRequest ="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row breadcrumbs-top">
        <div class="breadcrumb-wrapper col-12">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Admin">Administrator</a>
                </li>
                <li class="breadcrumb-item active">Audit Trail Management
                </li>
            </ol>
        </div>
    </div>
    <div class="content-body">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title"><i class=" la la-home   "></i>&nbsp Audit Trail Management</h4>
                <a class="heading-elements-toggle"><i class="la la-ellipsis-h font-medium-3"></i></a>
                <div class="heading-elements">
                    <ul class="list-inline mb-0">

                        <li>
                            <button type="button" class="btn btn-success text-white  dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Action
                            </button>
                            <div class="dropdown-menu arrow" x-placement="bottom-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 40px, 0px);">

                                <asp:LinkButton ID="lnkExportToWord" runat="server" OnClick="ExportToExcel_Click" CssClass="dropdown-item"><i class="la la-wordpress"></i>&nbsp Export To Excel</asp:LinkButton>

                            </div>
                        </li>


                        <li><a data-action="collapse"><i class="ft-minus"></i></a></li>
                        <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                        <%-- <li><a data-action="expand"><i class="ft-maximize"></i></a></li>--%>
                        <li><a data-action="close"><i class="ft-x"></i></a></li>
                    </ul>
                </div>
            </div>
            <hr />
            <div class="card-body">
                <div class="container">
                    <div class=" form-element-list " style="overflow: auto">

                        <div class=" form-body ">
                        </div>
                    </div>


                </div>
                <div class="row" style="overflow: auto">

                    <asp:GridView ID="gvAudit" runat="server" Font-Size="10px" AllowPaging="true" PageSize="20" OnPageIndexChanging="ABIACHANGING"
                        CssClass="table table-striped table-bordered dataex-res-configuration " AutoGenerateColumns="true"
                        EmptyDataText="There is no record for the selected item">
                    </asp:GridView>

                </div>
            </div>

        </div>
    </div>



</asp:Content>



