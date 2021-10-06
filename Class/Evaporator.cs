using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringUnits;
using SharpFluids;

namespace EESharp
{
   public class Evaporator
    {
        public Fluid Inlet { get; set; }
        public Fluid Outlet { get; set; }

       public Temperature SuperHeat { get; set; }



        public Evaporator(FluidList fluidType)
        {
            //Setting the inlet and outlet to the selected fluid type
            Inlet = new Fluid(fluidType);
            Outlet = new Fluid(fluidType);
        }


        public void DoCalculation()
        {

            Outlet.Copy(Inlet);

            //Update to H2s state
            Outlet.UpdatePT(Inlet.Pressure, Inlet.Tsat + SuperHeat);
        }



    }
}
