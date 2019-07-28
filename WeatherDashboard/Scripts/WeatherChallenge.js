    var my_variable;
    var yPoints = [];
    var ciudad = null;
    var unit = null;
    var cdLabel = "Cd. Obregon"
    var MetricLaber = "Centigrados"
    var app = angular.module('MyApp', [])


    app.controller('MyController', function ($scope, $http, $window) {

        $scope.data = [];
        $scope.myFunc = function () {
            var post = $http({
                method: "POST",
                url: "/Home/Clima",
                dataType: 'json',
                data: { Coordenadas: ciudad, units: unit },
                headers: { "Content-Type": "application/json" }
            });

            post.success(function (data) {
                $scope.dias = 0;
                $scope.dias = data;
                my_variable = data;
                addTable();
                chart();
            });

            post.error(function (data, status) {
                $window.alert(data.Message);
            });


        }


    });
    function addTable() {

        document.getElementById("TablaTemperaturas").innerHTML = ""
        var myTableDiv = document.getElementById("TablaTemperaturas")
        var table = document.createElement('TABLE')
        var tableBody = document.createElement('TBODY')
        table.border = '1'
        table.appendChild(tableBody);

        var heading = new Array();
        heading[0] = "Date"
        heading[1] = "Temperature"
        heading[2] = "Min Temperature"
        heading[3] = "Max Temperature"

        var stock = my_variable;
        var tr2 = document.createElement('TR');
        
        tableBody.appendChild(tr2);
        var th1 = document.createElement('TH')
        th1.width = '75';
        th1.setAttribute("colspan", 4);
        th1.appendChild(document.createTextNode(stock[0].city_name));
        tr2.appendChild(th1);

        var tr = document.createElement('TR');
        tableBody.appendChild(tr);
        for (i = 0; i < heading.length; i++) {
            var th = document.createElement('TH')
            th.width = '75';
            th.appendChild(document.createTextNode(heading[i]));
            tr.appendChild(th);
        }



        for (i = 0; i < stock.length; i++) {
            var x = 4;
            var tr = document.createElement('TR');

            var td1 = document.createElement('TD')
            td1.appendChild(document.createTextNode(stock[i].datetime));
            tr.appendChild(td1);
            var td2 = document.createElement('TD')
            td2.appendChild(document.createTextNode(stock[i].temp));
            tr.appendChild(td2);
            var td3 = document.createElement('TD')
            td3.appendChild(document.createTextNode(stock[i].min_temp));
            tr.appendChild(td3);
            var td4 = document.createElement('TD')
            td4.appendChild(document.createTextNode(stock[i].max_temp));
            tr.appendChild(td4);
            yPoints[i] = stock[i].intemp;

            tableBody.appendChild(tr);
        }
        cdLabel = stock[0].city_name;
        MetricLaber = stock[0].unidades;
        myTableDiv.appendChild(table);




    }
    function getvalCity(City) {
        ciudad = City.value;

    }
    function getvalmet(met) {
        unit = met.value;
    }
    function chart() {

        var chart = new CanvasJS.Chart("GraficaTemperaturas", {
            animationEnabled: true,
            theme: "light2",
            title: {
                text: "Weather next 16 days in  " + cdLabel + " on " + MetricLaber + ""
            },
            axisY: {
                includeZero: false
            },
            data: [{
                type: "line",
                dataPoints: [  //yPoints
                    { y: yPoints[0] },
                    { y: yPoints[1] },
                    { y: yPoints[2] },
                    { y: yPoints[3] },
                    { y: yPoints[4] },
                    { y: yPoints[5] },
                    { y: yPoints[6] },
                    { y: yPoints[7] },
                    { y: yPoints[8] },
                    { y: yPoints[9] },
                    { y: yPoints[10] },
                    { y: yPoints[11] },
                    { y: yPoints[12] },
                    { y: yPoints[13] },
                    { y: yPoints[14] },
                    { y: yPoints[15] },
                    { y: yPoints[16] }
                ]
            }]
        });
        chart.render();

    }



