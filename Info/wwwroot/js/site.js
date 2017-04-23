document.addEventListener("DOMContentLoaded", function () {
    var reset = function () {
        window.location = "/";
    }
    changeLocation = function (location) {
        if (window.location.href.split(location).length == 2) {
            reset();
        }
        else {
            window.location = "/?platform=" + location;
        }
    }
    var query = window.location.search.split("?platform=");
    if (query.length == 2) {
        var button = document.getElementById("filter-" + query[1]);
        button.classList.add("active");
    }1
});