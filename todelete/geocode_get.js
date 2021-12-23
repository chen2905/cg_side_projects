
$(function () {

    initGeocodeGet();
  

});

var geoCodes;
var countryRestrict;
function initGeocodeGet() {
    // alert("inside init");
    var countryRestrict = "AU";
     geoCodes = new google.maps.places.Autocomplete(document.getElementById('geoCodes'));
    geoCodes.setComponentRestrictions({ 'country': countryRestrict });
}

function OnSearchByLocation() {

    var place = geoCodes.getPlace();

    alert("Lat:" + place.geometry.location.lat() + " lng:" + place.geometry.location.lng());
}