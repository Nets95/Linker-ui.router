(function (angular) {
   var app = angular
    .module("linkModule")
    .controller("linkController", ["linkService", function (linkService) {
        var scope = this;
        scope.links = [];
        scope.newLinkTitle = "";
        scope.disableAddButton = disableAddButton;
        scope.disableEditButton = disableEditButton;
        scope.isEditEnabled = false;
        scope.isAddEnabled = false;
        scope.editLinkTitle = "";
        scope.currentEditedLink = {};

        (function () {
            linkService
            .getAllLinks()
            .then(function (response) {
                scope.links.push.apply(scope.links, response.data);
            });
        })();

        scope.addNewLink = function () {
            var newLink = { LinkTitle: scope.newLinkTitle, CurrentDate: Date.now() };
            linkService
            .addLink(newLink)
            .then(function (response) {
                console.log("hello");
                response.data.CurrentDate = Date.now();
                scope.links.push(response.data);
                scope.newLinkTitle = "";
                scope.isAddEnabled = false;
            });
        }
   
        scope.remooveLink = function (link) {
            linkService
            .remooveLink(link)
            .then(function (response) {
                console.log("[LinkController - remoove success!]")
                angular.forEach(scope.links, function (item, index) {
                    if (link.LinkTitle === item.LinkTitle) {
                        scope.links.splice(index, 1);
                    }
                });
            })
        }

        scope.updateLink = function (link, editLinkTitle) {
            linkService
            .updateLink(link, editLinkTitle)
            .then(function (response) {
                angular.forEach(scope.links, function (item, index) {
                    if (link.LinkTitle === item.LinkTitle) {
                        scope.links.splice(index, 1, response.data);
                        scope.isEditEnabled = false;
                    }
                });
            });
        }

        function disableAddButton () {
            return (angular.isString(scope.newLinkTitle) && scope.newLinkTitle.length >= 1 && scope.newLinkTitle.length <= 50);
        }

        function disableEditButton() {
            return (angular.isString(scope.editLinkTitle) && scope.editLinkTitle.length >= 1 && scope.editLinkTitle.length <= 50);
        }

        scope.EnableAdd = function () {
            scope.isAddEnabled = true;
        }

        scope.enableEdit = function(link) {
            angular.forEach(scope.links, function (item, index) {
                if (item.LinkTitle === link.LinkTitle) {
                    scope.editLinkTitle = link.LinkTitle;
                    scope.currentEditedLink = link;
                }
            });
            scope.isEditEnabled = true;
        }
        
    }]); 
})(angular);


