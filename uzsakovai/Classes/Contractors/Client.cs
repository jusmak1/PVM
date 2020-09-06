using Interfaces;
using Classes;
using uzsakovai.Interfaces;

namespace Contractors
{
    public class Client : Contractor, IVATPayer , IJuristicPerson, INaturalPerson
    {
        public Client() { }
        public Client(bool IsVATPayer, Location Location) : base(IsVATPayer, Location)
        { }

        public double CalculateVAT(Contractor contractor)
        {
            throw new System.NotImplementedException();
        }
    }
}