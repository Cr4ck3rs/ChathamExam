angular
  .module('weather')
  .component('forecast', {
    templateUrl: 'app/weather/forecast.html',
    bindings: {
      forecast: '<',
      request: '<'
    },
    controller: ForecastController
  });

  function ForecastController(){
    this.iconColor = "red";
  }
