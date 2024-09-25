using HtmlAgilityPack;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetadIran.Service
{ 
internal class HTMLServices
{

    public static HtmlDocument Loaddoc(string result)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(result);
        return doc;
    }


        public static List<HtmlNode> GetNoPadding(string result)
        {
            var doc = Loaddoc(result);
            var item = doc.DocumentNode.SelectNodes("//div").Where(n => n.HasClass("noPadding")).ToList();
            return item;
        }
        public static HtmlNode Get_Description(string result)
        {
            var doc = Loaddoc(result);
            var item = doc.DocumentNode.SelectNodes("//label").FirstOrDefault();
            return item;
        }
        public static HtmlNode Get_Card_Value(string result)
        {
            var doc = Loaddoc(result);
            var item = doc.DocumentNode.SelectNodes("//span").Where(n => n.HasClass("Card-Value")).FirstOrDefault();
            return item;
        }
        public static List<HtmlNode> GetState(string result)
        {
            var doc = Loaddoc(result);
            var item = doc.DocumentNode.SelectNodes("//div").Where(n => n.HasClass("muirtl-dk11c3")).ToList();
            return item;
        }


        public static HtmlNode GetDateSubmit_Offer(string result)
        {
            var doc = Loaddoc(result);
            var item = doc.DocumentNode.SelectNodes("//div").Where(n => n.HasClass("footerBox-customStyle")).First()?.SelectNodes("//span").Where(n => n.HasClass("Date-Value")).FirstOrDefault();
            return item;
        }


        public static HtmlNode ListDate(string result)
        {

            var doc = Loaddoc(result);
            var item = doc.DocumentNode.SelectNodes("//div").Where(n => n.HasClass("muirtl-k008qs")).FirstOrDefault();
            return item;

        }
        public static List<HtmlNode> Get_ListDeadline_Receive_Documents(string result)
        {

            var doc = Loaddoc(result);
            var item = doc.DocumentNode.SelectNodes("//div").Where(n => n.HasClass("Card-GridContainer-Footer-Box")&& n.HasClass("muirtl-150y25y")  &&n.HasClass("MuiBox-root")).ToList();
            return item;

        }
        public static HtmlNode Get_Reforms(string result)
        {

            var doc = Loaddoc(result);
            var item = doc.DocumentNode.SelectNodes("//div").Where(n => n.HasClass("mobile-centralboard")).FirstOrDefault()?.SelectNodes("//span").Where(n => n.HasClass("Date-Value")).FirstOrDefault(); ;
            return item;

        }

        //------------------------------------------------------------------------------------------------------

        public static HtmlNode GetLable(string result)
        {
            var doc = Loaddoc(result);
            var item = doc.DocumentNode.SelectNodes("//label").Where(n => n.HasClass("MuiTypography-root")).FirstOrDefault();
            return item;
        }




    }
}
