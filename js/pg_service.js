var geoCodes;
var countryRestrict;
var iLat;
var iLng;
var iCurrentPage = 0;
var iCheckedStars = [];
var iSort ='distance';
var mapProp;
var map;
var bounds;
var _gmarkers = [];
$(document).ready(function () {
    onSortChange();
    initGeocodeGet();
    initDates();
    windowScrollTop();
    initGmapSetting();
  
});

//geocode sections

function initGeocodeGet() {
    // alert("inside init");
    countryRestrict = "AU";
    geoCodes = new google.maps.places.Autocomplete(document.getElementById('geoCodes'));
    geoCodes.setComponentRestrictions({ 'country': countryRestrict });
   
}
//init dates

function initDates() {

    $("#fromDate").datepicker({
        showOn: "button",
        buttonImage: "images/calendar.gif",
        buttonImageOnly: true
    }).css({

        'display': 'inline'
    });
    $("#toDate").datepicker({
        showOn: "button",
        buttonImage: "images/calendar.gif",
        buttonImageOnly: true
    }).css({

        'display': 'inline'
    });
}

function onSearchByLocation() {
    searchHotel();
}
function searchHotel() {
    $("#tblHotelResult").find("tr").remove();
    _gmarkers = [];
    var iGeoCodes = $('#geoCodes').val();
    var place = geoCodes.getPlace();
  
    initGmapSetting();
   

    if (place != null && iGeoCodes!='') {
        iLat = place.geometry.location.lat();
        iLng = place.geometry.location.lng();
        //alert(iLat + ' ' + iLng);
        $('#spanSearchMsg').hide();
        iCurrentPage = 1;
        hotel_service_loadHotelDataViaWS(iLat, iLng, iCurrentPage, iCheckedStars.toString(),iSort);

        // alert(iCurrentPage);
      
    } else {
        $('#spanSearchMsg').show();
     
        $('#googleMap').hide(1000);

       
    }
}
function windowScrollTop() {
    $(window).scroll(function () {
        
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {
            iCurrentPage += 1;
            
            hotel_service_loadHotelDataViaWS(iLat, iLng, iCurrentPage, iCheckedStars.toString(),iSort);
            console.log('gmarker Items after scroll:'+_gmarkers.length);
        }
    });
}
function onStarClick() {
    iCheckedStars = [];
    $('#chkStars input:checked').each(function () {
        iCheckedStars.push($(this).attr('value'));
    });
    searchHotel();
    // alert(iCheckedStars);
}

function onSortChange() {
    iSort = 'distance';
    $('input[type=radio][name=rdnSort]').change(function () {

        iSort = this.value;
        searchHotel();
       // console.log('sort by ' + iSort);
    });
}

function initGmapSetting() {
    mapProp = {
        zoom: 10,
        center: new google.maps.LatLng(0, 0),
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        disableDefaultUI: true,
        scrollWheel: false,
        draggable: false,
       
    };
    map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
    bounds = new google.maps.LatLngBounds();
}