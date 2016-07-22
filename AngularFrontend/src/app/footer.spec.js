describe('footer component', function () {
  beforeEach(module('app', function ($provide) {
    $provide.factory('appFooter', function () {
      return {
        templateUrl: 'app/footer.html'
      };
    });
  }));
  it('should render \'Jorge Aguero\'', angular.mock.inject(function ($rootScope, $compile) {
    var element = $compile('<app-footer></app-footer>')($rootScope);
    $rootScope.$digest();
    var footer = element.find('a');
    expect(footer.html().trim()).toEqual('Jorge Aguero');
  }));
});
