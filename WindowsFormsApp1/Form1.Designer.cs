namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RangeSliger = new WindowsFormsControlLibrary1.UserControl1();
            this.AlphaTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RotateTrackBar = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ValeurTrieeLabel = new System.Windows.Forms.Label();
            this.rotateButton = new System.Windows.Forms.Button();
            this.timerRotate = new System.Windows.Forms.Timer(this.components);
            this.IdDateButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.timerInterpolation = new System.Windows.Forms.Timer(this.components);
            this.curveTrackBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotateTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.curveTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // RangeSliger
            // 
            this.RangeSliger.BackColor = System.Drawing.SystemColors.ControlDark;
            this.RangeSliger.Location = new System.Drawing.Point(18, 252);
            this.RangeSliger.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.RangeSliger.Max = 455;
            this.RangeSliger.Min = 0;
            this.RangeSliger.Name = "RangeSliger";
            this.RangeSliger.Size = new System.Drawing.Size(465, 70);
            this.RangeSliger.TabIndex = 0;
            // 
            // AlphaTrackBar
            // 
            this.AlphaTrackBar.Location = new System.Drawing.Point(18, 114);
            this.AlphaTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AlphaTrackBar.Name = "AlphaTrackBar";
            this.AlphaTrackBar.Size = new System.Drawing.Size(465, 90);
            this.AlphaTrackBar.TabIndex = 1;
            this.AlphaTrackBar.ValueChanged += new System.EventHandler(this.AlphaTrackBar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Transparence";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Altitudes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 359);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rotate";
            // 
            // RotateTrackBar
            // 
            this.RotateTrackBar.Location = new System.Drawing.Point(18, 409);
            this.RotateTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RotateTrackBar.Name = "RotateTrackBar";
            this.RotateTrackBar.Size = new System.Drawing.Size(465, 90);
            this.RotateTrackBar.TabIndex = 4;
            this.RotateTrackBar.ValueChanged += new System.EventHandler(this.RotateTrackBar_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "Sort";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Trajectoires trièes :";
            // 
            // ValeurTrieeLabel
            // 
            this.ValeurTrieeLabel.AutoSize = true;
            this.ValeurTrieeLabel.Location = new System.Drawing.Point(222, 14);
            this.ValeurTrieeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ValeurTrieeLabel.Name = "ValeurTrieeLabel";
            this.ValeurTrieeLabel.Size = new System.Drawing.Size(51, 25);
            this.ValeurTrieeLabel.TabIndex = 8;
            this.ValeurTrieeLabel.Text = "Non";
            // 
            // rotateButton
            // 
            this.rotateButton.Location = new System.Drawing.Point(164, 480);
            this.rotateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(162, 72);
            this.rotateButton.TabIndex = 9;
            this.rotateButton.Text = "Auto. Rotate";
            this.rotateButton.UseVisualStyleBackColor = true;
            this.rotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // timerRotate
            // 
            this.timerRotate.Interval = 10;
            this.timerRotate.Tick += new System.EventHandler(this.TimerRotate_Tick);
            // 
            // IdDateButton
            // 
            this.IdDateButton.Location = new System.Drawing.Point(160, 597);
            this.IdDateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IdDateButton.Name = "IdDateButton";
            this.IdDateButton.Size = new System.Drawing.Size(112, 36);
            this.IdDateButton.TabIndex = 10;
            this.IdDateButton.Text = "Activate";
            this.IdDateButton.UseVisualStyleBackColor = true;
            this.IdDateButton.Click += new System.EventHandler(this.IdDateButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 602);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Id / Date :";
            // 
            // timerInterpolation
            // 
            this.timerInterpolation.Interval = 50;
            this.timerInterpolation.Tick += new System.EventHandler(this.TimerInterpolation_Tick);
            // 
            // curveTrackBar
            // 
            this.curveTrackBar.Location = new System.Drawing.Point(18, 666);
            this.curveTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.curveTrackBar.Maximum = 20;
            this.curveTrackBar.Name = "curveTrackBar";
            this.curveTrackBar.Size = new System.Drawing.Size(465, 90);
            this.curveTrackBar.TabIndex = 12;
            this.curveTrackBar.ValueChanged += new System.EventHandler(this.CurveTrackBar_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 731);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(466, 41);
            this.label6.TabIndex = 13;
            this.label6.Text = "Axel Colas et Aurelien Gaillard";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 877);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.curveTrackBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IdDateButton);
            this.Controls.Add(this.rotateButton);
            this.Controls.Add(this.ValeurTrieeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RotateTrackBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AlphaTrackBar);
            this.Controls.Add(this.RangeSliger);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AlphaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotateTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.curveTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsControlLibrary1.UserControl1 RangeSliger;
        private System.Windows.Forms.TrackBar AlphaTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar RotateTrackBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ValeurTrieeLabel;
        private System.Windows.Forms.Button rotateButton;
        private System.Windows.Forms.Timer timerRotate;
        private System.Windows.Forms.Button IdDateButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timerInterpolation;
        private System.Windows.Forms.TrackBar curveTrackBar;
        private System.Windows.Forms.Label label6;
    }
}

