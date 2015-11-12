var App = angular.module("App", []);

App.controller("faqController", function ($scope, $http) {

    var urlFAQ = '/api/FAQ';
    var urlRequest = '/api/Request';
    var urlCategory = '/api/Category';
    
    // All ng-show: loading, faq, sendRequest, allRequests, newCategory, newFaq

    // Code for what should happen/show on front page (FAQ):
    startPage();

    // startPage()
    function startPage() {
        $scope.sendRequestPage = false;
        $scope.allFaqsPage = false;
        $scope.allRequestsPage = false;
        $scope.newCategoryPage = false;
        $scope.newFaqPage = false;

        $scope.loading = true;
        $scope.faqPage = true;

        // get all FAQs
        $http.get(urlFAQ).
        success(function (allFAQs) {
            $scope.faqs = allFAQs;
            $scope.loading = false;
        }).
        error(function (data, status) {
            
        });
    }

    // toggle FAQ
    $scope.toggleAnswer = function (id) {
        $('#faq-' + id).toggle();
    }

    // goToStartPage()
    $scope.goToStartPage = function () {
        startPage();
    }

    // goToSendRequest()
    $scope.goToSendRequest = function () {
        $scope.faqPage = false;
        $scope.allFaqsPage = false;
        $scope.allRequestsPage = false;
        $scope.newCategoryPage = false;
        $scope.newFaqPage = false;

        $scope.loading = true;
        $scope.sendRequestPage = true;
    }

    // goToAllFAQs()
    $scope.goToAllFAQs = function () {
        $scope.faqPage = false;
        $scope.sendRequestPage = false;
        $scope.allRequestsPage = false;
        $scope.newCategoryPage = false;
        $scope.newFaqPage = false;

        $scope.loading = true;
        $scope.allFaqsPage = true;
    }

    // goToAllRequests()
    $scope.goToAllRequests = function () {
        $scope.faqPage = false;
        $scope.sendRequestPage = false;
        $scope.allFaqsPage = false;
        $scope.newCategoryPage = false;
        $scope.newFaqPage = false;

        $scope.loading = true;
        $scope.allRequestsPage = true;
    }

    // goToNewCategory()
    $scope.goToNewCategory = function () {
        $scope.faqPage = false;
        $scope.sendRequestPage = false;
        $scope.allFaqsPage = false;
        $scope.allRequestsPage = false;
        $scope.newFaqPage = false;

        $scope.loading = true;
        $scope.newCategoryPage = true;
    }

    // goToNewFAQ()
    $scope.goToNewFAQ = function () {
        $scope.faqPage = false;
        $scope.sendRequestPage = false;
        $scope.allFaqsPage = false;
        $scope.allRequestsPage = false;
        $scope.newCategoryPage = false;

        $scope.loading = true;
        $scope.newFaqPage = true;

        // get all categories
        $http.get(urlCategory).
        success(function (allCategories) {
            $scope.categories = allCategories;
            $scope.loading = false;

            $scope.newFAQHeader = true;
            $scope.updateFAQHeader = false;

            $scope.updateFAQButton = false;
            $scope.registerFAQButton = true;
        }).
        error(function (data, status) {

        });
    }

    // updateFAQ()
    $scope.updateFAQ = function () {
        // i skjemaNyFAQ
    }

    // registerFAQ()
    $scope.registerFAQ = function () {
        // i skjemaNyFAQ
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