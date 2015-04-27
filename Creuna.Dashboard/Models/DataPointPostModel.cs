using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Creuna.Dashboard.Models
{
    public class DataPointPostModel<T>
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public T Value { get; set; }
    }
}