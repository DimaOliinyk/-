namespace КурсоваГрінченко
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxData = new TextBox();
            comboBoxChartType = new ComboBox();
            pictureBoxChart = new PictureBox();
            buttonClear = new Button();
            buttonDraw = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxChart).BeginInit();
            SuspendLayout();
            // 
            // textBoxData
            // 
            textBoxData.Location = new Point(12, 12);
            textBoxData.Name = "textBoxData";
            textBoxData.Size = new Size(125, 27);
            textBoxData.TabIndex = 0;
            // 
            // comboBoxChartType
            // 
            comboBoxChartType.FormattingEnabled = true;
            comboBoxChartType.Location = new Point(143, 12);
            comboBoxChartType.Name = "comboBoxChartType";
            comboBoxChartType.Size = new Size(216, 28);
            comboBoxChartType.TabIndex = 1;
            // 
            // pictureBoxChart
            // 
            pictureBoxChart.Location = new Point(12, 66);
            pictureBoxChart.Name = "pictureBoxChart";
            pictureBoxChart.Size = new Size(776, 479);
            pictureBoxChart.TabIndex = 2;
            pictureBoxChart.TabStop = false;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(605, 11);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(183, 29);
            buttonClear.TabIndex = 3;
            buttonClear.Text = "Очистити графік";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonDraw
            // 
            buttonDraw.Location = new Point(408, 10);
            buttonDraw.Name = "buttonDraw";
            buttonDraw.Size = new Size(191, 29);
            buttonDraw.TabIndex = 4;
            buttonDraw.Text = "Побудувати графік";
            buttonDraw.UseVisualStyleBackColor = true;
            buttonDraw.Click += buttonDraw_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 557);
            Controls.Add(buttonDraw);
            Controls.Add(buttonClear);
            Controls.Add(pictureBoxChart);
            Controls.Add(comboBoxChartType);
            Controls.Add(textBoxData);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxChart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxData;
        private ComboBox comboBoxChartType;
        private PictureBox pictureBoxChart;
        private Button buttonClear;
        private Button buttonDraw;
    }
}
