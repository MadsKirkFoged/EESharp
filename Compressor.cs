using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpFluids;
using UnitsNet;

namespace EESharp
{
   public class Compressor
    {
        public Fluid Inlet { get; set; }
        public Fluid Outlet { get; set; }

       public Pressure DischargePressure { get; set; }

        public double EtaI { get; set; }
        public double EtaV { get; set; }


        public Compressor(FluidList fluidType)
        {
            //Setting the inlet and outlet to the selected fluid type
            Inlet = new Fluid(fluidType);
            Outlet = new Fluid(fluidType);


        }


        public void DoCalculation()
        {

            Outlet.Copy(Inlet);

            //Update to H2s state
            Outlet.UpdatePS(DischargePressure, Inlet.Entropy);

            //Calculating H2
            SpecificEnergy H2 = ((Outlet.Enthalpy - Inlet.Enthalpy) / EtaI) + Inlet.Enthalpy;

            //Setting the outlet condition to H2
            Outlet.UpdatePH(DischargePressure, H2);
        }



    }
}
