using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;

namespace ModConflictChecker
{
    public partial class Form1 : Form
    {
        private string modsRoot = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = "Select the root directory containing multiple mod folders"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                modsRoot = dialog.SelectedPath;
                lblFolder.Text = modsRoot;
                txtOutput.AppendText($"Selected folder: {modsRoot}\n");
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(modsRoot) || !Directory.Exists(modsRoot))
            {
                MessageBox.Show("Please select a valid directory first.");
                return;
            }

            txtOutput.Clear();
            txtOutput.AppendText($"🔍 Scanning: {modsRoot}\n\n");

            FindDuplicateNames(modsRoot);
        }

        // regex for @name="something"
        static readonly Regex NameRegex = new(
            @"@name=['""]([^'""]+)['""]",
            RegexOptions.IgnoreCase | RegexOptions.Compiled
        );

        private static List<string> ExtractNamesFromXPath(string xpath) =>
            NameRegex.Matches(xpath)
                .Select(m => m.Groups[1].Value)
                .ToList();

        private static string NormalizePath(string path) =>
            path.Replace('\\', '/').ToLowerInvariant();

        private void FindDuplicateNames(string modsRoot)
        {
            var nameMap = new Dictionary<string, HashSet<(string mod, string path)>>();

            foreach (var modPath in Directory.GetDirectories(modsRoot))
            {
                string modName = Path.GetFileName(modPath);
                string configPath = Path.Combine(modPath, "config");

                if (!Directory.Exists(configPath))
                    continue;

                foreach (var filePath in Directory.GetFiles(configPath, "*.xml", SearchOption.AllDirectories))
                {
                    try
                    {
                        var doc = XDocument.Load(filePath);
                        string relPath = Path.GetRelativePath(modsRoot, filePath);
                        string normPath = NormalizePath(relPath);

                        foreach (var elem in doc.Descendants("set"))
                        {
                            string xpath = elem.Attribute("xpath")?.Value ?? "";
                            var names = ExtractNamesFromXPath(xpath);

                            foreach (var name in names)
                            {
                                string key = name.ToLowerInvariant();

                                if (!nameMap.ContainsKey(key))
                                    nameMap[key] = new HashSet<(string, string)>();

                                nameMap[key].Add((modName, normPath));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        txtOutput.AppendText($"⚠️ Parsing failed: {filePath}, Error: {ex.Message}\n");
                    }
                }
            }

            var highRisk = new Dictionary<string, HashSet<(string, string)>>();
            var warning = new Dictionary<string, HashSet<(string, string)>>();

            foreach (var (name, locations) in nameMap)
            {
                if (locations.Count <= 1)
                    continue;

                var mods = locations.Select(x => x.mod).ToHashSet();

                if (mods.Count > 1)
                    highRisk[name] = locations;
                else
                    warning[name] = locations;
            }

            PrintResults(highRisk, warning);
        }

        private void PrintResults(
            Dictionary<string, HashSet<(string mod, string path)>> highRisk,
            Dictionary<string, HashSet<(string mod, string path)>> warning)
        {
            txtOutput.SelectionColor = Color.Red;
            txtOutput.AppendText(new string('=', 40) + "\n");
            txtOutput.SelectionColor = Color.Red;
            txtOutput.AppendText("🚨 High-risk conflicts (multiple mod folders)\n");
            txtOutput.SelectionColor = Color.Red;
            txtOutput.AppendText(new string('=', 40) + "\n");

            if (highRisk.Count > 0)
            {
                foreach (var (name, locations) in highRisk)
                {
                    txtOutput.AppendText($"@name = '{name}' appears in:\n");

                    foreach (var (mod, xml) in locations.OrderBy(x => x.mod))
                        txtOutput.AppendText($"  - Mod: {mod}, File: {xml}\n");

                    txtOutput.AppendText("\n");
                }
            }
            else
            {
                txtOutput.AppendText("✅ No high-risk conflicts.\n\n");
            }
            txtOutput.SelectionColor = Color.Yellow;
            txtOutput.AppendText(new string('=', 40) + "\n");
            txtOutput.SelectionColor = Color.Yellow;
            txtOutput.AppendText("⚠️ Warning (duplicates inside same mod)\n");
            txtOutput.SelectionColor = Color.Yellow;
            txtOutput.AppendText(new string('=', 40) + "\n");

            if (warning.Count > 0)
            {
                foreach (var (name, locations) in warning)
                {
                    txtOutput.AppendText($"@name = '{name}' appears in:\n");

                    foreach (var (mod, xml) in locations.OrderBy(x => x.mod))
                        txtOutput.AppendText($"  - Mod: {mod}, File: {xml}\n");

                    txtOutput.AppendText("\n");
                }
            }
            else
            {
                txtOutput.SelectionColor = Color.Green;
                txtOutput.AppendText("✅ No internal conflicts.\n");
            }
        }

        private void btnNorm_Click(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ButtonShadow;
            this.ForeColor = SystemColors.ControlText;
            txtOutput.BackColor = SystemColors.ButtonShadow;
            txtOutput.ForeColor = SystemColors.ControlText;
            btnScan.BackColor = SystemColors.ButtonFace;
            btnSelectFolder.BackColor = SystemColors.ButtonFace;
            btnDark.BackColor = SystemColors.ButtonFace;
            btnNorm.BackColor = SystemColors.ButtonFace;
        }

        private void btnDark_Click(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ActiveCaptionText;
            this.ForeColor = SystemColors.Highlight;
            txtOutput.BackColor = SystemColors.ActiveCaptionText;
            txtOutput.ForeColor = SystemColors.Highlight;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var aboutBox = new xmlmodchecker.AboutBox();
            aboutBox.ShowDialog();
        }
    }
}
