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
    public partial class WebForm1 : System.Web.UI.Page
    {
        CategoryList ctlist = new CategoryList();
        IList<TelevisionsSubCat> televisionssubcat;
 
        protected void Page_Load(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://www.ows.newegg.com/Stores.egg/Categories/5");
            // Set the Method property of the request to POST.
            request.Method = "Get";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            IList<CategoryList> ctlist = new JavaScriptSerializer()
               .Deserialize<IList<CategoryList>>(responseFromServer);



            JsonSerializer serializer = new JsonSerializer();
            object result = JsonConvert.DeserializeObject(responseFromServer);

            IList<TelevisionsNavigation> televisionsnavigation = new JavaScriptSerializer().Deserialize<IList<TelevisionsNavigation>>(responseFromServer);
            
            // Read the content.
            string responseFromServer1 = reader.ReadToEnd();
            //JObject test = JObject.Parse(Convert.ToString( result));


            HtmlGenericControl tvmenu = (HtmlGenericControl)Master.FindControl("content television");
            string InnerHtml = "";
            int ItemCount = 0;

            foreach (var item in televisionsnavigation)
            {
                if (ItemCount < 9)
                {
                    if (ItemCount == 8)
                    {
                        //InnerHtml = InnerHtml + "<li onClick='javascript:display(this)' >" + item.Description + " <li>";
                    }
                    else
                    {

                        //InnerHtml = InnerHtml + "<li onClick='javascript:display(this)' >" + item.Description + " |<li>";
                    }
                }
                ItemCount++;

            }

            //UlSubMenu.InnerHtml = InnerHtml;

            //string Innertext = HidSubItem.Value;



        }
    }
}