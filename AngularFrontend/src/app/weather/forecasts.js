angular
  .module('weather')
  .component('forecasts', {
    templateUrl: 'app/weather/forecasts.html',
    bindings: {
      forecasts: '<',
      request: '<'
    }
  });
