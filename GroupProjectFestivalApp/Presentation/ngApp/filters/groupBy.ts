namespace GroupProjectFestivalApp.Filters {

    angular.module('GroupProjectFestivalApp').filter('groupBy', function () {
        return function (item, expression) {
            if (item) {
                if (!item.group) {
                    item.group = {};

                    for (let i = 0; i < item.length; i++) {
                        let ele = item[i];
                        item.group[ele[expression]] = item.group[ele[expression]] || [];
                        item.group[ele[expression]].push(ele);
                    }
                }

                return item.group;
            }
        };
    });
}