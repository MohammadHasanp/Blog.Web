using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Entyties
{
    public class BaseEntity<TKey>
    {
        [Key]
        public TKey ID { get; set; }
        public DateTime Time  { get; set; }
        public bool IsDelete { get; set; }
    }
}
