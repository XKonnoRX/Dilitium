namespace Dilitium
{
    partial class AddFileForm
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
            button1 = new Button();
            secrestBox = new TextBox();
            publicBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            d2button = new RadioButton();
            d3Button = new RadioButton();
            d5Button = new RadioButton();
            d5aesButton = new RadioButton();
            d3aesButton = new RadioButton();
            d2aesButton = new RadioButton();
            generateButton = new Button();
            logBox = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(277, 210);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Sign";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // secrestBox
            // 
            secrestBox.Location = new Point(56, 104);
            secrestBox.Name = "secrestBox";
            secrestBox.ReadOnly = true;
            secrestBox.Size = new Size(296, 23);
            secrestBox.TabIndex = 1;
            // 
            // publicBox
            // 
            publicBox.Location = new Point(56, 133);
            publicBox.Name = "publicBox";
            publicBox.ReadOnly = true;
            publicBox.Size = new Size(296, 23);
            publicBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 107);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "secret";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 136);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 4;
            label2.Text = "public";
            // 
            // d2button
            // 
            d2button.AutoSize = true;
            d2button.Location = new Point(12, 25);
            d2button.Name = "d2button";
            d2button.Size = new Size(73, 19);
            d2button.TabIndex = 5;
            d2button.Text = "Dilitium2";
            d2button.UseVisualStyleBackColor = true;
            // 
            // d3Button
            // 
            d3Button.AutoSize = true;
            d3Button.Checked = true;
            d3Button.Location = new Point(112, 25);
            d3Button.Name = "d3Button";
            d3Button.Size = new Size(73, 19);
            d3Button.TabIndex = 6;
            d3Button.TabStop = true;
            d3Button.Text = "Dilitium3";
            d3Button.UseVisualStyleBackColor = true;
            // 
            // d5Button
            // 
            d5Button.AutoSize = true;
            d5Button.Location = new Point(212, 25);
            d5Button.Name = "d5Button";
            d5Button.Size = new Size(73, 19);
            d5Button.TabIndex = 7;
            d5Button.Text = "Dilitium5";
            d5Button.UseVisualStyleBackColor = true;
            // 
            // d5aesButton
            // 
            d5aesButton.AutoSize = true;
            d5aesButton.Location = new Point(212, 50);
            d5aesButton.Name = "d5aesButton";
            d5aesButton.Size = new Size(96, 19);
            d5aesButton.TabIndex = 10;
            d5aesButton.Text = "Dilitium5 AES";
            d5aesButton.UseVisualStyleBackColor = true;
            // 
            // d3aesButton
            // 
            d3aesButton.AutoSize = true;
            d3aesButton.Location = new Point(112, 50);
            d3aesButton.Name = "d3aesButton";
            d3aesButton.Size = new Size(96, 19);
            d3aesButton.TabIndex = 9;
            d3aesButton.Text = "Dilitium3 AES";
            d3aesButton.UseVisualStyleBackColor = true;
            // 
            // d2aesButton
            // 
            d2aesButton.AutoSize = true;
            d2aesButton.Location = new Point(12, 50);
            d2aesButton.Name = "d2aesButton";
            d2aesButton.Size = new Size(96, 19);
            d2aesButton.TabIndex = 8;
            d2aesButton.Text = "Dilitium2 AES";
            d2aesButton.UseVisualStyleBackColor = true;
            // 
            // generateButton
            // 
            generateButton.Location = new Point(277, 75);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(75, 23);
            generateButton.TabIndex = 11;
            generateButton.Text = "Generate";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // logBox
            // 
            logBox.Location = new Point(56, 162);
            logBox.Multiline = true;
            logBox.Name = "logBox";
            logBox.ReadOnly = true;
            logBox.Size = new Size(209, 71);
            logBox.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 165);
            label3.Name = "label3";
            label3.Size = new Size(24, 15);
            label3.TabIndex = 13;
            label3.Text = "log";
            // 
            // AddFileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 245);
            Controls.Add(label3);
            Controls.Add(logBox);
            Controls.Add(generateButton);
            Controls.Add(d5aesButton);
            Controls.Add(d3aesButton);
            Controls.Add(d2aesButton);
            Controls.Add(d5Button);
            Controls.Add(d3Button);
            Controls.Add(d2button);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(publicBox);
            Controls.Add(secrestBox);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddFileForm";
            Text = "Add File";
            Load += AddFileForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox secrestBox;
        private TextBox publicBox;
        private Label label1;
        private Label label2;
        private RadioButton d2button;
        private RadioButton d3Button;
        private RadioButton d5Button;
        private RadioButton d5aesButton;
        private RadioButton d3aesButton;
        private RadioButton d2aesButton;
        private Button generateButton;
        private TextBox logBox;
        private Label label3;
    }
}