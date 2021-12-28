using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class grid_view_custom_paging : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
        {
        if (!IsPostBack)
            {
            int totalRows = 0;
            ViewState["Sort"] = "distance";

            wcf_service.ServiceClient cl = new wcf_service.ServiceClient();
            gvHotel.DataSource = cl.SearchHotels( out totalRows,"-33.8688197", "151.2092955", 5, "km", 1, gvHotel.PageSize, "", ViewState["Sort"].ToString());

            //gvHotel.DataSource = SearchHotels("-33.8688197", "151.2092955", 5, "km", 1, gvHotel.PageSize,  "", ViewState["Sort"].ToString(), out totalRows);
            gvHotel.DataBind();

            DataBindPageRepeater(0, gvHotel.PageSize, totalRows);
          
            }
        }
    private  List<Hotel> SearchHotels(string iCentreLat, string iCentreLon, int iRadius, string iMeasure, int iPageNumber, 
                                    int iPageSize, string iSelectedStars, string iSort,out int oTotalRows)
        {
        ISqlDataAccess _db = new SqlDataAccess();
        string SqlString = @"syp_Hotel_Columbus_pmGeocodeWithScroll 
                            @CentreLat,
                            @CentreLon,
                            @Radius,
	                        @Measure, 
                            @PageNumber,
                            @PageSize,
                            @SelectedStars,
                            @Sort
                            ";
        object param = new
            {
            CentreLat = iCentreLat,
            CentreLon = iCentreLon,
            Radius = iRadius,
            Measure = iMeasure,
            PageNumber = iPageNumber,
            PageSize = iPageSize,
            SelectedStars = iSelectedStars,
            Sort = iSort
            };
        List<Hotel> lstHotels = _db.LoadData<Hotel, dynamic>(SqlString, param);
        oTotalRows = 0;
        if (lstHotels.Count > 0)
            {
            foreach (Hotel hotel in lstHotels)
                {
                hotel.HotelImagePath = HotelImagePath(hotel.HotelID);
                oTotalRows = hotel.TotalRows;
                }

          
            }

        return lstHotels;
        }

    private string HotelImagePath(int iHotelID)
        {
        string hotelImagePath = "";
        ISqlDataAccess _db = new SqlDataAccess();
        string SqlString = @"sdp_HotelImage_pmHotelID @HotelID";
        object param = new
            {
            HotelID = iHotelID
            };
        List<HotelImage> lstHotelImages = _db.LoadData<HotelImage, dynamic>(SqlString, param);

        if (lstHotelImages.Count > 0)
            {
            hotelImagePath = lstHotelImages[0].ImageCSecure;
            }


        return hotelImagePath;
        }
    private void DataBindPageRepeater(int iPageIndex,int iPageSize, int iTotalRows)
        {
        int totalPages = iTotalRows / iPageSize;

        if ((iTotalRows % iPageSize) != 0)
            {
            totalPages += 1;
            }

        List<ListItem> pages = new List<ListItem>();
        if (totalPages > 1)
            {
            for(int i = 1; i <= totalPages; i++)
                {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != (iPageIndex + 1)));
                }
            }
        rptPaging.DataSource = pages;
        rptPaging.DataBind();

        }

    protected void rptPaging_Click(object sender, EventArgs e)
        {
        int totalRows = 0;
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        //Response.Write("go to page " + pageIndex);
        gvHotel.DataSource = SearchHotels("-33.8688197", "151.2092955", 5, "km", pageIndex, gvHotel.PageSize, "", ViewState["Sort"].ToString(), out totalRows);
        gvHotel.DataBind();

        DataBindPageRepeater(pageIndex-1, gvHotel.PageSize, totalRows);
        }
    protected void gvHotel_Sorting(object sender,   GridViewSortEventArgs e)
        {
        int totalRows = 0;
        ViewState["Sort"] = e.SortExpression.ToString();
        gvHotel.DataSource = SearchHotels("-33.8688197", "151.2092955", 5, "km", 1, gvHotel.PageSize, "", ViewState["Sort"].ToString(), out totalRows);
        gvHotel.DataBind();
        DataBindPageRepeater(0, gvHotel.PageSize, totalRows);
        }
    }