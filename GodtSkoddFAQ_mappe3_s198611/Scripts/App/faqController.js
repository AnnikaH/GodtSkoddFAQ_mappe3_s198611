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
        faqPart (inni allFaqsPage) (endre show inni her alt etter om har trykt "legg til ny" eller "endre")

        requestPart (inni allRequestsPage) (endre show inni her alt etter om har trykt "legg til ny" eller "endre")

        categoryPart (inni allCategoriesPage) (endre show inni her alt etter om har trykt "legg til ny" eller "endre")
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

        $('#allCategories').addClass("active");

        // get all categories:
        $http.get(urlCategory).
            success(function (allCategories) {
                $scope.categories = allCategories;
            }).
            error(function (data, status) {

            });

        // get all FAQs
        $http.get(urlFAQ).
            success(function (allFAQs) {
                $scope.faqs = allFAQs;
                $scope.loading = false;
            }).
            error(function (data, status) {

            });
    }

    // filterFAQFromCategory(id)
    $scope.filterFAQFromCategory = function (id) {
        // also possible to get all FAQs and just pick all with categoryId equal to id here in js

        //$scope.loading = true;

        // first "clear/unmark" all categories in case one has been selected before:
        angular.forEach($scope.categories, function (item) {
            $('#categoryChosen-' + item.id).removeClass("active");
        });
        // and also the "Alle" category:
        $('#allCategories').removeClass("active");

        $http.get(urlFAQ + "/GetByCategory/" + id).
            success(function (relevantFAQs) {
                $scope.faqs = relevantFAQs;
                $scope.loading = false;

                $('#categoryChosen-' + id).addClass("active");  // the selected category
            }).
            error(function (data, status) {
                //$scope.goToStartPage(); // reset (choose "Alle") if error occurs?
            });
    }

    // toggle FAQ - toggleAnswer(id)
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

        //$scope.skjema.$setPristine(); her?
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
            // have to run through all the objects to get the date-number (because the objects' date from backend is f.ex.: /Date(1447629982300)/
            angular.forEach(allRequests, function (item) {
                item.date = new Date(parseInt((item.date).substr(6)));
            })

            $scope.requests = allRequests;
            $scope.loading = false;

            /*angular.forEach($scope.requests, function (item) {
                var dateFromDb = item.date;
                alert(dateFromDb.toString());
                item.date = new Date();
            })*/
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
            $scope.categories = allCategories;
            $scope.loading = false;
        }).
        error(function (data, status) {

        });
    }

// ---------------------------- new and update ------------------------------

    // ---------- Category ------------

    // goToNewCategory()
    $scope.goToNewCategory = function () {
        $scope.categoryPart = true;

        $scope.registerCategoryHeader = true;
        $scope.updateCategoryHeader = false;

        $scope.registerCategoryButton = true;
        $scope.updateCategoryButton = false;
        $scope.cancelCategoryButton = true;

        // empty form if filled:
        $scope.nameCategory = "";
        // to avoid "fake" error messages for the form fields:
        $scope.formCategory.$setPristine();
    }

    // goToUpdateCategory(id)
    $scope.goToUpdateCategory = function (id) {
        $scope.categoryPart = true;

        $scope.registerCategoryHeader = false;
        $scope.updateCategoryHeader = true;

        $scope.registerCategoryButton = false;
        $scope.updateCategoryButton = true;
        $scope.cancelCategoryButton = true;

        // get the category from the database and fill in the form (formCategory):        
        $http.get(urlCategory + "/" + id).
            success(function (category) {
                $scope.idCategory = category.id;    // can get this later
                $scope.nameCategory = category.name;
            }).
            error(function (data, status) {
                //console.log(status + data);
            });
    }

    // deleteCategory(id)
    $scope.deleteCategory = function (id) {
        $http.delete(urlCategory + "/" + id).
            success(function (data) {
                $scope.goToAllCategories();
            }).
            error(function (data, status) {
                //console.log(status + data);
            });
    }

    // updateCategory()
    $scope.updateCategory = function () {
        // in formCategory

        // create category
        var category = {
            name: $scope.nameCategory
        };

        $http.put(urlCategory + "/" + $scope.idCategory, category).
            success(function (data) {
                $scope.goToAllCategories();
                $scope.categoryPart = false;
            }).
            error(function (data, status) {
                //console.log(status + data);
            });
    }

    // registerCategory()
    $scope.registerCategory = function () {
        // in formCategory

        var category = {
            name: $scope.nameCategory
        };

        $http.post(urlCategory, category).
          success(function (data) {
              $scope.goToAllCategories();
              $scope.categoryPart = false;

              //$scope.visKunder = true;
              //$scope.visSkjema = false;
              //$scope.regKnapp = true;
              //console.log("Lagre kunder OK!")
          }).
          error(function (data, status) {
              //console.log(status + data);
          });
    }

    // cancelCategory()
    $scope.cancelCategory = function () {
        $scope.categoryPart = false;
    }

    // ------------- FAQ ---------------

    // goToNewFaq()
    $scope.goToNewFaq = function () {
        $scope.faqPart = true;

        $scope.registerFAQHeader = true;
        $scope.updateFAQHeader = false;

        $scope.registerFAQButton = true;
        $scope.updateFAQButton = false;
        $scope.cancelFAQButton = true;

        // hide errormessage if is shown:
        $('#errorMessageFAQDiv').addClass("hidden");

        // get all categories (so the user can see what category ID to fill in)
        $http.get(urlCategory).
        success(function (allCategories) {
            $scope.categories = allCategories;
            $scope.loading = false;
        }).
        error(function (data, status) {

        });

        // empty form if filled:
        $scope.questionFAQ = "";
        $scope.answerFAQ = "";
        $scope.categoryIdFAQ = "";
        // to avoid "fake" error messages for the form fields:
        $scope.formFAQ.$setPristine();
    }

    // goToUpdateFAQ(id)
    $scope.goToUpdateFAQ = function (id) {
        $scope.faqPart = true;

        $scope.registerFAQHeader = false;
        $scope.updateFAQHeader = true;

        $scope.registerFAQButton = false;
        $scope.updateFAQButton = true;
        $scope.cancelFAQButton = true;

        // hide errormessage if is shown:
        $('#errorMessageFAQDiv').addClass("hidden");

        // get the FAQ from the database and fill in the form (formFAQ)
        $http.get(urlFAQ + "/" + id).
            success(function (faq) {
                $scope.idFAQ = faq.id;    // can get this later
                $scope.questionFAQ = faq.question;
                $scope.answerFAQ = faq.answer;
                $scope.categoryIdFAQ = faq.categoryId;
            }).
            error(function (data, status) {
                //console.log(status + data);
            });
    }

    // deleteFAQ(id)
    $scope.deleteFAQ = function (id) {
        $http.delete(urlFAQ + "/" + id).
            success(function (data) {
                $scope.goToAllFAQs();
            }).
            error(function (data, status) {
                //console.log(status + data);
            });
    }

    // updateFAQ()
    $scope.updateFAQ = function () {
        // in formFAQ

        // create FAQ
        var faq = {
            question: $scope.questionFAQ,
            answer: $scope.answerFAQ,
            categoryId: $scope.categoryIdFAQ
        };

        $http.put(urlFAQ + "/" + $scope.idFAQ, faq).
            success(function (data) {
                $scope.goToAllFAQs();
                $scope.faqPart = false;
            }).
            error(function (data, status) {
                //console.log(status + data);
                $('#errorMessageFAQ').html("Noe gikk galt. Finnes det en kategori med id " + $scope.categoryIdFAQ + "?");
                $('#errorMessageFAQDiv').removeClass("hidden");
            });
    }

    // registerFAQ()
    $scope.registerFAQ = function () {
        // in formFAQ

        var faq = {
            question: $scope.questionFAQ,
            answer: $scope.answerFAQ,
            categoryId: $scope.categoryIdFAQ
        };

        $http.post(urlFAQ, faq).
          success(function (data) {
              $scope.goToAllFAQs();
              $scope.faqPart = false;

              //$scope.visKunder = true;
              //$scope.visSkjema = false;
              //$scope.regKnapp = true;
              //console.log("Lagre kunder OK!")
          }).
          error(function (data, status) {
              //console.log(status + data);
              $('#errorMessageFAQ').html("Noe gikk galt. Finnes det en kategori med id " + $scope.categoryIdFAQ + "?");
              $('#errorMessageFAQDiv').removeClass("hidden");
          });
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

        // empty form if filled:
        $scope.senderFirstNameRequest = "";
        $scope.senderLastNameRequest = "";
        $scope.senderEmailRequest = "";
        $scope.subjectRequest = "";
        $scope.questionRequest = "";
        $scope.answeredRequest = false;
        // to avoid "fake" error messages for the form fields:
        $scope.formRequest.$setPristine();
    }

    // goToUpdateRequest(id)
    $scope.goToUpdateRequest = function (id) {
        $scope.requestPart = true;

        $scope.registerRequestHeader = false;
        $scope.updateRequestHeader = true;

        $scope.registerRequestButton = false;
        $scope.updateRequestButton = true;
        $scope.cancelRequestButton = true;

        // get the request from the database and fill in the form (formRequest)
        $http.get(urlRequest + "/" + id).
            success(function (request) {
                $scope.idRequest = request.id;    // can get this later
                $scope.senderFirstNameRequest = request.senderFirstName;
                $scope.senderLastNameRequest = request.senderLastName;
                $scope.senderEmailRequest = request.senderEmail;
                $scope.subjectRequest = request.subject;
                $scope.questionRequest = request.question;
                $scope.answeredRequest = request.answered;
            }).
            error(function (data, status) {
                //console.log(status + data);
            });
    }

    // deleteRequest(id)
    $scope.deleteRequest = function (id) {
        $http.delete(urlRequest + "/" + id).
            success(function (data) {
                $scope.goToAllRequests();
            }).
            error(function (data, status) {
                //console.log(status + data);
            });
    }

    // updateRequest()
    $scope.updateRequest = function () {
        // in formRequest

        // create request
        var request = {
            senderFirstName: $scope.senderFirstNameRequest,
            senderLastName: $scope.senderLastNameRequest,
            senderEmail: $scope.senderEmailRequest,
            subject: $scope.subjectRequest,
            question: $scope.questionRequest,
            date: new Date(), // now
            answered: $scope.answeredRequest
        };

        $http.put(urlRequest + "/" + $scope.idRequest, request).
            success(function (data) {
                $scope.goToAllRequests();
                $scope.requestPart = false;
            }).
            error(function (data, status) {
                //console.log(status + data);
            });
    }

    // registerRequest()
    $scope.registerRequest = function () {
        // in formRequest

        var request = {
            senderFirstName: $scope.senderFirstNameRequest,
            senderLastName: $scope.senderLastNameRequest,
            senderEmail: $scope.senderEmailRequest,
            subject: $scope.subjectRequest,
            question: $scope.questionRequest,
            date: new Date(),   // now
            answered: $scope.answeredRequest
        };

        $http.post(urlRequest, request).
          success(function (data) {
              $scope.goToAllRequests();
              $scope.requestPart = false;

              //$scope.visKunder = true;
              //$scope.visSkjema = false;
              //$scope.regKnapp = true;
              //console.log("Lagre kunder OK!")
          }).
          error(function (data, status) {
              //console.log(status + data);
          });
    }

    // cancelRequest()
    $scope.cancelRequest = function () {
        $scope.requestPart = false;
    }
});