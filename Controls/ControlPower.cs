using EngineeringUnits;
using EngineeringUnits.Units;
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


namespace ControlsEESharp
{
    public partial class ControlPower : NumericUpDownUnit
    {

        public new decimal Minimum 
        {
            get 
            { 
                return base.Minimum; 
            }   
            set 
            {
                Minimum2 = Power.FromKilowatts((double)value);
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
                Maximum2 = Power.FromKilowatts((double)value);
                base.Maximum = value;
            }

        }

        public Power Minimum2 { get; set; }
        public Power Maximum2 { get; set; }


        private PowerUnit unit;


        public ControlPower()
        {
            InitializeComponent();
            Unit = PowerUnit.Kilowatt;
            Minimum2 = Power.Zero;
            Maximum2 = Power.FromKilowatts(10000);

            Minimum = (decimal)Minimum2.ToUnit(unit).Value;
            Maximum = (decimal)Maximum2.ToUnit(unit).Value;
        }

        protected override void ToolTip1_Popup(Object sender, PopupEventArgs e)
        {

            string ToolTipstr;
            toolTip1.Popup -= ToolTip1_Popup;

            ToolTipstr = this.UnitValue.ToUnit(PowerUnit.BritishThermalUnitPerHour).ToString() + "\r\n";
            ToolTipstr += this.UnitValue.ToUnit(PowerUnit.ElectricalHorsepower).ToString() + "\r\n";
            ToolTipstr += this.UnitValue.ToUnit(PowerUnit.Kilowatt).ToString() + "\r\n";
            
            toolTip1.SetToolTip(this, ToolTipstr + ExtraToolTip);           
            toolTip1.Popup += ToolTip1_Popup;
        }

        


        public PowerUnit Unit
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


        public Power UnitValue
        {
            get
            {
                return Power.From((double)Value, Unit);
            }
            set
            {                
                Value = (Decimal)value.ToUnit(unit).Value;
            }
        }



        protected override void OnValueChanged(EventArgs e)
        {

            UnitValue = Power.From((double)Value, unit);         
            AdjustControlSize();
            Label = string.Format("{0:a}", UnitValue.ToUnit(unit));
            base.OnValueChanged(e);
        }

    }
}
