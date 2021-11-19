using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emulator_v1
{
    public partial class Form1 : Form
    {
        string selectedTime;
        string mode = "Manual";
        string dataType = "RDR";
        string SettingsLocation = @"C:\ProgramData\StrataGem571\Emulator\";
        bool dataIntervalsCreated = false;
        bool loaded = false;
        bool starterLoaded = false;

        public Form1()
        {
            InitializeComponent();
            if(!Directory.Exists(SettingsLocation + "Markets"))
            {
                Directory.CreateDirectory(SettingsLocation + "Markets");
            }
            if (!File.Exists(SettingsLocation + "Markets\\GBPUSDpro")) using (FileStream fs = File.Create(SettingsLocation + "Markets\\GBPUSDpro"));
            if (!File.Exists(SettingsLocation + "Markets\\EURUSDpro")) using (FileStream fs = File.Create(SettingsLocation + "Markets\\EURUSDpro"));
            if (!File.Exists(SettingsLocation + "Markets\\AUDUSDpro")) using (FileStream fs = File.Create(SettingsLocation + "Markets\\AUDUSDpro"));
            if (!File.Exists(SettingsLocation + "Markets\\NZDUSDpro")) using (FileStream fs = File.Create(SettingsLocation + "Markets\\NZDUSDpro"));
            if (!File.Exists(SettingsLocation + "Markets\\USDCADpro")) using (FileStream fs = File.Create(SettingsLocation + "Markets\\USDCADpro"));
            if (!File.Exists(SettingsLocation + "Markets\\USDJPYpro")) using (FileStream fs = File.Create(SettingsLocation + "Markets\\USDJPYpro"));
            if (!File.Exists(SettingsLocation + "Markets\\USDCHFpro")) using (FileStream fs = File.Create(SettingsLocation + "Markets\\USDCHFpro"));
            if (!File.Exists(SettingsLocation + "Data Intervals"))
            {
                dataIntervalsCreated = true;
                using (FileStream fs = File.Create(SettingsLocation + "Data Intervals")) ;
            }

            DirectoryInfo markets = new DirectoryInfo(SettingsLocation + "Markets");
            FileInfo[] files = markets.GetFiles();
            foreach (FileInfo f in files)
            {
                MarketDropdown.Items.Add(f);
            }

            DataIntervalsGrid.RowCount = 4;
            DataIntervalsGrid.Rows[0].Cells[1].Style.BackColor = Color.Gray;
            DataIntervalsGrid.Rows[0].Cells[2].Style.BackColor = Color.Gray;
            DataIntervalsGrid.Rows[0].Cells[3].Style.BackColor = Color.Gray;
            DataIntervalsGrid.Rows[0].Cells[4].Style.BackColor = Color.Gray;
            DataIntervalsGrid.Rows[0].Cells[5].Style.BackColor = Color.Gray;
            DataIntervalsGrid.Rows[1].Cells[3].Style.BackColor = Color.Gray;
            DataIntervalsGrid.Rows[1].Cells[4].Style.BackColor = Color.Gray;
            DataIntervalsGrid.Rows[1].Cells[5].Style.BackColor = Color.Gray;
            DataIntervalsGrid.Rows[2].Cells[4].Style.BackColor = Color.Gray;
            DataIntervalsGrid.Rows[2].Cells[5].Style.BackColor = Color.Gray;

            DataIntervalsGrid.Rows[0].Cells[1].ReadOnly = true;
            DataIntervalsGrid.Rows[0].Cells[2].ReadOnly = true;
            DataIntervalsGrid.Rows[0].Cells[3].ReadOnly = true;
            DataIntervalsGrid.Rows[0].Cells[4].ReadOnly = true;
            DataIntervalsGrid.Rows[0].Cells[5].ReadOnly = true;
            DataIntervalsGrid.Rows[1].Cells[3].ReadOnly = true;
            DataIntervalsGrid.Rows[1].Cells[4].ReadOnly = true;
            DataIntervalsGrid.Rows[1].Cells[5].ReadOnly = true;
            DataIntervalsGrid.Rows[2].Cells[4].ReadOnly = true;
            DataIntervalsGrid.Rows[2].Cells[5].ReadOnly = true;
            if (dataIntervalsCreated == false)
            {
                string[] fr = File.ReadAllLines(SettingsLocation + "Data Intervals");
                int j = 0;
                foreach (string s in fr)
                {
                    string[] split = s.Split(',');
                    int i = 0;
                    foreach (string st in split)
                    {
                        DataIntervalsGrid.Rows[j].Cells[i].Value = st;
                        i++;
                    }
                    j++;
                }
                switch (dataType)
                {
                    case "RDR":
                        DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 0].Value);
                        break;
                    case "LT3":
                        DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 1].Value);
                        break;
                    case "LT4":
                        DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 2].Value);
                        break;
                    case "LT6":
                        DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 3].Value);
                        break;
                }
            }
            RDRDataButton.Checked = true;
            ManualModeButton.Checked = true;
            if (DefaultBox.Text == "") DefaultBox.Text = "Empty";
        }

        private void StartBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTime = StartBox.Text.ToString();
        }

        private void StartBox_Clicked(object sender, EventArgs e)
        {
            if (starterLoaded == true) return;
            if (SourceBox.Text == "")
            {
                MessageBox.Show("Source box cannot be empty", "Error");
                return;
            }
            DirectoryInfo source = new DirectoryInfo(SourceBox.Text);
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo f in files)
            {
                if (!f.Name.Contains("KAPPA")) continue;
                else
                {
                    string[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                    foreach (string s in fr)
                    {
                        if (s == "") break;
                        String[] split = s.Split(',');
                        String box = split[0] + " " + split[1];
                        StartBox.Items.Add(box);
                    }
                    starterLoaded = true;
                    return;
                }
            }
            MessageBox.Show("No KAPPA file available in source location", "Error");
        }

        private void MarketDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SourceBox.Text = "";
            DestinationBox.Text = "";
            string[] fr = File.ReadAllLines(SettingsLocation + "Markets\\" + MarketDropdown.Text.ToString());
            if (fr.Length == 0) return;
            SourceBox.Text = fr[0];
            if (fr.Length == 1) return;
            DestinationBox.Text = fr[1];
            starterLoaded = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (MarketDropdown.Text == "")
            {
                MessageBox.Show("Market dropdown is empty. Please add name.", "Error");
                return;
            }
            string answer = Convert.ToString(MessageBox.Show("Are you sure you want to save this file?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (answer == "No") return;
            else
            {
                string save = SourceBox.Text + "\n" + DestinationBox.Text;
                if (File.Exists(SettingsLocation + "Markets\\" + MarketDropdown.Text))
                {
                    File.Delete(SettingsLocation + "Markets\\" + MarketDropdown.Text);
                }
                using (FileStream fs = File.Create(SettingsLocation + "Markets\\" + MarketDropdown.Text))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(save);
                    fs.Write(info, 0, info.Length);
                }

                DirectoryInfo markets = new DirectoryInfo(SettingsLocation + "Markets");
                FileInfo[] files = markets.GetFiles();
                MarketDropdown.Items.Clear();
                foreach (FileInfo file in files)
                {
                    MarketDropdown.Items.Add(file);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MarketDropdown.Text == "")
            {
                MessageBox.Show("Market dropdown is empty. Please add name.", "Error");
                return;
            }
            string answer = Convert.ToString(MessageBox.Show("Are you sure you want to delete this file?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (answer == "No") return;
            else
            {
                File.Delete(SettingsLocation + "Markets\\" + MarketDropdown.Text);
            }
            MarketDropdown.Text = "";
            SourceBox.Text = "";
            DestinationBox.Text = "";
            DirectoryInfo markets = new DirectoryInfo(SettingsLocation + "Markets");
            FileInfo[] files = markets.GetFiles();
            MarketDropdown.Items.Clear();
            foreach (FileInfo file in files)
            {
                MarketDropdown.Items.Add(file);
            }
        }

        private void SourceBox_MouseDoubleClick(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = SourceBox.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) SourceBox.Text = folderBrowserDialog1.SelectedPath;
        }

        private void DestinationBox_MouseDoubleClick(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = DestinationBox.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) DestinationBox.Text = folderBrowserDialog1.SelectedPath;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DirectoryInfo source = new DirectoryInfo(DestinationBox.Text);
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo f in files)
            {
                if (f.Name.Contains("StratSysStatus"))
                {
                    string[] fr = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                    string load = "";
                    DateTime time = DateTime.Now;
                    string[] timeTemp = Convert.ToString(time.Date).Split(' ');
                    string temp = fr[0];
                    string[] split = temp.Split(',');
                    split[0] = timeTemp[0];
                    split[1] = Convert.ToString(time.TimeOfDay);
                    load = string.Join(",", split);
                    if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                    {
                        File.Delete(DestinationBox.Text + "\\" + f.Name);
                    }
                    using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(load);
                        fs.Write(info, 0, info.Length);
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (dataType == "RDR")
            {
                DirectoryInfo source = new DirectoryInfo(SourceBox.Text);
                FileInfo[] files = source.GetFiles();
                foreach (FileInfo f in files)
                {
                    if (f.Name.Contains("StratSysStatus") || f.Name.Contains("PriceWatch") || f.Name.Contains("Zeta") || !f.Name.Contains("RDR")) continue;
                    String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                    String fw = "";
                    String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                    String[] fn = new string[fr.Length - 1];
                    String[] nfw2 = new string[nfw.Length + 1];
                    String newFile = "";
                    int stop = 0;
                    int i = 1;
                    foreach (string s in fr)
                    {
                        if (stop == 0)
                        {
                            stop = 1;
                            fw = fr[0];
                            continue;
                        }
                        fn[i - 1] = fr[i];
                        i++;
                    }
                    if (File.Exists(SourceBox.Text + "\\" + f.Name))
                    {
                        newFile = string.Join("\n", fn);
                        File.Delete(SourceBox.Text + "\\" + f.Name);
                    }
                    using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                        fs.Write(info, 0, info.Length);
                    }
                    i = 0;
                    foreach (string s in nfw)
                    {
                        if (nfw[i] == "")
                        {
                            nfw2[i] = fw;
                            break;
                        }
                        nfw2[i] = nfw[i];
                        i++;
                    }
                    if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                    {
                        File.Delete(DestinationBox.Text + "\\" + f.Name);
                    }
                    newFile = string.Join("\n", nfw2);
                    using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                        fs.Write(info, 0, info.Length);
                    }
                }
            }
            if (dataType == "LT3")
            {
                DirectoryInfo source = new DirectoryInfo(SourceBox.Text);
                FileInfo[] files = source.GetFiles();
                String fw = "";
                int timeToLookFor = 0;
                foreach (FileInfo f in files)
                {
                    if (f.Name.Contains("RDR"))
                    {
                        String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                        string[] temp = fr[0].Split(',');
                        string[] temp2 = temp[1].Split(':');
                        timeToLookFor = Convert.ToInt32(temp2[1]);
                    }
                }
                foreach (FileInfo f in files)
                {
                    if (f.Name.Contains("StratSysStatus") || f.Name.Contains("PriceWatch") || f.Name.Contains("Zeta")) continue;
                    if (f.Name.Contains("RDR"))
                    {
                        String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                        String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                        String[] fn = new string[fr.Length - 1];
                        String[] nfw2 = new string[nfw.Length + 1];
                        String newFile = "";
                        int stop = 0;
                        int i = 1;
                        foreach (string s in fr)
                        {
                            if (stop == 0)
                            {
                                stop = 1;
                                fw = fr[0];
                                continue;
                            }
                            fn[i - 1] = fr[i];
                            i++;
                        }
                        if (File.Exists(SourceBox.Text + "\\" + f.Name))
                        {
                            newFile = string.Join("\n", fn);
                            File.Delete(SourceBox.Text + "\\" + f.Name);
                        }
                        using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                            fs.Write(info, 0, info.Length);
                        }
                        i = 0;
                        foreach (string s in nfw)
                        {
                            if (nfw[i] == "")
                            {
                                nfw2[i] = fw;
                                break;
                            }
                            nfw2[i] = nfw[i];
                            i++;
                        }
                        if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                        {
                            File.Delete(DestinationBox.Text + "\\" + f.Name);
                        }
                        newFile = string.Join("\n", nfw2);
                        using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                            fs.Write(info, 0, info.Length);
                        }
                    }
                    else if (f.Name.Contains("WTR"))
                    {
                        if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[1, 1].Value)) == 0)
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                    }
                    else if (f.Name.Contains("LT") && !f.Name.Contains("LTX") && !f.Name.Contains("LTY") && !f.Name.Contains("LTZ"))
                    {
                        if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[2, 1].Value)) == 0)
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                    }
                }
            }
            if (dataType == "LT4")
            {
                DirectoryInfo source = new DirectoryInfo(SourceBox.Text);
                FileInfo[] files = source.GetFiles();
                String fw = "";
                int timeToLookFor = 0;
                foreach (FileInfo f in files)
                {
                    if (f.Name.Contains("RDR"))
                    {
                        String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                        string[] temp = fr[0].Split(',');
                        string[] temp2 = temp[1].Split(':');
                        timeToLookFor = Convert.ToInt32(temp2[1]);
                    }
                }
                foreach (FileInfo f in files)
                {
                    if (f.Name.Contains("StratSysStatus") || f.Name.Contains("PriceWatch") || f.Name.Contains("Zeta")) continue;
                    if (f.Name.Contains("RDR"))
                    {
                        String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                        String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                        String[] fn = new string[fr.Length - 1];
                        String[] nfw2 = new string[nfw.Length + 1];
                        String newFile = "";
                        int stop = 0;
                        int i = 1;
                        foreach (string s in fr)
                        {
                            if (stop == 0)
                            {
                                stop = 1;
                                fw = fr[0];
                                continue;
                            }
                            fn[i - 1] = fr[i];
                            i++;
                        }
                        if (File.Exists(SourceBox.Text + "\\" + f.Name))
                        {
                            newFile = string.Join("\n", fn);
                            File.Delete(SourceBox.Text + "\\" + f.Name);
                        }
                        using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                            fs.Write(info, 0, info.Length);
                        }
                        i = 0;
                        foreach (string s in nfw)
                        {
                            if (nfw[i] == "")
                            {
                                nfw2[i] = fw;
                                break;
                            }
                            nfw2[i] = nfw[i];
                            i++;
                        }
                        if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                        {
                            File.Delete(DestinationBox.Text + "\\" + f.Name);
                        }
                        newFile = string.Join("\n", nfw2);
                        using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                            fs.Write(info, 0, info.Length);
                        }
                    }
                    else if (f.Name.Contains("WTR"))
                    {
                        if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[1, 2].Value)) == 0)
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                    }
                    else if (f.Name.Contains("LT") && !f.Name.Contains("LTX") && !f.Name.Contains("LTY") && !f.Name.Contains("LTZ"))
                    {
                        if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[2, 2].Value)) == 0)
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                    }
                    else if (f.Name.Contains("LTX"))
                    {
                        if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[3, 2].Value)) == 0)
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                    }
                }
            }
            if (dataType == "LT6")
            {
                DirectoryInfo source = new DirectoryInfo(SourceBox.Text);
                FileInfo[] files = source.GetFiles();
                String fw = "";
                int timeToLookFor = 0;
                foreach (FileInfo f in files)
                {
                    if (f.Name.Contains("RDR"))
                    {
                        String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                        string[] temp = fr[0].Split(',');
                        string[] temp2 = temp[1].Split(':');
                        timeToLookFor = Convert.ToInt32(temp2[1]);
                    }
                }
                foreach (FileInfo f in files)
                {
                    if (f.Name.Contains("StratSysStatus") || f.Name.Contains("PriceWatch") || f.Name.Contains("Zeta")) continue;
                    if (f.Name.Contains("RDR"))
                    {
                        String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                        String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                        String[] fn = new string[fr.Length - 1];
                        String[] nfw2 = new string[nfw.Length + 1];
                        String newFile = "";
                        int stop = 0;
                        int i = 1;
                        foreach (string s in fr)
                        {
                            if (stop == 0)
                            {
                                stop = 1;
                                fw = fr[0];
                                continue;
                            }
                            fn[i - 1] = fr[i];
                            i++;
                        }
                        if (File.Exists(SourceBox.Text + "\\" + f.Name))
                        {
                            newFile = string.Join("\n", fn);
                            File.Delete(SourceBox.Text + "\\" + f.Name);
                        }
                        using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                            fs.Write(info, 0, info.Length);
                        }
                        i = 0;
                        foreach (string s in nfw)
                        {
                            if (nfw[i] == "")
                            {
                                nfw2[i] = fw;
                                break;
                            }
                            nfw2[i] = nfw[i];
                            i++;
                        }
                        if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                        {
                            File.Delete(DestinationBox.Text + "\\" + f.Name);
                        }
                        newFile = string.Join("\n", nfw2);
                        using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                            fs.Write(info, 0, info.Length);
                        }
                    }
                    else if (f.Name.Contains("WTR"))
                    {
                        if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[1, 3].Value)) == 0)
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                    }
                    else if (f.Name.Contains("LT") && !f.Name.Contains("LTX") && !f.Name.Contains("LTY") && !f.Name.Contains("LTZ"))
                    {
                        if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[2, 3].Value)) == 0)
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                    }
                    else if (f.Name.Contains("LTX"))
                    {
                        if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[3, 3].Value)) == 0)
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                    }
                    else if (f.Name.Contains("LTY"))
                    {
                        int temp = 1;
                        if (DataIntervalsGrid[4, 3].Value == "W")
                        {
                            temp = 10080;
                        }
                        else if (DataIntervalsGrid[4, 3].Value == "M")
                        {
                            temp = 40320;
                        }
                        else
                        {
                            temp = Convert.ToInt32(DataIntervalsGrid[4, 3].Value);
                        }
                        if ((timeToLookFor % temp) == 0)
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                    }
                    else if (f.Name.Contains("LTZ"))
                    {
                        int temp = 1;
                        if (DataIntervalsGrid[5, 3].Value == "W")
                        {
                            temp = 10080;
                        }
                        else if (DataIntervalsGrid[5, 3].Value == "M")
                        {
                            temp = 40320;
                        }
                        else
                        {
                            temp = Convert.ToInt32(DataIntervalsGrid[5, 3].Value);
                        }
                        if ((timeToLookFor % temp) == 0)
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                    }
                }
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if(StartBox.Text == "")
            {
                MessageBox.Show("Must select a start time before loading", "Error");
                return;
            }
            DirectoryInfo source = new DirectoryInfo(SourceBox.Text);
            FileInfo[] files = source.GetFiles();
            DirectoryInfo dest = new DirectoryInfo(DestinationBox.Text);
            if (!dest.Exists)
            {
                string answer = Convert.ToString(MessageBox.Show("Destination directory does not exist. Do you want to create it?", "Creation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (answer == "Yes")
                {
                    Directory.CreateDirectory(DestinationBox.Text);
                }
            }
            if (!source.Exists)
            {
                MessageBox.Show("Source directory does not exist", "Error");
                return;
            }
            foreach (FileInfo f in files)
            {
                if(f.Name.Contains("PriceWatch") || f.Name.Contains("StratSysStatus"))
                {
                    string[] fl = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                    String nf = string.Join("\n", fl);
                    if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                    {
                        File.Delete(DestinationBox.Text + "\\" + f.Name);
                    }
                    using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(nf);
                        fs.Write(info, 0, info.Length);
                    }
                    continue;
                }
                if (f.Name.Contains("Zeta")) continue;
                String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                String[] fw = new string[fr.Length];
                String[] ft = new string[fr.Length];
                string[] timeSplit = selectedTime.Split(' ');
                string selectedTimeSplit = timeSplit[1];
                string selectedDateSplit = timeSplit[0];
                DateTime time;
                DateTime date;
                TimeSpan time2;
                int i = 0;
                foreach (string s in fr)
                {
                    if (s == "") break;
                    string[] split = s.Split(',');
                    time = Convert.ToDateTime(split[1]);
                    date = Convert.ToDateTime(split[0]);
                    time2 = time.TimeOfDay;
                    if (date.CompareTo(Convert.ToDateTime(selectedDateSplit)) != -1)
                    {
                        if (time2.CompareTo(Convert.ToDateTime(selectedTimeSplit).TimeOfDay) != 1)
                        {
                            fw[i] = fr[i];
                            fr[i] = null;
                            i++;
                        }
                        else break;
                    }
                    else break;
                }
                String newFile = string.Join("\n", fw);
                if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                {
                    File.Delete(DestinationBox.Text + "\\" + f.Name);
                }
                using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                    fs.Write(info, 0, info.Length);
                }
                if (File.Exists(SourceBox.Text + "\\" + f.Name))
                {
                    File.Delete(SourceBox.Text + "\\" + f.Name);
                }
                int t = 0;
                for(int j = 0; i < fr.Length; i++)
                {
                    if (fr[i] != null)
                    {
                        ft[t] = fr[i];
                        t++;
                    }
                }
                newFile = string.Join("\n", ft);
                using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                    fs.Write(info, 0, info.Length);
                }
            }
            loaded = true;
            MessageBox.Show("Loading completed successfully", "Complete");
        }

        private void MarketLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(SettingsLocation + "Markets");
        }

        private void SourceLabel_Click(object sender, EventArgs e)
        {
            if (SourceBox.Text != "") System.Diagnostics.Process.Start(SourceBox.Text);
            else MessageBox.Show("Source location is empty", "Error");
        }

        private void DestinationLabel_Click(object sender, EventArgs e)
        {
            if(DestinationBox.Text != "") System.Diagnostics.Process.Start(DestinationBox.Text);
            else MessageBox.Show("Destination location is empty", "Error");
        }

        private void ManualModeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ManualModeButton.Checked) mode = "Manual";
        }

        private void DefaultModeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DefaultModeButton.Checked) mode = "Default";
        }

        private void AutomaticModeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AutomaticModeButton.Checked) mode = "Auto";
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if(loaded != true)
            {
                string answer = Convert.ToString(MessageBox.Show("Data has not been loaded. Do you wish to continue? Note, proceeding may cause crashes", "Creation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (answer == "No")
                {
                    return;
                }
            }
            if (SourceBox.Text == "")
            {
                MessageBox.Show("Source directory cannot be empty", "Error");
                return;
            }
            if (DestinationBox.Text == "")
            {
                MessageBox.Show("Destination directory cannot be empty", "Error");
                return;
            }
            DirectoryInfo dest = new DirectoryInfo(DestinationBox.Text);
            DirectoryInfo source = new DirectoryInfo(SourceBox.Text);
            if (!dest.Exists)
            {
                string answer = Convert.ToString(MessageBox.Show("Destination directory does not exist. Do you want to create it?", "Creation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (answer == "Yes")
                {
                    Directory.CreateDirectory(DestinationBox.Text);
                }
            }
            if (!source.Exists)
            {
                MessageBox.Show("Source directory does not exist", "Error");
                return;
            }
            if (mode == "Manual")
            {
                if(dataType == "RDR")
                {
                    FileInfo[] files = source.GetFiles();
                    foreach (FileInfo f in files)
                    {
                        if (f.Name.Contains("StratSysStatus") || f.Name.Contains("PriceWatch") || f.Name.Contains("Zeta") || !f.Name.Contains("RDR")) continue;
                        String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                        String fw = "";
                        String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                        String[] fn = new string[fr.Length - 1];
                        String[] nfw2 = new string[nfw.Length + 1];
                        String newFile = "";
                        int stop = 0;
                        int i = 1;
                        foreach (string s in fr)
                        {
                            if (stop == 0)
                            {
                                stop = 1;
                                fw = fr[0];
                                continue;
                            }
                            fn[i - 1] = fr[i];
                            i++;
                        }
                        if (File.Exists(SourceBox.Text + "\\" + f.Name))
                        {
                            newFile = string.Join("\n", fn);
                            File.Delete(SourceBox.Text + "\\" + f.Name);
                        }
                        using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                            fs.Write(info, 0, info.Length);
                        }
                        i = 0;
                        foreach (string s in nfw)
                        {
                            if (nfw[i] == "")
                            {
                                nfw2[i] = fw;
                                break;
                            }
                            nfw2[i] = nfw[i];
                            i++;
                        }
                        if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                        {
                            File.Delete(DestinationBox.Text + "\\" + f.Name);
                        }
                        newFile = string.Join("\n", nfw2);
                        using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                            fs.Write(info, 0, info.Length);
                        }
                    }
                }
                if(dataType == "LT3")
                {
                    FileInfo[] files = source.GetFiles();
                    String fw = "";
                    int timeToLookFor = 0;
                    foreach (FileInfo f in files)
                    {
                        if (f.Name.Contains("RDR"))
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            string[] temp = fr[0].Split(',');
                            string[] temp2 = temp[1].Split(':');
                            timeToLookFor = Convert.ToInt32(temp2[1]);
                        }
                    }
                    foreach (FileInfo f in files)
                    {
                        if (f.Name.Contains("StratSysStatus") || f.Name.Contains("PriceWatch") || f.Name.Contains("Zeta")) continue;
                        if (f.Name.Contains("RDR"))
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                        else if (f.Name.Contains("WTR"))
                        {
                            if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[1, 1].Value)) == 0)
                            {
                                String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                                String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                                String[] fn = new string[fr.Length - 1];
                                String[] nfw2 = new string[nfw.Length + 1];
                                String newFile = "";
                                int stop = 0;
                                int i = 1;
                                foreach (string s in fr)
                                {
                                    if (stop == 0)
                                    {
                                        stop = 1;
                                        fw = fr[0];
                                        continue;
                                    }
                                    fn[i - 1] = fr[i];
                                    i++;
                                }
                                if (File.Exists(SourceBox.Text + "\\" + f.Name))
                                {
                                    newFile = string.Join("\n", fn);
                                    File.Delete(SourceBox.Text + "\\" + f.Name);
                                }
                                using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                                i = 0;
                                foreach (string s in nfw)
                                {
                                    if (nfw[i] == "")
                                    {
                                        nfw2[i] = fw;
                                        break;
                                    }
                                    nfw2[i] = nfw[i];
                                    i++;
                                }
                                if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                                {
                                    File.Delete(DestinationBox.Text + "\\" + f.Name);
                                }
                                newFile = string.Join("\n", nfw2);
                                using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                            }
                        }
                        else if (f.Name.Contains("LT") && !f.Name.Contains("LTX") && !f.Name.Contains("LTY") && !f.Name.Contains("LTZ"))
                        {
                            if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[2, 1].Value)) == 0)
                            {
                                String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                                String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                                String[] fn = new string[fr.Length - 1];
                                String[] nfw2 = new string[nfw.Length + 1];
                                String newFile = "";
                                int stop = 0;
                                int i = 1;
                                foreach (string s in fr)
                                {
                                    if (stop == 0)
                                    {
                                        stop = 1;
                                        fw = fr[0];
                                        continue;
                                    }
                                    fn[i - 1] = fr[i];
                                    i++;
                                }
                                if (File.Exists(SourceBox.Text + "\\" + f.Name))
                                {
                                    newFile = string.Join("\n", fn);
                                    File.Delete(SourceBox.Text + "\\" + f.Name);
                                }
                                using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                                i = 0;
                                foreach (string s in nfw)
                                {
                                    if (nfw[i] == "")
                                    {
                                        nfw2[i] = fw;
                                        break;
                                    }
                                    nfw2[i] = nfw[i];
                                    i++;
                                }
                                if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                                {
                                    File.Delete(DestinationBox.Text + "\\" + f.Name);
                                }
                                newFile = string.Join("\n", nfw2);
                                using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                            }
                        }
                    }
                }
                if(dataType == "LT4")
                {
                    FileInfo[] files = source.GetFiles();
                    String fw = "";
                    int timeToLookFor = 0;
                    foreach (FileInfo f in files)
                    {
                        if (f.Name.Contains("RDR"))
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            string[] temp = fr[0].Split(',');
                            string[] temp2 = temp[1].Split(':');
                            timeToLookFor = Convert.ToInt32(temp2[1]);
                        }
                    }
                    foreach (FileInfo f in files)
                    {
                        if (f.Name.Contains("StratSysStatus") || f.Name.Contains("PriceWatch") || f.Name.Contains("Zeta")) continue;
                        if (f.Name.Contains("RDR"))
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                        else if (f.Name.Contains("WTR"))
                        {
                            if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[1, 2].Value)) == 0)
                            {
                                String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                                String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                                String[] fn = new string[fr.Length - 1];
                                String[] nfw2 = new string[nfw.Length + 1];
                                String newFile = "";
                                int stop = 0;
                                int i = 1;
                                foreach (string s in fr)
                                {
                                    if (stop == 0)
                                    {
                                        stop = 1;
                                        fw = fr[0];
                                        continue;
                                    }
                                    fn[i - 1] = fr[i];
                                    i++;
                                }
                                if (File.Exists(SourceBox.Text + "\\" + f.Name))
                                {
                                    newFile = string.Join("\n", fn);
                                    File.Delete(SourceBox.Text + "\\" + f.Name);
                                }
                                using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                                i = 0;
                                foreach (string s in nfw)
                                {
                                    if (nfw[i] == "")
                                    {
                                        nfw2[i] = fw;
                                        break;
                                    }
                                    nfw2[i] = nfw[i];
                                    i++;
                                }
                                if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                                {
                                    File.Delete(DestinationBox.Text + "\\" + f.Name);
                                }
                                newFile = string.Join("\n", nfw2);
                                using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                            }
                        }
                        else if (f.Name.Contains("LT") && !f.Name.Contains("LTX") && !f.Name.Contains("LTY") && !f.Name.Contains("LTZ"))
                        {
                            if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[2, 2].Value)) == 0)
                            {
                                String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                                String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                                String[] fn = new string[fr.Length - 1];
                                String[] nfw2 = new string[nfw.Length + 1];
                                String newFile = "";
                                int stop = 0;
                                int i = 1;
                                foreach (string s in fr)
                                {
                                    if (stop == 0)
                                    {
                                        stop = 1;
                                        fw = fr[0];
                                        continue;
                                    }
                                    fn[i - 1] = fr[i];
                                    i++;
                                }
                                if (File.Exists(SourceBox.Text + "\\" + f.Name))
                                {
                                    newFile = string.Join("\n", fn);
                                    File.Delete(SourceBox.Text + "\\" + f.Name);
                                }
                                using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                                i = 0;
                                foreach (string s in nfw)
                                {
                                    if (nfw[i] == "")
                                    {
                                        nfw2[i] = fw;
                                        break;
                                    }
                                    nfw2[i] = nfw[i];
                                    i++;
                                }
                                if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                                {
                                    File.Delete(DestinationBox.Text + "\\" + f.Name);
                                }
                                newFile = string.Join("\n", nfw2);
                                using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                            }
                        }
                        else if (f.Name.Contains("LTX"))
                        {
                            if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[3, 2].Value)) == 0)
                            {
                                String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                                String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                                String[] fn = new string[fr.Length - 1];
                                String[] nfw2 = new string[nfw.Length + 1];
                                String newFile = "";
                                int stop = 0;
                                int i = 1;
                                foreach (string s in fr)
                                {
                                    if (stop == 0)
                                    {
                                        stop = 1;
                                        fw = fr[0];
                                        continue;
                                    }
                                    fn[i - 1] = fr[i];
                                    i++;
                                }
                                if (File.Exists(SourceBox.Text + "\\" + f.Name))
                                {
                                    newFile = string.Join("\n", fn);
                                    File.Delete(SourceBox.Text + "\\" + f.Name);
                                }
                                using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                                i = 0;
                                foreach (string s in nfw)
                                {
                                    if (nfw[i] == "")
                                    {
                                        nfw2[i] = fw;
                                        break;
                                    }
                                    nfw2[i] = nfw[i];
                                    i++;
                                }
                                if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                                {
                                    File.Delete(DestinationBox.Text + "\\" + f.Name);
                                }
                                newFile = string.Join("\n", nfw2);
                                using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                            }
                        }
                    }
                }
                if(dataType == "LT6")
                {
                    FileInfo[] files = source.GetFiles();
                    String fw = "";
                    int timeToLookFor = 0;
                    foreach (FileInfo f in files)
                    {
                        if (f.Name.Contains("RDR"))
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            string[] temp = fr[0].Split(',');
                            string[] temp2 = temp[1].Split(':');
                            timeToLookFor = Convert.ToInt32(temp2[1]);
                        }
                    }
                    foreach (FileInfo f in files)
                    {
                        if (f.Name.Contains("StratSysStatus") || f.Name.Contains("PriceWatch") || f.Name.Contains("Zeta")) continue;
                        if (f.Name.Contains("RDR"))
                        {
                            String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                            String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                            String[] fn = new string[fr.Length - 1];
                            String[] nfw2 = new string[nfw.Length + 1];
                            String newFile = "";
                            int stop = 0;
                            int i = 1;
                            foreach (string s in fr)
                            {
                                if (stop == 0)
                                {
                                    stop = 1;
                                    fw = fr[0];
                                    continue;
                                }
                                fn[i - 1] = fr[i];
                                i++;
                            }
                            if (File.Exists(SourceBox.Text + "\\" + f.Name))
                            {
                                newFile = string.Join("\n", fn);
                                File.Delete(SourceBox.Text + "\\" + f.Name);
                            }
                            using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                            i = 0;
                            foreach (string s in nfw)
                            {
                                if (nfw[i] == "")
                                {
                                    nfw2[i] = fw;
                                    break;
                                }
                                nfw2[i] = nfw[i];
                                i++;
                            }
                            if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                            {
                                File.Delete(DestinationBox.Text + "\\" + f.Name);
                            }
                            newFile = string.Join("\n", nfw2);
                            using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                fs.Write(info, 0, info.Length);
                            }
                        }
                        else if (f.Name.Contains("WTR"))
                        {
                            if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[1, 3].Value)) == 0)
                            {
                                String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                                String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                                String[] fn = new string[fr.Length - 1];
                                String[] nfw2 = new string[nfw.Length + 1];
                                String newFile = "";
                                int stop = 0;
                                int i = 1;
                                foreach (string s in fr)
                                {
                                    if (stop == 0)
                                    {
                                        stop = 1;
                                        fw = fr[0];
                                        continue;
                                    }
                                    fn[i - 1] = fr[i];
                                    i++;
                                }
                                if (File.Exists(SourceBox.Text + "\\" + f.Name))
                                {
                                    newFile = string.Join("\n", fn);
                                    File.Delete(SourceBox.Text + "\\" + f.Name);
                                }
                                using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                                i = 0;
                                foreach (string s in nfw)
                                {
                                    if (nfw[i] == "")
                                    {
                                        nfw2[i] = fw;
                                        break;
                                    }
                                    nfw2[i] = nfw[i];
                                    i++;
                                }
                                if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                                {
                                    File.Delete(DestinationBox.Text + "\\" + f.Name);
                                }
                                newFile = string.Join("\n", nfw2);
                                using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                            }
                        }
                        else if (f.Name.Contains("LT") && !f.Name.Contains("LTX") && !f.Name.Contains("LTY") && !f.Name.Contains("LTZ"))
                        {
                            if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[2, 3].Value)) == 0)
                            {
                                String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                                String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                                String[] fn = new string[fr.Length - 1];
                                String[] nfw2 = new string[nfw.Length + 1];
                                String newFile = "";
                                int stop = 0;
                                int i = 1;
                                foreach (string s in fr)
                                {
                                    if (stop == 0)
                                    {
                                        stop = 1;
                                        fw = fr[0];
                                        continue;
                                    }
                                    fn[i - 1] = fr[i];
                                    i++;
                                }
                                if (File.Exists(SourceBox.Text + "\\" + f.Name))
                                {
                                    newFile = string.Join("\n", fn);
                                    File.Delete(SourceBox.Text + "\\" + f.Name);
                                }
                                using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                                i = 0;
                                foreach (string s in nfw)
                                {
                                    if (nfw[i] == "")
                                    {
                                        nfw2[i] = fw;
                                        break;
                                    }
                                    nfw2[i] = nfw[i];
                                    i++;
                                }
                                if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                                {
                                    File.Delete(DestinationBox.Text + "\\" + f.Name);
                                }
                                newFile = string.Join("\n", nfw2);
                                using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                            }
                        }
                        else if (f.Name.Contains("LTX"))
                        {
                            if ((timeToLookFor % Convert.ToInt32(DataIntervalsGrid[3, 3].Value)) == 0)
                            {
                                String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                                String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                                String[] fn = new string[fr.Length - 1];
                                String[] nfw2 = new string[nfw.Length + 1];
                                String newFile = "";
                                int stop = 0;
                                int i = 1;
                                foreach (string s in fr)
                                {
                                    if (stop == 0)
                                    {
                                        stop = 1;
                                        fw = fr[0];
                                        continue;
                                    }
                                    fn[i - 1] = fr[i];
                                    i++;
                                }
                                if (File.Exists(SourceBox.Text + "\\" + f.Name))
                                {
                                    newFile = string.Join("\n", fn);
                                    File.Delete(SourceBox.Text + "\\" + f.Name);
                                }
                                using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                                i = 0;
                                foreach (string s in nfw)
                                {
                                    if (nfw[i] == "")
                                    {
                                        nfw2[i] = fw;
                                        break;
                                    }
                                    nfw2[i] = nfw[i];
                                    i++;
                                }
                                if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                                {
                                    File.Delete(DestinationBox.Text + "\\" + f.Name);
                                }
                                newFile = string.Join("\n", nfw2);
                                using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                            }
                        }
                        else if (f.Name.Contains("LTY"))
                        {
                            int temp = 1;
                            if (DataIntervalsGrid[4, 3].Value == "W")
                            {
                                temp = 10080;
                            }
                            else if (DataIntervalsGrid[4, 3].Value == "M")
                            {
                                temp = 40320;
                            }
                            else
                            {
                                temp = Convert.ToInt32(DataIntervalsGrid[4, 3].Value);
                            }
                            if ((timeToLookFor % temp) == 0)
                            {
                                String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                                String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                                String[] fn = new string[fr.Length - 1];
                                String[] nfw2 = new string[nfw.Length + 1];
                                String newFile = "";
                                int stop = 0;
                                int i = 1;
                                foreach (string s in fr)
                                {
                                    if (stop == 0)
                                    {
                                        stop = 1;
                                        fw = fr[0];
                                        continue;
                                    }
                                    fn[i - 1] = fr[i];
                                    i++;
                                }
                                if (File.Exists(SourceBox.Text + "\\" + f.Name))
                                {
                                    newFile = string.Join("\n", fn);
                                    File.Delete(SourceBox.Text + "\\" + f.Name);
                                }
                                using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                                i = 0;
                                foreach (string s in nfw)
                                {
                                    if (nfw[i] == "")
                                    {
                                        nfw2[i] = fw;
                                        break;
                                    }
                                    nfw2[i] = nfw[i];
                                    i++;
                                }
                                if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                                {
                                    File.Delete(DestinationBox.Text + "\\" + f.Name);
                                }
                                newFile = string.Join("\n", nfw2);
                                using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                            }
                        }
                        else if (f.Name.Contains("LTZ"))
                        {
                            int temp = 1;
                            if(DataIntervalsGrid[5, 3].Value == "W")
                            {
                                temp = 10080;
                            }
                            else if(DataIntervalsGrid[5, 3].Value == "M")
                            {
                                temp = 40320;
                            }
                            else
                            {
                                temp = Convert.ToInt32(DataIntervalsGrid[5, 3].Value);
                            }
                            if ((timeToLookFor % temp) == 0)
                            {
                                String[] fr = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                                String[] nfw = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                                String[] fn = new string[fr.Length - 1];
                                String[] nfw2 = new string[nfw.Length + 1];
                                String newFile = "";
                                int stop = 0;
                                int i = 1;
                                foreach (string s in fr)
                                {
                                    if (stop == 0)
                                    {
                                        stop = 1;
                                        fw = fr[0];
                                        continue;
                                    }
                                    fn[i - 1] = fr[i];
                                    i++;
                                }
                                if (File.Exists(SourceBox.Text + "\\" + f.Name))
                                {
                                    newFile = string.Join("\n", fn);
                                    File.Delete(SourceBox.Text + "\\" + f.Name);
                                }
                                using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                                i = 0;
                                foreach (string s in nfw)
                                {
                                    if (nfw[i] == "")
                                    {
                                        nfw2[i] = fw;
                                        break;
                                    }
                                    nfw2[i] = nfw[i];
                                    i++;
                                }
                                if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                                {
                                    File.Delete(DestinationBox.Text + "\\" + f.Name);
                                }
                                newFile = string.Join("\n", nfw2);
                                using (FileStream fs = File.Create(DestinationBox.Text + "\\" + f.Name))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(newFile);
                                    fs.Write(info, 0, info.Length);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("This button is for Manual mode only");
            }
        }

        private void RDRDataButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RDRDataButton.Checked) dataType = "RDR";
            switch (dataType)
            {
                case "RDR":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 0].Value);
                    break;
                case "LT3":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 1].Value);
                    break;
                case "LT4":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 2].Value);
                    break;
                case "LT6":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 3].Value);
                    break;
            }
        }

        private void LT3DataButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LT3DataButton.Checked) dataType = "LT3";
            switch (dataType)
            {
                case "RDR":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 0].Value);
                    break;
                case "LT3":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 1].Value);
                    break;
                case "LT4":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 2].Value);
                    break;
                case "LT6":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 3].Value);
                    break;
            }
        }

        private void LT4DataButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LT4DataButton.Checked) dataType = "LT4";
            switch (dataType)
            {
                case "RDR":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 0].Value);
                    break;
                case "LT3":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 1].Value);
                    break;
                case "LT4":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 2].Value);
                    break;
                case "LT6":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 3].Value);
                    break;
            }
        }

        private void LT6DataButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LT6DataButton.Checked) dataType = "LT6";
            switch (dataType)
            {
                case "RDR":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 0].Value);
                    break;
                case "LT3":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 1].Value);
                    break;
                case "LT4":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 2].Value);
                    break;
                case "LT6":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 3].Value);
                    break;
            }
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            if (MarketDropdown.Text == "")
            {
                MessageBox.Show("Market dropdown is empty. Please add name.", "Error");
                return;
            }
            string answer = Convert.ToString(MessageBox.Show("Are you sure you want to save this as a new file?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (answer == "No") return;
            else
            {
                string save = SourceBox.Text + "\n" + DestinationBox.Text;
                if (File.Exists(SettingsLocation + "Markets\\" + MarketDropdown.Text))
                {
                    File.Delete(SettingsLocation + "Markets\\" + MarketDropdown.Text);
                }
                using (FileStream fs = File.Create(SettingsLocation + "Markets\\" + MarketDropdown.Text))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(save);
                    fs.Write(info, 0, info.Length);
                }

                DirectoryInfo markets = new DirectoryInfo(SettingsLocation + "Markets");
                FileInfo[] files = markets.GetFiles();
                MarketDropdown.Items.Clear();
                foreach (FileInfo file in files)
                {
                    MarketDropdown.Items.Add(file);
                }
            }
        }

        private void DataIntervalsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch(dataType)
            {
                case "RDR":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 0].Value);
                    break;
                case "LT3":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 1].Value);
                    break;
                case "LT4":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 2].Value);
                    break;
                case "LT6":
                    DefaultBox.Text = Convert.ToString(DataIntervalsGrid[0, 3].Value);
                    break;
            }

            string save = "";
            int i = 0;
            foreach(DataGridViewRow row in DataIntervalsGrid.Rows)
            {
                if (i == 0)
                {
                    save += DataIntervalsGrid[0, 0].Value + "\n";
                }
                if (i == 1)
                {
                    save += Convert.ToString(DataIntervalsGrid[0, 1].Value) + "," + Convert.ToString(DataIntervalsGrid[1, 1].Value) + "," + Convert.ToString(DataIntervalsGrid[2, 1].Value) + "\n";
                }
                if (i == 2)
                {
                    save += Convert.ToString(DataIntervalsGrid[0, 2].Value) + "," + Convert.ToString(DataIntervalsGrid[1, 2].Value) + "," + Convert.ToString(DataIntervalsGrid[2, 2].Value) + "," + Convert.ToString(DataIntervalsGrid[3, 2].Value) + "\n";
                }
                if (i == 3)
                {
                    save += Convert.ToString(DataIntervalsGrid[0, 3].Value) + "," + Convert.ToString(DataIntervalsGrid[1, 3].Value) + "," + Convert.ToString(DataIntervalsGrid[2, 3].Value) + "," + Convert.ToString(DataIntervalsGrid[3, 3].Value) + "," + Convert.ToString(DataIntervalsGrid[4, 3].Value) + "," + Convert.ToString(DataIntervalsGrid[5, 3].Value);
                }
                i++;
            }
            if (File.Exists(SettingsLocation + "Data Intervals"))
            {
                File.Delete(SettingsLocation + "Data Intervals");
            }
            using (FileStream fs = File.Create(SettingsLocation + "Data Intervals"))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(save);
                fs.Write(info, 0, info.Length);
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (loaded != true)
            {
                string answer = Convert.ToString(MessageBox.Show("Data has not been loaded. Do you wish to continue? Note, proceeding may cause crashes", "Creation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (answer == "No")
                {
                    return;
                }
            }
            switch (dataType)
            {
                case "RDR":
                    if(Convert.ToString(DataIntervalsGrid[0, 0].Value) == "")
                    {
                        MessageBox.Show("Please fill in data intervals tabel", "Error");
                        return;
                    }
                    break;
                case "LT3":
                    if (Convert.ToString(DataIntervalsGrid[0, 1].Value) == "" || Convert.ToString(DataIntervalsGrid[1, 1].Value) == "" || Convert.ToString(DataIntervalsGrid[2, 1].Value) == "")
                    {
                        MessageBox.Show("Please fill in data intervals tabel", "Error");
                        return;
                    }
                    break;
                case "LT4":
                    if (Convert.ToString(DataIntervalsGrid[0, 2].Value) == "" || Convert.ToString(DataIntervalsGrid[1, 2].Value) == "" || Convert.ToString(DataIntervalsGrid[2, 2].Value) == "" || Convert.ToString(DataIntervalsGrid[3, 2].Value) == "")
                    {
                        MessageBox.Show("Please fill in data intervals tabel", "Error");
                        return;
                    }
                    break;
                case "LT6":
                    if (Convert.ToString(DataIntervalsGrid[0, 3].Value) == "" || Convert.ToString(DataIntervalsGrid[1, 3].Value) == "" || Convert.ToString(DataIntervalsGrid[2, 3].Value) == "" || Convert.ToString(DataIntervalsGrid[3, 3].Value) == "" || Convert.ToString(DataIntervalsGrid[4, 3].Value) == "" || Convert.ToString(DataIntervalsGrid[5, 3].Value) == "")
                    {
                        MessageBox.Show("Please fill in data intervals tabel", "Error");
                        return;
                    }
                    break;
            }
            if (SourceBox.Text == "")
            {
                MessageBox.Show("Source directory cannot be empty", "Error");
                return;
            }
            if (DestinationBox.Text == "")
            {
                MessageBox.Show("Destination directory cannot be empty", "Error");
                return;
            }
            if (mode == "Default")
            {
                DefaultModeButton.BackColor = Color.DarkGreen;
                DefaultModeButton.ForeColor = Color.White;
            }
            else if (mode == "Auto")
            {
                AutomaticModeButton.BackColor = Color.DarkGreen;
                AutomaticModeButton.ForeColor = Color.White;
            }
            DirectoryInfo dest = new DirectoryInfo(DestinationBox.Text);
            DirectoryInfo source = new DirectoryInfo(SourceBox.Text);
            if (!dest.Exists)
            {
                string answer = Convert.ToString(MessageBox.Show("Destination directory does not exist. Do you want to create it?", "Creation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (answer == "Yes")
                {
                    Directory.CreateDirectory(DestinationBox.Text);
                }
            }
            if(!source.Exists)
            {
                MessageBox.Show("Source directory does not exist", "Error");
                return;
            }
            if (mode != "Manual")
            {
                if (StatusBox.Text == "")
                {
                    MessageBox.Show("StratSysStatus mrkt file update interval is empty", "Error");
                    return;
                }
                timer1.Interval = 1000 * Convert.ToInt32(StatusBox.Text);
                if (mode == "Default") timer2.Interval = 60000 * Convert.ToInt32(DefaultBox.Text);
                else if (mode == "Auto")
                {
                    if (AutoBox.Text == "")
                    {
                        MessageBox.Show("Auto interval is empty", "Error");
                        return;
                    }
                    timer2.Interval = 1000 * Convert.ToInt32(AutoBox.Text);
                }
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
            else
            {
                MessageBox.Show("These buttons are not for manual mode. Switch modes to use.", "Error");
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            if (mode == "Default")
            {
                DefaultModeButton.BackColor = Form.DefaultBackColor;
                DefaultModeButton.ForeColor = Color.Black;
            }
            else if (mode == "Auto")
            {
                AutomaticModeButton.BackColor = Form.DefaultBackColor;
                AutomaticModeButton.ForeColor = Color.Black;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            if(loaded != true)
            {
                string answer = Convert.ToString(MessageBox.Show("Data has not been loaded. Do you wish to continue? Note, proceeding may cause crashes", "Creation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (answer == "No")
                {
                    return;
                }
            }
            loaded = false;
            if (SourceBox.Text == "")
            {
                MessageBox.Show("Source directory cannot be empty", "Error");
                return;
            }
            if (DestinationBox.Text == "")
            {
                MessageBox.Show("Destination directory cannot be empty", "Error");
                return;
            }
            DirectoryInfo source = new DirectoryInfo(SourceBox.Text);
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo f in files)
            {
                String file = "";
                if (!File.Exists(DestinationBox.Text + "\\" + f.Name) || f.Name.Contains("Zeta")) continue;
                String[] destinationFilePieces = File.ReadAllLines(DestinationBox.Text + "\\" + f.Name);
                String[] sourceFilePieces = File.ReadAllLines(SourceBox.Text + "\\" + f.Name);
                foreach (String s in destinationFilePieces)
                {
                    if (s == "" && !f.Name.Contains("PriceWatch") && !f.Name.Contains("StratSysStatus"))
                    {
                        foreach (string st in sourceFilePieces)
                        {
                            file += st + "\n";
                        }
                        break;
                    }
                    file += s + "\n";
                }
                if (File.Exists(SourceBox.Text + "\\" + f.Name))
                {
                    File.Delete(SourceBox.Text + "\\" + f.Name);
                }
                if (File.Exists(DestinationBox.Text + "\\" + f.Name))
                {
                    File.Delete(DestinationBox.Text + "\\" + f.Name);
                }
                using (FileStream fs = File.Create(SourceBox.Text + "\\" + f.Name))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(file);
                    fs.Write(info, 0, info.Length);
                }
            }
            MessageBox.Show("Reset complete", "Complete");
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            if (mode == "Default")
            {
                DefaultModeButton.BackColor = Form.DefaultBackColor;
                DefaultModeButton.ForeColor = Color.Black;
            }
            else if (mode == "Auto")
            {
                AutomaticModeButton.BackColor = Form.DefaultBackColor;
                AutomaticModeButton.ForeColor = Color.Black;
            }
        }

        private void HelpPDFButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(SettingsLocation + "\\Emulator.pdf")) System.Diagnostics.Process.Start(SettingsLocation + "\\Emulator.pdf");
            else MessageBox.Show("Emulator.pdf file missing from settings location", "Error");
        }
    }
}