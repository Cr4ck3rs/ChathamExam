
describe('main component', function () {
  beforeEach(module('app', function ($provide) {
    $provide.factory('appHeaderDirective', function () {
      return {};
    });
  }));
  beforeEach(module('app', function ($provide) {
    $provide.factory('appTitleDirective', function () {
      return {};
    });
  }));
  beforeEach(module('app', function ($provide) {
    $provide.factory('appWeatherDirective', function () {
      return {};
    });
  }));
  beforeEach(module('app', function ($provide) {
    $provide.factory('appFooterDirective', function () {
      return {};
    });
  }));
  it('should render the header, title, techs and footer', angular.mock.inject(function ($rootScope, $compile) {
    var element = $compile('<app>Loading...</app>')($rootScope);
    $rootScope.$digest();
    expect(element.find('app-header').length).toEqual(1);
    expect(element.find('app-title').length).toEqual(1);
    expect(element.find('app-techs').length).toEqual(1);
    expect(element.find('app-footer').length).toEqual(1);
  }));
});
