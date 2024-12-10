using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace Dilitium
{
    public partial class Form1 : Form
    {
        public List<string> files = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("res"))
                Directory.CreateDirectory("res");
            files = Directory.GetFiles("res").ToList();
            foreach (string file in files)
            {
                if (!file.Contains(".sign"))
                {
                    var button = new FileButton(Path.GetFileName(file), FileButton_DoubleClick);
                    flowLayoutPanel.Controls.Add(button);
                }
            }
        }
        public void AddFile(string path)
        {
            files.Add(Path.GetFileName(path));
            var button = new FileButton(Path.GetFileName(path), FileButton_DoubleClick);
            flowLayoutPanel.Controls.Add(button);
        }
        public void OpenFile(string file)
        {
            var path = Path.Combine("res", file);
            var data = File.ReadAllBytes(path);
            if (!Path.Exists(Path.Combine("res", $"{Path.GetFileNameWithoutExtension(path)}.sign")))
            {
                MessageBox.Show("Файл цифровой подписи не найден!");
                return;
            }
            var sign = JsonSerializer.Deserialize<Sign>(File.ReadAllText(Path.Combine("res", $"{Path.GetFileNameWithoutExtension(path)}.sign")));
            var watch = new Stopwatch();
            watch.Start();
            var cycles = Functions.GetCpuCyclesAndMemory(()=>Functions.CheckSign(data, sign));
            watch.Stop();
            var check = Functions.CheckSign(data, sign);
            var allowedMessage = "Цифровая подпись верна";
            if (!check)
                allowedMessage = "Цифровая подпись не верна";
            MessageBox.Show($"{allowedMessage}\n\nTime: {watch.ElapsedMilliseconds}мс\nCPU cycles: {cycles.cycles}\nMemory usage: {cycles.memoryUsage}");
            if (check)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = path,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии файла: {ex.Message}");
                }
            }
        }

        private void FileButton_DoubleClick(object sender, EventArgs e)
        {
            OpenFile(((FileButton)sender).Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Открыть файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var addForm = new AddFileForm(openFileDialog.FileName, this);
                    addForm.ShowDialog();
                }
            }
        }
    }
}
