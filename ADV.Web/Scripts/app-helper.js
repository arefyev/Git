var Helper = new function () {

    this.statePortfolioKey = 'portfolio_data';

    this.intersect = function (a, b) {
        var d = {};
        var results = [];
        for (var i = 0; i < b.length; i++) {
            d[b[i]] = true;
        }
        for (var j = 0; j < a.length; j++) {
            if (d[a[j]])
                results.push(a[j]);
        }
        return results;
    };
};

var StateManager = new function () {
    var savedData = [];

    this.getData = function (key) {
        return savedData[key];
    };

    this.setData = function (key, data) {
        savedData[key] = data;
    };
};

document.addEventListener("DOMContentLoaded", function (event) {
    document.getElementById("site-loader").style.display = 'none';
});