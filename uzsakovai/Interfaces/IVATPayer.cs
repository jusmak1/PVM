using Contractors;
using System;
using System.Collections.Generic;
using System.Text;

namespace uzsakovai.Interfaces
{
    interface IVATPayer
    {
        public double CalculateVAT(Contractor contractor);
    }
}
