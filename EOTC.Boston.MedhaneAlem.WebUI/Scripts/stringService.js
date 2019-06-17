/// <reference path="script.js" />
//factory is a method which is used to create a custom service and register that with Angular
//This service will return a java script object
myApp.factory('stringService', function () {
    return {
        //receive an input
        processString: function (input) {
            if (!input) {
                return input;
            }
            var output = "";

            for (var i = 0; i < input.length; i++) {
                if (i > 0 && input[i] == input[i].toUpperCase()) {
                    output = output + " ";
                }
                output = output + input[i];
            }
            return output;
        }
    };
});