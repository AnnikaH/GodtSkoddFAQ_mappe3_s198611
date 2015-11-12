var App = angular.module("App", []);

App.controller("faqController", function ($scope, $http) {

    var urlFAQ = '/api/FAQ';
    var urlRequest = '/api/Request';
    var urlCategory = '/api/Category';
    
    // All ng-show: loading, faq, sendRequest, allRequests, newCategory, newFaq

    // Code for what should happen/show on front page (FAQ):
    $scope.sendRequest = false;
    $scope.allRequests = false;
    $scope.newCategory = false;
    $scope.newFaq = false;
    $scope.loading = true;
    $scope.faq = true;

    $scope.goToStartPage = function () {
        $scope.sendRequest = false;
        $scope.allRequests = false;
        $scope.newCategory = false;
        $scope.newFaq = false;

        $scope.loading = true;
        $scope.faq = true;
    }

    $scope.goToSendRequest = function () {
        $scope.faq = false;
        $scope.allRequests = false;
        $scope.newCategory = false;
        $scope.newFaq = false;

        $scope.loading = true;
        $scope.sendRequest = true;
    }

    $scope.goToAllRequests = function () {
        $scope.faq = false;
        $scope.sendRequest = false;
        $scope.newCategory = false;
        $scope.newFaq = false;

        $scope.loading = true;
        $scope.allRequests = true;
    }

    $scope.goToNewCategory = function () {
        $scope.faq = false;
        $scope.sendRequest = false;
        $scope.allRequests = false;
        $scope.newFaq = false;

        $scope.loading = true;
        $scope.newCategory = true;
    }

    $scope.goToNewFAQ = function () {
        $scope.faq = false;
        $scope.sendRequest = false;
        $scope.allRequests = false;
        $scope.newCategory = false;

        $scope.loading = true;
        $scope.newFaq = true;
    }

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