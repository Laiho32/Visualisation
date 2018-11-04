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
            ((System.ComponentModel.ISupportInitialize)(this.AlphaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotateTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.curveTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // RangeSliger
            // 
            this.RangeSliger.BackColor = System.Drawing.SystemColors.ControlDark;
            this.RangeSliger.Location = new System.Drawing.Point(12, 161);
            this.RangeSliger.Max = 300;
            this.RangeSliger.Min = 0;
            this.RangeSliger.Name = "RangeSliger";
            this.RangeSliger.Size = new System.Drawing.Size(310, 45);
            this.RangeSliger.TabIndex = 0;
            // 
            // AlphaTrackBar
            // 
            this.AlphaTrackBar.Location = new System.Drawing.Point(12, 73);
            this.AlphaTrackBar.Name = "AlphaTrackBar";
            this.AlphaTrackBar.Size = new System.Drawing.Size(310, 56);
            this.AlphaTrackBar.TabIndex = 1;
            this.AlphaTrackBar.ValueChanged += new System.EventHandler(this.AlphaTrackBar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Transparence";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Altitudes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rotate";
            // 
            // RotateTrackBar
            // 
            this.RotateTrackBar.Location = new System.Drawing.Point(12, 262);
            this.RotateTrackBar.Name = "RotateTrackBar";
            this.RotateTrackBar.Size = new System.Drawing.Size(310, 56);
            this.RotateTrackBar.TabIndex = 4;
            this.RotateTrackBar.ValueChanged += new System.EventHandler(this.RotateTrackBar_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Sort";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Trajectoires trièes :";
            // 
            // ValeurTrieeLabel
            // 
            this.ValeurTrieeLabel.AutoSize = true;
            this.ValeurTrieeLabel.Location = new System.Drawing.Point(148, 9);
            this.ValeurTrieeLabel.Name = "ValeurTrieeLabel";
            this.ValeurTrieeLabel.Size = new System.Drawing.Size(34, 17);
            this.ValeurTrieeLabel.TabIndex = 8;
            this.ValeurTrieeLabel.Text = "Non";
            // 
            // rotateButton
            // 
            this.rotateButton.Location = new System.Drawing.Point(109, 307);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(108, 46);
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
            this.IdDateButton.Location = new System.Drawing.Point(107, 382);
            this.IdDateButton.Name = "IdDateButton";
            this.IdDateButton.Size = new System.Drawing.Size(75, 23);
            this.IdDateButton.TabIndex = 10;
            this.IdDateButton.Text = "Activate";
            this.IdDateButton.UseVisualStyleBackColor = true;
            this.IdDateButton.Click += new System.EventHandler(this.IdDateButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 385);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
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
            this.curveTrackBar.Location = new System.Drawing.Point(12, 426);
            this.curveTrackBar.Maximum = 20;
            this.curveTrackBar.Name = "curveTrackBar";
            this.curveTrackBar.Size = new System.Drawing.Size(310, 56);
            this.curveTrackBar.TabIndex = 12;
            this.curveTrackBar.ValueChanged += new System.EventHandler(this.CurveTrackBar_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 561);
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
    }
}

