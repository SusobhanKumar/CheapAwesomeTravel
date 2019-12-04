using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapTravel.Models
{
    public class HotelModel
    {
        public Hotel hotel { get; set; }
        public List<Rate> rates { get; set; }
    }
    public class Hotel
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public int geoId { get; set; }
        public int rating { get; set; }
    }
    public class Rate

    {
        public string rateType { get; set; }
        public string boardType { get; set; }
        public double value { get; set; }
    }
}
