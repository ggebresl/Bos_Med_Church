/// <reference path="script.js" />
myApp.filter("genderFilter", function () {
    return function (inputgender) {
        switch (inputgender) {
            case 1:
                return "Male";
            case 2:
                return "Female";
            case 3:                        
                return "Not disclosed";
        }
    }
})