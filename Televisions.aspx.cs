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

namespace Hometheaterbuilderv2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl ReplaceTelvision = (HtmlGenericControl)Master.FindControl("ReplaceTelvision");
            ReplaceTelvision.Attributes.Add("style", "background:url(Images/Menu-Bar---TV-ImgeTest.jpg);height:85px;width:110px; margin-left: 20px;margin-top: 10px;");

            NeweggAPI api = new NeweggAPI();

            List<SubCategory> televisions = api.GetCategoryByName("Electronics").GetSubCategoryByName("Televisions").GetSubCategories();

            UlSubMenu.Attributes.Add("style","list-style-type:none;");
            int ItemCount = 0;
            foreach (SubCategory tv in televisions)
            {
                if (ItemCount < 9)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("onClick", "javascript:display(this)");
                    li.Attributes.Add("style", "display:inline;");
                    li.InnerHtml = tv.Description;
                    if (ItemCount != 8)
                        li.InnerHtml += " |";
                    UlSubMenu.Controls.Add(li);
                }
                ItemCount++;
            }

            ProductQuery products = televisions[0].QueryProducts();

            Categorygrid.DataSource = products.ProductListItems;
            Categorygrid.DataBind();
        }
    }
}