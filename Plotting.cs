using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitsNet;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.WinForms;
using System.Windows.Media;
using System.Diagnostics;
using System.Globalization;
using SharpFluids;



namespace EESharp
{
    public class Plot_LogPH
    {


        private  Pressure GraphPMax, GraphPMin;

        private  SpecificEnergy GraphHMax, GraphHMin;
        private  LiveCharts.WinForms.CartesianChart MyChart;
        private  int counter;
        private SharpFluids.FluidList RefType;


        public Plot_LogPH(LiveCharts.WinForms.CartesianChart myChart, SharpFluids.FluidList refType)
        {
            //Settings
            MyChart = myChart;
            RefType = refType;
            Fluid Dome = new Fluid(RefType);


            //Finding the zoom on the X-axis
            Dome.UpdatePX(Dome.P_Min, 0);
            GraphHMin = Dome.Enthalpy * 0.5;
            Dome.UpdatePX(Dome.P_Min, 1);            
            GraphHMax = Dome.Enthalpy * 1.4;

            //Rounds to nearest 50
            GraphHMin = SpecificEnergy.FromJoulesPerKilogram(Math.Round(GraphHMin.JoulesPerKilogram / 50) * 50);    



            //Creating Y Axis
            MyChart.AxisY.Add(new LogarithmicAxis
            {
                LabelFormatter = value => (Math.Pow(10, value)).ToString("N0"),
                Base = 10,//Note that Max and min values are based on the 'Base = 10'!
                MaxValue = 2.5, //2.5, 
                MinValue = 0, //1    
                Title = "Pressure - [" + string.Format(new CultureInfo("en-US"), "{0:a}", GraphPMax.ToUnit(UnitsNet.Units.PressureUnit.Bar)) + "]",

                Separator = new Separator
                {
                    Stroke = Brushes.LightGray,
                    Step = Math.Log10(10) / 2,
                    StrokeThickness = 1,
                },

            });



            //Creating X Axis
            MyChart.AxisX.Add(new Axis
            {
                LabelFormatter = value => value.ToString("N0"),
                MaxValue = GraphHMax.ToUnit(UnitsNet.Units.SpecificEnergyUnit.KilojoulePerKilogram).Value,
                MinValue = GraphHMin.ToUnit(UnitsNet.Units.SpecificEnergyUnit.KilojoulePerKilogram).Value,
                Title = "Enthalpy - [" + string.Format(new CultureInfo("en-US"), "{0:a}", GraphHMax.ToUnit(UnitsNet.Units.SpecificEnergyUnit.KilojoulePerKilogram)) + "]",
                Separator = new Separator
                {
                    Stroke = Brushes.LightGray,
                    Step = 100,
                    StrokeThickness = 0.3,
                },
            });

           //Settings
            MyChart.DataTooltip = null;
            MyChart.DisableAnimations = true;
            MyChart.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            MyChart.Hoverable = false;
        }

        public void Plot(Fluid input, Fluid output)
        {

            var Results = new ChartValues<ObservablePoint>();


            Results.Add(new ObservablePoint
            {
                X = input.Enthalpy.KilojoulesPerKilogram,
                Y = input.Pressure.Bars,
            });


            Results.Add(new ObservablePoint
            {
                X = output.Enthalpy.KilojoulesPerKilogram,
                Y = output.Pressure.Bars
            });


            //configure the chart to plot ObservablePoint
            var mapper = Mappers.Xy<ObservablePoint>()
                .X(point => point.X)
                .Y(point => Math.Log10(point.Y));


            var series = new LineSeries
            {
                Configuration = mapper,
                Values = Results,
                Fill = System.Windows.Media.Brushes.Transparent,
                ToolTip = null,
                DataLabels = false,
                LineSmoothness = 0,
                Stroke = Brushes.Red,
                StrokeThickness = 3,
            };

            if (input.Pressure > Pressure.Zero && output.Pressure > Pressure.Zero)
            {
                MyChart.Series.Add(series);

            }
        }

        public void Plot(Fluid input)
        {

            var Results = new ChartValues<ObservablePoint>();


            Results.Add(new ObservablePoint
            {
                X = input.Enthalpy.KilojoulesPerKilogram,
                Y = input.Pressure.Bars,
            });


            //configure the chart to plot ObservablePoint
            var mapper = Mappers.Xy<ObservablePoint>()
                .X(point => point.X)
                .Y(point => Math.Log10(point.Y));


            var series = new LineSeries
            {
                Configuration = mapper,
                Values = Results,
                Fill = System.Windows.Media.Brushes.Transparent,
                ToolTip = null,
                DataLabels = false,
                LineSmoothness = 0,
                Stroke = Brushes.Red,
                StrokeThickness = 3,
            };

            if (input.Pressure > Pressure.Zero)
            {
                MyChart.Series.Add(series);

            }
        }

        public  void Clear()
        {



            for (int i = counter; i < MyChart.Series.Count; MyChart.Series.RemoveAt(i))
            {

            }



            //MyChart.Series.RemoveAt(1);

        }

        public  void PlotLogPH()
        {
            MyChart.Series.Add(LineSerie(Dome(), Brushes.Black));
        }

        //Mapper og setup
        private  LineSeries LineSerie(ChartValues<ObservablePoint> input, SolidColorBrush Color)
        {

            //lets configure the chart to plot ObservablePoint
            var mapper = Mappers.Xy<ObservablePoint>()
                .X(point => point.X)
                .Y(point => Math.Log10(point.Y));

            var series = new LineSeries
            {
                Configuration = mapper,
                Values = input,
                Fill = System.Windows.Media.Brushes.Transparent,
                PointGeometry = null,
                ToolTip = null,
                DataLabels = false,
                LineSmoothness = 0,
                Stroke = Color,
                //Brushes.LightBlue
            };


            return series;
        }

        //Dome
        private ChartValues<ObservablePoint> Dome()
        {
            var Results = new ChartValues<ObservablePoint>();
            var SelectedFluid = new Fluid(RefType);
            Pressure top, bottom, step;

            //This defines the top of the 'dome'       
            top = SelectedFluid.P_Crit;
            bottom = SelectedFluid.P_Min;
            step = Pressure.FromBars(1);


            //Creating the left side of the dome with X = 0
            for (Pressure i = bottom; i <= top; i = i + step)
            {
                SelectedFluid.UpdatePX(i, 0);
                Results.Add(new ObservablePoint
                {
                    X = SelectedFluid.Enthalpy.ToUnit(UnitsNet.Units.SpecificEnergyUnit.KilojoulePerKilogram).Value,
                    Y = i.ToUnit(UnitsNet.Units.PressureUnit.Bar).Value
                });

            }


            //Creating the right side of the dome with X = 1
            for (Pressure i = top; i >= bottom; i = i - step)
            {
                SelectedFluid.UpdatePX(i, 1);
                Results.Add(new ObservablePoint
                {
                    X = SelectedFluid.Enthalpy.ToUnit(UnitsNet.Units.SpecificEnergyUnit.KilojoulePerKilogram).Value,
                    Y = i.ToUnit(UnitsNet.Units.PressureUnit.Bar).Value
                });
            }


            return Results;
        }

        
        
        
    }
}
