using Classes;
using Interfaces;
using System;
using uzsakovai.Interfaces;

namespace Contractors
{
    public class ServiceProvider : Contractor, IVATPayer, IJuristicPerson
    {
        public ServiceProvider() { }
        public ServiceProvider(bool IsVATPayer, Location Location) : base(IsVATPayer, Location)
        { }

        public double CalculateVAT(Contractor contractor)
        {
            if (!IsVATPayer) return 0;

            if (!contractor.IsInContent("EU")) return 0;

            if (IsInExactLocation(contractor.Location)) return Location.VATinPercent;

            if (contractor.IsInContent("EU"))
            {
                if(contractor.Location != Location)
                {
                    if (!contractor.IsVATPayer) return contractor.Location.VATinPercent;
                    else return 0;
                }
            }

            throw new NotImplementedException();
        }
    }

}