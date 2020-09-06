
namespace Classes
{
    public class Location
    {
        public string Continent { get; set; }
        public string Country { get; set; }
        public double VATinPercent { get; set; }

        public static bool operator ==(Location location1, Location Location2)
        {
            return location1.Continent == Location2.Continent &&
                   location1.Country == Location2.Country;
        }

        public static bool operator !=(Location location1, Location Location2)
        {
            return !(location1 == Location2);
        }
    }
}