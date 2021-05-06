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
using UnitsNet;
using UnitsNet.Units;

namespace ControlsEESharp
{
    public partial class ControlTemperature : NumericUpDownUnit
    {


       
        public new decimal Minimum 
        {
            get 
            { 
                return base.Minimum; 
            }   
            set 
            {
                Minimum2 = Temperature.FromDegreesCelsius(value);
                base.Minimum = value; 
            }  

        }

        public new decimal Maximum
        {
            get
            {
                return base.Maximum;
            }
            set
            {
                Maximum2 = Temperature.FromDegreesCelsius(value);
                base.Maximum = value;
            }

        }

        public Temperature Minimum2 { get; set; }
        public Temperature Maximum2 { get; set; }


        private TemperatureUnit unit;


        public ControlTemperature()
        {
            InitializeComponent();
            Unit = TemperatureUnit.DegreeCelsius;
            Minimum2 = Temperature.FromKelvins(0);
            Maximum2 = Temperature.FromDegreesCelsius(10000);

            Minimum = (decimal)Minimum2.ToUnit(unit).Value;
            Maximum = (decimal)Maximum2.ToUnit(unit).Value;
        }

        protected override void ToolTip1_Popup(Object sender, PopupEventArgs e)
        {

            string ToolTipstr;
            toolTip1.Popup -= ToolTip1_Popup;

            ToolTipstr = this.UnitValue.ToUnit(TemperatureUnit.DegreeCelsius).ToString() + "\r\n";
            ToolTipstr += this.UnitValue.ToUnit(TemperatureUnit.DegreeFahrenheit).ToString() + "\r\n";
            ToolTipstr += this.UnitValue.ToUnit(TemperatureUnit.Kelvin).ToString() + "\r\n";

            toolTip1.SetToolTip(this, ToolTipstr + ExtraToolTip);           
            toolTip1.Popup += ToolTip1_Popup;
        }


        public TemperatureUnit Unit
        {
            private set
            {
                unit = value;                
                Label = string.Format("{0:a}", UnitValue.ToUnit(unit));            
            }
            get 
            { 
                return unit; 
            }
        }


        public Temperature UnitValue
        {
            get
            {
                return Temperature.From(Value, Unit);
            }
            set
            {                
                Value = (Decimal)value.ToUnit(unit).Value;
            }
        }



        protected override void OnValueChanged(EventArgs e)
        {

            UnitValue = Temperature.From(Value, unit);         
            AdjustControlSize();
            Label = string.Format("{0:a}", UnitValue.ToUnit(unit));
            base.OnValueChanged(e);
        }

    }
}
