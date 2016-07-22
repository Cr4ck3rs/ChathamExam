describe('header component', function () {
  beforeEach(module('app', function ($provide) {
    $provide.factory('appHeader', function () {
      return {
        templateUrl: 'app/header.html'
      };
    });
  }));
  it('should render \'Fountain Generator\'', angular.mock.inject(function ($rootScope, $compile) {
    var element = $compile('<app-header></app-header>')($rootScope);
    $rootScope.$digest();
    var header = element.find('p');
    expect(header.html().trim()).toEqual('Weather Forecast');
  }));
});
