// Must add "src="https://www.google.com/jsapi" @_Layout.cshtml
// Load Visualization API and chart package
google.load("visualization", "1.0", { packages: ["corechart"] });

$(document).ready(function() {
  $.ajax({
    url: "/Home/PopulationData",
    dataType: "json",
    type: "GET",
    error: function(xhr, status, error) {
      var err = eval("(" + xhr.responseText + ")");
      toastr.error(err.message);
    },
    success: function(data) {
      var chartData = setChartData(data);
      BarChart(chartData, "chart_div1");
      ColumnChart(false, chartData, "chart_div2");
      ColumnChart(true, chartData, "chart_div3");
      var pieChartData1 = setPieChartData1(data);
      PieChart(pieChartData1, "chart_div4", "2010");
      var pieChartData2 = setPieChartData2(data);
      PieChart(pieChartData2, "chart_div5", "2000");
      return false;
    }
  });
});

function setChartData(data) {
  var dataArray = [["City", "2010 Population", "2000 Population"]];
  $.each(data, function(i, item) {
    dataArray.push([
      item.cityName,
      parseInt(item.populationYear2010),
      parseInt(item.populationYear2000)
    ]);
  });
  var chartData = google.visualization.arrayToDataTable(dataArray);
  return chartData;
}

function setPieChartData1(data) {
  var dataArray = [["City", "2010 Population"]];
  $.each(data, function(i, item) {
    dataArray.push([item.cityName, parseInt(item.populationYear2010)]);
  });
  var chartData = google.visualization.arrayToDataTable(dataArray);
  return chartData;
}

function setPieChartData2(data) {
  var dataArray = [["City", "2000 Population"]];
  $.each(data, function(i, item) {
    dataArray.push([item.cityName, parseInt(item.populationYear2000)]);
  });
  var chartData = google.visualization.arrayToDataTable(dataArray);
  return chartData;
}

function BarChart(data, chartId) {
  var options = {
    title: "Population of Largest U.S. Cities",
    chartArea: {
      width: "50%"
    },
    colors: ["#b0120a", "#ffab91"],
    hAxis: {
      title: "Total Population",
      minValue: 0
    },
    vAxis: {
      title: "City"
    }
  };
  var chart = new google.visualization.BarChart(
    document.getElementById(chartId)
  );
  chart.draw(data, options);
}

function ColumnChart(boolean, data, chartId) {
  var options = {
    title: "Population of Largest U.S. Cities",
    isStacked: boolean,
    chartArea: {
      width: "50%"
    },
    colors: ["#b0120a", "#ffab91"],
    hAxis: {
      title: "City"
    },
    vAxis: {
      title: "Total Population",
      minValue: 0
    }
  };
  var chart = new google.visualization.ColumnChart(
    document.getElementById(chartId)
  );
  chart.draw(data, options);
}

function PieChart(data, chartId, Year) {
  var options = {
    title: "Population of Largest U.S. Cities (" + Year + ")",
    chartArea: {
      width: "50%"
    }
  };
  var chart = new google.visualization.PieChart(
    document.getElementById(chartId)
  );
  chart.draw(data, options);
}
