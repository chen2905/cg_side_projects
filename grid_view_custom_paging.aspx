<%@ Page Language="C#" AutoEventWireup="true" CodeFile="grid_view_custom_paging.aspx.cs" Inherits="grid_view_custom_paging" %>


<%@ Register TagPrefix="cgsp" TagName="iheader" Src="~/include/iheader.ascx" %>
<%@ Register TagPrefix="cgsp" TagName="ifooter" Src="~/include/ifooter.ascx" %>
<cgsp:iheader ID="iheader01" runat="server"></cgsp:iheader>
<body>
    <form id="form1" runat="server">
        <div class="h-100 container-sm my-3 border border-5 rounded shadow-lg">
            <a href="default.aspx">Home</a>
            <asp:GridView ID="gvHotel" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" 
                OnSorting="gvHotel_Sorting" AllowSorting="true"
                CssClass="table table-condensed table-hover">
                <Columns>
                    <asp:BoundField DataField="HotelID" HeaderText="ID" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <img alt="<%# Eval("HotelName")%>" src="<%# Eval("HotelImagePath")%>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="HotelName" HeaderText="Hotel Name" SortExpression="hotelname"/>
                    <asp:BoundField DataField="Stars" HeaderText="Stars" SortExpression="star"/>
                     <asp:TemplateField  HeaderText="Distance from center" SortExpression="distance">
                        <ItemTemplate>
                            <%# Eval("DistanceFromCenter")%> km
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Repeater ID="rptPaging" runat="server">
                <ItemTemplate>
                    <asp:LinkButton ID="lbnPage" runat="server" Text='<%#Eval("Text") %>'
                        CommandArgument='<%#Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="rptPaging_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
    <link href="css/pg_grid_view_custom_paging.css" rel="stylesheet" />
</body>

<cgsp:ifooter ID="ifooter01" runat="server"></cgsp:ifooter>
