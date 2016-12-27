using System;
using System.Collections.Generic;

namespace IpStorage.Models
{
    public partial class Visitors
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public string Browser { get; set; }
        public string ReffererUrl { get; set; }
    }
}
