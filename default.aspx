<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<%@ Register TagPrefix="cgsp" TagName="iheader" Src="~/include/iheader.ascx" %>
<%@ Register TagPrefix="cgsp" TagName="ifooter" Src="~/include/ifooter.ascx" %>
<cgsp:iheader ID="iheader01" runat="server"></cgsp:iheader>
<body>
    <div class="p-5 bg-success text-white text-center">
        <h1>Chen Gao(Max) side projects</h1>
        <p>Do it yourself and learn</p>
    </div>

    <nav class="navbar navbar-expand-sm ">
        <div class="container-fluid">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link active" href="default.aspx">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="data_load_on_scroll.aspx">Data Load On Scroll</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="grid_view_custom_paging.aspx">Grid View Custom Paging</a>
                </li>

            </ul>
        </div>
    </nav>

    <div class="container mt-5">
        <div class="row">
            <div class="col-sm-4">
                <h2>About Me</h2>
                <h5>Photo of me:</h5>
                <div class="fakeimg">Fake Image</div>
                <p>Some text about me in culpa qui officia deserunt mollit anim..</p>
                <h3 class="mt-4">Some Links</h3>
                <p>Lorem ipsum dolor sit ame.</p>
                <ul class="nav nav-pills flex-column">
                    <li class="nav-item">
                        <a class="nav-link" href="#">Active</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Link</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Link</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link disabled" href="#">Disabled</a>
                    </li>
                </ul>
                <hr class="d-sm-none">
            </div>
            <div class="col-sm-8">
                <div class="row">
                    <p class="badge bg-success">Dec 22, 2021</p>
                    <p>
                        This <a href="data_load_on_scroll.aspx">Data Load On Scroll</a> .net web form demo on how to integrage
                    </p>
                    <p>
                        html, jquery,boostrap 5, web service, dapper, generic list
                       
                    </p>

                    <p>
                        into a scrollable web form which search,filter and display hotel data dynamally into tables and Google map.

        
                    </p>
                    <p>You can find how to set up a empty web site via VS2019 in "I:\research\show and tell\211222 setting up dot net websites from vs2019.docx"</p>

                </div>
                <div class="row">
                    <p class="badge bg-success">Dec 23, 2021</p>
                    <p>
                        This <a href="grid_view_custom_paging.aspx">Grid View Custom Paging</a> .net web form demo on create a simple grid view with sorting and paging.
                    </p>
                    <p>
                        Tech: html, jquery,boostrap 5, dapper, generic list
                       
                    </p>


                </div>
            </div>
        </div>
    </div>

    <div class="mt-5 p-4 bg-dark text-white text-center">
        <p>Footer</p>
    </div>
    <link href="css/pg_default.css" rel="stylesheet" />
</body>
<cgsp:ifooter ID="ifooter01" runat="server"></cgsp:ifooter>
