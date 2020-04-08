//import m from 'mithril';

const fishPlantingApi = {
    urls: {
        "counties": "/api/counties",
        "waters": "/api/waters",
        "plants": "/api"
    },
    routes: [],
    counties: [],
    watersForCounty: [],
    plantsForWaterAndCounty: null,
    loadCounties: function () {
        m.request({
            url: fishPlantingApi.urls["counties"],
            method: "GET"
        })
        .then(function (result) {
            fishPlantingApi.counties = result
        });
    },
    loadWatersForCounty: function (county) {
        console.debug("loadWatersForCounty", county);
        fishPlantingApi.watersForCounty = []; // clear
        m.request({
            url: fishPlantingApi.urls["waters"],
            params: {
                county: county
            },
            method: "GET"
        })
        .then(function (result) {
            fishPlantingApi.watersForCounty = result.data;
            if (result.error) {
                alert("While loading the data...\n", result.error);
            }
        });
    },
    loadPlantsForWaterAndCounty: function (water, county) {
        console.debug("loadPlantsForWaterAndCounty", { water: water, county: county });
        fishPlantingApi.plantsForWaterAndCounty = null; // clear
        m.request({
            url: fishPlantingApi.urls["plants"],
            params: {
                county: county,
                water: water
            }
        }).then(function (result) {
            fishPlantingApi.plantsForWaterAndCounty = result.data;
            if (result.error) {
                alert("While loading the data...\n", result.error);
            }
        });
    }
};

const CountiesListComponent = {
    oninit: fishPlantingApi.loadCounties,
    view: function () {
        if (fishPlantingApi.counties.length) {
            return m("div"
                , m("h2", "Counties")
                , m("ul#counties",
                    fishPlantingApi.counties.map(function (item) {
                        return m("li",
                            m(m.route.Link,
                                {
                                    href: "/waters/" + item.name
                                },
                                item.name)
                            );
                    })
                ));
        } else {
            return m("p", "Loading...");
        }
    }
}

const GeoCoordinate = {
    view: function (vnode) {
        var lat = vnode.attrs.latitude;
        var lon = vnode.attrs.longitude;
        return m("span.geo", [
            "(",
            m("span.latitude", { title: lat }, lat),
            ", ",
            m("span.longitude", { title: lon }, lon),
            ")"
        ]);
    }
}

const WatersForCounty = {
    oninit: function (vnode) {
        fishPlantingApi.loadWatersForCounty(vnode.attrs.county);
    },
    view: function (vnode) {
        var county = vnode.attrs.county;
        if (fishPlantingApi.watersForCounty.length) {
            return m("div", [
                m("h2", "Waters for " + county),
                m("div", fishPlantingApi.watersForCounty.map(function (item) {
                    return m("div",
                        m("h3",
                            m(m.route.Link, {
                                href: "/plants/" + encodeURIComponent(county) + "/" + encodeURIComponent(item.name)
                            }, item.name)
                        ),
                        m("div", item.counties.map(function (cnty, index) {
                            if (index > 0) return ", " + cnty.name;
                            else return cnty.name;
                        })),
                        m(GeoCoordinate, {
                            latitude: item.coordinate.latitude,
                            longitude: item.coordinate.longitude,
                        })
                    );
                }))
            ]);
        } else {
            return m("p", "Loading...");
        }
    }
}

const WaterComponent = {
    view: function (vnode) {
        var water = vnode.attrs.water;
        return m("div",
            m("div.water", water.name),
            m("div.counties", water.counties.map(function (cnty, index) {
                if (index > 0) return ", " + cnty.name;
                else return cnty.name;
            })),
            m("div.coordinate",
                m(GeoCoordinate, {
                    latitude: water.coordinate.latitude,
                    longitude: water.coordinate.longitude,
                })
            )
        );
    }
}

const FishPlantsList = {
    oninit: function (vnode) {
        fishPlantingApi.loadPlantsForWaterAndCounty(vnode.attrs.water, vnode.attrs.county);
    },
    view: function () {
        const data = fishPlantingApi.plantsForWaterAndCounty;
        if (data && data.length > 0) {
            // Water+County the same for each, group into heading
            var result = [
                m(WaterComponent, { water: data[0].water }),
                m("hr")
            ];
            result.push(
                m("table",
                    m("caption", "Table of fish plants for the water."),
                    m("thead",
                        m("tr",
                            m("th[title=Week of plant]", "Week"),
                            m("th", "Species"),
                            m("th", "Size")
                        )
                    ),
                    m("tbody",
                        data.map(function (item) {
                            return m("tr", [
                                m("td", item.week),
                                m("td", item.species.name),
                                m("td", item.size.name)
                            ]);
                        })
                    )
                )
            );
            return result;
        } else if (data) {
            return m("p", "No data.");
        } else {
            return m("p", "Loading...");
        }
    }
} 

fishPlantingApi.routes = Object.freeze([
    {
        key: "counties",
        route: "/counties",
        component: CountiesListComponent,
    },
    {
        key: "waters",
        route: "/waters/:county",
        component: WatersForCounty
    },
    {
        key: "plants",
        route: "/plants/:county/:water",
        component: FishPlantsList
    }
]);

window.addEventListener("load", function () {
    m.route(document.getElementById("app"),
        fishPlantingApi.routes[0].route,
        Object.fromEntries(
            fishPlantingApi.routes.map(function (route) {
            return [
                route.route,
                route.component
            ]
        }))
        //{
        //"/counties": CountiesListComponent,
        //"/waters/:county": WatersForCounty,
        //"/plants/:county/:water": FishPlantsList
        //}
    );
});
