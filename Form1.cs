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
using SharpFluids;
using UnitsNet;
using UnitsNet.Units;

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
            LOGPH.PlotLogPH();


            //Compressor calculations
            Fluid CompressorInlet = new Fluid(FluidList.Ammonia);
            Fluid CompressorOutlet = new Fluid(FluidList.Ammonia);
            Fluid CompressorOutletH2s = new Fluid(FluidList.Ammonia);

            //Giving the inlet guess on its condition
            CompressorInlet.UpdatePX(Pressure.FromBars(5), 1);
            LOGPH.Plot(CompressorInlet);

            //Calculating the outlet af compressor

            //This is h1
            SpecificEnergy h1 = CompressorInlet.Enthalpy;

            //Updating output refrigerant with the high pressure and the entropy(from input)
            CompressorOutletH2s.UpdatePS(Pressure.FromBars(30), CompressorInlet.Entropy);
            LOGPH.Plot(CompressorOutletH2s);

            //Setting h2s from output-refrigerant
            SpecificEnergy H2s = CompressorOutletH2s.Enthalpy;

            //Compressor calculation
            SpecificEnergy h2 = ((H2s - h1) / 0.80) + h1;

            //Compressor outlet condition
            CompressorOutlet.UpdatePH(CompressorOutletH2s.Pressure, h2);
            LOGPH.Plot(CompressorOutlet);

            //Plot Compressor as lines
            LOGPH.Plot(CompressorInlet, CompressorOutlet);



            //Creating a condensator
            Fluid CondenserInlet = new Fluid(FluidList.Ammonia);
            Fluid CondenserOutlet = new Fluid(FluidList.Ammonia);

            //The inlet of the condenser is the same as compressor outlet
            CondenserInlet.Copy(CompressorOutlet);


            //Condensator outlet
            CondenserOutlet.UpdatePX(CondenserInlet.Pressure, 0);

            //Plot Condensator as lines
            LOGPH.Plot(CondenserInlet, CondenserOutlet);



            //Creating a Expansion valve
            Fluid ValveInlet = new Fluid(FluidList.Ammonia);
            Fluid ValveOutlet = new Fluid(FluidList.Ammonia);


            //The inlet of the valve is the same as condens outlet
            ValveInlet.Copy(CondenserOutlet);

            //Expansion valve drops the pressure down but keeps the Enthalpy
            ValveOutlet.UpdatePH(CompressorInlet.Pressure, ValveInlet.Enthalpy);

            //Plot Valve as lines
            LOGPH.Plot(ValveInlet, ValveOutlet);



            //Creating an Evaporator
            Fluid EvaporatorInlet = new Fluid(FluidList.Ammonia);
            Fluid EvaporatorOutlet = new Fluid(FluidList.Ammonia);

            //The inlet of the valve is the same as condens outlet
            EvaporatorInlet.Copy(ValveOutlet);

            //Creating a superheat of 10°C
            EvaporatorOutlet.UpdatePT(EvaporatorInlet.Pressure, EvaporatorInlet.Tsat + TemperatureDelta.FromKelvins(10));


            //Plot Valve as lines
            LOGPH.Plot(EvaporatorInlet, EvaporatorOutlet);


            //Telling the compressor that it is connected to the evaporator
            CompressorInlet.Copy(EvaporatorOutlet);









            //Calculations


            //Can we find the power input to the compressor?

            //Setting a massflow
            MassFlow MassflowCompressor = MassFlow.FromKilogramsPerSecond(0.45);

            //Power = Massflow * (H2 - H1)
            Power PowerToCompressor = MassflowCompressor * (CompressorOutlet.Enthalpy - CompressorInlet.Enthalpy);

            //Print it to Debug screen without telling it in what unit we want to see it
            Debug.Print(PowerToCompressor.ToString());

            //Giving it a unit to display it in
            Debug.Print(PowerToCompressor.ToUnit(PowerUnit.Kilowatt).ToString());


            ///What if we want to calculation an equation that the unit-system cant handle?

            //!Beware!: Normally you should let the UnitSystem handle the units because it checks the units for you
            // and it puts out an error if you have messed up the units.
            // Sometimes the unitsystem give you an error even though the equation is correct and then you have to
            // do this to bypass the unitsystem and then you have to handle the units yourself!

            //The Stefan - Boltzmann Constant
            double σ = 5.6703*10E-8; //(W / m2K4)

            Temperature TempOfBlackBody = Temperature.FromDegreesCelsius(20);
            Area AreaOfBody = Area.FromSquareMeters(0.634);

            //q = σ * T^4 * A 
            Power RadiationPower = Power.FromWatts(σ * Math.Pow(TempOfBlackBody.Kelvins, 4) * AreaOfBody.SquareMeters);

            //Display result
            Debug.Print(RadiationPower.ToUnit(PowerUnit.Kilowatt).ToString());

        }


    }
}
