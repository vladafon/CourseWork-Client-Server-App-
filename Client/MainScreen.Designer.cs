namespace Client
{
    partial class MainScreen
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dirPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.subString = new System.Windows.Forms.TextBox();
            this.sendRequest = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.getDirs = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dirPath
            // 
            this.dirPath.Location = new System.Drawing.Point(436, 28);
            this.dirPath.Name = "dirPath";
            this.dirPath.Size = new System.Drawing.Size(352, 20);
            this.dirPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбранный путь к файлу:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Искомая подстрока:";
            // 
            // subString
            // 
            this.subString.Location = new System.Drawing.Point(436, 54);
            this.subString.Name = "subString";
            this.subString.Size = new System.Drawing.Size(352, 20);
            this.subString.TabIndex = 3;
            // 
            // sendRequest
            // 
            this.sendRequest.Location = new System.Drawing.Point(296, 84);
            this.sendRequest.Name = "sendRequest";
            this.sendRequest.Size = new System.Drawing.Size(75, 23);
            this.sendRequest.TabIndex = 6;
            this.sendRequest.Text = "Найти";
            this.sendRequest.UseVisualStyleBackColor = true;
            this.sendRequest.Click += new System.EventHandler(this.sendRequest_Click);
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(296, 122);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(492, 306);
            this.resultBox.TabIndex = 8;
            this.resultBox.Text = "";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "/"});
            this.listBox1.Location = new System.Drawing.Point(12, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(264, 251);
            this.listBox1.TabIndex = 9;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // getDirs
            // 
            this.getDirs.Location = new System.Drawing.Point(157, 285);
            this.getDirs.Name = "getDirs";
            this.getDirs.Size = new System.Drawing.Size(109, 29);
            this.getDirs.TabIndex = 10;
            this.getDirs.Text = "Открыть папку";
            this.getDirs.UseVisualStyleBackColor = true;
            this.getDirs.Click += new System.EventHandler(this.getDirs_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 285);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(109, 29);
            this.backButton.TabIndex = 11;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.getDirs);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.sendRequest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dirPath);
            this.Name = "MainScreen";
            this.Text = "StringFinder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox dirPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox subString;
        private System.Windows.Forms.Button sendRequest;
        private System.Windows.Forms.RichTextBox resultBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button getDirs;
        private System.Windows.Forms.Button backButton;
    }
}

