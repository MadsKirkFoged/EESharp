using System;
using EESharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpFluids;
using UnitsNet;
using UnitsNet.Units;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //Creating Compressor object
            Compressor Comp = new Compressor(FluidList.Ammonia);

            //Settings for the compressor
            Comp.DischargePressure = Pressure.FromBars(60);
            Comp.EtaI = 0.80;
            Comp.EtaV = 0.80;
            Comp.Inlet.UpdatePX(Pressure.FromBars(20), 1);
            Comp.Inlet.MassFlow = MassFlow.FromKilogramsPerSecond(0.65);

            //Calling the compressor calculations
            Comp.DoCalculation();


            //Test Input case
            Assert.AreEqual(0.80, Comp.EtaI);
            Assert.AreEqual(0.80, Comp.EtaV);
            Assert.AreEqual(20, Comp.Inlet.Pressure.Bars, 0.00001);
            Assert.AreEqual(60, Comp.DischargePressure.Bars, 0.00001);
            Assert.AreEqual(1637090.7774993675, Comp.Inlet.Enthalpy.JoulesPerKilogram, 0.1);
            Assert.AreEqual(0.65, Comp.Inlet.MassFlow.KilogramsPerSecond, 0.00001);



            //Test Output condition
            Assert.AreEqual(1834964.38585952, Comp.Outlet.Enthalpy.JoulesPerKilogram, 10);
            Assert.AreEqual(60, Comp.Outlet.Pressure.Bars, 0.001);
            Assert.AreEqual(0.018348331149592015, Comp.Outlet.VolumeFlow.CubicMetersPerSecond, 0.001);
            Assert.AreEqual(Comp.Inlet.MassFlow, Comp.Outlet.MassFlow);


        }
    }
}
