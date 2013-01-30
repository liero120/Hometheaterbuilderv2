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
            HtmlGenericControl ReplaceTelvision = (HtmlGenericControl)Master.FindControl("ReplaceTelvision");
            ReplaceTelvision.Attributes.Add("style", "background:url(Images/Menu-Bar---TV-ImgeTest.jpg);height:85px;width:110px; margin-left: 20px;margin-top: 10px;");

            NeweggAPI api = new NeweggAPI();
            List<SubCategory> televisions = api.GetCategoryByName("Electronics").GetSubCategoryByName("Televisions").GetSubCategories();

            UlSubMenu.Attributes.Add("style","list-style-type:none;");
            int itemCount = 0;
            foreach (SubCategory tv in televisions)
            {
                if (itemCount < 9)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("onClick", "PageMethods.GetTelevisions(this.id, onGetTelevisions);");
                    li.Attributes.Add("style", "display:inline;");
                    li.Attributes.Add("id", itemCount.ToString());
                    li.InnerHtml = tv.Description;
                    if (itemCount != 8)
                        li.InnerHtml += " |";
                    UlSubMenu.Controls.Add(li);
                }
                itemCount++;
            }
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
    }
}