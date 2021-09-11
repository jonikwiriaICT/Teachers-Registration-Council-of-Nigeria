<%@ Page Title="" Language="C#" MasterPageFile="~/TrcnMaster.master" AutoEventWireup="true" CodeFile="TRCNReport.aspx.cs" Inherits="HenryAdm_TRCNReport" ValidateRequest ="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row breadcrumbs-top">
        <div class="breadcrumb-wrapper col-12">
            <ol class="breadcrumb">
               <li class="breadcrumb-item"><a href="Admin">Administrator</a>
                </li>
                <li class="breadcrumb-item active">Administrator Report
                </li>
            </ol>
        </div>
    </div>
    <div class="content-body">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title"><i class=" la la-line-chart "></i>&nbsp Report</h4>
                <a class="heading-elements-toggle"><i class="la la-ellipsis-h font-medium-3"></i></a>
                <div class="heading-elements">
                    <ul class="list-inline mb-0">
                        <li>
                            <asp:DropDownList ID="ddlStateID" CssClass="form-control btnLoadProject" runat="server"></asp:DropDownList></li>
                        <li>
                            <asp:DropDownList ID="ddlQuery"  AutoPostBack="true" OnSelectedIndexChanged="RefreshPage" CssClass="form-control text-sm-left btnLoadProject" runat="server">
                                <asp:ListItem Value="2"> All Teachers Report by State</asp:ListItem>
                                <asp:ListItem Value="3"> Verified Teachers Report by State</asp:ListItem>
                                <asp:ListItem Value="4"> Not verified Teachers Report by State</asp:ListItem>
                                <asp:ListItem Value="5">  Printed Certificate Report by State</asp:ListItem>
                                <asp:ListItem Value="6">  Not Printed Certificate Report by State</asp:ListItem>
                                <asp:ListItem Value="7">  Non Applied Licensed by State</asp:ListItem>
                                <asp:ListItem Value="8">   Applied Licensed by State</asp:ListItem>
                                <asp:ListItem Value="9">   Printed Licensed by State</asp:ListItem>
                                <asp:ListItem Value="school_type">  School Type Report by State</asp:ListItem>                     
                            </asp:DropDownList>
                        </li>
                        <li>
                            <button type="button" class="btn btn-success text-white  dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Action
                            </button>
                            <div class="dropdown-menu arrow" x-placement="bottom-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 40px, 0px);">
                               
                                <asp:LinkButton ID="lnkExportToWord" runat="server" CommandArgument="word" OnClick="ExportReport" CssClass="dropdown-item"><i class="la la-wordpress"></i>&nbsp Export To Word</asp:LinkButton>
                                <div class="dropdown-divider" id="div" runat="server"  ></div>
                                <asp:LinkButton ID="lnkExportToPdf"  runat="server" CommandArgument="pdf" OnClick="ExportReport" CssClass="dropdown-item"><i class=" la la-paperclip"></i>&nbsp Export To PDF</asp:LinkButton>
                                <div class="dropdown-divider"></div>
                                <asp:LinkButton ID="lnkExportToExcel" runat="server" CommandArgument="excel" OnClick="ExportReport" CssClass="dropdown-item"><i class="la la-floppy-o"></i>&nbsp Export To Excel</asp:LinkButton>
                            </div>
                        </li>
                        <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                        <%-- <li><a data-action="expand"><i class="ft-maximize"></i></a></li>--%>
                        <li><a data-action="close"><i class="ft-x"></i></a></li>
                    </ul>
                </div>
            </div>
            <hr />
            <div class="card-body">
                <div class="content-body">
                    <section class="row">
                        <div class="col-12">
                            <div class="card">

                                <div class="card-body row">
                                    <div class=" col-lg-12 form-group">
                                        <div id="divContent" runat="server" class="divContent">
                                            <div class="row">
                                                <div class="col-lg-1">
                                                    <img id="image1" runat="server" src="~/assets/images/trcn.png" style="width: 8em; height: 8em" />
                                                </div>
                                                <div class="col-lg-10">
                                                    <br />
                                                    &nbsp &nbsp   &nbsp &nbsp    &nbsp &nbsp
                                                    <asp:Label ID="lblReport" runat="server" CssClass="text-info" Font-Size="Large" Text="Teachers Registration Council of Nigeria"></asp:Label>

                                                </div>
                                            </div>


                                            <div class="col-lg-12" style="overflow: auto">
                                                <h2>
                                                    <asp:Label ID="lblReportTitle" runat="server" CssClass="text-bold-700 text-lg-left text-dark" ></asp:Label><br />
                                                    <asp:Label ID="lblDate" runat="server" CssClass="text-bold-700 text-lg-left text-dark" ></asp:Label><br />
                                                </h2>

                                                <br />
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <asp:GridView ID="gvQuery" runat="server" Font-Size="10px"
                                                            CssClass="table table-striped table-bordered " AutoGenerateColumns="true"
                                                            EmptyDataText="There is no record for the selected item">
                                                        </asp:GridView>
                                                         <div class="row">
                                                             <div class="col-md-6">
                                                                  <asp:GridView ID="gvTotal" runat="server" Font-Size="10px"
                                                            CssClass="table table-striped table-bordered " AutoGenerateColumns="true"
                                                            EmptyDataText="There is no record for the selected item">
                                                        </asp:GridView>
                                                             </div>
                                                         </div>
                                                     
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="card-body">
                                                         <div id="report" runat ="server" >
                                                                <div id="registerreport" style="height: 400px" ></div>
                                                         </div>
                                                            <div id="report1" runat ="server" >
                                                              <div id="certificatereport" style="height: 400px"  ></div>
                                                         </div>
                                                             <div id="report2" runat ="server" >
                                                              <div id="licensedreport"  style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
                                                            
                                                         </div>
                                                             <div id="report4" runat ="server" >
                                                                         <div id="schoolTypereport"  style="height: 400px"></div>
                                                         </div>
                                                              <div id="report3" runat ="server" >
                                                              <div id="categoryReport"   style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
                                                           
                                                         </div>
                                                             <div id="report5" runat ="server" >
                                                               <div id="genderreport"  style="height: 400px"></div>
                                                           
                                                         </div>
                                                             <div id="report6" runat ="server" >
                                                               <div id="resultReport"  style="height: 400px"></div>
                                                           
                                                         </div>
                                                           
                                                            
                                                            
                                                
                                                         
                                                        </div>
                                                    </div>
                                                </div>

                                                <hr />
                                                <asp:GridView ID="gvReports" runat="server" Font-Size="10px" AllowPaging ="true"  OnPageIndexChanging="gvReportPaging" PageSize="7"
                                                    CssClass="table table-striped table-bordered " AutoGenerateColumns="true"
                                                    EmptyDataText="There is no record for the selected item">
                                                </asp:GridView>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-1 col-md-1 col-sm-12">
                                    </div>
                                    <hr />

                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
            <div class=" card-body">
                <div class="row">
                </div>


            </div>
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
    <script >
        function printRecord() {
            var contents = $('.divContent').html();
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
            frameDoc.document.write('   <link rel="stylesheet" type="text/css" href="assets/vendors/css/tables/datatable/datatables.min.css">');
            //Append the DIV contents.
            frameDoc.document.write(contents);
            frameDoc.document.write('</body></html>');
            frameDoc.document.close();
            setTimeout(function () {
                window.frames["frame1"].focus();
                window.frames["frame1"].print();
                frame1.remove();
            

            }, 500);
         
         
        };
 
    </script>
    <script>
        function getChart(){
                       
            var stateID = $(".btnLoadProject").val();
            var jsonData = JSON.stringify({
                state: stateID,
            });           
            $.ajax({
                type: "POST",
                url: "trcnWebServices.asmx/getTeacherStatus",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessProjectYear,
                error: OnErrorProjectCost
            });
            $.ajax({
                type: "POST",
                url: "trcnWebServices.asmx/getCertificateStatus",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCertificate,
                error: OnErrorCertificate
            });
            $.ajax({
                type: "POST",
                url: "trcnWebServices.asmx/getLicensed",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onDisbursementSuccess_,
                error: OnErrorDisbursement_
            });          
            function OnSuccessProjectYear(reponse) {
                var sData = reponse.d;
                var sLabel = sData[0];
                var sDataSet = sData[1];
                var ints = sDataSet.map(parseFloat);
                Highcharts.chart('registerreport', {
                    chart: {
                        type: 'column',
                        options3d: {
                            enabled: true,
                            alpha: 15,
                            beta: 15,
                            viewDistance: 25,
                            depth: 40
                        }
                    },

                    title: {
                        text: 'Teachers Status'
                    },

                    xAxis: {
                        categories: sLabel,
                        labels: {
                            skew3d: true,
                            style: {
                                fontSize: '10px'
                            }
                        }
                    },

                    yAxis: {
                        allowDecimals: false,
                        min: 0,
                        title: {
                            text: ' Teachers Status',
                            skew3d: true
                        }
                    },

                    tooltip: {
                        headerFormat: '<b>{point.key}</b><br>',
                        pointFormat: '<span style="color:{series.color}">\u25CF</span> {series.name}: {point.y} / {point.stackTotal}'
                    },

                    plotOptions: {
                        column: {
                            stacking: 'normal',
                            depth: 40
                        }
                    },

                    series: [{
                        name: 'TRCN Teachers Status',
                        data: ints,
                        stack: 'TRCN Teachers Status'
                    }]
                });

            }
            function OnErrorProjectCost(repo) {
                alert(" something went wrong on Teacher Status report, please try later !");
            }
            function OnSuccessCertificate(reponse) {
                var sData = reponse.d;
                var sLabel = sData[0];
                var sDataSet = sData[1];
                var ints = sDataSet.map(parseFloat);
                Highcharts.chart('certificatereport', {
                    chart: {
                        type: 'column',
                        options3d: {
                            enabled: true,
                            alpha: 15,
                            beta: 15,
                            viewDistance: 25,
                            depth: 40
                        }
                    },

                    title: {
                        text: 'Teachers Certificate'
                    },

                    xAxis: {
                        categories: sLabel,
                        labels: {
                            skew3d: true,
                            style: {
                                fontSize: '10px'
                            }
                        }
                    },

                    yAxis: {
                        allowDecimals: false,
                        min: 0,
                        title: {
                            text: ' Teachers Certificate',
                            skew3d: true
                        }
                    },

                    tooltip: {
                        headerFormat: '<b>{point.key}</b><br>',
                        pointFormat: '<span style="color:{series.color}">\u25CF</span> {series.name}: {point.y} / {point.stackTotal}'
                    },

                    plotOptions: {
                        column: {
                            stacking: 'normal',
                            depth: 40
                        }
                    },

                    series: [{
                        name: 'TRCN Teachers Certificate',
                        data: ints,
                        stack: 'TRCN Teachers Certificate'
                    }]
                });

            }
            function OnErrorCertificate(repo) {
                alert(" something went wrong on Teacher Certificate report, please try later !");
            }
            function onDisbursementSuccess_(reponse) {
                var sData = reponse.d;
                var sLabel = sData[0];
                var sDataSet = sData[1];
                var ints = sDataSet.map(parseFloat);
                Highcharts.chart('licensedreport', {
                    chart: {
                        type: 'column',
                        options3d: {
                            enabled: true,
                            alpha: 15,
                            beta: 15,
                            viewDistance: 25,
                            depth: 40
                        }
                    },

                    title: {
                        text: 'Teachers Licensed'
                    },

                    xAxis: {
                        categories: sLabel,
                        labels: {
                            skew3d: true,
                            style: {
                                fontSize: '10px'
                            }
                        }
                    },

                    yAxis: {
                        allowDecimals: false,
                        min: 0,
                        title: {
                            text: 'Teachers Licensed',
                            skew3d: true
                        }
                    },

                    tooltip: {
                        headerFormat: '<b>{point.key}</b><br>',
                        pointFormat: '<span style="color:{series.color}">\u25CF</span> {series.name}: {point.y} / {point.stackTotal}'
                    },

                    plotOptions: {
                        column: {
                            stacking: 'normal',
                            depth: 40
                        }
                    },

                    series: [{
                        name: 'Teachers Licensed',
                        data: ints,
                        stack: 'Teachers Licensed'
                    } ]
                });
            }
            function OnErrorDisbursement_(repo) {
                alert(" something went wrong on Licensed Report, pls try later !");
            }
        }
    </script>
    <script>

        var subjects = <%=chartData%>;
        Highcharts.chart('schoolTypereport', {
            chart: {
                type: 'pie',
                options3d: {
                    enabled: true,
                    alpha: 45
                }
            },
            title: {
                text: 'School Type'
            },
            subtitle: {
                text: 'School Type Analysis'
            },
            plotOptions: {
                pie: {
                    innerSize: 100,
                    depth: 45
                }
            },
            series: [{
                name: 'School Type',
                data: subjects
            }]
        });
    </script>
    <script>
        var gender = <%=genderData%>;
        Highcharts.chart('genderreport', {
            chart: {
                type: 'pie',
                options3d: {
                    enabled: true,
                    alpha: 45,
                    beta: 0
                }
            },
            title: {
                text: 'Gender Analysis'
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    depth: 35,
                    dataLabels: {
                        enabled: true,
                        format: '{point.name}'
                    }
                }
            },
            series: [{
                type: 'pie',
                name: 'Gender Analysis',
                data: gender
            }]
        });
    </script>
    <script>
        var category = <%=categoryChart%>;
        Highcharts.chart('categoryReport', {
            chart: {
                type: 'pie',
                options3d: {
                    enabled: true,
                    alpha: 45,
                    beta: 0
                }
            },
            title: {
                text: 'Category Analysis'
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    depth: 35,
                    dataLabels: {
                        enabled: true,
                        format: '{point.name}'
                    }
                }
            },
            series: [{
                type: 'pie',
                name: 'Category Analysis',
                data: category
            }]
        });
    </script>
       <script>

           
       


           var results = <%=sChartResult%>;
           Highcharts.chart('resultstatus', {
            chart: {
                type: 'pie',
                options3d: {
                    enabled: true,
                    alpha: 45,
                    beta: 0
                }
            },
            title: {
                text: 'Result Status'
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    depth: 35,
                    dataLabels: {
                        enabled: true,
                        format: '{point.name}'
                    }
                }
            },
            series: [{
                type: 'pie',
                name: 'Result Status',
                data: results
            }]
        });
    </script>
    <script>
        $(document).ready(function () {
            
            
            function getAnalysis () {
                var stateID = $(".btnLoadProject").val();
                var jsonData = JSON.stringify({
                    state: stateID,
                });           
                $.ajax({
                    type: "POST",
                    url: "trcnWebServices.asmx/getTeacherStatus",
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessProjectYear,
                    error: OnErrorProjectCost
                });
                $.ajax({
                    type: "POST",
                    url: "trcnWebServices.asmx/getCertificateStatus",
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessCertificate,
                    error: OnErrorCertificate
                });
                $.ajax({
                    type: "POST",
                    url: "trcnWebServices.asmx/getLicensed",
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: onDisbursementSuccess_,
                    error: OnErrorDisbursement_
                });          
                function OnSuccessProjectYear(reponse) {
                    var sData = reponse.d;
                    var sLabel = sData[0];
                    var sDataSet = sData[1];
                    var ints = sDataSet.map(parseFloat);
                    Highcharts.chart('registerreport', {
                        chart: {
                            type: 'column',
                            options3d: {
                                enabled: true,
                                alpha: 15,
                                beta: 15,
                                viewDistance: 25,
                                depth: 40
                            }
                        },

                        title: {
                            text: 'Teachers Status'
                        },

                        xAxis: {
                            categories: sLabel,
                            labels: {
                                skew3d: true,
                                style: {
                                    fontSize: '10px'
                                }
                            }
                        },

                        yAxis: {
                            allowDecimals: false,
                            min: 0,
                            title: {
                                text: ' Teachers Status',
                                skew3d: true
                            }
                        },

                        tooltip: {
                            headerFormat: '<b>{point.key}</b><br>',
                            pointFormat: '<span style="color:{series.color}">\u25CF</span> {series.name}: {point.y} / {point.stackTotal}'
                        },

                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                depth: 40
                            }
                        },

                        series: [{
                            name: 'TRCN Teachers Status',
                            data: ints,
                            stack: 'TRCN Teachers Status'
                        }]
                    });

                }
                function OnErrorProjectCost(repo) {
                    alert(" something went wrong on Teacher Status report, please try later !");
                }
                function OnSuccessCertificate(reponse) {
                    var sData = reponse.d;
                    var sLabel = sData[0];
                    var sDataSet = sData[1];
                    var ints = sDataSet.map(parseFloat);
                    Highcharts.chart('certificatereport', {
                        chart: {
                            type: 'column',
                            options3d: {
                                enabled: true,
                                alpha: 15,
                                beta: 15,
                                viewDistance: 25,
                                depth: 40
                            }
                        },

                        title: {
                            text: 'Teachers Certificate'
                        },

                        xAxis: {
                            categories: sLabel,
                            labels: {
                                skew3d: true,
                                style: {
                                    fontSize: '10px'
                                }
                            }
                        },

                        yAxis: {
                            allowDecimals: false,
                            min: 0,
                            title: {
                                text: ' Teachers Certificate',
                                skew3d: true
                            }
                        },

                        tooltip: {
                            headerFormat: '<b>{point.key}</b><br>',
                            pointFormat: '<span style="color:{series.color}">\u25CF</span> {series.name}: {point.y} / {point.stackTotal}'
                        },

                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                depth: 40
                            }
                        },

                        series: [{
                            name: 'TRCN Teachers Certificate',
                            data: ints,
                            stack: 'TRCN Teachers Certificate'
                        }]
                    });

                }
                function OnErrorCertificate(repo) {
                    alert(" something went wrong on Teacher Certificate report, please try later !");
                }
                function onDisbursementSuccess_(reponse) {
                    var sData = reponse.d;
                    var sLabel = sData[0];
                    var sDataSet = sData[1];
                    var ints = sDataSet.map(parseFloat);
                    Highcharts.chart('licensedreport', {
                        chart: {
                            type: 'column',
                            options3d: {
                                enabled: true,
                                alpha: 15,
                                beta: 15,
                                viewDistance: 25,
                                depth: 40
                            }
                        },

                        title: {
                            text: 'Teachers Licensed'
                        },

                        xAxis: {
                            categories: sLabel,
                            labels: {
                                skew3d: true,
                                style: {
                                    fontSize: '10px'
                                }
                            }
                        },

                        yAxis: {
                            allowDecimals: false,
                            min: 0,
                            title: {
                                text: 'Teachers Licensed',
                                skew3d: true
                            }
                        },

                        tooltip: {
                            headerFormat: '<b>{point.key}</b><br>',
                            pointFormat: '<span style="color:{series.color}">\u25CF</span> {series.name}: {point.y} / {point.stackTotal}'
                        },

                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                depth: 40
                            }
                        },

                        series: [{
                            name: 'Teachers Licensed',
                            data: ints,
                            stack: 'Teachers Licensed'
                        } ]
                    });
                }
                function OnErrorDisbursement_(repo) {
                    alert(" something went wrong on Licensed Report, pls try later !");
                }
            }

           

        });
    </script>

</asp:Content>

