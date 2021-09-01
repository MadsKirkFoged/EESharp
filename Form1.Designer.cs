namespace EESharp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MyChart = new LiveCharts.WinForms.CartesianChart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MyChartXY = new LiveCharts.WinForms.CartesianChart();
            this.inputPower = new ControlsEESharp.ControlPower();
            this.inputMassFlow = new ControlsEESharp.ControlMassFlow();
            this.inputPressure = new ControlsEESharp.ControlPressure();
            this.InputTemperature = new ControlsEESharp.ControlTemperature();
            this.OutputTemperature = new ControlsEESharp.ControlTemperature();
            this.button1 = new System.Windows.Forms.Button();
            this.outputPressure = new ControlsEESharp.ControlPressure();
            this.outputMassFlow = new ControlsEESharp.ControlMassFlow();
            this.outputPower = new ControlsEESharp.ControlPower();
            ((System.ComponentModel.ISupportInitialize)(this.inputPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMassFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputMassFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPower)).BeginInit();
            this.SuspendLayout();
            // 
            // MyChart
            // 
            this.MyChart.Location = new System.Drawing.Point(12, 65);
            this.MyChart.Name = "MyChart";
            this.MyChart.Size = new System.Drawing.Size(571, 293);
            this.MyChart.TabIndex = 0;
            this.MyChart.Text = "cartesianChart1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // MyChartXY
            // 
            this.MyChartXY.Location = new System.Drawing.Point(617, 65);
            this.MyChartXY.Name = "MyChartXY";
            this.MyChartXY.Size = new System.Drawing.Size(571, 293);
            this.MyChartXY.TabIndex = 2;
            this.MyChartXY.Text = "cartesianChart1";
            // 
            // inputPower
            // 
            this.inputPower.BackColor = System.Drawing.Color.White;
            this.inputPower.ExtraToolTip = null;
            this.inputPower.Location = new System.Drawing.Point(33, 458);
            this.inputPower.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.inputPower.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.inputPower.Name = "inputPower";
            this.inputPower.OutputControl = false;
            this.inputPower.Size = new System.Drawing.Size(80, 20);
            this.inputPower.TabIndex = 11;
            this.inputPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inputPower.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // inputMassFlow
            // 
            this.inputMassFlow.BackColor = System.Drawing.Color.White;
            this.inputMassFlow.ExtraToolTip = null;
            this.inputMassFlow.Location = new System.Drawing.Point(33, 432);
            this.inputMassFlow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.inputMassFlow.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.inputMassFlow.Name = "inputMassFlow";
            this.inputMassFlow.OutputControl = false;
            this.inputMassFlow.Size = new System.Drawing.Size(80, 20);
            this.inputMassFlow.TabIndex = 9;
            this.inputMassFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inputMassFlow.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // inputPressure
            // 
            this.inputPressure.BackColor = System.Drawing.Color.White;
            this.inputPressure.ExtraToolTip = null;
            this.inputPressure.Location = new System.Drawing.Point(33, 406);
            this.inputPressure.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.inputPressure.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.inputPressure.Name = "inputPressure";
            this.inputPressure.OutputControl = false;
            this.inputPressure.Size = new System.Drawing.Size(80, 20);
            this.inputPressure.TabIndex = 8;
            this.inputPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inputPressure.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // InputTemperature
            // 
            this.InputTemperature.BackColor = System.Drawing.Color.White;
            this.InputTemperature.DecimalPlaces = 2;
            this.InputTemperature.ExtraToolTip = null;
            this.InputTemperature.Location = new System.Drawing.Point(33, 380);
            this.InputTemperature.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.InputTemperature.Minimum = new decimal(new int[] {
            27315,
            0,
            0,
            -2147352576});
            //this.InputTemperature.Name = "InputTemperature";
            //this.InputTemperature.OutputControl = false;
            //this.InputTemperature.Size = new System.Drawing.Size(80, 20);
            //this.InputTemperature.TabIndex = 7;
            //this.InputTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.InputTemperature.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            //this.InputTemperature.Value = new decimal(new int[] {
            //100,
            //0,
            //0,
            //0});
            //// 
            //// OutputTemperature
            //// 
            //this.OutputTemperature.BackColor = System.Drawing.Color.White;
            //this.OutputTemperature.ExtraToolTip = null;
            //this.OutputTemperature.InterceptArrowKeys = false;
            //this.OutputTemperature.Location = new System.Drawing.Point(189, 379);
            //this.OutputTemperature.Maximum = new decimal(new int[] {
            //10000,
            //0,
            //0,
            //0});
            //this.OutputTemperature.Minimum = new decimal(new int[] {
            //27315,
            //0,
            //0,
            //-2147352576});
            //this.OutputTemperature.Name = "OutputTemperature";
            //this.OutputTemperature.OutputControl = true;
            //this.OutputTemperature.ReadOnly = true;
            //this.OutputTemperature.Size = new System.Drawing.Size(80, 20);
            //this.OutputTemperature.TabIndex = 12;
            //this.OutputTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.OutputTemperature.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 500);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // outputPressure
            // 
            this.outputPressure.BackColor = System.Drawing.Color.White;
            this.outputPressure.ExtraToolTip = null;
            this.outputPressure.InterceptArrowKeys = false;
            this.outputPressure.Location = new System.Drawing.Point(189, 405);
            this.outputPressure.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.outputPressure.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.outputPressure.Name = "outputPressure";
            this.outputPressure.OutputControl = true;
            this.outputPressure.ReadOnly = true;
            this.outputPressure.Size = new System.Drawing.Size(80, 20);
            this.outputPressure.TabIndex = 14;
            this.outputPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.outputPressure.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // outputMassFlow
            // 
            this.outputMassFlow.BackColor = System.Drawing.Color.White;
            this.outputMassFlow.ExtraToolTip = null;
            this.outputMassFlow.InterceptArrowKeys = false;
            this.outputMassFlow.Location = new System.Drawing.Point(189, 431);
            this.outputMassFlow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.outputMassFlow.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.outputMassFlow.Name = "outputMassFlow";
            this.outputMassFlow.OutputControl = true;
            this.outputMassFlow.ReadOnly = true;
            this.outputMassFlow.Size = new System.Drawing.Size(80, 20);
            this.outputMassFlow.TabIndex = 15;
            this.outputMassFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.outputMassFlow.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // outputPower
            // 
            this.outputPower.BackColor = System.Drawing.Color.White;
            this.outputPower.ExtraToolTip = null;
            this.outputPower.InterceptArrowKeys = false;
            this.outputPower.Location = new System.Drawing.Point(189, 457);
            this.outputPower.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.outputPower.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.outputPower.Name = "outputPower";
            this.outputPower.OutputControl = true;
            this.outputPower.ReadOnly = true;
            this.outputPower.Size = new System.Drawing.Size(80, 20);
            this.outputPower.TabIndex = 16;
            this.outputPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.outputPower.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 539);
            this.Controls.Add(this.outputPower);
            this.Controls.Add(this.outputMassFlow);
            this.Controls.Add(this.outputPressure);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OutputTemperature);
            this.Controls.Add(this.inputPower);
            this.Controls.Add(this.inputMassFlow);
            this.Controls.Add(this.inputPressure);
            this.Controls.Add(this.InputTemperature);
            this.Controls.Add(this.MyChartXY);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.MyChart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.inputPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMassFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputMassFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart MyChart;
        private System.Windows.Forms.TextBox textBox1;
        private LiveCharts.WinForms.CartesianChart MyChartXY;
        private ControlsEESharp.ControlTemperature InputTemperature;
        private ControlsEESharp.ControlPressure inputPressure;
        private ControlsEESharp.ControlMassFlow inputMassFlow;
        private ControlsEESharp.ControlPower inputPower;
        private ControlsEESharp.ControlTemperature OutputTemperature;
        private System.Windows.Forms.Button button1;
        private ControlsEESharp.ControlPressure outputPressure;
        private ControlsEESharp.ControlMassFlow outputMassFlow;
        private ControlsEESharp.ControlPower outputPower;
    }
}

