<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AnaLysis.aspx.cs" Inherits="EmployeeProductivityManagement.AnaLysis" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <div class="row">
                <div class="col">
                    <p class="text-white mt-5 mb-5">IP Address : <b>
                       <asp:Label ID="lblIP" runat="server" Text=""></asp:Label> Date : <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                    </b></p>
                </div>
            </div>
            <!-- row -->
            <div class="row tm-content-row ">
                <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12 tm-block-col ">
                    <div class="tm-bg-primary-dark tm-block tm-block-h-auto">
                        <h2 class="tm-block-title"></h2>
                        <canvas id="barChart"></canvas>
                        <asp:Label ID="lblIdle" runat="server" Text="Label" style="display:none">
                        </asp:Label>
                        <asp:Label ID="lblRestrictedApps" runat="server" Text="Label" style="display:none">
                        </asp:Label>
                        <div class="mt-3">
                            <a href="Dashboard.aspx" class="btn btn-primary">Back</a>
                            <asp:Button ID="btnNotify" runat="server" Text="Notify" class="btn btn-info" 
                                onclick="btnNotify_Click" />
                          </div>
                    </div>
                </div>
            </div>
        </div>
         <script src="js/jquery-3.3.1.min.js"></script>
    <!-- https://jquery.com/download/ -->
    <script src="js/moment.min.js"></script>
    <!-- https://momentjs.com/ -->
    <script src="js/Chart.min.js"></script>
    <!-- http://www.chartjs.org/docs/latest/ -->
    <script src="js/bootstrap.min.js"></script>
    <!-- https://getbootstrap.com/ -->
    <script src="js/tooplate-scripts.js"></script>
    <script>
        Chart.defaults.global.defaultFontColor = 'white';
        var ctxLine,
            ctxBar,
            ctxPie,
            optionsLine,
            optionsBar,
            optionsPie,
            configLine,
            configBar,
            configPie,
            lineChart,
        barChart, pieChart;
        // DOM is ready
        $(function () {
            drawBarChart(); // Bar Chart
            drawPieChart(); // Pie Chart

            $(window).resize(function () {
                updateLineChart();
                updateBarChart();
            });
        })


        function drawBarChart() {
            var idle = parseInt($('#ContentPlaceHolder1_lblIdle').html());
            var restr = parseInt($('#ContentPlaceHolder1_lblRestrictedApps').html());
            if ($("#barChart").length) {
                ctxBar = document.getElementById("barChart").getContext("2d");

                optionsBar = {
                    responsive: true,
                    scales: {
                        yAxes: [{
                            barPercentage: 0.2,
                            ticks: {
                                beginAtZero: true
                            },
                            scaleLabel: {
                                display: true,
                                labelString: "Data in Seconds"
                            }
                        }]
                    }
                };

                optionsBar.maintainAspectRatio =
            $(window).width() < width_threshold ? false : true;

                /**
                * COLOR CODES
                * Red: #F7604D
                * Aqua: #4ED6B8
                * Green: #A8D582
                * Yellow: #D7D768
                * Purple: #9D66CC
                * Orange: #DB9C3F
                * Blue: #3889FC
                */

                configBar = {
                    type: "horizontalBar",
                    data: {
                        labels: ["Idle Time", "Restricted Apps Usage"],
                        datasets: [{
                            label: "Data in Seconds",
                            data: [idle, restr, 28],
                            backgroundColor: [
                        "#F7604D",
                        "#4ED6B8"
                    ],
                            borderWidth: 0
                        }]
                    },
                    options: optionsBar
                };

                barChart = new Chart(ctxBar, configBar);
            }
        }

    </script>
</asp:Content>
