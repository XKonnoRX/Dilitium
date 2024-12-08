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
        public void AddNewFile(string path)
        {
            var data = File.ReadAllBytes(path);
            var watch = new Stopwatch();
            watch.Start();
            var cycles = Functions.GetCpuCyclesAndMemory(() => Functions.GenerateKeys());
            watch.Stop();
            var mess = $"���� ������� ��������!\n\nTime (generate keys): {watch.ElapsedMilliseconds}��\nCPU cycles (generate keys): {cycles.cycles}\nMemory usage (generate keys): {cycles.memoryUsage}";
            var keys = Functions.GenerateKeys();
            watch.Reset();
            watch.Start();
            cycles = Functions.GetCpuCyclesAndMemory(() => Functions.CreateSign(data,keys));
            watch.Stop();
            var sign = Functions.CreateSign(data, keys);
            File.Copy(path, Path.Combine("res", Path.GetFileName(path)));
            File.WriteAllText(Path.Combine("res", $"{Path.GetFileNameWithoutExtension(path)}.sign"), JsonSerializer.Serialize(sign));
            File.SetAttributes(Path.Combine("res", Path.GetFileName(path)), FileAttributes.ReadOnly);
            File.SetAttributes(Path.Combine("res", $"{Path.GetFileNameWithoutExtension(path)}.sign"), FileAttributes.ReadOnly);
            files.Add(Path.GetFileName(path));
            var button = new FileButton(Path.GetFileName(path), FileButton_DoubleClick);
            flowLayoutPanel.Controls.Add(button);
            MessageBox.Show($"{mess}\nTime (sign): {watch.ElapsedMilliseconds}��\nCPU cycles (sign): {cycles.cycles}\nMemory usage (sign): {cycles.memoryUsage}");
        }
        public void OpenFile(string file)
        {
            var path = Path.Combine("res", file);
            var data = File.ReadAllBytes(path);
            if (!Path.Exists(Path.Combine("res", $"{Path.GetFileNameWithoutExtension(path)}.sign")))
            {
                MessageBox.Show("���� �������� ������� �� ������!");
                return;
            }
            var sign = JsonSerializer.Deserialize<Sign>(File.ReadAllText(Path.Combine("res", $"{Path.GetFileNameWithoutExtension(path)}.sign")));
            var watch = new Stopwatch();
            watch.Start();
            var cycles = Functions.GetCpuCyclesAndMemory(()=>Functions.CheckSign(data, sign));
            watch.Stop();
            var check = Functions.CheckSign(data, sign);
            var allowedMessage = "�������� ������� �����";
            if (!check)
                allowedMessage = "�������� ������� �� �����";
            MessageBox.Show($"{allowedMessage}\n\nTime: {watch.ElapsedMilliseconds}��\nCPU cycles: {cycles.cycles}\nMemory usage: {cycles.memoryUsage}");
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
                    MessageBox.Show($"������ ��� �������� �����: {ex.Message}");
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
                openFileDialog.Title = "������� ����";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AddNewFile(openFileDialog.FileName);
                }
            }
        }
    }
}
