using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Hometheaterbuilderv2.Model;
using System.Text;
using System.Web.Services;

namespace Hometheaterbuilderv2
{
    public partial class TelevisionsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<HtmlAnchor> navs = new List<HtmlAnchor>();
            navs.Add((HtmlAnchor)Master.FindControl("navHTPC"));
            navs.Add((HtmlAnchor)Master.FindControl("navMediaPlayer"));
            navs.Add((HtmlAnchor)Master.FindControl("navAudio"));
            navs.Add((HtmlAnchor)Master.FindControl("navControl"));
            navs.Add((HtmlAnchor)Master.FindControl("navForum"));
            navs.Add((HtmlAnchor)Master.FindControl("navWishList"));
            foreach (HtmlAnchor nav in navs)
            {
                nav.Attributes["class"] += " navbutton-off";
            }

            NeweggAPI api = new NeweggAPI();
            List<SubCategory> televisions = api.GetCategoryByName("Electronics").GetSubCategoryByName("Televisions").GetSubCategories();

            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Attributes.Add("style", "list-style-type:none;");
            for (int i = 0; i < televisions.Count; ++i)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Attributes.Add("onClick", "PageMethods.GetTelevisions(this.id, onGetTelevisions);");
                li.Attributes.Add("id", i.ToString());
                li.InnerHtml = televisions[i].Description;
                ul.Controls.Add(li);
            }
            Master.FindControl("submenu").Controls.Add(ul);
        }

        [WebMethod]
        public static string GetTelevisions(int id)
        {
            NeweggAPI api = new NeweggAPI();
            List<SubCategory> televisions = api.GetCategoryByName("Electronics").GetSubCategoryByName("Televisions").GetSubCategories();
            string json = "{}";
            if (id < televisions.Count)
            {
                ProductQuery products = televisions[id].QueryProducts();
                List<TelevisionProduct> televisionProducts = new List<TelevisionProduct>();
                foreach (ProductListItem p in products.ProductListItems)
                {
                    TelevisionProduct tp = new TelevisionProduct();
                    tp.Title = p.Title;
                    tp.AverageRating = p.AverageRating.ToString();
                    tp.Discount = p.Discount != null ? p.Discount.ToString() : "";
                    tp.OriginalPrice = p.OriginalPrice;
                    tp.FinalPrice = p.FinalPrice;
                    tp.Thumbnail = "<img src='" + p.Image.ThumbnailImagePath + "' />";
                    televisionProducts.Add(tp);
                }
                json = new JavaScriptSerializer().Serialize(televisionProducts);
            }
            return json;
        }
    }

    public class TelevisionProduct
    {
        public string Title { get; set; }
        public string OriginalPrice { get; set; }
        public string Discount { get; set; }
        public string FinalPrice { get; set; }
        public string AverageRating { get; set; }
        public string Thumbnail { get; set; }
    }
}