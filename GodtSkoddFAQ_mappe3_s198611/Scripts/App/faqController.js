var App = angular.module("App", []);

App.controller("faqController", function ($scope, $http) {

    var urlFAQ = '/api/FAQ';
    var urlRequest = '/api/Request';
    var urlCategory = '/api/Category';
    
    /* All ng-show pages:
        loading
        faqPage
        sendRequestPage
        allFaqsPage
        allRequestsPage
        allCategoriesPage

       All ng-show parts:
        categoryPart (inni allCategoriesPage) (endre show inni her alt etter om har trykt "legg til ny" eller "endre")

        faqPart (inni allFaqsPage) (endre show inni her alt etter om har trykt "legg til ny" eller "endre")

        Etter hvert: requestPart
    */

    // Code for what should happen/show on front page (FAQ):
    startPage();

    // startPage()
    function startPage() {
        $scope.sendRequestPage = false;
        $scope.allFaqsPage = false;
        $scope.allRequestsPage = false;
        $scope.allCategoriesPage = false;

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
        $scope.allCategoriesPage = false;

        $scope.loading = true;
        $scope.sendRequestPage = true;
    }

    // goToAllFAQs()
    $scope.goToAllFAQs = function () {
        $scope.faqPage = false;
        $scope.sendRequestPage = false;
        $scope.allRequestsPage = false;
        $scope.allCategoriesPage = false;

        $scope.loading = true;
        $scope.allFaqsPage = true;

        // get all FAQs
        $http.get(urlFAQ).
        success(function (allFAQs) {
            $scope.faqs = allFAQs;
            $scope.loading = false;
        }).
        error(function (data, status) {

        });
    }

    // goToAllRequests()
    $scope.goToAllRequests = function () {
        $scope.faqPage = false;
        $scope.sendRequestPage = false;
        $scope.allFaqsPage = false;
        $scope.allCategoriesPage = false;
        
        $scope.loading = true;
        $scope.allRequestsPage = true;

        // get all requests
        $http.get(urlRequest).
        success(function (allRequests) {
            $scope.requests = allRequests;
            $scope.loading = false;
        }).
        error(function (data, status) {

        });
    }

    // goToAllCategories()
    $scope.goToAllCategories = function () {
        $scope.faqPage = false;
        $scope.sendRequestPage = false;
        $scope.allRequestsPage = false;
        $scope.allFaqsPage = false;
        
        $scope.loading = true;
        $scope.allCategoriesPage = true;

        // get all categories
        $http.get(urlCategory).
        success(function (allCategories) {
            $scope.faqs = allCategories;
            $scope.loading = false;
        }).
        error(function (data, status) {

        });
    }

// ---------------------------- new and update ------------------------------

    // ---------- Category ------------

    // goToNewCategory()
    $scope.goToNewCategory = function () {
        /*$scope.faqPage = false;
        $scope.sendRequestPage = false;
        $scope.allFaqsPage = false;
        $scope.allRequestsPage = false;

        $scope.loading = true;
        $scope.allCategoriesPage = true;*/

        $scope.categoryPart = true;

        $scope.registerCategoryHeader = true;
        $scope.updateCategoryHeader = false;

        $scope.registerCategoryButton = true;
        $scope.updateCategoryButton = false;
        $scope.cancelCategoryButton = true;
    }

    // goToUpdateCategory(id)
    $scope.goToUpdateCategory = function (id) {
        $scope.categoryPart = true;

        $scope.registerCategoryHeader = false;
        $scope.updateCategoryHeader = true;

        $scope.registerCategoryButton = false;
        $scope.updateCategoryButton = true;
        $scope.cancelCategoryButton = true;

        // fill in the form (formCategory)
        
    }

    // deleteCategory(id)
    $scope.deleteCategory = function (id) {

    }

    // updateCategory()
    $scope.updateCategory = function () {
        // in formCategory
    }

    // registerCategory()
    $scope.registerCategory = function () {
        // in formCategory


    }

    // cancelCategory()
    $scope.cancelCategory = function () {
        $scope.categoryPart = false;
    }

    // ------------- FAQ ---------------

    // goToNewFaq()
    $scope.goToNewFaq = function () {
        /*$scope.faqPage = false;
        $scope.sendRequestPage = false;
        $scope.allFaqsPage = false;
        $scope.allRequestsPage = false;
        $scope.newCategoryPage = false;

        $scope.loading = true;
        $scope.newFaqPage = true;*/

        $scope.faqPart = true;

        $scope.registerFAQHeader = true;
        $scope.updateFAQHeader = false;

        $scope.registerFAQButton = true;
        $scope.updateFAQButton = false;
        $scope.cancelFAQButton = true;

        // get all categories (so the user can see what category ID to fill in)
        $http.get(urlCategory).
        success(function (allCategories) {
            $scope.categories = allCategories;
            $scope.loading = false;
        }).
        error(function (data, status) {

        });
    }

    // goToUpdateFAQ(id)
    $scope.goToUpdateFAQ = function (id) {
        $scope.faqPart = true;

        $scope.registerFAQHeader = false;
        $scope.updateFAQHeader = true;

        $scope.registerFAQButton = false;
        $scope.updateFAQButton = true;
        $scope.cancelFAQButton = true;

        // fill in the form (formFAQ)
        
    }

    // deleteFAQ(id)
    $scope.deleteFAQ = function (id) {

    }

    // updateFAQ()
    $scope.updateFAQ = function () {
        // in formFAQ
    }

    // registerFAQ()
    $scope.registerFAQ = function () {
        // in formFAQ
    }

    // cancelFAQ()
    $scope.cancelFAQ = function () {
        $scope.faqPart = false;
    }

    // ---------- Request ------------

    // goToNewRequest()
    $scope.goToNewRequest = function () {
        $scope.requestPart = true;

        $scope.registerRequestHeader = true;
        $scope.updateRequestHeader = false;

        $scope.registerRequestButton = true;
        $scope.updateRequestButton = false;
        $scope.cancelRequestButton = true;
    }

    // goToUpdateRequest(id)
    $scope.goToUpdateRequest = function (id) {
        $scope.requestPart = true;

        $scope.registerRequestHeader = false;
        $scope.updateRequestHeader = true;

        $scope.registerRequestButton = false;
        $scope.updateRequestButton = true;
        $scope.cancelRequestButton = true;

        // fill in the form (formRequest)

    }

    // deleteRequest(id)
    $scope.deleteRequest = function (id) {

    }

    // updateRequest()
    $scope.updateRequest = function () {
        // in formRequest
    }

    // registerRequest()
    $scope.registerRequest = function () {
        // in formRequest
    }

    // cancelRequest()
    $scope.cancelRequest = function () {
        $scope.requestPart = false;
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