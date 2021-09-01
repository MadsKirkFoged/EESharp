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
            PlottingPowerMassFlow XYChart = new PlottingPowerMassFlow(MyChartXY);



            //Playing around with a normal XY Graph
            XYChart.Plot(Power.FromKilowatts(10), MassFlow.FromKilogramsPerSecond(1));
            XYChart.Plot(Power.FromKilowatts(11), MassFlow.FromKilogramsPerSecond(1.2));
            XYChart.Plot(Power.FromKilowatts(12), MassFlow.FromKilogramsPerSecond(1.6));
            XYChart.Plot(Power.FromKilowatts(13), MassFlow.FromKilogramsPerSecond(1.7));
            XYChart.Plot(Power.FromKilowatts(14), MassFlow.FromKilogramsPerSecond(1.8));
            XYChart.Plot(Power.FromKilowatts(15), MassFlow.FromKilogramsPerSecond(1.9));
            XYChart.Plot(Power.FromKilowatts(17), MassFlow.FromKilogramsPerSecond(2));
            XYChart.Plot(Power.FromKilowatts(21), MassFlow.FromKilogramsPerSecond(2.8));
            XYChart.Plot(Power.FromKilowatts(25), MassFlow.FromKilogramsPerSecond(3));

            //Plotting LOGPH
            LOGPH.PlotLogPH();

            //Creating a new Water Fluid
            Fluid Vand = new Fluid(FluidList.Water);

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


            //LOGPH.Clear();


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
            double σ = 5.6703 * 10E-8; //(W / m2K4)

            Temperature TempOfBlackBody = Temperature.FromDegreesCelsius(20);
            Area AreaOfBody = Area.FromSquareMeters(0.634);

            //q = σ * T^4 * A 
            Power RadiationPower = Power.FromWatts(σ * Math.Pow(TempOfBlackBody.Kelvins, 4) * AreaOfBody.SquareMeters);

            //Display result
            Debug.Print(RadiationPower.ToUnit(PowerUnit.Kilowatt).ToString());



            //Example: Putting code in Class to make it easyier to reuse


            //New instance of a compressor
            Compressor Comp1 = new Compressor(FluidList.Ammonia);

            //Settings for the compressor
            Comp1.DischargePressure = Pressure.FromBars(60);
            Comp1.EtaI = 0.80;
            Comp1.EtaV = 0.80;

            //Giving the compressor en inlet condition
            Comp1.Inlet.UpdatePX(Pressure.FromBars(20), 1);

            //Calling the compressor calculations
            Comp1.DoCalculation();

            //Plotting the result
            LOGPH.Plot(Comp1.Inlet, Comp1.Outlet);




            //Binary search
            //We try to create our own UpdatePS() function using the UpdatePT() function
            //WHY: To demonstrate the capabilities of Binary search


            Fluid my_fluid = new Fluid(FluidList.Ammonia);

            //This is want we are aiming for
            Entropy Aim = Entropy.FromJoulesPerKelvin(1699.7);

            //Setting up Max,mid and min that are going to be used in the Binary search
            Temperature Max = my_fluid.LimitTemperatureMax;
            Temperature Min = my_fluid.LimitTemperatureMin;
            Temperature Mid = Temperature.Zero;


            //Searching loop (setting a max limit of iternation of 20)
            for (int i = 0; i < 20; i++)
            {

                //Calculate the current mid-point
                Mid = Temperature.FromKelvins((Max.Kelvins + Min.Kelvins) / 2);

                //Call our equation using the new mid-point
                my_fluid.UpdatePT(Pressure.FromBars(10), Mid);


                //Check if our midt point is above or below our aim-point
                if (my_fluid.Entropy > Aim)
                    Max = Mid;
                else
                    Min = Mid;

                //Stop if we are almost there
                if (my_fluid.Entropy.Abs() - Aim.Abs() < Entropy.FromJoulesPerKelvin(0.1))
                    break;             
            }




            //Functions
            //If you are doing something more the once, functions are a good way to reuse code

            Temperature P_in = Temperature.FromDegreesCelsius(50);
            Temperature P_Out = Temperature.FromDegreesCelsius(30);
            Temperature S_in = Temperature.FromDegreesCelsius(10);
            Temperature S_Out = Temperature.FromDegreesCelsius(20);

            //Ex of what a function can do
            TemperatureDelta MeanT = ArithmeticMean(P_in, P_Out, S_in, S_Out);





            //Another ex of what a function can do
            //Moving it outside the dome
            my_fluid.UpdatePX(my_fluid.Pressure,0);
            my_fluid.UpdatePH(my_fluid.Pressure, my_fluid.Enthalpy - SpecificEnergy.FromJoulesPerKilogram(10000));

            //Here we move the Fluid object into the dome (if it is outside of it..)
            MoveIntoDome(my_fluid);



            //Creating strings with a '$' is a great way to make a better overview of the string inside the code
            Debug.Print($"This fluid has a density of: {my_fluid.Density} and a temperature of: {my_fluid.Temperature.ToUnit(TemperatureUnit.DegreeCelsius)}");
            //Debug.Print($"It also have a density with many numbers: {my_fluid.Density.ToString("s9")} ");




        }

        private void button1_Click(object sender, EventArgs e)
        {

            //This code is called when the buttom is clicked

            //An ex of how to use and transfer user in/output
            OutputTemperature.UnitValue = InputTemperature.UnitValue;
            outputPressure.UnitValue = inputPressure.UnitValue;
            outputMassFlow.UnitValue = inputMassFlow.UnitValue;
            outputPower.UnitValue = inputPower.UnitValue;
        }

        public void MoveIntoDome(Fluid f1)
        {
            //This function moves a Fluid into the Dome

            //Temporary fluid only used in this function
            Fluid Localfluid = new Fluid();
            Localfluid.Copy(f1);


            //Already inside, do nothing
            if (f1.Quality >= 0 && f1.Quality <= 1)
            {
                return; //This makes the function stop here
            }
            else if (f1.Pressure > f1.CriticalPressure) //Above dome?
            {
                return; //This makes the function stop here
            }


            //Test if it is on the left side
            Localfluid.UpdatePX(Localfluid.Pressure, 0);

            if (f1.Enthalpy <= Localfluid.Enthalpy)
            {
                f1.UpdatePX(f1.Pressure, 0);
            }
            else
            {
                f1.UpdatePX(f1.Pressure, 1);
            }

        }



        public TemperatureDelta ArithmeticMean(Temperature P_in, Temperature P_Out, Temperature S_in, Temperature S_Out)
        {

            //https://www.engineeringtoolbox.com/arithmetic-logarithmic-mean-temperature-d_436.html
            //AMTD = (tpi + tpo) / 2 - (tsi + tso) / 2
            //AMTD = Arithmetic Mean Temperature Difference(oF, oC)
            //tpi = primary inlet temperature(oF, oC)
            //tpo = primary outlet temperature(oF, oC)
            //tsi = secondary inlet temperature(oF, oC)
            //tso = secondary outlet temperature(oF, oC)


            TemperatureDelta AMTD = TemperatureDelta.FromKelvins((P_in.Kelvins + P_Out.Kelvins) / 2 - (S_in.Kelvins + S_Out.Kelvins) / 2);


            return AMTD;

        }

    }
}
