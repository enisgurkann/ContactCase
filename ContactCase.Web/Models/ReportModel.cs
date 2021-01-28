using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.Web.Models
{
    public class ReportModel
    {
        public Guid Id { get; set; }
        public string Tag { get; set; }
        public int Count { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
