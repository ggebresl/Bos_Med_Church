//Create the module and name it myEOTC - By Gary (Gerawork) Gebreslassie
var myApp = angular
           .module("myEOTC", ["ngRoute"])
           .config(function ($routeProvider, $locationProvider) {
               $routeProvider.caseInsensitiveMatch = true;

               $locationProvider.html5Mode(true);
               $routeProvider
                   .when('/', {
                       controller: 'homeController',
                       controllerAs: 'home',
                       templateUrl: 'Templates/home.html'
                   })
                   .when('/home', {
                       controller: 'homeController',
                       templateUrl: 'Templates/home.html'
                   })
                   .when('/liturgy', {
                       controller: 'liturgyController',
                       templateUrl: 'Templates/liturgy.html'
                   })
                   .when('/video', {
                       controller: 'videoController',
                       templateUrl: 'Templates/video.html'

                   })
                  //.when('/services', {
                  //    controller: 'servicesController',
               //    templateUrl: 'Templates/services.html'
                
               .when('/geez', {
                   controller: 'geezController',
                   templateUrl: 'Templates/geez.html'
                      //template: "<h1>Services in Action </h1>",
                  })
                   .when('/contacts', {
                       templateUrl: 'Templates/contacts.html',
                       controller: 'contactsController'
                   })
                   .when('/links', {
                       controller: 'linksController',
                       templateUrl: 'Templates/links.html'
                   })
                 .when('/kinye', {
                     //templateUrl: '/bostonmedhanealem/Templates/kinyes.html',
                     templateUrl: 'Templates/kinyes.html',
                     controller: 'kinyesController'
                 })
                  .when('/photos', {
                      controller: 'imagesController',
                      templateUrl: 'Templates/photos.html'
                  })
                   .otherwise('/');
               //.otherwise({
               //    redirectTo: 'Index.html'
               // });
           })
                        // create the controller and inject Angular's $scope
             .controller('mainController', function ($scope) {
                 $scope.message = "EOTC";
             })
             .controller("homeController", function ($scope) {
                 $scope.message = "Zema of Saint Yared";
             })
             .controller("home", function ($scope) {
                 $scope.message = "Zema of Saint Yared";
             })
             .controller("videoController", function ($scope, $http,$route,$log) {
                 $scope.vdieos = "EOTC";
                 $scope.services = ["Video"];
                 //Get list of Videos using Rest based Web API Control/Method Calls
                 $scope.reloadData2 = function () {
                     $route.reload();
                 }
                 $scope.playServiceType = function (selectedService) {
                     $scope.audios = "";
                     if (selectedService == "Video") {
                         $scope.audios = "";
                         $http.get('api/Video/GetListOfVideos')
                         .then(function (response) {
                             $scope.audios = response.data;

                             if (!$scope.audios.startsWith("Video"))
                             {
                                 alert($scope.audios);
                             }
                            
                             //  $log.info(response);
                         },
                         function (reason) {
                             $scope.error = reason.data;
                             // $log.info(reason);
                         });
                     }
                     else
                     {
                            alert('Please select from the provided lists. ');
                     }
                     return $scope.audios;
                 }

             })
             .controller("geezController", function ($scope) {
                 $scope.message = "Boston Menbere Luele Medhane Alem EOTC-GEEZ";
             })

             //.controller("servicesController", function ($scope) {
             //    $scope.message = "Boston Menbere Luele Medhane Alem EOTC-Services";
             //})
           //.controller("contactsController", function ($scope) {
           //    $scope.formView = "Knyes.html";
           //    $scope.message = "Please print the Membership Form and mail it to the provided address";

           //})
           .controller("imagesController", function ($scope, $http, $route) {
              // var resp = $scope;
               $scope.reloadData = function () {
                   $route.reload();
               }
               $http.get('api/Image/GetListOfImages')
               .then(function (response) {
                   $scope.images = response.data;
                   if (!$scope.images.startsWith("Large")) {
                       alert($scope.images);
                   }
               },
                function (reason) {
                    $scope.error = reason.data;
                    // $log.info(reason);
                });
           })
         .controller("liturgyController", function ($scope, $http, $route, $log) {

             $scope.services = ["Akuakuam", "Audio", "Kidase", "Kebero", "Mewaset", "Mezmur", "Sibket", "Wereb", "Zmare"];
             $scope.reloadData2 = function () {
                 $route.reload();
             }
             $scope.playServiceType = function (selectedService) {
                 $scope.audios = "";

                 if (selectedService == "Audio") {
                     $scope.audios = "";
                     $http({
                         method: 'GET',
                         url: 'api/Audio/GetListOfAudios'
                     })
                     .then(function (response) {
                         $scope.audios = response.data;
                          $log.info(response);
                         if (!$scope.audios.startsWith("Audio")) {
                             alert($scope.audios);
                         }
                     },
                     function (reason) {
                         $scope.error = reason.data;
                          $log.info(reason);
                     });
                 }
                 else if (selectedService == "Akuakuam") {
                     $scope.audios = "";
                     $http.get('api/Akuakuam/GetListOfAkuakuams')
                    .then(function (response) {
                        $scope.audios = response.data;
                        // $log.info(response);
                        if (!$scope.audios.startsWith("Akuakuam")) {
                            alert($scope.audios);
                        }
                    },
                     function (reason) {
                         $scope.error = reason.data;
                         // $log.info(reason);
                     });
                 }
                 else if (selectedService == "Kidase") {
                     $scope.audios = "";
                     $http.get('api/Kidase/GetListOfKidases')
                    .then(function (response) {
                        $scope.audios = response.data;
                        // $log.info(response);
                        if (!$scope.audios.startsWith("Kidase")) {
                            alert($scope.audios);
                        }
                    },
                     function (reason) {
                         $scope.error = reason.data;
                         // $log.info(reason);
                     });
                 }
                 else if (selectedService == "Kebero") {
                     $scope.audios = "";
                     $http.get('api/Kebero/GetListOfKeberos')
                    .then(function (response) {
                        $scope.audios = response.data;
                        // $log.info(response);
                        if (!$scope.audios.startsWith("Kebero")) {
                            alert($scope.audios);
                        }
                    },
                     function (reason) {
                         $scope.error = reason.data;
                         // $log.info(reason);
                     });
                 }
                 else if (selectedService == "Mewaset") {
                     $scope.audios = "";
                     $http.get('api/Mewaset/GetListOfMewasets')
                    .then(function (response) {
                        $scope.audios = response.data;
                        // $log.info(response);
                        if (!$scope.audios.startsWith("Mewaset")) {
                            alert($scope.audios);
                        }
                    },
                     function (reason) {
                         $scope.error = reason.data;
                         // $log.info(reason);
                     });
                 }
                 else if (selectedService == "Mezmur") {
                     $scope.audios = "";
                     $http.get('api/Mezmur/GetListOfMezmurs')
                    .then(function (response) {
                        $scope.audios = response.data;
                        if (!$scope.audios.startsWith("Mezmur")) {
                            alert($scope.audios);
                        }
                        // $log.info(response);
                    },
                     function (reason) {
                         $scope.error = reason.data;
                         //  $log.info(reason);
                     });
                 }

                 else if (selectedService == "Zmare") {
                     $scope.audios = "";
                     $http.get('api/Zmare/GetListOfZmares')
                     .then(function (response) {
                         $scope.audios = response.data;
                         if (!$scope.audios.startsWith("Zmare")) {
                             alert($scope.audios);
                         }
                         //  $log.info(response);
                     },
                     function (reason) {
                         $scope.error = reason.data;
                         // $log.info(reason);
                     });
                 }
                 else if (selectedService == "Sibket") {
                     $scope.audios = "";
                     $http.get('api/Sibket/GetListOfSibkets')
                     .then(function (response) {
                         $scope.audios = response.data;
                         if (!$scope.audios.startsWith("Sibket")) {
                             alert($scope.audios);
                             
                         }
                         //  $log.info(response);
                     },
                     function (reason) {
                         $scope.error = reason.data;
                         // $log.info(reason);
                     });
                 }
                 else if (selectedService == "Wereb") {
                     $scope.audios = "";
                     $http.get('api/Wereb/GetListOfWerebs')
                     .then(function (response) {
                         $scope.audios = response.data;
                         if (!$scope.audios.startsWith("Wereb")) {
                             alert($scope.audios);
                         }
                         //  $log.info(response);
                     },
                     function (reason) {
                         $scope.error = reason.data;
                         // $log.info(reason);
                     });
                 }
                 else if (selectedService == "Video") {
                     $scope.audios = "";
                     $http.get('api/Video/GetListOfVideos')
                     .then(function (response) {
                         $scope.audios = response.data;
                         //  $log.info(response);
                         if (!$scope.audios.startsWith("Video")) {
                             alert($scope.audios);
                         }
                     },
                     function (reason) {
                         $scope.error = reason.data;
                         // $log.info(reason);
                     });
                 }
                 else {
                     alert('Please select from the provided lists. ');
                 }
             }
             return $scope.audios;
         });

    


 