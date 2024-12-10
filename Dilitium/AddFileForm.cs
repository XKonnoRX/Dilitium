using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dilitium
{
    public partial class AddFileForm : Form
    {
        string FilePath = string.Empty;
        Form1 mainForm;
        AsymmetricCipherKeyPair keys = null;
        public AddFileForm(string filePath, Form1 mainForm)
        {
            InitializeComponent();
            FilePath = filePath;
            this.mainForm = mainForm;
        }

        private void AddFileForm_Load(object sender, EventArgs e)
        {
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            DilithiumParameters parametrs = DilithiumParameters.Dilithium3;
            if (d2button.Checked)
                parametrs = DilithiumParameters.Dilithium2;
            if (d3Button.Checked)
                parametrs = DilithiumParameters.Dilithium3;
            if (d2aesButton.Checked)
                parametrs = DilithiumParameters.Dilithium2Aes;
            if (d3aesButton.Checked)
                parametrs = DilithiumParameters.Dilithium3Aes;
            if (d5Button.Checked)
                parametrs = DilithiumParameters.Dilithium5;
            if (d5aesButton.Checked)
                parametrs = DilithiumParameters.Dilithium5Aes;
            Functions.SetParametrs(parametrs);
            var watch = new Stopwatch();
            watch.Start();
            var cycles = Functions.GetCpuCyclesAndMemory(() => { keys = Functions.GenerateKeys(); });
            watch.Stop();
            var secret = ((DilithiumPrivateKeyParameters)keys.Private).GetEncoded();
            var publ = ((DilithiumPublicKeyParameters)keys.Public).GetEncoded();
            secrestBox.Text = Convert.ToBase64String(secret);
            publicBox.Text = Convert.ToBase64String(publ);
            logBox.Text = $"Time: {watch.ElapsedMilliseconds}мс\r\nCPU cycles: {cycles.cycles}\r\nMemory usage: {cycles.memoryUsage}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = File.ReadAllBytes(FilePath);
            var watch = new Stopwatch();
            Sign sign = new Sign();
            watch.Start();
            var cycles = Functions.GetCpuCyclesAndMemory(() => { sign = Functions.CreateSign(data, keys); });
            watch.Stop();
            File.Copy(FilePath, Path.Combine("res", Path.GetFileName(FilePath)));
            File.WriteAllText(Path.Combine("res", $"{Path.GetFileNameWithoutExtension(FilePath)}.sign"), JsonSerializer.Serialize(sign));
            File.SetAttributes(Path.Combine("res", Path.GetFileName(FilePath)), FileAttributes.ReadOnly);
            File.SetAttributes(Path.Combine("res", $"{Path.GetFileNameWithoutExtension(FilePath)}.sign"), FileAttributes.ReadOnly);
            mainForm.AddFile(FilePath);
            MessageBox.Show($"Файл успешно подписан\nTime: {watch.ElapsedMilliseconds}мс\nCPU cycles: {cycles.cycles}\nMemory usage: {cycles.memoryUsage}");
            this.Close();
        }
    }
}
