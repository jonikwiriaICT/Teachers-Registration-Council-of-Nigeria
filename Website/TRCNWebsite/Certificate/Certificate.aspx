<%@ Page Title="" Language="C#" MasterPageFile="~/TrcnMaster.master" AutoEventWireup="true" CodeFile="Certificate.aspx.cs" Inherits="Certificate_Certificate" ValidateRequest ="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row breadcrumbs-top">
        <div class="breadcrumb-wrapper col-12">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="task">dashboard</a>
                </li>
                <li class="breadcrumb-item active">Certificate
                </li>
            </ol>
        </div>
    </div>
    <div class="row">
        <div class="col-xl-3 col-lg-6 col-12">
            <asp:LinkButton ID="lnkNotPrintedCertificate" runat="server" OnClick="reportClicked">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="info">
                                        &nbsp
                                    </h3>
                                    <h6 class="text-white">Not Printed Certificate</h6>
                                </div>
                                <div>
                                    <i class=" fa fa-certificate fa-5x text-white  float-right"></i>
                                </div>
                            </div>
                            <div class="progress progress-sm mt-1 mb-0 box-shadow-2">
                                <div class="progress-bar bg-white" role="progressbar" style="width: 100%" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:LinkButton>
        </div>
        <div class="col-xl-3 col-lg-6 col-12">
            <asp:LinkButton ID="lnkPrintedCertificate" runat="server" OnClick="reportClicked">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="info">
                                        &nbsp
                                    </h3>
                                    <h6 class="text-white">All Printed Certificate</h6>
                                </div>
                                <div>
                                    <i class=" fa fa-certificate fa-5x text-white  float-right"></i>
                                </div>
                            </div>
                            <div class="progress progress-sm mt-1 mb-0 box-shadow-2">
                                <div class="progress-bar bg-white" role="progressbar" style="width: 100%" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:LinkButton>
        </div>
    </div>

</asp:Content>


