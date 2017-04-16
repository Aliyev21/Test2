using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Web.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString
        {
            get
            {
                return CreatedDate.ToShortDateString();
            }
        }
    }
}
