﻿var map, queryTask, query;  //identity
var identifyTask, identifyParams, initialExtent, aecam, mtitle, theStore;  //identity, grid, 
var exportUrl = "http://argis.ualr.edu/ieagis/rest/services/Utilities/PrintingTools/GPServer/Export%20Web%20Map%20Task";
var restUrl = "http://argis.ualr.edu/ieagis/rest/services/ARKANSAS_INFO/MapServer";
function init() {
    //dojo.connect(grid, "onRowClick", onRowClickHandler);
    //identity setup the popup window 
    var popup = new esri.dijit.Popup({
        fillSymbol: new esri.symbol.SimpleFillSymbol(esri.symbol.SimpleFillSymbol.STYLE_SOLID, new esri.symbol.SimpleLineSymbol(esri.symbol.SimpleLineSymbol.STYLE_SOLID, new dojo.Color([255, 0, 0]), 2), new dojo.Color([255, 255, 0, 0.25]))
    }, dojo.create("div"));

    initialExtent = new esri.geometry.Extent(172209.475904854, 3601359.1077277837, 985642.1125089643, 4064083.0555859907, new esri.SpatialReference({
        wkid: 26915
    }));
    //xmin, ymin, xmax, ymax

    map = new esri.Map("map", {
        extent: initialExtent,
        logo: false,
        zoom: 8,
        infoWindow: popup
    });


    aecam = new esri.layers.ArcGISDynamicMapServiceLayer(restUrl, {
        id: 'aecam',
        opacity: 0.8
    });
    dojo.connect(map, "onLoad", function () {
        navToolbar = new esri.toolbars.Navigation(map);
        createPrintDijit(dojo.byId('map_name').value);
    });

    /*dojo.connect(map, 'onLayersAddResult', function(results) {			  
    var toc = new agsjs.dijit.TOC({
    map: map,
    layerInfos: [{
    layer: ARKANSAS_INFO,
    title: "AR Fire Districts"
    }]
    }, 'tocDiv');
    toc.startup();
    });*/

    map.addLayers([aecam]);

    //debug
    //dojo.connect(map,"onClick",layerList);

    //identify
    dojo.connect(map, "onClick", executeIdentifyTask);

    //create identify tasks and setup parameters 
    dojo.connect(map, "onLoad", function () {
        //dojo.style(dojo.byId("leftPane"), "display", "none");
        //dojo.style(dojo.byId("map"), "display", "block");
        identifyTask = new esri.tasks.IdentifyTask("http://argis.ualr.edu/ieagis/rest/services/ARKANSAS_INFO/MapServer");

        identifyParams = new esri.tasks.IdentifyParameters();
        identifyParams.tolerance = 10;
        identifyParams.returnGeometry = true;
        identifyParams.width = map.width;
        identifyParams.height = map.height;

        map._layers.aecam.setVisibleLayers([4, 9, 10, 11]);
        //map._layers.aecam.setVisibleLayers([4, 9, 11]);

        //Create Find Task using Post code layer
        findTask = new esri.tasks.FindTask("http://argis.ualr.edu/ieagis/rest/services/ARKANSAS_INFO/MapServer");
        //Create the find parameters
        findParams = new esri.tasks.FindParameters();
        findParams.returnGeometry = true;
        findParams.outSpatialReference = map.spatialReference;

        queryDistTask = new esri.tasks.QueryTask("http://argis.ualr.edu/ieagis/rest/services/ARKANSAS_INFO/MapServer/11");

        //build query filter
        queryDist = new esri.tasks.Query();
        queryDist.returnGeometry = false;
        queryDist.outFields = ["OBJECTID", "Name"];
        runDistQuery();


        queryTask = new esri.tasks.QueryTask("http://argis.ualr.edu/ieagis/rest/services/ARKANSAS_INFO/MapServer/9");

        //build query filter
        query = new esri.tasks.Query();
        query.returnGeometry = false;
        query.outFields = ["OBJECTID_1", "CITY_NAME"];
        runQuery();
    });

    //dojo.connect(searchButton,"onclick",setPrintTitle);	
    //dojo.connect(searchDistButton,"onclick",setDistPrintTitle);					
}
function runQuery() {
    //CITY
    query.where = "OBJECTID_1<>0";
    //execute query
    queryTask.execute(query, qryResults);
}
function runDistQuery() {
    queryDist.where = "OBJECTID<>0";
    //SCHOOL DIST
    //execute query
    queryDistTask.execute(queryDist, qryDistResults);
}
function qryResults(results) {

    //Populate the dropdown list box with unique values
    values = [];
    testVals = {};

    features = results.features;
    dojo.forEach(features, function (feature) {
        curName = feature.attributes.CITY_NAME;
        if (!testVals[curName]) {
            testVals[curName] = true;
            values.push({ "OBJECTID_1": feature.attributes.OBJECTID_1, "CITY_NAME": feature.attributes.CITY_NAME });
        }
    });

    dataItems = {
        identifier: "OBJECTID_1",
        label: "CITY_NAME",
        items: values
    };

    cityStore = new dojo.data.ItemFileReadStore({ data: dataItems });

    dijit.byId("citySearch").set("store", cityStore);
}

function qryDistResults(results) {

    //Populate the dropdown list box with unique values
    values = [];
    testVals = {};

    features = results.features;
    dojo.forEach(features, function (feature) {
        curName = feature.attributes.Name;
        if (!testVals[curName]) {
            testVals[curName] = true;
            values.push({ "OBJECTID": feature.attributes.OBJECTID, "Name": feature.attributes.Name });
        }
    });

    dataItems = {
        identifier: "OBJECTID",
        label: "Name",
        items: values
    };

    theStore = new dojo.data.ItemFileReadStore({ data: dataItems });

    dijit.byId("distSearch").set("store", theStore);
}
function setPrintTitle() {
    //alert(document.getElementById('program').options[document.getElementById('program').selectedIndex].text);
    var searchVal = dojo.byId('citySearch').value + " County";

    var searchString = searchVal;

    dojo.byId('map_name').value = searchString;
}
function setDistPrintTitle() {
    //alert(document.getElementById('program').options[document.getElementById('program').selectedIndex].text);
    var searchVal = dojo.byId('distSearch').value + " School District";

    var searchString = searchVal;

    dojo.byId('map_name').value = searchString;
}
function handleError(err) {
    console.log("Something broke: ", err);
}
function createPrintDijit(printTitle) {
    var layoutTemplate, templateNames, mapOnlyIndex, templates;

    // create an array of objects that will be used to create print templates
    var layouts = [
				  {
				      "name": "Letter ANSI A Landscape",
				      "label": "Landscape (PDF)",
				      "format": "pdf",
				      "options": {
				          "legendLayers": [], // empty array means no legend
				          "scalebarUnit": "Miles",
				          "titleText": printTitle + ", Landscape PDF"
				      }
				  }, {
				      "name": "Letter ANSI A Portrait",
				      "label": "Portrait (Image)",
				      "format": "jpg",
				      "options": {
				          "legendLayers": [],
				          "scaleBarUnit": "Miles",
				          "titleText": printTitle + ", Portrait JPG"
				      }
				  }, {
				      label: "Map Only (PNG)",
				      format: "PNG32",
				      layout: "MAP_ONLY",
				      preserveScale: false,
				      exportOptions: {
				          width: 1024,
				          height: 768,
				          dpi: 96
				      }
				  }
				];

    // create the print templates, could also use dojo.map
    var templates = [];
    dojo.forEach(layouts, function (lo) {
        var t = new esri.tasks.PrintTemplate();
        t.layout = lo.name;
        t.label = lo.label;
        t.format = lo.format;
        t.preserveScale = false;
        t.layoutOptions = lo.options;
        templates.push(t);
    });

    printer = new esri.dijit.Print({
        "map": map,
        "templates": templates,
        "asynch": false,
        url: exportUrl
    }, dojo.byId("printButton"));
    printer.startup();
    dojo.connect(printer, "onPrintStart", function () {
        this.templates[0].layoutOptions.titleText = dojo.byId("map_name").value;
    });
}
//identity
function executeIdentifyTask(evt) {
    if (evt.mapPoint) {
        identifyParams.geometry = evt.mapPoint;
    } else {
        identifyParams.geometry = evt.geometry;
    }
    identifyParams.mapExtent = map.extent;
    identifyParams.layerIds = [9, 11]; //identifyParams.layerIds = [2]; //	
    var deferred = identifyTask.execute(identifyParams);

    deferred.addCallback(function (response) {
        // response is an array of identify result objects    
        // Let's return an array of features.
        return dojo.map(response, function (result) {
            var feature = result.feature;
            feature.attributes.layerName = result.layerName;
            var template = new esri.InfoTemplate();
            template.setTitle(feature.attributes.layerName);
            //alert(result.layerName);
            switch (result.layerName) {
                case 'County':
                    template.setContent(getCountyContent);
                    feature.setInfoTemplate(template);
                    break;
                case 'School District':
                    template.setContent(getSchoolDistContent);
                    feature.setInfoTemplate(template);
                    break;
                case 'Parcels':
                    template.setContent(getParcelContent);
                    feature.setInfoTemplate(template);
                    break;
                case 'City':
                    template.setContent(getCityContent);
                    feature.setInfoTemplate(template);
                    break;
                default:
                    return false;
            }
            return feature;
        });
    });


    // InfoWindow expects an array of features from each deferred
    // object that you pass. If the response from the task execution 
    // above is not an array of features, then you need to add a callback
    // like the one above to post-process the response and return an
    // array of features.
    map.infoWindow.setFeatures([deferred]);
    if (evt.mapPoint) {
        map.infoWindow.show(evt.mapPoint);
    } else {
        map.infoWindow.show(evt.geometry);
    }
}
function doFind() {
    dojo.byId("distSearch").value = "";
    var srchfield = "OBJECTID_1";
    var ID = '';
    findParams.searchFields = [srchfield];
    findParams.layerIds = [9];
    map._layers.aecam.setVisibleLayers([4, 10, 9, 11]);
    dojo.byId("map_name").value = "City of " + dojo.byId("citySearch").value;
    cityStore.fetch({ query: { CITY_NAME: dojo.byId("citySearch").value },
        onItem: function (item) {
            //alert(item.OBJECTID_1);
            ID = item.OBJECTID_1;
        }
    });
    findParams.searchText = ID[0];
    findTask.execute(findParams, showResults, errorSrch);
}
function doDistFind() {
    dojo.byId("citySearch").value = "";
    var srchfield = "OBJECTID";
    var OID = '';
    findParams.searchFields = [srchfield];
    findParams.layerIds = [11];
    map._layers.aecam.setVisibleLayers([4, 9, 10, 11]);
    dojo.byId("map_name").value = dojo.byId("distSearch").value + " School District";
    theStore.fetch({ query: { Name: dojo.byId("distSearch").value },
        onItem: function (item) {
            //alert(item.OBJECTID_1);
            OID = item.OBJECTID;
        }
    });
    //alert(OID);
    findParams.searchText = OID[0];
    findTask.execute(findParams, showResults, errorSrch);
    //findParams.searchText = dojo.byId("distSearch").value;

}
function errorSrch(error) {
    alert(error);
}
function showResults(results) {

    if (results.length == 0) {
        alert('No results found. Please try again.');
        resetMap();
        return false;
    }
    //alert(results.length);
    map.graphics.clear();

    var symbol = new esri.symbol.SimpleFillSymbol(esri.symbol.SimpleFillSymbol.STYLE_SOLID,
				  new esri.symbol.SimpleLineSymbol(esri.symbol.SimpleLineSymbol.STYLE_DASHDOT,
				  new dojo.Color([255, 0, 0]), 2), new dojo.Color([255, 255, 0, 0.25]));

    //create array of attributes
    var items = dojo.map(results, function (result) {
        var graphic = new esri.Graphic(result.feature.toJson());
        graphic.setSymbol(symbol);
        map.graphics.add(graphic);
        return result.feature.attributes;
    });

    var currentGraphic = map.graphics.graphics[0];

    map.setExtent(currentGraphic._extent);
}
function resetMap() {
    dojo.byId('map_name').value = "School Districts";
    dojo.byId('citySearch').value = "";
    dojo.byId('distSearch').value = "";
    map.setExtent(initialExtent);
    map.graphics.clear();
    map._layers.aecam.setVisibleLayers([4, 9, 10, 11]);
}

function selectTab(tab) {
    dijit.byId('accordion').selectChild(tab);
}

function getSchoolDistContent(graphic) {
    content = "<table>";
    content += "<tr><td>School District:</td><td>" + graphic.attributes.Name + " </td></tr>";
    content += "<tr><td>LEA:</td><td>" + graphic.attributes.LEA + " </td></tr>";
    content += "</table>";
    return content;
}

function getCountyContent(graphic) {
    content = "<table>";
    content += "<tr><td>County:</td><td>" + graphic.attributes.NAME10 + " </td></tr>";
    content += "<tr><td>FIPS:</td><td>" + graphic.attributes.STATEFP10 + graphic.attributes.COUNTYFP10 + " </td></tr>";
    content += "</table>";
    return content;
}
function getCityContent(graphic) {
    //alert(graphic.attributes.PSTR_NAM);
    content = "<table>";
    content += "<tr><td width='50%'>City:</td><td></td><td>" + graphic.attributes.INCORPORAT + "</tr>";
    content += "<tr><td>County:</td><td></td><td>" + graphic.attributes.DISTRICT_N + "</tr>";
    content += "<tr><td>Pop 2000:</td><td></td><td>" + graphic.attributes.POP2000 + "</tr>";
    content += "<tr><td>Pop 2010:</td><td></td><td>" + graphic.attributes.POP2010 + "</tr>";
    content += "</table>";
    return content;
}
//not used debug function
function layerList() {

    var lyrs = map._layers.aecam;

    alert(lyrs.visibleLayers);
    map.removeLayer(0);

}
function searchToggle(which) {
    dojo.style(dojo.byId("distDiv"), "display", "none");
    dojo.style(dojo.byId("cityDiv"), "display", "none");
    dojo.style(dojo.byId(which.value), "display", "block");
}

dojo.addOnLoad(init);
