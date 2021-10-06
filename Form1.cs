using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineeringUnits;
using EngineeringUnits.Units;
using SharpFluids;


namespace EESharp
{
    public partial class Form1 : Form
    {

       





        public Form1()
        {

            //Starting up frontpage
            InitializeComponent();

            //Starting LOGPH diagram
            Plot_LogPH LOGPH = new Plot_LogPH(MyChart, FluidList.Ammonia);


            //Setting up class's
            Compressor Comp = new Compressor(FluidList.Ammonia);
            Condenser Cond = new Condenser(FluidList.Ammonia);
            ExpValve Valve = new ExpValve(FluidList.Ammonia);
            Evaporator Evap = new Evaporator(FluidList.Ammonia);


            //Connecting the units
            Cond.Inlet = Comp.Outlet;
            Valve.Inlet = Cond.Outlet;
            Evap.Inlet = Valve.Outlet;
            Comp.Inlet = Evap.Outlet;

            //Settings for the compressor
            Comp.DischargePressure = Pressure.FromBars(60);
            Comp.EtaI = 0.80;
            Comp.EtaV = 0.80;

            //Settings for the Valve
            Valve.EvapPressure = Pressure.FromBars(10);

            //Settings for the Valve
            Evap.SuperHeat = Temperature.FromKelvins(10);


            for (int i = 0; i < 10; i++)
            {

                Comp.DoCalculation();
                Cond.DoCalculation();
                Valve.DoCalculation();
                Evap.DoCalculation();

            }

            //Drawing the dome
            LOGPH.PlotLogPH();

            LOGPH.Plot(Comp.Inlet, Comp.Outlet);
            LOGPH.Plot(Cond.Inlet, Cond.Outlet);
            LOGPH.Plot(Valve.Inlet, Valve.Outlet);
            LOGPH.Plot(Evap.Inlet, Evap.Outlet);



        }

      

       



        

    }
}
