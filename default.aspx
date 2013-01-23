<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Hometheaterbuilderv2.WebForm1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="bodycontent" runat="server">
    <%-- <link type="text/css" rel="stylesheet" href="css/reset.css" />				
 <link type="text/css" rel="stylesheet" href="css/style.css" />	--%>


<div style=" vertical-align:middle; width: 100%; height: 100%; background-image: url('images/site-background.gif')">

    <table style="width: 100%" border="0" cellpadding="0px" cellspacing="0px">
        <tr>
            <td style="width: 33.3%;">
                &nbsp;
            </td>
            <td style="width: 900px; vertical-align:middle;" >
               
               <%--Carousel Scroller Code--%>
               
               <div id="container-carousel">
		<div id="example" >
			<div id="slides">
				<div class="slides_container">
					<div class="slide">
						<h1>First Slide</h1>
						<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident.</p>
						<p><a href="#4" class="link">Check out the fourth slide &rsaquo;</a></p>
					</div>
					<div class="slide">
						<h1>Second Slide</h1>
						<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident.</p>
						<p><a href="#5" class="link">Check out the fifth slide &rsaquo;</a></p>
					</div>
					<div class="slide">
						<h1>Third Slide</h1>
						<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident.</p>
						<p><a href="#1" class="link">Check out the first slide &rsaquo;</a></p>
					</div>
					<div class="slide">
						<h1>Fourth Slide</h1>
						<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident.</p>
						<p><a href="#6" class="link">Check out the sixth slide &rsaquo;</a></p>
					</div>
					<div class="slide">
						<h1>Fifth Slide</h1>
						<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident.</p>
						<p><a href="#7" class="link">Check out the seventh slide &rsaquo;</a></p>
					</div>
					<div class="slide">
						<h1>Sixth Slide</h1>
						<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident.</p>
						<p><a href="#1" class="link">Check out the first slide &rsaquo;</a></p>
					</div>
					<div class="slide">
						<h1>Seventh Slide</h1>
						<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident.</p>
						<p><a href="#3" class="link">Check out the third slide &rsaquo;</a></p>
					</div>
				</div>
				<a href="#" class="prev"><img src="images/arrow-prev.png" width="24" height="43" alt="Arrow Prev"></a>
				<a href="#" class="next"><img src="images/arrow-next.png" width="24" height="43" alt="Arrow Next"></a>
			</div>
			<img src="images/example-frame.png" width="739px" height="313px" alt="Example Frame" id="frame">
		</div>
	</div>


            </td>
            <td style="width: 33.3%;">
                
            </td>
        </tr>
        <tr>
            <td style="width: 33.3%;">
                
            </td>
            <td style="width: 900px;">
                
                <%--Table Layout for news boxes--%>

                 <div style="width:900px; float:left; margin-top: -35px;">
            <div style="margin-left: 10px;height:600px; width: 430px; float: left;">
               <div style="width:100%;float:left; background-color: #8F9091;height:20px; border-radius: 2px 2px 2px 2px; padding-top: 5px;">
                <span style="color:White;margin-left:10px; font-weight: bolder;">    Latest Forum News</span>
               </div>
                <div style="width:100%;float:left;height:550px; background-color: #E6E6E6; border-radius: 2px 2px 2px 2px; padding-top: 5px;">
        
               </div>
          </div>
            <div style="margin-left: 10px; height:600px;width: 440px; float: left;">
               <div style="width:100%;float:left; background-color: #8F9091;height:20px; border-radius: 2px 2px 2px 2px; padding-top: 5px;">
              <span style="color:White;margin-left:10px; font-weight: bolder;">  Latest Builds</span>
               </div>
                <div style="width:100%;float:left;height:275px; background-color: #E6E6E6; border-radius: 2px 2px 2px 2px; padding-top: 5px;">
          
               </div>
                <div style="width:100%;float:left; margin-top: 8px; background-color: #8F9091;height:20px; border-radius: 2px 2px 2px 2px;padding-top: 5px;">
              <span style="color:White;margin-left:10px; font-weight: bolder;"> Price Drops</span>
               </div>
                <div style="width:100%;float:left;height:275px; background-color: #E6E6E6; border-radius: 2px 2px 2px 2px; padding-top: 5px;">
          
               </div>
          </div>
       
        </div>




            </td>
            <td style="width: 33.3%;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 33.3%;">
                &nbsp;
            </td>
            <td style="width: 900px;">
                &nbsp;
            </td>
            <td style="width: 33.3%;">
                &nbsp;
            </td>
        </tr>
    </table>


</div>


</asp:Content>
