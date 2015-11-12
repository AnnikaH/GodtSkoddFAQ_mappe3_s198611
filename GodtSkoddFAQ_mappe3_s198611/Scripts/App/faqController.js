var App = angular.module("App", []);

App.controller("faqController", function ($scope, $http) {

    var urlFAQ = '/api/FAQ';
    var urlRequest = '/api/Request';
    var urlCategory = '/api/Category';
    
    $scope.goToStartPage = function () {
        window.location.reload;
    }

    $scope.goToSendRequest = function () {
        $scope.loading = false;
        $scope.faq = false;
        $scope.sendRequest = false;
        $scope.allRequests = false;
        $scope.newCategory = false;
        $scope.newFaq = false;

        $scope.$apply;
    }

    $scope.goToAllRequests = function () {
        $scope.loading = false;
        $scope.faq = false;
        $scope.sendRequest = false;
        $scope.allRequests = true;
        $scope.newCategory = false;
        $scope.newFaq = false;

        $scope.$apply();
    }

    $scope.goToNewCategory = function () {
        $scope.loading = false;
        $scope.faq = false;
        $scope.sendRequest = false;
        $scope.allRequests = false;
        $scope.newCategory = true;
        $scope.newFaq = false;

        $scope.$apply();
    }

    $scope.goToNewFAQ = function () {
        $scope.loading = false;
        $scope.faq = false;
        $scope.sendRequest = false;
        $scope.allRequests = false;
        $scope.newCategory = false;
        $scope.newFaq = true;

        $scope.$apply();
    }

    // All ng-show: loading, faq, sendRequest, allRequests, newCategory, newFaq

    // Code for what should happen/show on front page (FAQ):
    $scope.loading = true;
    $scope.faq = true;
    $scope.sendRequest = true;
    $scope.allRequests = true;
    $scope.newCategory = true;
    $scope.newFaq = true;

    $scope.$apply();

    /*$http.get(urlFAQ).
        success(function (allFAQs) {
            $scope.faq = true;
        }).
        error(function (data, status) {
            $scope.faq = false;
        });*/

    /*
    var url = '/api/Kunde/';
    $scope.sletteFeil = false;

    function hentAlleKunder() {
        $scope.sletteFeil = false;
        $http.get(url).
          success(function (alleKunder) {
              $scope.kunder = alleKunder;
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    hentAlleKunder();

    $scope.registerKunde = function () {
        // lag et object for overføring til server via post
        console.log("Inne i registerKunde");
        var kunde = {
            fornavn: $scope.fornavn,
            etternavn: $scope.etternavn,
            adresse: $scope.adresse,
            postnr: $scope.postnr,
            poststed: $scope.poststed
        };

        $http.post(url, kunde).
          success(function (data) {
              // returner ingen ting, alternativt kan alle kundene returneres, men det er ikke helt "REST"
              hentAlleKunder(); // må gjøre dette inne i post ellers vil hentAlleKunder kjøre før den er ferdig
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    $scope.slettKunde = function () {
        $http.delete(url + $scope.sletteId).
        success(function (feil) {
            console.log("Retur fra sletting : " + feil);
            if (feil == "false") // husk dette er en JSON variabel som streng ikke en boolsk -variabel som på server.
            {
                $scope.sletteFeil = true;
                console.log("inne i false testen");
            }
            else {
                hentAlleKunder();
            }
        }).
        error(function (data, status) {
            console.log(status + data);
        });
    }*/
});