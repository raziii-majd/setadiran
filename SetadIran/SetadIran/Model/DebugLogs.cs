using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetadIran.Model
{
    [Table("DebugLogs")]
    public class DebugLog
    {
        [Key]
        public int Id { get; set; }
        public string Controller { get; set; }
        public string API { get; set; }
        public bool IsError { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Appliocation { get; set; }
        public DateTime ServerDateTime { get; set; }
        public string Type { get; set; }
    }
}
