
namespace TableConvert
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonPaste = new System.Windows.Forms.Button();
            this.buttonTsv = new System.Windows.Forms.Button();
            this.buttonCsv = new System.Windows.Forms.Button();
            this.buttonMarkdown = new System.Windows.Forms.Button();
            this.buttonJira = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.timerMessage = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.AcceptsReturn = true;
            this.textBox.AcceptsTab = true;
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::TableConvert.Properties.Settings.Default, "TextFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox.Font = global::TableConvert.Properties.Settings.Default.TextFont;
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(776, 270);
            this.textBox.TabIndex = 0;
            this.textBox.WordWrap = false;
            // 
            // buttonPaste
            // 
            this.buttonPaste.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPaste.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPaste.Location = new System.Drawing.Point(300, 288);
            this.buttonPaste.Name = "buttonPaste";
            this.buttonPaste.Size = new System.Drawing.Size(200, 46);
            this.buttonPaste.TabIndex = 1;
            this.buttonPaste.Text = "&Paste";
            this.buttonPaste.UseVisualStyleBackColor = true;
            this.buttonPaste.Click += new System.EventHandler(this.buttonPaste_Click);
            // 
            // buttonTsv
            // 
            this.buttonTsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTsv.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonTsv.Location = new System.Drawing.Point(12, 340);
            this.buttonTsv.Name = "buttonTsv";
            this.buttonTsv.Size = new System.Drawing.Size(200, 46);
            this.buttonTsv.TabIndex = 2;
            this.buttonTsv.Text = "&TSV";
            this.buttonTsv.UseVisualStyleBackColor = true;
            this.buttonTsv.Click += new System.EventHandler(this.buttonTsv_Click);
            // 
            // buttonCsv
            // 
            this.buttonCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCsv.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonCsv.Location = new System.Drawing.Point(12, 392);
            this.buttonCsv.Name = "buttonCsv";
            this.buttonCsv.Size = new System.Drawing.Size(200, 46);
            this.buttonCsv.TabIndex = 3;
            this.buttonCsv.Text = "&CSV";
            this.buttonCsv.UseVisualStyleBackColor = true;
            this.buttonCsv.Click += new System.EventHandler(this.buttonCsv_Click);
            // 
            // buttonMarkdown
            // 
            this.buttonMarkdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMarkdown.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonMarkdown.Location = new System.Drawing.Point(588, 340);
            this.buttonMarkdown.Name = "buttonMarkdown";
            this.buttonMarkdown.Size = new System.Drawing.Size(200, 46);
            this.buttonMarkdown.TabIndex = 4;
            this.buttonMarkdown.Text = "&Markdown";
            this.buttonMarkdown.UseVisualStyleBackColor = true;
            this.buttonMarkdown.Click += new System.EventHandler(this.buttonMarkdown_Click);
            // 
            // buttonJira
            // 
            this.buttonJira.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonJira.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonJira.Location = new System.Drawing.Point(588, 392);
            this.buttonJira.Name = "buttonJira";
            this.buttonJira.Size = new System.Drawing.Size(200, 46);
            this.buttonJira.TabIndex = 5;
            this.buttonJira.Text = "&JIRA";
            this.buttonJira.UseVisualStyleBackColor = true;
            this.buttonJira.Click += new System.EventHandler(this.buttonJira_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMessage.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMessage.ForeColor = System.Drawing.Color.Blue;
            this.labelMessage.Location = new System.Drawing.Point(218, 337);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(364, 104);
            this.labelMessage.TabIndex = 6;
            this.labelMessage.Text = "Copied !";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMessage.Visible = false;
            // 
            // timerMessage
            // 
            this.timerMessage.Interval = 2000;
            this.timerMessage.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonJira);
            this.Controls.Add(this.buttonMarkdown);
            this.Controls.Add(this.buttonCsv);
            this.Controls.Add(this.buttonTsv);
            this.Controls.Add(this.buttonPaste);
            this.Controls.Add(this.textBox);
            this.Name = "FormMain";
            this.Text = "TableConvert";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonPaste;
        private System.Windows.Forms.Button buttonTsv;
        private System.Windows.Forms.Button buttonCsv;
        private System.Windows.Forms.Button buttonMarkdown;
        private System.Windows.Forms.Button buttonJira;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Timer timerMessage;
    }
}

