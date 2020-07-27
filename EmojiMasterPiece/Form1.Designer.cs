namespace EmojiMasterPiece
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.picture_target = new System.Windows.Forms.PictureBox();
            this.btn_startStop = new System.Windows.Forms.Button();
            this.EvolutionTimer = new System.Windows.Forms.Timer(this.components);
            this.btn_target = new System.Windows.Forms.Button();
            this.btn_emojiFolder = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.list_emojis = new System.Windows.Forms.ListView();
            this.picture_output = new System.Windows.Forms.PictureBox();
            this.lbl_emojis = new System.Windows.Forms.Label();
            this.lbl_target = new System.Windows.Forms.Label();
            this.trackBar_reproduction = new System.Windows.Forms.TrackBar();
            this.chart_evolution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl_output = new System.Windows.Forms.Label();
            this.emoji_images = new System.Windows.Forms.ImageList(this.components);
            this.lbl_generation = new System.Windows.Forms.Label();
            this.lbl_reproduction = new System.Windows.Forms.Label();
            this.lbl_top = new System.Windows.Forms.Label();
            this.trackBar_top = new System.Windows.Forms.TrackBar();
            this.lbl_mutation = new System.Windows.Forms.Label();
            this.trackBar_mutation = new System.Windows.Forms.TrackBar();
            this.chart_derivative = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl_populationSize = new System.Windows.Forms.Label();
            this.num_populationSize = new System.Windows.Forms.NumericUpDown();
            this.btn_reset = new System.Windows.Forms.Button();
            this.num_emojis = new System.Windows.Forms.NumericUpDown();
            this.lbl_emojiCount = new System.Windows.Forms.Label();
            this.btn_brute = new System.Windows.Forms.Button();
            this.num_brute = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picture_target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_output)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_reproduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_evolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_mutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_derivative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_populationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_emojis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_brute)).BeginInit();
            this.SuspendLayout();
            // 
            // picture_target
            // 
            this.picture_target.Location = new System.Drawing.Point(10, 15);
            this.picture_target.Name = "picture_target";
            this.picture_target.Size = new System.Drawing.Size(407, 309);
            this.picture_target.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_target.TabIndex = 0;
            this.picture_target.TabStop = false;
            this.picture_target.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_startStop
            // 
            this.btn_startStop.Location = new System.Drawing.Point(731, 281);
            this.btn_startStop.Name = "btn_startStop";
            this.btn_startStop.Size = new System.Drawing.Size(114, 39);
            this.btn_startStop.TabIndex = 1;
            this.btn_startStop.Text = "Start";
            this.btn_startStop.UseVisualStyleBackColor = true;
            this.btn_startStop.Click += new System.EventHandler(this.btn_startStop_Click);
            // 
            // EvolutionTimer
            // 
            this.EvolutionTimer.Interval = 1;
            this.EvolutionTimer.Tick += new System.EventHandler(this.EvolutionTimer_Tick);
            // 
            // btn_target
            // 
            this.btn_target.Location = new System.Drawing.Point(314, 281);
            this.btn_target.Name = "btn_target";
            this.btn_target.Size = new System.Drawing.Size(103, 40);
            this.btn_target.TabIndex = 5;
            this.btn_target.Text = "Select target";
            this.btn_target.UseVisualStyleBackColor = true;
            this.btn_target.Click += new System.EventHandler(this.btn_target_Click);
            // 
            // btn_emojiFolder
            // 
            this.btn_emojiFolder.Location = new System.Drawing.Point(750, 605);
            this.btn_emojiFolder.Name = "btn_emojiFolder";
            this.btn_emojiFolder.Size = new System.Drawing.Size(95, 31);
            this.btn_emojiFolder.TabIndex = 6;
            this.btn_emojiFolder.Text = "Add emoji";
            this.btn_emojiFolder.UseVisualStyleBackColor = true;
            this.btn_emojiFolder.Click += new System.EventHandler(this.btn_emojiFolder_Click);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(423, 281);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(114, 39);
            this.btn_export.TabIndex = 2;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // list_emojis
            // 
            this.list_emojis.HideSelection = false;
            this.list_emojis.Location = new System.Drawing.Point(423, 327);
            this.list_emojis.Name = "list_emojis";
            this.list_emojis.Size = new System.Drawing.Size(422, 309);
            this.list_emojis.TabIndex = 8;
            this.list_emojis.UseCompatibleStateImageBehavior = false;
            // 
            // picture_output
            // 
            this.picture_output.Location = new System.Drawing.Point(10, 327);
            this.picture_output.Name = "picture_output";
            this.picture_output.Size = new System.Drawing.Size(405, 309);
            this.picture_output.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_output.TabIndex = 9;
            this.picture_output.TabStop = false;
            // 
            // lbl_emojis
            // 
            this.lbl_emojis.AutoSize = true;
            this.lbl_emojis.Location = new System.Drawing.Point(420, 327);
            this.lbl_emojis.Name = "lbl_emojis";
            this.lbl_emojis.Size = new System.Drawing.Size(49, 17);
            this.lbl_emojis.TabIndex = 10;
            this.lbl_emojis.Text = "Emojis";
            // 
            // lbl_target
            // 
            this.lbl_target.AutoSize = true;
            this.lbl_target.Location = new System.Drawing.Point(12, 9);
            this.lbl_target.Name = "lbl_target";
            this.lbl_target.Size = new System.Drawing.Size(50, 17);
            this.lbl_target.TabIndex = 11;
            this.lbl_target.Text = "Target";
            // 
            // trackBar_reproduction
            // 
            this.trackBar_reproduction.Location = new System.Drawing.Point(608, 206);
            this.trackBar_reproduction.Maximum = 100;
            this.trackBar_reproduction.Name = "trackBar_reproduction";
            this.trackBar_reproduction.Size = new System.Drawing.Size(237, 56);
            this.trackBar_reproduction.TabIndex = 12;
            this.trackBar_reproduction.Scroll += new System.EventHandler(this.trackBar_reproduction_Scroll);
            // 
            // chart_evolution
            // 
            chartArea11.Name = "ChartArea1";
            this.chart_evolution.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chart_evolution.Legends.Add(legend11);
            this.chart_evolution.Location = new System.Drawing.Point(851, 327);
            this.chart_evolution.Name = "chart_evolution";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.chart_evolution.Series.Add(series11);
            this.chart_evolution.Size = new System.Drawing.Size(499, 309);
            this.chart_evolution.TabIndex = 13;
            this.chart_evolution.Text = "chart1";
            // 
            // lbl_output
            // 
            this.lbl_output.AutoSize = true;
            this.lbl_output.Location = new System.Drawing.Point(7, 327);
            this.lbl_output.Name = "lbl_output";
            this.lbl_output.Size = new System.Drawing.Size(47, 17);
            this.lbl_output.TabIndex = 14;
            this.lbl_output.Text = "Ouput";
            // 
            // emoji_images
            // 
            this.emoji_images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.emoji_images.ImageSize = new System.Drawing.Size(32, 32);
            this.emoji_images.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lbl_generation
            // 
            this.lbl_generation.AutoSize = true;
            this.lbl_generation.Location = new System.Drawing.Point(427, 245);
            this.lbl_generation.Name = "lbl_generation";
            this.lbl_generation.Size = new System.Drawing.Size(46, 17);
            this.lbl_generation.TabIndex = 15;
            this.lbl_generation.Text = "label1";
            // 
            // lbl_reproduction
            // 
            this.lbl_reproduction.Font = new System.Drawing.Font("SamsungOneUILatin 700", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reproduction.Location = new System.Drawing.Point(423, 206);
            this.lbl_reproduction.Name = "lbl_reproduction";
            this.lbl_reproduction.Size = new System.Drawing.Size(189, 56);
            this.lbl_reproduction.TabIndex = 16;
            this.lbl_reproduction.Text = "Reproduction";
            // 
            // lbl_top
            // 
            this.lbl_top.Font = new System.Drawing.Font("SamsungOneUILatin 700", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_top.Location = new System.Drawing.Point(423, 144);
            this.lbl_top.Name = "lbl_top";
            this.lbl_top.Size = new System.Drawing.Size(189, 56);
            this.lbl_top.TabIndex = 18;
            this.lbl_top.Text = "Top";
            // 
            // trackBar_top
            // 
            this.trackBar_top.Location = new System.Drawing.Point(608, 144);
            this.trackBar_top.Maximum = 100;
            this.trackBar_top.Name = "trackBar_top";
            this.trackBar_top.Size = new System.Drawing.Size(237, 56);
            this.trackBar_top.TabIndex = 17;
            this.trackBar_top.Scroll += new System.EventHandler(this.trackBar_top_Scroll);
            // 
            // lbl_mutation
            // 
            this.lbl_mutation.Font = new System.Drawing.Font("SamsungOneUILatin 700", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mutation.Location = new System.Drawing.Point(423, 82);
            this.lbl_mutation.Name = "lbl_mutation";
            this.lbl_mutation.Size = new System.Drawing.Size(189, 56);
            this.lbl_mutation.TabIndex = 20;
            this.lbl_mutation.Text = "Mutation";
            this.lbl_mutation.Click += new System.EventHandler(this.lbl_mutation_Click);
            // 
            // trackBar_mutation
            // 
            this.trackBar_mutation.Location = new System.Drawing.Point(608, 82);
            this.trackBar_mutation.Maximum = 100;
            this.trackBar_mutation.Name = "trackBar_mutation";
            this.trackBar_mutation.Size = new System.Drawing.Size(237, 56);
            this.trackBar_mutation.TabIndex = 19;
            this.trackBar_mutation.Scroll += new System.EventHandler(this.trackBar_mutation_Scroll);
            // 
            // chart_derivative
            // 
            chartArea12.Name = "ChartArea1";
            this.chart_derivative.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.chart_derivative.Legends.Add(legend12);
            this.chart_derivative.Location = new System.Drawing.Point(851, 11);
            this.chart_derivative.Name = "chart_derivative";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.chart_derivative.Series.Add(series12);
            this.chart_derivative.Size = new System.Drawing.Size(499, 309);
            this.chart_derivative.TabIndex = 21;
            this.chart_derivative.Text = "chart1";
            // 
            // lbl_populationSize
            // 
            this.lbl_populationSize.Font = new System.Drawing.Font("SamsungOneUILatin 700", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_populationSize.Location = new System.Drawing.Point(423, 15);
            this.lbl_populationSize.Name = "lbl_populationSize";
            this.lbl_populationSize.Size = new System.Drawing.Size(171, 35);
            this.lbl_populationSize.TabIndex = 23;
            this.lbl_populationSize.Text = "Population";
            // 
            // num_populationSize
            // 
            this.num_populationSize.Location = new System.Drawing.Point(430, 53);
            this.num_populationSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_populationSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_populationSize.Name = "num_populationSize";
            this.num_populationSize.Size = new System.Drawing.Size(158, 22);
            this.num_populationSize.TabIndex = 24;
            this.num_populationSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.num_populationSize.ValueChanged += new System.EventHandler(this.num_populationSize_ValueChanged);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(784, 15);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(61, 60);
            this.btn_reset.TabIndex = 25;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // num_emojis
            // 
            this.num_emojis.Location = new System.Drawing.Point(601, 53);
            this.num_emojis.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.num_emojis.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_emojis.Name = "num_emojis";
            this.num_emojis.Size = new System.Drawing.Size(158, 22);
            this.num_emojis.TabIndex = 27;
            this.num_emojis.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lbl_emojiCount
            // 
            this.lbl_emojiCount.Font = new System.Drawing.Font("SamsungOneUILatin 700", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_emojiCount.Location = new System.Drawing.Point(594, 15);
            this.lbl_emojiCount.Name = "lbl_emojiCount";
            this.lbl_emojiCount.Size = new System.Drawing.Size(165, 35);
            this.lbl_emojiCount.TabIndex = 26;
            this.lbl_emojiCount.Text = "Emojis";
            // 
            // btn_brute
            // 
            this.btn_brute.Location = new System.Drawing.Point(731, 245);
            this.btn_brute.Name = "btn_brute";
            this.btn_brute.Size = new System.Drawing.Size(114, 39);
            this.btn_brute.TabIndex = 28;
            this.btn_brute.Text = "Brute";
            this.btn_brute.UseVisualStyleBackColor = true;
            this.btn_brute.Click += new System.EventHandler(this.btn_brute_Click);
            // 
            // num_brute
            // 
            this.num_brute.Location = new System.Drawing.Point(618, 254);
            this.num_brute.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.num_brute.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_brute.Name = "num_brute";
            this.num_brute.Size = new System.Drawing.Size(107, 22);
            this.num_brute.TabIndex = 29;
            this.num_brute.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 642);
            this.Controls.Add(this.num_brute);
            this.Controls.Add(this.btn_brute);
            this.Controls.Add(this.lbl_generation);
            this.Controls.Add(this.num_emojis);
            this.Controls.Add(this.lbl_emojiCount);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.num_populationSize);
            this.Controls.Add(this.lbl_populationSize);
            this.Controls.Add(this.chart_derivative);
            this.Controls.Add(this.lbl_mutation);
            this.Controls.Add(this.trackBar_mutation);
            this.Controls.Add(this.lbl_top);
            this.Controls.Add(this.trackBar_top);
            this.Controls.Add(this.lbl_reproduction);
            this.Controls.Add(this.lbl_output);
            this.Controls.Add(this.chart_evolution);
            this.Controls.Add(this.trackBar_reproduction);
            this.Controls.Add(this.lbl_target);
            this.Controls.Add(this.lbl_emojis);
            this.Controls.Add(this.btn_emojiFolder);
            this.Controls.Add(this.btn_target);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_startStop);
            this.Controls.Add(this.picture_target);
            this.Controls.Add(this.list_emojis);
            this.Controls.Add(this.picture_output);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture_target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_output)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_reproduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_evolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_mutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_derivative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_populationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_emojis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_brute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture_target;
        private System.Windows.Forms.Button btn_startStop;
        private System.Windows.Forms.Timer EvolutionTimer;
        private System.Windows.Forms.Button btn_target;
        private System.Windows.Forms.Button btn_emojiFolder;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.ListView list_emojis;
        private System.Windows.Forms.PictureBox picture_output;
        private System.Windows.Forms.Label lbl_emojis;
        private System.Windows.Forms.Label lbl_target;
        private System.Windows.Forms.TrackBar trackBar_reproduction;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_evolution;
        private System.Windows.Forms.Label lbl_output;
        private System.Windows.Forms.ImageList emoji_images;
        private System.Windows.Forms.Label lbl_generation;
        private System.Windows.Forms.Label lbl_reproduction;
        private System.Windows.Forms.Label lbl_top;
        private System.Windows.Forms.TrackBar trackBar_top;
        private System.Windows.Forms.Label lbl_mutation;
        private System.Windows.Forms.TrackBar trackBar_mutation;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_derivative;
        private System.Windows.Forms.Label lbl_populationSize;
        private System.Windows.Forms.NumericUpDown num_populationSize;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label lbl_emojiCount;
        private System.Windows.Forms.NumericUpDown num_emojis;
        private System.Windows.Forms.Button btn_brute;
        private System.Windows.Forms.NumericUpDown num_brute;
    }
}

