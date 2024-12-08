
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Dilitium
{
    public partial class FileButton : UserControl
    {
        public string Text { get; set; }
        public FileButton(string text, EventHandler eventHandler)
        {
            InitializeComponent();
            Text = text;
            label.Text = text;
            label.Location = new Point(Size.Width / 2 - label.Width / 2, label.Location.Y);
            var toolTip = new ToolTip();
            toolTip.SetToolTip(this, text);
            DoubleClick += eventHandler;
            label.DoubleClick += (s, e) =>
            {
                eventHandler(this, e);
            };
            pictureBox1.DoubleClick += (s, e) =>
            {
                eventHandler(this, e);
            };
        }
        private void FileButton_Load(object sender, EventArgs e)
        {

        }

        private void FileButton_MouseHover(object sender, EventArgs e)
        {
            BackColor = SystemColors.GradientInactiveCaption;
        }

        private void FileButton_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void FileButton_MouseLeave(object sender, EventArgs e)
        {
            BackColor = SystemColors.Control;
        }

        private void FileButton_DoubleClick(object sender, EventArgs e)
        {

        }
    }
    public class TransparentPanel : Panel
    {
        public TransparentPanel()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.FromArgb(100, 255, 255, 255); // Полупрозрачный белый
        }
    }
}
