using Interfaces;
using Classes;
using uzsakovai.Interfaces;

namespace Contractors
{
    public abstract class Contractor
    {
        public bool IsVATPayer { get; set; }
        public Location Location { get; set; }

        public Contractor() { }
        public Contractor(bool isVATPayer, Location location)
        {
            isVATPayer = IsVATPayer;
            location = Location;
        }

        public bool IsInExactLocation(Location location)
        {
            return location == Location;
        }
        public bool IsInContent(string content)
        {
            return Location.Continent == content;
        }

        public bool IsInCountry(string country)
        {
            return Location.Country == country;
        }

     
    }
}