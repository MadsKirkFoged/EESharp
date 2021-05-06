using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UnitsNet;
using UnitsNet.Units;
using System.Diagnostics;
using System.Drawing;

namespace ControlsEESharp
{
    public partial class NumericUpDownUnit : NumericUpDown
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);
        private const int EM_SETMARGINS = 0xd3;
        private const int EC_RIGHTMARGIN = 2;
        private const int EC_LEFTMARGIN = 1;
        protected Label label;
        protected string SelectedUnitSystem;
        protected bool UpstartDone = false;
        protected string startingUpUnit;
        protected ToolTip toolTip1;





        public string ExtraToolTip { get; set; }

        private bool outputControl;

        public bool OutputControl
        {
            get
            {
                return outputControl;
            }
            set
            {
                Controls[0].Visible = !value;
                ReadOnly = value;
                this.InterceptArrowKeys = !value;
                outputControl = value;
            }


        }

        public NumericUpDownUnit() : base()
        {
            BackColor = Color.White;
            
            var textBox = Controls[1];            
            label = new Label() { Text = "NoUnit!", Dock = DockStyle.Right, AutoSize = true, ForeColor = Color.DimGray};
            textBox.Controls.Add(label);
            Minimum = -9999999999999;
            Maximum = 99999999999999;
            AutoSize = false;
            //Anchor = (AnchorStyles.Right);
            TextAlign = HorizontalAlignment.Right;
            UpDownAlign = LeftRightAlignment.Left;
            //BackColor = Color.White;
            //this.ForeColor = Color.White;
            InitializeComponent();
            ToolTip();
        }



        private void ToolTip()
        {
            // Create the ToolTip and associate with the Form container.
            toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this, this.Value.ToString());

            toolTip1.Popup += ToolTip1_Popup;
            

        }

        protected virtual void ToolTip1_Popup(Object sender, PopupEventArgs e)
        {
            toolTip1.Popup -= ToolTip1_Popup;
            toolTip1.SetToolTip(this, ExtraToolTip);
            toolTip1.Popup += ToolTip1_Popup;
        }

        public override void UpButton()
        {
            base.UpButton();            
            Value = Math.Floor(Value);
        }

        public override void DownButton()
        {
            base.DownButton();
            Value = Math.Ceiling(Value);
        }

        protected void AdjustControlSize()
        {
            int size = GetDigits(Value);
            int length = this.Width;

            if (size > 0 && 4 < size && this.Width < 65)            
                length = 65;            
            else if (size > 4 && 6 < size && this.Width < 75)            
                length = 75;            
            else if (size > 6 && 8 < size && this.Width < 85)            
                length = 85;            
            else if (size > 8 && 10 < size && this.Width < 95)            
                length = 95;            
            else if (size > 10 && 12 < size && this.Width < 105)            
                length = 105;
            

            Size = new Size(length, Size.Height);


        }

        protected static int GetDigits(decimal dec)
        {
            decimal d = decimal.Floor(dec < 0 ? decimal.Negate(dec) : dec);
            // As stated in the comments of the question, 
            // 0.xyz should return 0, therefore a special case
            if (d == 0m)
                return 0;
            int cnt = 1;
            while ((d = decimal.Floor(d / 10m)) != 0m)
                cnt++;
            return cnt;
        }

        protected string Label
        {
            get { return label.Text; }
            set { 

                label.Text = value; 
                if (IsHandleCreated) 
                    SetMargin(); 
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetMargin();
        }

       
        private void SetMargin()
        {
            SendMessage(Controls[1].Handle, EM_SETMARGINS, EC_RIGHTMARGIN, (1+label.Width) << 16);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (!ReadOnly)
            {
                base.OnMouseWheel(e);
            }
        }



    }
}
