<%@ Page Language="C#" AutoEventWireup="true" CodeFile="call_back.aspx.cs" Inherits="call_back" %>

<%@ Register TagPrefix="cgsp" TagName="iheader" Src="~/include/iheader.ascx" %>
<%@ Register TagPrefix="cgsp" TagName="ifooter" Src="~/include/ifooter.ascx" %>
<cgsp:iheader ID="iheader01" runat="server"></cgsp:iheader>
<body>
    <form id="form1" runat="server">
        <div class="h-100 container-sm my-3 border border-5 rounded shadow-lg">
            <a href="default.aspx">Home</a>

            <pre>
                I just met you,
                And this is crazy,
                But here's my number (delegate),
                So if something happens (event),
                Call me, maybe (callback)?
            </pre>
          
            <img src="images/call_back_01.jpg" class="img-fluid" alt="call back example code" />
        <img src="images/call_back_02.jpg" class="img-fluid" alt="call back example code"/>

        </div>
    </form>
</body>

<cgsp:ifooter ID="ifooter01" runat="server"></cgsp:ifooter>
