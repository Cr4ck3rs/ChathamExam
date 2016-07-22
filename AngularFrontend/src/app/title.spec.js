describe('title component', function () {
  beforeEach(module('app', function ($provide) {
    $provide.factory('appTitle', function () {
      return {
        templateUrl: 'app/title.html'
      };
    });
  }));
  it('should render > Weather Api!', angular.mock.inject(function ($rootScope, $compile) {
    var element = $compile('<app-title></app-title>')($rootScope);
    $rootScope.$digest();
    var title = element.find('h1');
    expect(title.html().trim()).toEqual('>Weather Api!');
  }));
});
