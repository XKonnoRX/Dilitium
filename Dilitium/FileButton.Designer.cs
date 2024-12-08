namespace Dilitium
{
    partial class FileButton
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            label = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.google_docs;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(70, 68);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.DoubleClick += FileButton_DoubleClick;
            pictureBox1.MouseLeave += FileButton_MouseLeave;
            pictureBox1.MouseHover += FileButton_MouseHover;
            // 
            // label
            // 
            label.Location = new Point(3, 74);
            label.MaximumSize = new Size(74, 30);
            label.MinimumSize = new Size(74, 30);
            label.Name = "label";
            label.Size = new Size(74, 30);
            label.TabIndex = 1;
            label.Text = "fdgf";
            label.TextAlign = ContentAlignment.TopCenter;
            label.DoubleClick += FileButton_DoubleClick;
            label.MouseLeave += FileButton_MouseLeave;
            label.MouseHover += FileButton_MouseHover;
            // 
            // FileButton
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(label);
            Controls.Add(pictureBox1);
            Name = "FileButton";
            Size = new Size(77, 105);
            Load += FileButton_Load;
            DoubleClick += FileButton_DoubleClick;
            MouseLeave += FileButton_MouseLeave;
            MouseHover += FileButton_MouseHover;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label;
    }
}
