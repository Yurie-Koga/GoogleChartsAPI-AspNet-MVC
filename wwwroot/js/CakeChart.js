// Must add "src="https://www.google.com/jsapi" @_Layout.cshtml
// Load Visualization API and chart package
google.load("visualization", "1.0", { packages: ["corechart"] });

$(document).ready(function() {
  $.ajax({
    url: "/Home/CakeData",
    dataType: "json",
    type: "GET",
    error: function(xhr, status, error) {
      var err = eval("(" + xhr.responseText + ")");
      toastr.error(err.message);
    },
    success: function(data) {
      var chartData = setCakeData(data);
      CakeBarChart(chartData, "chart_cake");
      return false;
    }
  });
});

function setCakeData(data) {
  var dataArray = [["Cake", "2019", "2015", "2010", "2005"]];
  $.each(data, function(i, item) {
    dataArray.push([
      item.cakeName,
      parseInt(item.eatenYear2019),
      parseInt(item.eatenYear2015),
      parseInt(item.eatenYear2010),
      parseInt(item.eatenYear2005)
    ]);
  });
  var chartData = google.visualization.arrayToDataTable(dataArray);
  return chartData;
}

function CakeBarChart(data, chartId) {
  var options = {
    title: "Amount of eaten cakes",
    chartArea: {
      width: "50%"
    },
    colors: ["#0D47A1", "#1976D2", "#2196F3", "#64B5F6"],
    hAxis: {
      title: "Total amount",
      minValue: 0
    },
    vAxis: {
      title: "Cake"
    }
  };
  var chart = new google.visualization.BarChart(
    document.getElementById(chartId)
  );
  chart.draw(data, options);
}
