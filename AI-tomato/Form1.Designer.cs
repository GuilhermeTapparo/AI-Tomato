
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AI_tomato
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
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.cellCountLabel = new System.Windows.Forms.Label();
            this.foodCountLabel = new System.Windows.Forms.Label();
            this.maxAgeLabel = new Label();
            this.maxReproductionsLabel = new Label();
            this.ticksLabel = new Label();
            this.historyChart = new Chart();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(820, 394);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.OnStartButtonClick);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(820, 423);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 0;
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.OnStopButtonClick);
            // 
            // cellCountLabel
            // 
            this.cellCountLabel.Location = new System.Drawing.Point(820, 9);
            this.cellCountLabel.Name = "cellCountLabel";
            this.cellCountLabel.Size = new System.Drawing.Size(120, 20);
            this.cellCountLabel.TabIndex = 1;
            this.cellCountLabel.Text = "Células vivas: 0";
            // 
            // foodCountLabel
            // 
            this.foodCountLabel.Location = new System.Drawing.Point(820, 38);
            this.foodCountLabel.Name = "foodCountLabel";
            this.foodCountLabel.Size = new System.Drawing.Size(120, 20);
            this.foodCountLabel.TabIndex = 2;
            this.foodCountLabel.Text = "Comida: 0";

            // 
            // MaxAgeLabel
            // 
            this.maxAgeLabel.Location = new System.Drawing.Point(820, 101);
            this.maxAgeLabel.Name = "MaxAgeLabel";
            this.maxAgeLabel.Size = new System.Drawing.Size(120, 20);
            this.maxAgeLabel.TabIndex = 2;
            this.maxAgeLabel.Text = "Maior idade: 0";
            // 
            // MaxReproductionsLabel
            // 
            this.maxReproductionsLabel.Location = new System.Drawing.Point(820, 70);
            this.maxReproductionsLabel.Name = "MaxReproductionsLabel";
            this.maxReproductionsLabel.Size = new System.Drawing.Size(234, 20);
            this.maxReproductionsLabel.TabIndex = 2;
            this.maxReproductionsLabel.Text = "Maior número de reproduções: 0";

            // 
            // ticksLabel
            // 
            this.ticksLabel.Location = new System.Drawing.Point(820, 130);
            this.ticksLabel.Name = "TicksLabel";
            this.ticksLabel.Size = new System.Drawing.Size(234, 20);
            this.ticksLabel.TabIndex = 2;
            this.ticksLabel.Text = "Rounds/Ticks: 0";

            // Cria o gráfico
            historyChart.Location = new Point(820, 170);
            historyChart.Size = new Size(400, 200);
            Controls.Add(historyChart);

            // Adiciona uma série para o número de células vivas
            Series cellSeries = new Series("Células vivas");
            cellSeries.ChartType = SeriesChartType.Line;
            cellSeries.Color = Color.Red;
            cellSeries.BorderWidth = 3;
            historyChart.Series.Add(cellSeries);

            // Adiciona uma série para o número de comidas disponíveis
            Series foodSeries = new Series("Comidas disponíveis");
            foodSeries.ChartType = SeriesChartType.Line;
            foodSeries.Color = Color.Green;
            foodSeries.BorderWidth = 3;
            historyChart.Series.Add(foodSeries);

            // Configura os eixos X e Y
            historyChart.ChartAreas.Add(new ChartArea());
            historyChart.ChartAreas[0].AxisX.Title = "Tempo";
            historyChart.ChartAreas[0].AxisY.Title = "Quantidade";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 625);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.cellCountLabel);
            this.Controls.Add(this.foodCountLabel);
            this.Controls.Add(this.maxAgeLabel);
            this.Controls.Add(this.maxReproductionsLabel);
            this.Controls.Add(this.ticksLabel);
            this.Controls.Add(this.historyChart);
            this.Name = "Automato";
            this.Text = "Automato";
            this.ResumeLayout(false);

        }

        #endregion

        private Button startButton;
        private Button stopButton;
        private Chart historyChart;
        private Label cellCountLabel;
        private Label foodCountLabel;
        private Label maxAgeLabel;
        private Label maxReproductionsLabel;
        private Label ticksLabel;
    }
}

