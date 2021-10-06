using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringUnits;
using SharpFluids;

namespace EESharp
{
   public class Condenser
    {
        public Fluid Inlet { get; set; }
        public Fluid Outlet { get; set; }

       public Pressure DischargePressure { get; set; }



        public Condenser(FluidList fluidType)
        {
            //Setting the inlet and outlet to the selected fluid type
            Inlet = new Fluid(fluidType);
            Outlet = new Fluid(fluidType);
        }


        public void DoCalculation()
        {
            Outlet.Copy(Inlet);

            //Update to H2s state
            Outlet.UpdatePX(Inlet.Pressure, 0);
        }



    }
}
