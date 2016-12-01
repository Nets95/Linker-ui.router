(function (angular) {
    angular
    .module("linkModule")
    .factory("linkService", ["$http", function ($http) {
       
        var service = {
            addLink: addLink,
            getAllLinks: getAllLinks,
            remooveLink: remooveLink,
            updateLink: updateLink
        };

            return service;

            function addLink(link) {
                var promise =  $http.post("/Home/AddLink", link);
                return promise;
            }

            function getAllLinks() {
                var promise = $http.get("/Home/GetAllLinks");
                return promise;
            }
            
            function remooveLink(link) {
                var promise = $http.post("/Home/RemooveLink", link);
                return promise;
            }

            function updateLink(link, editLinkTitle) {
                var promise = $http.post("/Home/UpdateLink", { link: link, editLinkTitle: editLinkTitle });
                return promise;
            }
    }]);

   

    
    
})(angular);

