<%@ Page Language="C#" AutoEventWireup="true" CodeFile="data_load_on_scroll_with_api.aspx.cs" Inherits="_data_load_on_scroll_with_api" %>

<%@ Register TagPrefix="cgsp" TagName="iheader" Src="~/include/iheader.ascx" %>
<%@ Register TagPrefix="cgsp" TagName="ifooter" Src="~/include/ifooter.ascx" %>
<cgsp:iheader ID="iheader01" runat="server"></cgsp:iheader>
<body>
    <form id="form1" runat="server">
        <div class="h-100 container-sm my-3 border border-5 rounded shadow-lg">
            <a href="default.aspx">Home</a>
            <div class="fixedSearch">
                <div class="row form-group p-1 d-flex flex-row ">
                    <div class="col-md-7 border border-5">
                        <input type="text" placeholder="From Date" id="fromDate" class="form-control inp100" />
                        <input type="text" placeholder="To Date" id="toDate" class="form-control inp100" />
                        <input id="geoCodes" placeholder="Type and select location" type="text" runat="server" class="form-control inp400" />
                        <span id="spanSearchMsg" class="text-danger" style="display: none;">*</span>

                        <button type="button" id="btnSearch" onclick="onSearchByLocation()" class="form-control btn btn-outline-primary inp70">
                            <span id="spnLoading" class="spinner-border spinner-border-sm" style="display: none;"></span>Search
                            
                        </button>
                    </div>




                    <%--  <div class="col-md-1">
                       
                    </div>--%>
                </div>

                <div class="row form-group p-1 d-flex flex-row" id="chkStars">
                    <div class="col-md-7 border border-5">
                        <label class="control-label" for="chkHotelStar1">Filter by: </label>
                        <div class="form-check form-check-inline">
                            <label class="form-check-label" for="chkHotelStar1">1 star</label>
                            <input class="form-check-input" type="checkbox" id="chkHotelStar1" value="1" onclick="onStarClick()" />

                        </div>
                        <div class="form-check form-check-inline">
                            <label class="form-check-label" for="chkHotelStar2">2 stars</label>
                            <input class="form-check-input" type="checkbox" id="chkHotelStar2" value="2" onclick="onStarClick()" />

                        </div>
                        <div class="form-check form-check-inline">
                            <label class="form-check-label" for="chkHotelStar3">3 stars</label>
                            <input class="form-check-input" type="checkbox" id="chkHotelStar3" value="3" onclick="onStarClick()" />

                        </div>
                        <div class="form-check form-check-inline">
                            <label class="form-check-label" for="chkHotelStar4">4 stars</label>
                            <input class="form-check-input" type="checkbox" id="chkHotelStar4" value="4" onclick="onStarClick()" />

                        </div>
                        <div class="form-check form-check-inline">
                            <label class="form-check-label" for="chkHotelStar5">5 stars</label>
                            <input class="form-check-input" type="checkbox" id="chkHotelStar5" value="5" onclick="onStarClick()" />

                        </div>
                    </div>

                </div>
                <div class="row form-group p-1 d-flex flex-row">
                    <div class="col-md-7 border border-5">
                        <label class="control-label" for="rdnSort">Sorted by:</label>
                        <div class="form-check form-check-inline">
                            <input class="form-check-input" type="radio" name="rdnSort" id="rdnSort1" value="distance" checked='checked'>
                            <label class="form-check-label" for="rdnSort1">Distance</label>
                        </div>
                        <div class="form-check form-check-inline">
                            <input class="form-check-input" type="radio" name="rdnSort" id="rdnSort2" value="star">
                            <label class="form-check-label" for="rdnSort2">Star Rating</label>
                        </div>
                        <div class="form-check form-check-inline">
                            <input class="form-check-input" type="radio" name="rdnSort" id="rdnSort3" value="hotelname">
                            <label class="form-check-label" for="rdnSort3">Hotel Name</label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row form-group p-1 d-flex flex-row">
                <div class="col-md-7">

                    <div id="divHotelResult" class="col-md-12 fixedResult" style="display: none;">
                        <table id="tblHotelResult" class="table table-striped table-hover table-borderless">
                            <tbody></tbody>
                        </table>
                    </div>
                </div>
                <div class="col-md-5"  id="divMapArea" style="display: none;">
                    <div class="fixedMap">
                        <button type="button" class="form-control btn btn-outline-primary inp" data-bs-toggle="collapse" data-bs-target="#divMap">Show/hide the map</button>
                        <br />
                        <br />
                        <div class="collapse show divMap" id="divMap">
                            <div id="divMapMsg"></div>
                            <br />
                            <div id="googleMap" class="googleMap"></div>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
    <script src="js/hotel_service_api.js?date=<%=dateTime%>"></script>
    <script src="js/map_service.js?date=<%=dateTime%>"></script>
    <script src="js/pg_service.js?date=<%=dateTime%>"></script>
    <link href="css/pg_data_load_on_scroll_style.css?date=<%=dateTime%>" rel="stylesheet" />
</body>

<cgsp:ifooter ID="ifooter01" runat="server"></cgsp:ifooter>
