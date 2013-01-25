using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using Hometheaterbuilderv2.Model;
using System.Text;

namespace Hometheaterbuilderv2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        IList<CategoryList> ctlist;
        IList<TelevisionsSubCat> televisionssubcat;

        protected void Page_Load(object sender, EventArgs e)
        {
            // HtmlGenericControl divControl = new HtmlGenericControl("headerorange"); 
            //
            // HtmlGenericControl UlSubMenu = (HtmlGenericControl)Page .FindControl("UlSubMenu");
            //HtmlGenericControl para = (HtmlGenericControl)para.Controls. ("UlSubMenu");
            //UlSubMenu.Controls.

            HtmlGenericControl currentMenu = (HtmlGenericControl)Master.FindControl("headerImageTelevision");
            currentMenu.Style.Add("display", "none");
            HtmlGenericControl HeadOrange = (HtmlGenericControl)Master.FindControl("HeadOrange");
            HeadOrange.Style.Add("display", "none");
            HtmlGenericControl ReplaceTelvision = (HtmlGenericControl)Master.FindControl("ReplaceTelvision");
            ReplaceTelvision.Attributes.Add("style", "background:url(Images/Menu-Bar---TV-ImgeTest.jpg);height:85px;width:110px; margin-left: 20px;margin-top: 10px;");
            HtmlGenericControl TleTextDiv = (HtmlGenericControl)Master.FindControl("TleTextDiv");
            TleTextDiv.Style.Add("display", "Inline");

            WebRequest request = WebRequest.Create("http://www.ows.newegg.com/Stores.egg/Categories/1");
            // Set the Method property of the request to POST.
            request.Method = "Get";
            WebResponse response = request.GetResponse();
            //provide a responde fron URI
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            ctlist = new JavaScriptSerializer().Deserialize<IList<CategoryList>>(responseFromServer);

            //foreach (var item in ctlist)
            //{

            //}
            //Categorygrid.DataSource = ctlist.ToList();
            //Categorygrid.DataBind();
            WebRequest request1 = WebRequest.Create("http://www.ows.newegg.com/Stores.egg/Navigation/10/264/6946");
            // Set the Method property of the request to POST.
            request1.Method = "Get";
            WebResponse response1 = request1.GetResponse();
            Stream dataStream1 = response1.GetResponseStream();
            StreamReader reader1 = new StreamReader(dataStream1);
            // Read the content.
            string responseFromServer1 = reader1.ReadToEnd();
            IList<TelevisionsNavigation> televisionsnavigation = new JavaScriptSerializer().Deserialize<IList<TelevisionsNavigation>>(responseFromServer1);
            string InnerHtml = "";
            int ItemCount = 0;
            foreach (var item in televisionsnavigation)
            {
                if (ItemCount < 9)
                {
                    if (ItemCount == 8)
                    {
                        InnerHtml = InnerHtml + "<li onClick='javascript:display(this)' >" + item.Description + " <li>";
                    }
                    else
                    {

                        InnerHtml = InnerHtml + "<li onClick='javascript:display(this)' >" + item.Description + " |<li>";
                    }
                }
                ItemCount++;

            }
            UlSubMenu.InnerHtml = InnerHtml;

            string Innertext = HidSubItem.Value;
            string postData = "";
            if (Innertext == "")
            {
                postData = @"{""Description"": ""LED TV"", 
   ""CategoryType"":1,""CategoryID"":798,""StoreID"":10,""ShowSeeAllDeals"":false,""NodeId"":9260
  }";
                subText.InnerHtml = "Televisions > LED TV";
            }
            else
            {
                foreach (var item in televisionsnavigation)
                {
                    if (item.Description == Innertext.Trim())
                    {

                        //postData = @"{""Description"": ";
                        //string strt=    ",""CategoryType"":1,""CategoryID"":798,""StoreID"":10,""ShowSeeAllDeals"":false,""NodeId"":9260}";
                        postData = @"{""Description"":""" + item.Description + @""", ""CategoryType"":1,""CategoryID"":" + item.CategoryID + @",""StoreID"":10,""ShowSeeAllDeals"":false,""NodeId"":" + item.NodeId + @"}";
                        subText.InnerHtml = "Televisions > " + item.Description;
                        //postData = "@"{"""
                        //    postData=postData + item.Description 
                        //        postData=postData 


                        //   postData = "{""Description"":"+ postData  + "";           //+item.Description +"";
                        //,'CategoryType':1,'CategoryID':" + item.CategoryID + "'StoreID':10,'ShowSeeAllDeals':false,'NodeId':" + item.NodeId + "}";
                    }

                }

            }
            WebRequest request2 = WebRequest.Create("http://www.ows.newegg.com/Search.egg/Advanced");
            // Set the Method property of the request to POST.
            request2.Method = "POST";
            // Create POST data and convert it to a byte array.
            //   string postData = "{'SubCategoryId': 147,'NValue': '','StoreDepaId': 1,'NodeId': 7611,'BrandId': -1,'PageNumber': 1,'CategoryId': 17}";


            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //utf8 is language format
            request2.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request2.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream2 = request2.GetRequestStream();
            // Write the data to the request stream.
            dataStream2.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream2.Close();
            // Get the response.
            WebResponse response2 = request2.GetResponse();
            dataStream2 = response2.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader2 = new StreamReader(dataStream2);
            // Read the content.
            string responseFromServer2 = reader2.ReadToEnd();
            string sub = responseFromServer2.Substring(366);
            int lastIndex = sub.LastIndexOf("PaginationInfo") - 3;
            string Stringcollation = "[" + sub.Substring(0, lastIndex) + "]";
            televisionssubcat = new JavaScriptSerializer().Deserialize<IList<TelevisionsSubCat>>(Stringcollation);
            Categorygrid.DataSource = televisionssubcat.ToList();
            Categorygrid.DataBind();
        }
    }
}