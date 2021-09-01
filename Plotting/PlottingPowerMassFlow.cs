using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.WinForms;
using System.Windows.Media;
using System.Diagnostics;
using System.Globalization;
using SharpFluids;
using EngineeringUnits;

namespace EESharp
{
    public class PlottingPowerMassFlow
    {

        private  LiveCharts.WinForms.CartesianChart MyChart;


        public PlottingPowerMassFlow(LiveCharts.WinForms.CartesianChart myChart)
        {
            //Settings
            MyChart = myChart;


            //Creating Y Axis
            MyChart.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString("N1"),
                //MaxValue = 25, 
                //MinValue = 0,  
                Title = "Capacity [kW]",

                Separator = new Separator
                {
                    Stroke = Brushes.LightGray,
                    Step = 0.5,
                    StrokeThickness = 0.3,
                },

            });



            //Creating X Axis
            MyChart.AxisX.Add(new Axis
            {
                LabelFormatter = value => value.ToString("N0"),
                //MaxValue = 2,
                //MinValue = 0,
                
                Title = "MassFlow [Kgs]",
                Separator = new Separator
                {
                    Stroke = Brushes.LightGray,
                    Step = 5,
                    StrokeThickness = 0.3,
                },
            });

           //Settings
            MyChart.DataTooltip = null;
            MyChart.DisableAnimations = true;
            MyChart.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            MyChart.Hoverable = false;
        }

        public void Plot(Power power, MassFlow massflow)
        {

            var Results = new ChartValues<ObservablePoint>();


            Results.Add(new ObservablePoint
            {
                X = power.Kilowatts,
                Y = massflow.KilogramsPerSecond,
            });



            //configure the chart to plot ObservablePoint
            var mapper = Mappers.Xy<ObservablePoint>()
                .X(point => point.X)
                .Y(point => point.Y);


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


            MyChart.Series.Add(series);

            
        }

        public  void Clear()
        {
            MyChart.Series.Clear();
        }
  
    }
}
