var myCenter;
var myCenterMarker;
var htmlInfoWindow = null;
var infowindow = new google.maps.InfoWindow();

function map_serivce_addMapMarker(iMarkerNumber, iImageNumber, iLat, iLng, iTitle, iContent, IsVenue, iMap, iHotelID) {
    //alert("here');
    // ####### SETUP VARS
    var myLatLng = new google.maps.LatLng(iLat, iLng);
    if (IsVenue)
        imgPrefix = 'venue_';
    else
        imgPrefix = 'mark_';
    var str = "000" + iImageNumber;
    var subStr = str.substring(str.length - 3, str.length);
    var strImagePath = "";
    if (iMarkerNumber == '0') {
        strImagePath = 'images/gmap/venue_000.gif';
    } else {
         strImagePath = "../images/gmap/" + imgPrefix + subStr + ".png";
    }
    

    // ####### PLACE MARKER

    var marker = new google.maps.Marker({
        position: myLatLng,
        map: iMap,
        icon: strImagePath,
        iw: map_service_buildInfoWindow(iTitle, iContent)
    });
    
    // ####### ADD INFO WINDOW
   
    google.maps.event.addListener(marker, 'click', function () {
        infowindow.setContent(this.iw);
        infowindow.open(iMap, this);
    });

    // ####### CENTRE AND FIT MAP
    bounds.extend(myLatLng);
    if (iMarkerNumber == '0') {
        //iMap.fitBounds(bounds);
        iMap.setCenter(bounds.getCenter());
        iMap.setZoom(14);
       
    } else {
        iMap.fitBounds(bounds);
        //alert("there");
    }

    ////####### LEGEND
    //_legend = _legend + '<tr><td valign="top">';
    //_legend = _legend + '<a href="javascript: showMap(' + (iMarkerNumber) + ')"><img src="' + strImagePath + '" alt="" height="25px" width="17px" /></a></td>';
    ////_legend = _legend + '<td><a href="javascript: showMap(' + (iMarkerNumber) + ')">' + iTitle + '</a></td>';
    //_legend = _legend + '<td><a href="#h' + iHotelID + '">' + iTitle + '</a></td>';
    //_legend = _legend + '</tr>';
    return marker;
}
function map_service_buildInfoWindow(title, content) {
    infoWin = '<div class="divMapInfo">';
    infoWin += '<div class="divMapInfoHdr">' + title + '</div>';
    infoWin += '<div class="divMapInfoContent">' + content + '</div>';
    infoWin += '</div>';
    return infoWin;
}

function showMap(iMarker) {
    google.maps.event.trigger(_gmarkers[iMarker], "click");
}