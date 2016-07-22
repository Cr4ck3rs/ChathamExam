angular
  .module('weather')
  .component('appWeather', {
    templateUrl: 'app/weather/weather.html',
    controller: ['$scope', WeatherController]
  });

/** @ngInject */
function WeatherController($scope) {
  var vm = this;

  vm.forecasts = {};

  vm.request = {};
  vm.request.source = 0;
  vm.request.preferCentigrades = false;
  vm.request.latitude = 0;
  vm.request.longitude = 0;

  function getLocation() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(setLocation);
    }
  }

  function setLocation(position) {
    $scope.$apply(function () {
      if (position) {
        vm.request.latitude = parseFloat(position.coords.latitude.toFixed(4));
        vm.request.longitude = parseFloat(position.coords.longitude.toFixed(4));
      }
    });
  }

  vm.$onInit = function(){
    getLocation();
  };


}
