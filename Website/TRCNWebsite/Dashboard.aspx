<%@ Page Title="" Language="C#" MasterPageFile="~/TrcnMaster.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-body">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title"><i class=" la la-line-chart "></i>&nbsp Analysis</h4>
                <a class="heading-elements-toggle"><i class="la la-ellipsis-h font-medium-3"></i></a>
                <div class="heading-elements">
                    <ul class="list-inline mb-0">
                        <li>
                            <asp:DropDownList ID="ddlStateID" AutoPostBack="true" OnSelectedIndexChanged="RefreshPage" CssClass="form-control btnLoadProject" runat="server"></asp:DropDownList></li>
                        <li><a data-action="collapse"><i class="ft-minus"></i></a></li>
                        <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                        <%-- <li><a data-action="expand"><i class="ft-maximize"></i></a></li>--%>
                        <li><a data-action="close"><i class="ft-x"></i></a></li>
                    </ul>
                </div>
            </div>
            <hr />
            <div class=" card-body">
                <div class="row">

                    <div class="col-md-6">
                        <div class="card-body">
                            <div id="resultstatus" style="height: 400px"></div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="card-body">
                            <div id="resultExamType" style="height: 400px"></div>
                        </div>
                    </div>

                </div>

                <div class="row">

                    <div class="col-md-6">
                        <div class="card-body">
                            <div id="registerreport" style="height: 400px"></div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="card-body">
                            <div id="certificatereport" style="height: 400px"></div>
                        </div>
                    </div>

                </div>
                <div class="row">

                    <!-- Simple Pie Chart -->
                    <div class="col-md-6 col-sm-12">
                        <div class="card-body">
                            <div id="licensedreport" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
                        </div>
                    </div>
                    <div class="col-md-6" runat="server" visible="false">
                        <div class="card-body">
                            <div id="categoryReport" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="card-body">
                            <div id="schoolTypereport" style="height: 400px"></div>
                        </div>
                    </div>
                    <!-- Simple Doughnut Chart -->


                </div>
                <div class="row">

                    <div class="col-md-6" runat="server" visible="false">
                        <div class="card-body">
                            <div id="genderreport" style="height: 400px"></div>
                        </div>
                    </div>

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
    <script src="assets/jQuery3D.js"></script>
    <script>
        function getChart() {

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
                    }]
                });
            }
            function OnErrorDisbursement_(repo) {

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

        var resultsType = <%=sExamType%>;
        Highcharts.chart('resultExamType', {
            chart: {
                type: 'pie',
                options3d: {
                    enabled: true,
                    alpha: 45
                }
            },
            title: {
                text: 'Result Type'
            },
            subtitle: {
                text: 'Result Type Analysis'
            },
            plotOptions: {
                pie: {
                    innerSize: 100,
                    depth: 45
                }
            },
            series: [{
                name: 'Result Type',
                data: resultsType
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
        $(document).ready(function () {


            function getAnalysis() {
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
                        }]
                    });
                }
                function OnErrorDisbursement_(repo) {

                }
            }



        });
    </script>

</asp:Content>


