using System;
using System.Collections.Generic;
using System.Text;

namespace WebJobsSample.Models
{
    public class WorkItem
    {
        public string Id { get; set; }

        public int Priority { get; set; }

        public string Region { get; set; }

        public int Category { get; set; }

        public string Description { get; set; }
    }
}
