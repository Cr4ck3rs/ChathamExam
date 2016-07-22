angular
  .module('weather')
  .component('query', {
    templateUrl: 'app/weather/query.html',
    bindings: {
      forecasts: '=',
      request: '='
    },
    controller: ['$http', QueryController]
  });

function QueryController($http) {
  var vm = this;

  vm.sources = [
    {
      Id: 0,
      Title: 'Forecast.io'
    },
    {
      Id: 1,
      Title: 'Wunderground'
    },
    {
      Id: 2,
      Title: 'World Weather Online'
    }
  ];

  vm.getForecasts = function (request) {
    var url = "http://localhost:5000/api/weather/provider/" + request.source +
     "/latitude/" + request.latitude + "/longitude/" + request.longitude;

    console.log(url);

    $http
       .get(url)
       .then(function (response) {
         vm.forecasts = response.data;
         console.log(response.data);
       });
  };
}
