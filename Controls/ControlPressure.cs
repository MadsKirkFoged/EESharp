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
    public partial class ControlPressure : NumericUpDownUnit
    {

        public new decimal Minimum 
        {
            get 
            { 
                return base.Minimum; 
            }   
            set 
            {
                Minimum2 = Pressure.FromBars((double)value);
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
                Maximum2 = Pressure.FromBars((double)value);
                base.Maximum = value;
            }

        }

        public Pressure Minimum2 { get; set; }
        public Pressure Maximum2 { get; set; }


        private PressureUnit unit;


        public ControlPressure()
        {
            InitializeComponent();
            Unit = PressureUnit.Bar;
            Minimum2 = Pressure.Zero;
            Maximum2 = Pressure.FromBars(10000);

            Minimum = (decimal)Minimum2.As(unit);
            Maximum = (decimal)Maximum2.As(unit);
        }

        protected override void ToolTip1_Popup(Object sender, PopupEventArgs e)
        {

            string ToolTipstr;
            toolTip1.Popup -= ToolTip1_Popup;

            ToolTipstr = this.UnitValue.ToUnit(PressureUnit.Bar).ToString() + "\r\n";
            ToolTipstr += this.UnitValue.ToUnit(PressureUnit.Pascal).ToString() + "\r\n";
            ToolTipstr += this.UnitValue.ToUnit(PressureUnit.PoundForcePerSquareInch).ToString() + "\r\n";

            toolTip1.SetToolTip(this, ToolTipstr + ExtraToolTip);           
            toolTip1.Popup += ToolTip1_Popup;
        }

        


        public PressureUnit Unit
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


        public Pressure UnitValue
        {
            get
            {
                return Pressure.From((double)Value, Unit);
            }
            set
            {                
                Value = (Decimal)value.ToUnit(unit).Value;
            }
        }



        protected override void OnValueChanged(EventArgs e)
        {

            UnitValue = Pressure.From((double)Value, unit);         
            AdjustControlSize();
            Label = string.Format("{0:a}", UnitValue.ToUnit(unit));
            base.OnValueChanged(e);
        }

    }
}
