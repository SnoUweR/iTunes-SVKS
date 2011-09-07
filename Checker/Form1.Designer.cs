namespace Checker
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainLabel = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.stepLabel = new System.Windows.Forms.Label();
            this.nextStep = new System.Windows.Forms.Button();
            this.setupProgress = new System.Windows.Forms.ProgressBar();
            this.otherLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::Checker.Properties.Resources.itunes_logo_black61009;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(445, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // mainLabel
            // 
            this.mainLabel.AutoEllipsis = true;
            this.mainLabel.Location = new System.Drawing.Point(12, 67);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainLabel.Size = new System.Drawing.Size(420, 150);
            this.mainLabel.TabIndex = 1;
            this.mainLabel.Text = resources.GetString("mainLabel.Text");
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(147, 206);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(146, 43);
            this.runButton.TabIndex = 10;
            this.runButton.Text = "Закрыть";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Visible = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // stepLabel
            // 
            this.stepLabel.AutoSize = true;
            this.stepLabel.Location = new System.Drawing.Point(12, 236);
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(108, 13);
            this.stepLabel.TabIndex = 9;
            this.stepLabel.Text = "Шаг 1: Приветствие";
            // 
            // nextStep
            // 
            this.nextStep.Location = new System.Drawing.Point(357, 231);
            this.nextStep.Name = "nextStep";
            this.nextStep.Size = new System.Drawing.Size(75, 23);
            this.nextStep.TabIndex = 8;
            this.nextStep.Text = "Далее";
            this.nextStep.UseVisualStyleBackColor = true;
            this.nextStep.Click += new System.EventHandler(this.button1_Click);
            // 
            // setupProgress
            // 
            this.setupProgress.Location = new System.Drawing.Point(0, 260);
            this.setupProgress.Name = "setupProgress";
            this.setupProgress.Size = new System.Drawing.Size(444, 23);
            this.setupProgress.TabIndex = 7;
            // 
            // otherLabel
            // 
            this.otherLabel.AutoEllipsis = true;
            this.otherLabel.Location = new System.Drawing.Point(12, 163);
            this.otherLabel.Name = "otherLabel";
            this.otherLabel.Size = new System.Drawing.Size(420, 40);
            this.otherLabel.TabIndex = 11;
            this.otherLabel.Text = "label2";
            this.otherLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.otherLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 283);
            this.Controls.Add(this.otherLabel);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.stepLabel);
            this.Controls.Add(this.nextStep);
            this.Controls.Add(this.setupProgress);
            this.Controls.Add(this.mainLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Добро пожаловать в iTunes SVKS | Шаг 1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label stepLabel;
        private System.Windows.Forms.Button nextStep;
        private System.Windows.Forms.ProgressBar setupProgress;
        private System.Windows.Forms.Label otherLabel;
    }
}

