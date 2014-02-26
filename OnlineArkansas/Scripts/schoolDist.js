var map, queryTask, graphic, query;
var identifyTask, identifyParams, initialExtent, schoolDist, mtitle, theStore, navToolbar;
var exportUrl = "http://argis.ualr.edu/ieagis/rest/services/Utilities/PrintingTools/GPServer/Export%20Web%20Map%20Task";
var restUrl = "http://argis.ualr.edu/ieagis/rest/services/ARKANSAS_INFO/MapServer";
require([
        "esri/map", "esri/geometry/Extent", "esri/tasks/IdentifyTask", "esri/tasks/IdentifyParameters", "esri/SpatialReference", "esri/InfoTemplate",
		"esri/dijit/Popup", "esri/symbols/SimpleFillSymbol", "esri/symbols/SimpleLineSymbol", "esri/graphic", "dijit/form/Button", "dijit/form/RadioButton", "dojo/dom-attr",
		"esri/layers/ArcGISDynamicMapServiceLayer", "esri/layers/FeatureLayer", "esri/toolbars/navigation", "dijit/layout/AccordionContainer", "dojo/query",
		"dijit/layout/ContentPane", "dijit/form/FilteringSelect", "dijit/layout/BorderContainer", "dojo/parser", "esri/dijit/Print", "modules/HomeButton", "dijit/Tooltip",
        "esri/tasks/PrintTemplate", "esri/tasks/QueryTask", "esri/tasks/query", "esri/tasks/FindTask", "esri/tasks/FindParameters", "dojo/data/ItemFileReadStore", "dojo/dom",
		"dojo/domReady!"
      ], function (
        Map, InitialExtent, IdentifyTask, IdentifyParameters, SpatialReference, InfoTemplate,
        Popup, SimpleFillSymbol, SimpleLineSymbol, Graphic, Button, RadioButton, domAttr,
        ArcGISDynamicMapServiceLayer, FeatureLayer, Navigation, AccordionContainer, djQuery,
        ContentPane, FilteringSelect, BorderContainer, parser, Print, HomeButton, Tooltip,
        PrintTemplate, QueryTask, query, FindTask, FindParameters, ItemFileReadStore, dom
      ) {

          parser.parse();

          //set the initial extent
          initialExtent = new InitialExtent(172209.475904854, 3601359.1077277837, 985642.8725089643, 4064083.0555859907, new SpatialReference({
              wkid: 26915
          }));

          //define the map
          map = new Map("mapDiv", {
              extent: initialExtent,
              logo: false,
              zoom: 8
          });

          //get the layer
          schoolDist = new ArcGISDynamicMapServiceLayer(restUrl, {
              id: 'schoolDist',
              opacity: 0.8
          });

          //add the map service layer
          //school dist, cities, counties
          map.addLayer(schoolDist);

          //set up the identify task
          map.on("click", executeIdentifyTask);

          //when the map loads
          map.on("load", function () {
              //set up the '+' and '-' button
              navToolbar = new Navigation(map);

              var zoomInDiv = djQuery(".esriSimpleSliderIncrementButton");
              domAttr.set(zoomInDiv[0], "title", "Zoom in");

              var zoomOutDiv = djQuery(".esriSimpleSliderDecrementButton");
              domAttr.set(zoomOutDiv[0], "title", "Zoom out");
              //navToolbar.set('title', 'Test Report'); //does work :)
              //navToolbar.setZoomSymbol(zoomSymbol);
              //domAttr.set("div.esriSimpleDecrementButton", "title", "Zoom Out"); // set              
              //set the visible layers
              //roads=4, city=9, county=10, school district=11
              map._layers.schoolDist.setVisibleLayers([4, 9, 10, 11]);
          });


          var home = new HomeButton({
              map: map
              //theme: "esriSimpleSlider esriSimpleSliderVertical esriSimpleSliderTL esriSimpleSliderIncrementButton"
          }, "HomeButton");
          home.startup();

          //02/03/14 jj - removed reset button
          //connect the 'Reset' button
          //dijit.byId("reset").on("click", resetMap);

          //when the user changes the school district or city dropdown zoom to the district or city
          dijit.byId("distSearch").on("change", function () { doFind(this.value, "dist"); });
          dijit.byId("citySearch").on("change", function () { doFind(this.value, "city"); });


          //create the radio buttons to toggle between the school district search and the city search
          var radpar = new RadioButton({
              checked: true,
              value: "distDiv",
              name: "searchParam",
              onChange: function (b) { if (b) searchToggle(this.value); }
          }, "radpar");

          var radpro = new RadioButton({
              checked: false,
              value: "cityDiv",
              name: "searchParam",
              onChange: function (b) { if (b) searchToggle(this.value); }
          }, "radpro");

          //tie the onChange events of the radio buttons to toggle between the school district and city
          dijit.byId('radpar').on('change', function () {
              var value = this.value;
          });

          dijit.byId('radpro').on('change', function () {
              var value = this.value;
          });

          //set up the parameters for the idetify task
          identifyParams = new IdentifyParameters();
          identifyParams.tolerance = 10;
          identifyParams.returnGeometry = true;
          identifyParams.width = map.width;
          identifyParams.height = map.height;

          //Create Find Task using Post code layer
          findTask = new FindTask(restUrl);
          //Create the find parameters
          findParams = new FindParameters();
          findParams.returnGeometry = true;
          findParams.outSpatialReference = map.spatialReference;

          //set up the school district query
          queryDistTask = new QueryTask("http://argis.ualr.edu/ieagis/rest/services/ARKANSAS_INFO/MapServer/11");

          //build query filter for sd
          queryDist = new query();
          queryDist.returnGeometry = false;
          queryDist.outFields = ["OBJECTID", "Name"];
          runDistQuery();

          //set up the city query
          queryCityTask = new QueryTask("http://argis.ualr.edu/ieagis/rest/services/ARKANSAS_INFO/MapServer/9");

          //build query filter for city
          queryCity = new query();
          queryCity.returnGeometry = false;
          queryCity.outFields = ["OBJECTID_1", "CITY_NAME"];
          runQuery();


          //set up the print dijit
          printer = new Print({
              map: map,
              url: exportUrl,
              templates: [{
                  label: "Letter Landscape (PDF)",
                  format: "PDF",
                  layout: "Letter ANSI A Landscape",
                  layoutOptions: {
                      titleText: dojo.byId('map_name').value,
                      authorText: "IEA",
                      copyrightText: "UALR IEA",
                      scalebarUnit: "Miles",
                      legendLayers: []
                  }
              }, {
                  label: "A4 Landscape (PDF)",
                  format: "PDF",
                  layout: "A4 Landscape",
                  layoutOptions: {
                      titleText: dojo.byId('map_name').value,
                      authorText: "IEA",
                      copyrightText: "UALR IEA",
                      scalebarUnit: "Miles",
                      legendLayers: []
                  }
              }, {
                  label: "Map",
                  format: "PDF",
                  layout: "MAP_ONLY",
                  exportOptions: {
                      width: 500,
                      height: 400,
                      dpi: 96
                  }
              }]
          }, dom.byId("printButton"));

          //get the print title from the legend
          //printer.on('print-start', function () {
          dojo.connect(printer, "onPrintStart", function () {
              for (var i = 0; i < this.templates.length - 1; i++) {
                  this.templates[i].layoutOptions.titleText = dojo.byId('map_name').value;
              }
          });

          //render the print widget
          printer.startup();

          /* City queries 
          **************************/
          function runQuery() {
              //CITY Query
              queryCity.where = "OBJECTID_1<>0";
              //execute query
              queryCityTask.execute(queryCity, qryResults);
          }

          //populate the 'cityStore' with city query results
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

              cityStore = new ItemFileReadStore({ data: dataItems });

              dijit.byId("citySearch").set("store", cityStore);
          }
          /* City queries 
          **************************/



          /* School District queries 
          **************************/
          function runDistQuery() {
              //School District query
              queryDist.where = "OBJECTID<>0";
              //SCHOOL DIST
              //execute query
              queryDistTask.execute(queryDist, qryDistResults);
          }

          //populate 'theStore' with school district query results
          function qryDistResults(results) {
              // alert("here");
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

              theStore = new ItemFileReadStore({ data: dataItems });

              dijit.byId("distSearch").set("store", theStore);
          }
          /* School District queries 
          **************************/


          /* Identify Task 
          **************************/
          function executeIdentifyTask(evt) {
              var popup = new Popup({
                  fillSymbol: new SimpleFillSymbol(SimpleFillSymbol.STYLE_SOLID, new SimpleLineSymbol(SimpleLineSymbol.STYLE_SOLID, new dojo.Color([255, 0, 0]), 2), new dojo.Color([255, 255, 0, 0.25]))
              }, dojo.create("div"));

              identifyTask = new IdentifyTask(restUrl);

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
                      var template = new InfoTemplate();
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


          function doFind(value, area) {
              var srchfield, ID;

              ID = '';
              if (area == "city") {
                  dojo.byId("distSearch").value = "";
                  srchfield = "OBJECTID_1";
                  findParams.layerIds = [9];
                  dojo.byId("map_name").value = "City of " + dojo.byId("citySearch").value;
              } else {
                  dojo.byId("citySearch").value = "";
                  srchfield = "OBJECTID";
                  findParams.layerIds = [11];
                  dojo.byId("map_name").value = dojo.byId("distSearch").value + " School District";
              }
              findParams.searchFields = [srchfield];
              map._layers.schoolDist.setVisibleLayers([4, 10, 9, 11]);
              if (area == "city") {
                  //dojo.byId("map_name").value = "City of " + dojo.byId("citySearch").value;
                  cityStore.fetch({ query: { CITY_NAME: dojo.byId("citySearch").value },
                      onItem: function (item) {
                          //alert(item.OBJECTID_1);
                          ID = item.OBJECTID_1;
                      }
                  });
              } else {
                  theStore.fetch({ query: { Name: dojo.byId("distSearch").value },
                      onItem: function (item) {
                          //alert(item.OBJECTID_1);
                          ID = item.OBJECTID;
                      }
                  });
              }
              findParams.searchText = ID[0];
              findTask.execute(findParams, showResults, errorSrch);
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

              var symbol = new SimpleFillSymbol(SimpleFillSymbol.STYLE_SOLID,
				          new SimpleLineSymbol(SimpleLineSymbol.STYLE_DASHDOT,
				          new dojo.Color([255, 0, 0]), 2), new dojo.Color([255, 255, 0, 0.25]));

              //create array of attributes
              var items = dojo.map(results, function (result) {
                  graphic = new Graphic(result.feature.toJson());
                  graphic.setSymbol(symbol);
                  map.graphics.add(graphic);
                  return result.feature.attributes;
              });

              var currentGraphic = map.graphics.graphics[0];

              map.setExtent(currentGraphic._extent);
          }

          /* Reset Button
          **************************/
          function resetMap() {
              dojo.byId('map_name').value = "School Districts";
              dojo.byId('citySearch').value = "";
              dojo.byId('distSearch').value = "";
              map.setExtent(initialExtent);
              map.graphics.clear();
              map._layers.schoolDist.setVisibleLayers([4, 9, 10, 11]);
          }

          function selectTab(tab) {
              dijit.byId('accordion').selectChild(tab);
          }

          /* Identify Templates
          ***************************/
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
          /* Identify Templates
          ***************************/

          //not used debug function
          function layerList() {

              var lyrs = map._layers.schoolDist;

              alert(lyrs.visibleLayers);
              map.removeLayer(0);

          }

          /* Search area - School District or City radio
          *************************************************/
          function searchToggle(which) {
              //alert(which);
              dojo.style(dojo.byId("distDiv"), "display", "none");
              dojo.style(dojo.byId("cityDiv"), "display", "none");
              dojo.style(dojo.byId(which), "display", "block");
          }
      });