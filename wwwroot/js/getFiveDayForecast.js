function formatDate(date) {
    return (date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear());
}

function DisplayFiveDayWeatherForecast() {
    $("#loader").show();
    $.ajax({
        type: "GET",
        url: '@Url.Action("GetWeatherResultsForNextFiveDays", "Weather")',
        success: function (weatherResult) {
            for (var i = 0; i < weatherResult.weatherRecords.length; i++) {
                let count = i;
                let weatherObject = weatherResult.weatherRecords[count];
                let weatherObjectDate = new Date(weatherObject.date);


                $("#weatherList").append(function () {
                    return "<li class='list-group-item'>" +
                        "<h2>" + formatDate(weatherObjectDate) + "</h2>" +
                        "<p style='font-weight:bold' display='block'>"
                        + weatherObject.weatherState + " "
                        + "</p>" +
                        "<img src='https://www.metaweather.com/static/img/weather/png/"
                        + weatherObject.weatherStateIcon + ".png' width='50' height='50'>" +
                        "</li>";
                });
            }
        },
        complete: function () {
            $("#loader").hide();
        }
    });
};

$(document).ready(function () {

    DisplayFiveDayWeatherForecast();

    $("#getWeather").click(function () {
        $("#weatherList").empty();
        DisplayFiveDayWeatherForecast();
    });
});