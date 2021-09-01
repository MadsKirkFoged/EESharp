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
    public partial class ControlMassFlow : NumericUpDownUnit
    {

        public new decimal Minimum 
        {
            get 
            { 
                return base.Minimum; 
            }   
            set 
            {
                Minimum2 = MassFlow.FromKilogramsPerSecond((double)value);
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
                Maximum2 = MassFlow.FromKilogramsPerSecond((double)value);
                base.Maximum = value;
            }

        }

        public MassFlow Minimum2 { get; set; }
        public MassFlow Maximum2 { get; set; }


        private MassFlowUnit unit;


        public ControlMassFlow()
        {
            InitializeComponent();
            Unit = MassFlowUnit.KilogramPerSecond;
            Minimum2 = MassFlow.Zero;
            Maximum2 = MassFlow.FromKilogramsPerSecond(10000);

            Minimum = (decimal)Minimum2.ToUnit(unit).Value;
            Maximum = (decimal)Maximum2.ToUnit(unit).Value;
        }

        protected override void ToolTip1_Popup(Object sender, PopupEventArgs e)
        {

            string ToolTipstr;
            toolTip1.Popup -= ToolTip1_Popup;

            ToolTipstr = this.UnitValue.ToUnit(MassFlowUnit.KilogramPerSecond).ToString() + "\r\n";
            ToolTipstr += this.UnitValue.ToUnit(MassFlowUnit.KilogramPerMinute).ToString() + "\r\n";
            ToolTipstr += this.UnitValue.ToUnit(MassFlowUnit.PoundPerSecond).ToString() + "\r\n";
            
            toolTip1.SetToolTip(this, ToolTipstr + ExtraToolTip);           
            toolTip1.Popup += ToolTip1_Popup;
        }

        


        public MassFlowUnit Unit
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


        public MassFlow UnitValue
        {
            get
            {
                return MassFlow.From((double)Value, Unit);
            }
            set
            {                
                Value = (Decimal)value.ToUnit(unit).Value;
            }
        }



        protected override void OnValueChanged(EventArgs e)
        {

            UnitValue = MassFlow.From((double)Value, unit);         
            AdjustControlSize();
            Label = string.Format("{0:a}", UnitValue.ToUnit(unit));
            base.OnValueChanged(e);
        }

    }
}
