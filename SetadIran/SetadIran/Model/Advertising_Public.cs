using HtmlAgilityPack;
using SetadIran.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetadIran.Model
{
    [Table("Advertising_Public")]
    public class Advertising_Public
    {
        public Advertising_Public() { }
        public Advertising_Public(HomePage home,int j)
        {
            Description = home.sharh(j).GetAttribute("innerHTML");
            Description = HTMLServices.GetLable(home.sharh(j).GetAttribute("innerHTML")).InnerText;
            Executive_Body = home.dastgahejrayi(j).Text;
            State_City = (home.State(j)).Text;
            Transaction_Number = (home.shomaremoamele(j)).Text;
            Category_Product = (home.dastebandikala(j)).Text;
            Submit_Offer = (home.ersalpishnehad(j)).Text;
            Deadline_Receive_Documents = (home.mohletdaryaftersal(j)).Text;
            Reforms = (home.eslahat(j)).Text;
            RegisterData = DateTime.Now;
        }






        [Key]
        public long Id { get; set; }
    
        public string? Description { get; set; }
        [MaxLength(2000)]
        public string? Executive_Body { get; set; }
        [MaxLength(500)]
        public string? State_City { get; set; }
        [MaxLength(500)]
        public string? Category_Product { get; set; }
        [MaxLength(500)]
        public string? Transaction_Number { get; set; }
        [MaxLength(500)]
        public string? Deadline_Receive_Documents { get; set; }
        [MaxLength(1000)]
        public string? Reforms { get; set; }
        [MaxLength(500)]
        public string? Submit_Offer { get; set; }
        public DateTime? RegisterData { get; set; }

    }
}
