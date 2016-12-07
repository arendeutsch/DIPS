using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DIPS.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}