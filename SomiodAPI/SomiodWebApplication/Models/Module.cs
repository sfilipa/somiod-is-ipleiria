using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace SomiodWebApplication.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Res_type { get; set; }
        public DateTime Creation_dt { get; set; }
        public int Parent { get; set; }
        public List<Data> Data { get; set; }

    }
}