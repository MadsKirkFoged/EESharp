using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringUnits;
using SharpFluids;

namespace EESharp
{
   public class ExpValve
    {
        public Fluid Inlet { get; set; }
        public Fluid Outlet { get; set; }

       public Pressure EvapPressure { get; set; }



        public ExpValve(FluidList fluidType)
        {
            //Setting the inlet and outlet to the selected fluid type
            Inlet = new Fluid(fluidType);
            Outlet = new Fluid(fluidType);
        }


        public void DoCalculation()
        {

            Outlet.Copy(Inlet);

            Outlet.UpdatePH(EvapPressure, Inlet.Enthalpy);
        }



    }
}
