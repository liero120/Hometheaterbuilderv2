using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using EntertainmentBuilder.Model;

namespace Hometheaterbuilderv2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CategoryList ctlist = new CategoryList();

        protected void Page_Load(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://www.ows.newegg.com/Stores.egg/Categories/1");
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
            //JObject test = JObject.Parse(Convert.ToString( result));
        }
    }
}