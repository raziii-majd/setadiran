using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SetadIran.Context;
using SetadIran.Model;
using SetadIran.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetadIran
{
    public class Operations
    {

        public static void SetadIranCollector()
        {
            while (true)
            {
                var hourOfday = DateTime.Now.Hour;
                DayOfWeek dayOfWeek = DateTime.Today.DayOfWeek;
                if (hourOfday > 18 || hourOfday < 7 || dayOfWeek == DayOfWeek.Friday)
                {
                    Thread.Sleep(10000);
                    continue;
                }
                var Driver = new Driver();
                Driver.wait = new WebDriverWait(Driver.driver, new TimeSpan(0, 0, Driver.timeout));
                try
                {
                    Driver.OpenSite();
                    LoggingService.Log("site opened!", "Food_FarsiCollector", "Food_FarsiCollector", false, "site opened", "", "Info");
                    HomePage home = new HomePage(Driver.driver);
                    home.samane.Click();
                    home.checkval.Click();
                    home.Send_Offer.Click();
                    home.checkDate.SendKeys(GregorianToPersian(DateTime.Now));
                    home.sendfilter.Click();
                    var List_Li_Botton = home.List_Li_Botton;
                    int LisCount = home.List_Li_Botton.Count();
                    string Lislengthstr = home.Li_Botton(LisCount-2).Text;
                    int Lislength = Convert.ToInt32(Lislengthstr);
                    var list_Item = home.List_Items;

                    var setaddb = new MainContext();

                    IWebElement li;
                    for (var i = 1; i <= Lislength; i++)
                    {
                        if (i == 1 && Lislength >= 3)
                        {
                             li = home.Li_Botton(i + 2);
                            
                        }
                        else if (i == 2 && Lislength >= 4)
                        {
                             li = home.Li_Botton(i + 2);
                            
                        }
                        else if (i == 3 && Lislength >= 5)
                        {
                             li = home.Li_Botton(i + 2);
                          
                        }
                        else if (i == 4 && Lislength >= 6)
                        {
                             li = home.Li_Botton(i + 2);
                            
                        }
                        else if (i == 5 || Lislength - 2 >= i)
                        {
                             li = home.Li_Botton(7);
                           
                        }
                        else if (i == Lislength - 1)
                        {
                             li = home.Li_Botton(8);
                            
                        }
                        else if (i == Lislength )
                        {
                             li = home.Li_Botton(9);
                           
                        }
                        else
                        {
                            break;
                        }
                        li.Click();
                      

                        for (var j = 1; j <= list_Item.Count; j++)
                        {
                            var temp = new Advertising_Public(home,j);
                            if (setaddb.Advertising_Public.Where(p => p.Description == temp.Description && p.Executive_Body == temp.Executive_Body).FirstOrDefault() == null)
                            {
                                setaddb.Add(temp);
                                setaddb.SaveChanges();
                            }
                        }

                        //foreach (var item in list_Item)
                        //{
                        //    Advertising_Public temp = new Advertising_Public();
                        //    var list_4_nopading = HTMLServices.GetNoPadding(item.GetAttribute("innerHTML"));
                        //    temp.Description = HTMLServices.Get_Description(list_4_nopading[0].InnerHtml).InnerText;
                        //    temp.Executive_Body = HTMLServices.Get_Card_Value(list_4_nopading[1].InnerHtml).InnerText;
                        //    var List_State = HTMLServices.GetState(list_4_nopading[2].InnerHtml);
                        //    temp.State_City = HTMLServices.Get_Card_Value(List_State[0].InnerHtml).InnerText;
                        //    temp.Transaction_Number = HTMLServices.Get_Card_Value(List_State[1].InnerHtml).InnerText;
                        //    temp.Category_Product = HTMLServices.Get_Card_Value(list_4_nopading[3].InnerHtml).InnerText;


                        //    temp.Submit_Offer = HTMLServices.GetDateSubmit_Offer(item.GetAttribute("innerHTML")).InnerText;
                        //    var ListDeadline= HTMLServices.ListDate(item.GetAttribute("innerHTML"));
                        //    var listReceive_Documents = HTMLServices.Get_ListDeadline_Receive_Documents(ListDeadline.InnerHtml);
                        //    temp.Deadline_Receive_Documents = HTMLServices.Get_Card_Value(listReceive_Documents[0].InnerHtml).InnerText;
                        //    temp.Reforms = HTMLServices.Get_Card_Value(listReceive_Documents[1].InnerHtml).InnerText;
                        //    setaddb.Add(temp);
                        //    setaddb.SaveChanges();

                        //}


                    }

                }
                catch (Exception e)
                {
                    LoggingService.Log("fetching data failed with exception: ", "DataCollector", "Food_FarsiCollector", true, "fetching data failed", "" + e, "error");
                }
                try { Driver.driver.Close(); } catch { }
                Driver.driver.Quit();
                try { Driver.driver.Close(); } catch { }
            }
        }



        static public string GregorianToPersian(DateTime? date, int format = 0)
        {
             PersianCalendar pc = new PersianCalendar();

            try
            {
                switch (format)
                {
                    case 0:
                        return (date == null) ? null : string.Format("{0}-{1}-{2} {3}", pc.GetYear(date ?? new DateTime()), pc.GetMonth(date ?? new DateTime()).ToString().PadLeft(2, '0'), pc.GetDayOfMonth(date ?? new DateTime()).ToString().PadLeft(2, '0'), (date ?? new DateTime()).TimeOfDay.ToString(@"hh\:mm\:ss"));
                    case 1:
                        return (date == null) ? null : string.Format("{0}-{1}-{2}", pc.GetYear(date ?? new DateTime()), pc.GetMonth(date ?? new DateTime()).ToString().PadLeft(2, '0'), pc.GetDayOfMonth(date ?? new DateTime()).ToString().PadLeft(2, '0'));
                    default:
                        return (date == null) ? null : string.Format("{0}", (date ?? new DateTime()).TimeOfDay.ToString(@"hh\:mm\:ss"));
                }
            }
            catch
            {
                return "";
            }
        }
    }
}
