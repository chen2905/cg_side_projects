

function f() {
    $("#divMapMsg").html('<span class="badge rounded-pill bg-success">Hotels found for ' + $('#geoCodes').val()+'</span>');
}
function hotel_service_loadHotelDataViaWS(iLat, iLng, iCurrentPageNumber, iSelectedStars,iSort) {
    $('#spnLoading').show();
   
    $.ajax({
        url: 'web_services/ws_hotel.asmx/SearchHotels',
        method: 'post',
        dataType: "json",
        data: {
            iCentreLat: iLat,
            iCentreLon: iLng,
            iRadius: 100,
            iMeasure:'KM',
            iPageNumber: iCurrentPageNumber,
            iPageSize: 10,
            iSelectedStars: iSelectedStars,
            iSort: iSort
        },
        success: function (data) {
        
            var hotelTable = $('#tblHotelResult tbody');
          
            $('#divMapArea').fadeIn(1000);
            _gmarkers.push(map_serivce_addMapMarker(0, 0, iLat, iLng, 'Center', '', 0, map, 0));

            $(data).each(function (index, hotel) {
                _gmarkers.push(map_serivce_addMapMarker(hotel.HotelOrder, hotel.HotelOrder, hotel.Lat, hotel.Lng, hotel.HotelName, hotel.City, 0, map, hotel.HotelID));
              hotelTable.append('<tr><td>' + hotel_service_hotelCard(hotel.HotelImagePath, hotel.HotelName, hotel.Stars, hotel.DistanceFromCenter, hotel.HotelOrder) + '</td></tr>'
              
                );
            });
            $('#divHotelResult').slideDown("slow", function () {
                f();
            });
          /*   .css("background","green");*/
             //$('#divLoading').hide();
            $('#spnLoading').hide();
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}

function hotel_service_hotelCard(iImagePath, iHotelName, iStars, iDistanceFromCenter,iHotelOrder){
    var strCard = '<div class="card">'
    strCard += '<div class="row no-gutters">'
    strCard += '        <div class="col-md-2">'
    strCard += '           <img class="card-img img-thumbnail hotel-img" src="' + iImagePath + '" alt="' + iHotelName+'">'
    strCard += '            </div>'
    strCard += '            <div class="col-md-10">'
    strCard += '                 <div class="card-body">'
    strCard += '                    <h7>' + iHotelName +'</h7>'
    strCard += '                    <p class="card-text">' + iStars + ' stars</p>'
    strCard += '                    <p class="card-text">' + iDistanceFromCenter + ' km from center</p>'
    strCard += '    <a href = "#top" onclick = "javascript:showMap(' + iHotelOrder +');" > <i class="bi bi-geo-alt"></i></a>'
    strCard += '                </div>'
    strCard += '            </div>'
    strCard += '        </div>'
    strCard += '    </div>'
    return strCard;

}