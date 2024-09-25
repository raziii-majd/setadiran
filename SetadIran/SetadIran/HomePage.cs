using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetadIran
{
    public class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement samane => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[1]/div/div[2]/div/div/div[1]/div[1]/div/p/div"));
        public IWebElement Send_Offer => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[1]/div/div[6]/div/div/div[1]/div[1]/div/p/div"));

        public IWebElement checkval => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[1]/div/div[2]/div/div/div[2]/div/div/div/div/div/div/div/ul/li[2]/div/div[2]/div/div/input"));

        public IWebElement checkDate => driver.FindElement(By.Id("toSendDeadlineDate"));

        public IWebElement sendfilter => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[1]/div/div[9]/div/div/button"));




        public IList<IWebElement> List_Li_Botton => driver.FindElements(By.ClassName("MuiPaginationItem-circular"));
        public IWebElement Li_Botton(int str) => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[2]/div[3]/nav/ul/li[" + str + "]/button"));



        public IList<IWebElement> List_Items => driver.FindElements(By.ClassName("content"));
        public IWebElement sharh(int i) => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[2]/div[2]/div/div[" + i + "]/div/div/div[2]/div[1]/div/div/div/div/span[2]"));

        public IWebElement dastgahejrayi(int i) => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[2]/div[2]/div/div[" + i + "]/div/div/div[2]/div[2]/div/div/div/span[2]"));

        public IWebElement State(int i) => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[2]/div[2]/div/div["+i+"]/div/div/div[2]/div[3]/div/div[1]/div/span[2]"));

        public IWebElement shomaremoamele(int i) => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[2]/div[2]/div/div[" + i + "]/div/div/div[2]/div[3]/div/div[2]/div/span[2]"));

        public IWebElement dastebandikala(int i) => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[2]/div[2]/div/div[" + i + "]/div/div/div[2]/div[4]/div/div/div/span[2]"));

        public IWebElement ersalpishnehad(int i) => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[2]/div[2]/div/div[" + i + "]/div/div/div[2]/div[5]/div/div[1]/div[2]/div/span"));

        public IWebElement mohletdaryaftersal(int i) => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[2]/div[2]/div/div[" + i + "]/div/div/div[2]/div[5]/div/div[3]/span[3]"));


        public IWebElement eslahat(int i) => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[4]/div/div/div[2]/div[2]/div[2]/div/div[" + i + "]/div/div/div[2]/div[5]/div/div[4]/div[2]/span[3]"));

        //public IWebElement dastgahejrayi2(int i)
        //{
        //    try
        //    {
        //        return driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[3]/div/div/div[2]/div[2]/div[2]/div/div[" + i + "]/div/div/div[2]/div[2]/div/div/div/span[2]"));
        //    }
        //    catch
        //    {

        //        return null;

        //    }
        //}
    }
}
