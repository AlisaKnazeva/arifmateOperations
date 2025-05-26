namespace prac1
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnSaveText = new System.Windows.Forms.Button();
            this.btnLoadText = new System.Windows.Forms.Button();
            this.btnSaveJson = new System.Windows.Forms.Button();
            this.btnLoadJson = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            
            // btnSaveText
            this.btnSaveText.Location = new System.Drawing.Point(20, 20);
            this.btnSaveText.Name = "btnSaveText";
            this.btnSaveText.Size = new System.Drawing.Size(120, 40);
            this.btnSaveText.TabIndex = 0;
            this.btnSaveText.Text = "Сохранить в TXT";
            this.btnSaveText.UseVisualStyleBackColor = true;
            this.btnSaveText.Click += new System.EventHandler(this.BtnSaveText_Click);
            
            // btnLoadText
            this.btnLoadText.Location = new System.Drawing.Point(160, 20);
            this.btnLoadText.Name = "btnLoadText";
            this.btnLoadText.Size = new System.Drawing.Size(120, 40);
            this.btnLoadText.TabIndex = 1;
            this.btnLoadText.Text = "Загрузить из TXT";
            this.btnLoadText.UseVisualStyleBackColor = true;
            this.btnLoadText.Click += new System.EventHandler(this.BtnLoadText_Click);
            
            // btnSaveJson
            this.btnSaveJson.Location = new System.Drawing.Point(300, 20);
            this.btnSaveJson.Name = "btnSaveJson";
            this.btnSaveJson.Size = new System.Drawing.Size(120, 40);
            this.btnSaveJson.TabIndex = 2;
            this.btnSaveJson.Text = "Сохранить в JSON";
            this.btnSaveJson.UseVisualStyleBackColor = true;
            this.btnSaveJson.Click += new System.EventHandler(this.BtnSaveJson_Click);
            
            // btnLoadJson
            this.btnLoadJson.Location = new System.Drawing.Point(440, 20);
            this.btnLoadJson.Name = "btnLoadJson";
            this.btnLoadJson.Size = new System.Drawing.Size(120, 40);
            this.btnLoadJson.TabIndex = 3;
            this.btnLoadJson.Text = "Загрузить из JSON";
            this.btnLoadJson.UseVisualStyleBackColor = true;
            this.btnLoadJson.Click += new System.EventHandler(this.BtnLoadJson_Click);
            
            // textBoxOutput
            this.textBoxOutput.Location = new System.Drawing.Point(20, 80);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(540, 340);
            this.textBoxOutput.TabIndex = 4;
            
            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.btnLoadJson);
            this.Controls.Add(this.btnSaveJson);
            this.Controls.Add(this.btnLoadText);
            this.Controls.Add(this.btnSaveText);
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Name = "Form1";
            this.Text = "Управление библиотекой";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSaveText;
        private System.Windows.Forms.Button btnLoadText;
        private System.Windows.Forms.Button btnSaveJson;
        private System.Windows.Forms.Button btnLoadJson;
        private System.Windows.Forms.TextBox textBoxOutput;
    }
}