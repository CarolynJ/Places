using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlacesMVCpractice.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}