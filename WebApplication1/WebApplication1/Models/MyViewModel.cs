using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MyViewModel
    {
        public int Priority { get; set; }
        public int DateStart { get; set; }
        public int DateEnd { get; set; }

    }


}