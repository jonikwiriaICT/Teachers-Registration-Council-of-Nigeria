<%@ Page Title="" Language="C#" MasterPageFile="~/TrcnMaster.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Administrator" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row" runat="server">
        <div class="col-xl-3 col-lg-6 col-12">
            <asp:LinkButton ID="lnkRegistration" runat="server" OnClick="reportClicked">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="info">
                                       &nbsp
                                    </h3>
                                    <h6 class ="text-white">Teacher Registration</h6>
                                </div>
                                <div>
                                    <i class=" fa fa-user text-white fa-5x   float-right"></i>
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
            <asp:LinkButton ID="lnkDocAccountNotVerified" runat="server" OnClick="reportClicked">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="info">
                                       &nbsp
                                    </h3>
                                    <h6 class ="text-white">Teacher Not Verified</h6>
                                </div>
                                <div>
                                    <i class=" fa fa-pencil fa-5x text-white  float-right"></i>
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
            <asp:LinkButton ID="lnkDocAccountVerified" runat="server" OnClick="reportClicked">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="info">
                                       &nbsp
                                    </h3>
                                    <h6 class ="text-white ">Teacher Verified Log</h6>
                                </div>
                                <div>
                                    <i class=" fa fa-pencil-square-o fa-5x text-white  float-right"></i>
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
            <asp:LinkButton ID="lnkSearchResult" runat="server" OnClick="reportClicked">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="info">
                                      &nbsp
                                    </h3>
                                    <h6 class="text-white">Result Upload</h6>
                                </div>
                                <div>
                                    <i class=" fa fa-user-secret fa-5x text-white  float-right"></i>
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
    <div class="row" runat="server">
        <div class="col-xl-3 col-lg-6 col-12">
            <asp:LinkButton ID="lnkNotVerifiedTeacher" runat="server" OnClick="reportClicked">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success ">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="info">
                                       
                                    </h3>
                                    <h6 class="text-white">Not Verified Teachers</h6>
                                </div>
                                <div>
                                    <i class=" fa fa-newspaper-o fa-5x text-white  float-right"></i>
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
            <asp:LinkButton ID="lnkVerifiedTeachers" runat="server" OnClick="reportClicked">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="info">
                                       &nbsp
                                    </h3>
                                    <h6 class="text-white">Verified Teachers</h6>
                                </div>
                                <div>
                                    <i class=" fa fa-credit-card fa-5x text-white  float-right"></i>
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
            <asp:LinkButton ID="lnkNotPrintedCertificate" runat="server" OnClick="reportClicked">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="info">
                                       &nbsp
                                    </h3>
                                    <h6 class="text-white ">Not Printed Certificate</h6>
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
                              
                                    </h3>
                                    <h6 class="text-white ">All Printed Certificate</h6>
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
    <div class="row">
        <div class="col-xl-3 col-lg-6 col-12">
            <asp:LinkButton ID="lnkUsermanagement" runat="server" OnClick="reportClicked">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="info">
                                       &nbsp
                                    </h3>
                                    <h6 class="text-white">User Management</h6>
                                </div>
                                <div>
                                    <i class=" fa fa-users fa-5x text-white  float-right"></i>
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
            <asp:LinkButton ID="lnkAuditTrailManagementSystem" runat="server" OnClick="reportClicked">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success ">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="info">
                                      &nbsp
                                    </h3>
                                    <h6 class="text-white">Audit Trail Management</h6>
                                </div>
                                <div>
                                    <i class=" fa fa-home fa-5x text-white  float-right"></i>
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
            <asp:LinkButton ID="lnkReport" runat="server" OnClick="reportClicked">
            <div class="card pull-up">
            <div class="card-content">
                <div class="card-body bg-success">
                    <div class="media d-flex">
                        <div class="media-body text-left">
                            <h3 class="text-white">TRCN</h3>
                            <h6 class="text-white">Reports</h6>
                        </div>
                        <div>
                            <i class=" fa fa-line-chart  fa-5x text-white  float-right"></i>
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
         <div class="col-xl-3 col-lg-6 col-12" runat="server">
            <asp:LinkButton ID="lnkRequestFormNotAttendedTo" runat="server" OnClick="reportClicked">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success ">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="text-white">
                                 
                                    </h3>
                                    <h6 class="text-white ">Complain Form not attended to</h6>
                                </div>
                                <div>
                                    <i class=" fa fa-address-card-o fa-5x text-white  float-right"></i>
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
    <div class="row">

       
        <div class="col-xl-3 col-lg-6 col-12" runat="server">
            <asp:LinkButton ID="lnkAttendedRequestForm" OnClick="reportClicked" runat="server">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="info">
                                      
                                    </h3>
                                    <h6 class="text-white ">Complain Form attended to</h6>
                                </div>
                                <div>
                                    <i class="fa fa-address-book fa-5x text-white  float-right"></i>
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
        <div class="col-xl-3 col-lg-6 col-12" runat="server">
            <asp:LinkButton ID="lnkMCDPForm" OnClick="reportClicked" runat="server">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body bg-success ">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="text-white">
                     
                                    </h3>
                                    <h6 class="text-white ">MCDP Form</h6>
                                </div>
                                <div>
                                    <i class=" fa fa-user-plus fa-5x text-white  float-right"></i>
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


