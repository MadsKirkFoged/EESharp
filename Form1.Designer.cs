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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 438);
            this.Controls.Add(this.MyChartXY);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.MyChart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart MyChart;
        private System.Windows.Forms.TextBox textBox1;
        private LiveCharts.WinForms.CartesianChart MyChartXY;
    }
}

