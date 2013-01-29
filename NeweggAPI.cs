using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;

namespace Hometheaterbuilderv2
{
    public class NeweggAPI
    {
        List<Category> _mainCategories = new List<Category>();
        public NeweggAPI()
        {
            _mainCategories = GetCategories();
        }
        ~NeweggAPI() { }

        List<Category> GetCategories()
        {
            List<Category> json = new List<Category>();
            WebRequest rqstCategories = WebRequest.Create("http://www.ows.newegg.com/Stores.egg/Menus");
            rqstCategories.Method = "GET";
            using (Stream stream = rqstCategories.GetResponse().GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string jsonString = reader.ReadToEnd();
                
                json = new JavaScriptSerializer().Deserialize<List<Category>>(jsonString);
            }
            return json;
        }

        public Category GetCategoryByName(string name)
        {
            foreach(Category cat in _mainCategories) {
                if (cat.Title.ToLower().Equals(name.ToLower()))
                    return cat;
            }
            return null;
        }
    }

    [Serializable]
    public class Category
    {
        string _title;
        string _storeDepartment;
        int _storeId;
        bool _showSeeAllDeals;
        List<SubCategory> _subCategoryCache = null;

        public Category() { }
        public Category(string title, string storeDepartment, int storeId, bool showSeeAllDeals)
        {
            _title = title;
            _storeDepartment = storeDepartment;
            _storeId = storeId;
            _showSeeAllDeals = showSeeAllDeals;
        }

        public List<SubCategory> GetSubCategories()
        {
            if (_subCategoryCache == null)
            {
                WebRequest rqstCategories = WebRequest.Create("http://www.ows.newegg.com/Stores.egg/Categories/" + StoreID);
                rqstCategories.Method = "GET";
                using (Stream stream = rqstCategories.GetResponse().GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    string jsonString = reader.ReadToEnd();

                    _subCategoryCache = new JavaScriptSerializer().Deserialize<List<SubCategory>>(jsonString);
                }
            }
            return _subCategoryCache;
        }

        public SubCategory GetSubCategoryByName(string name)
        {
            foreach (SubCategory subCat in GetSubCategories())
            {
                if (subCat.Description.ToLower().Equals(name.ToLower()))
                    return subCat;
            }
            return null;
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string StoreDepa
        {
            get { return _storeDepartment; }
            set { _storeDepartment = value; }
        }

        public int StoreID
        {
            get { return _storeId; }
            set { _storeId = value; }
        }

        public bool ShowSeeAllDeals
        {
            get { return _showSeeAllDeals; }
            set { _showSeeAllDeals = value; }
        }
    }

    [Serializable]
    public class SubCategory
    {
        string _description;
        int _type;
        int _id;
        int _storeId;
        int _nodeId;
        bool _showSeeAllDeals;

        public SubCategory() { }
        public SubCategory(string description, int type, int id, int storeId, int nodeId, bool showSeeAllDeals)
        {
            _description = description;
            _type = type;
            _id = id;
            _storeId = storeId;
            _nodeId = nodeId;
            _showSeeAllDeals = showSeeAllDeals;
        }

        public List<SubCategory> GetSubCategories()
        {
            List<SubCategory> json = new List<SubCategory>();
            WebRequest rqstCategories = WebRequest.Create("http://www.ows.newegg.com/Stores.egg/Navigation/" + StoreID + "/" + CategoryID + "/" + NodeId);
            rqstCategories.Method = "GET";
            using (Stream stream = rqstCategories.GetResponse().GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string jsonString = reader.ReadToEnd();

                json = new JavaScriptSerializer().Deserialize<List<SubCategory>>(jsonString);
            }
            return json;
        }

        public ProductQuery QueryProducts()
        {
            ProductQuery json = new ProductQuery();
            WebRequest rqstQuery = WebRequest.Create("http://www.ows.newegg.com/Search.egg/Advanced");
            rqstQuery.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(ToJSON());
            rqstQuery.ContentType = "application/x-www-form-urlencoded";
            rqstQuery.ContentLength = byteArray.Length;
            Stream outStream = rqstQuery.GetRequestStream();
            outStream.Write(byteArray, 0, byteArray.Length);
            outStream.Close();
            using (Stream stream = rqstQuery.GetResponse().GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string jsonString = reader.ReadToEnd();

                json = new JavaScriptSerializer().Deserialize<ProductQuery>(jsonString);
            }
            return json;
        }

        string ToJSON()
        {
            return @"{""Description"":""" + Description + @""",""CategoryType"":" + CategoryType + @",""CategoryID"":" + CategoryID + @",""StoreID"":" + StoreID + @",""ShowSeeAllDeals"":" + ShowSeeAllDeals.ToString().ToLower() + @",""NodeId"":" + NodeId + @"}";
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int CategoryType
        {
            get { return _type; }
            set { _type = value; }
        }

        public int CategoryID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int StoreID
        {
            get { return _storeId; }
            set { _storeId = value; }
        }

        public bool ShowSeeAllDeals
        {
            get { return _showSeeAllDeals; }
            set { _showSeeAllDeals = value; }
        }

        public int NodeId
        {
            get { return _nodeId; }
            set { _nodeId = value; }
        }
    }

    public class CoremetricsInfo
    {
        public string CategoryID { get; set; }
        public object ProductName { get; set; }
        public string PageID { get; set; }
        public object Brand { get; set; }
    }

    public class ReviewSummary
    {
        public int Rating { get; set; }
        public string TotalReviews { get; set; }
    }

    public class Image
    {
        public object ItemNumber { get; set; }
        public object Title { get; set; }
        public string FullPath { get; set; }
        public string ThumbnailImagePath { get; set; }
        public string SmallImagePath { get; set; }
        public string PathSize35 { get; set; }
        public string PathSize60 { get; set; }
        public string PathSize100 { get; set; }
        public string PathSize125 { get; set; }
        public string PathSize180 { get; set; }
        public string PathSize300 { get; set; }
        public string PathSize640 { get; set; }
    }

    public class ProductListItem
    {
        public bool IsCellPhoneItem { get; set; }
        public bool ShowOriginalPrice { get; set; }
        public string MailInRebateText { get; set; }
        public bool IsComboBundle { get; set; }
        public int ProductStockType { get; set; }
        public string MappingFinalPrice { get; set; }
        public bool IsFeaturedItem { get; set; }
        public bool IsMicrosoftDownloadItem { get; set; }
        public bool IsProductKeyOnly { get; set; }
        public string Title { get; set; }
        public string OriginalPrice { get; set; }
        public object Discount { get; set; }
        public string FinalPrice { get; set; }
        public bool FreeShippingFlag { get; set; }
        public string Model { get; set; }
        public ReviewSummary ReviewSummary { get; set; }
        public Image Image { get; set; }
        public string SellerName { get; set; }
        public string ParentItem { get; set; }
        public string SellerId { get; set; }
        public int ShipByNewegg { get; set; }
        public int ItemGroupID { get; set; }
        public int ItemOwnerType { get; set; }
        public int NumberOfReviews { get; set; }
        public int AverageRating { get; set; }
        public bool Instock { get; set; }
        public object XmlSpec { get; set; }
        public object WarrantyInfo { get; set; }
        public string NeweggItemNumber { get; set; }
        public string PromotionInfo { get; set; }
        public bool InstockForCombo { get; set; }
        public DateTime ETA { get; set; }
        public bool IsInPMCC { get; set; }
        public bool CanAddToCart { get; set; }
        public object StrCartImg { get; set; }
        public object StrAlt { get; set; }
        public object StrAddItem { get; set; }
        public object StaticText { get; set; }
        public int InstantSaving { get; set; }
        public bool HasMappingPrice { get; set; }
        public int UnitPrice { get; set; }
        public object BrandInfo { get; set; }
        public int LimitQuantity { get; set; }
        public bool IsShellShockerItem { get; set; }
        public string PromotionText { get; set; }
        public int ItemMapPriceMarkType { get; set; }
        public bool IsHot { get; set; }
        public bool IsPreLaunch { get; set; }
        public string ItemNumber { get; set; }
    }

    public class PaginationInfo
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
    }

    public class ProductQuery
    {
        public object NavigationContentList { get; set; }
        public object RelatedLinkList { get; set; }
        public CoremetricsInfo CoremetricsInfo { get; set; }
        public bool IsAllComboBundle { get; set; }
        public bool CanBeCompare { get; set; }
        public int MasterComboStoreId { get; set; }
        public int SubCategoryId { get; set; }
        public bool HasDeactivatedItems { get; set; }
        public bool HasHasSimilarItems { get; set; }
        public int SearchProvider { get; set; }
        public int SearchResultType { get; set; }
        public List<ProductListItem> ProductListItems { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}