/* -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
             _________ ______   _______                  _______  ______   _______ _________ _______  _______                _______ 
    |\     /|\__   __/(  __  \ (  ____ \       |\     /|(  ____ )(  __  \ (  ___  )\__   __/(  ____ \(  ____ )     |\     /|/ ___   )
    | )   ( |   ) (   | (  \  )| (    \/       | )   ( || (    )|| (  \  )| (   ) |   ) (   | (    \/| (    )|     | )   ( |\/   )  |
    | | _ | |   | |   | |   ) || (__           | |   | || (____)|| |   ) || (___) |   | |   | (__    | (____)|     | |   | |    /   )
    | |( )| |   | |   | |   | ||  __)          | |   | ||  _____)| |   | ||  ___  |   | |   |  __)   |     __)     ( (   ) )  _/   / 
    | || || |   | |   | |   ) || (             | |   | || (      | |   ) || (   ) |   | |   | (      | (\ (         \ \_/ /  /   _/  
    | () () |   | |   | (__/  )| (____/\       | (___) || )      | (__/  )| )   ( |   | |   | (____/\| ) \ \__       \   /  (   (__/\
    (_______)   )_(   (______/ (_______/       (_______)|/       (______/ |/     \|   )_(   (_______/|/   \__/        \_/   \_______/

    GHWT: Definitive Edition Updater Version 2 - By IMF24
     - - - - - - - - - - - - - - - - - - - - - - - - - -

    

-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- */
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Diagnostics;
using Microsoft.Win32;
using MadMilkman.Ini;

namespace WTDE_Updater_V2 {
    public partial class Main : Form {
        public string OWD = Directory.GetCurrentDirectory();

        public Main() {
            InitializeComponent();
            AttemptGHWTInstallPath();
            this.Text = $"GHWT: Definitive Edition Updater - V{VERSION}";
            VersionInfoLabel.Text = $"GHWT: DE Updater V{VERSION} by IMF24\nBG Image: Fox (FoxInari)";

            TipLabel.Text = "";

            HeadLabel.Text = "Press the \"Start Update\" button below,\nand watch the magic happen!\n\nThen just sit back; we'll handle the rest.";
            CurrentFileLabel.Text = "Current File Progress";


        }

        public const string VERSION = "2.0";

        public void UpdateAutoExecute() {
            try {
                IniFile file = new IniFile();
                file.Load("Updater.ini");

                if (file.Sections["Updater"].Keys["AutoUpdate"].Value == "1") {
                    ExecuteDownload(file.Sections["Updater"].Keys["GameDirectory"].Value);
                    this.Show();
                }
            } catch {
                return;
            }
        }

        public string[] GetHashListData() {
            using (WebClient client = new WebClient()) {
                string downloadString = client.DownloadString("https://gitgud.io/fretworks/ghwt-de-volatile/-/raw/master/GHWTDE/hashlist.dat");
                return downloadString.Split(new char[] { '\r', '\n' });
            }
        }

        public string GetUserHash(string fileToCheck) {
            if (!File.Exists(fileToCheck)) return "00000000000000000000000000000000";
            using (var md5 = MD5.Create()) {
                using (var file = File.OpenRead(fileToCheck)) {
                    var hash = md5.ComputeHash(file);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public async void ExecuteDownload(string workDir) {
            BeginUpdate.Enabled = false;
            EndUpdateButton.Enabled = true;

            BackgroundWorkerMain.RunWorkerAsync();

            // For our convenience, let's set our working directory to the user provided one.
            Directory.SetCurrentDirectory(workDir);

            // First two lines, we can skip. Also update the header label.
            string[] hashListData = GetHashListData();
            string version = hashListData[1];
            HeadLabel.Text = "Sit tight, we're updating your mod!\n" +
                             $"Updating to Version {version}...\n\n" +
                             "Be patient, make yourself a cup of tea...";

            var filePaths = new List<string>();
            var fileHashes = new List<string>();
            // var fileOuts = new List<string>();
            var fileOutPaths = new List<string>();
            var fileDirs = new List<string>();
            for (var i = 2; i < hashListData.Length; i += 2) {
                filePaths.Add("https://gitgud.io/fretworks/ghwt-de-volatile/-/raw/master/GHWTDE/" + hashListData[i]);
            }
            for (var i = 3; i < hashListData.Length; i += 2) {
                fileHashes.Add(hashListData[i]);
            }
            for (var i = 0; i < filePaths.Count; i++) {
                using (WebClient wc = new WebClient()) {
                    string newOutDir = filePaths[i].Split("Content/").Last();
                    Console.WriteLine($"new out dir: {newOutDir}");
                    fileOutPaths.Add(newOutDir);
                }
            }
            TotalProgress.Maximum = filePaths.Count;
            /*
            for (var i = 0; i < filePaths.Count; i++) {
                foreach (var path in fileOutPaths) {
                    string currentPath = filePaths[i].Split("/").First();
                    string fileName = filePaths[i].Split("/").Last();

                    string newPath = currentPath + path + fileName;
                    fileDirs.Add(newPath);
                }
            }
            */

            Console.WriteLine($"Is there even data in hashListData? {hashListData.Length}");

            Console.WriteLine($"-- ARRAY LENGTH CHECK ---------------\n" +
                              $"filePaths = {filePaths.Count}\n" +
                              $"fileHashes = {fileHashes.Count}\n" +
                              // $"fileOuts = {fileOuts.Count}\n" +
                              $"fileOutPaths = {fileOutPaths.Count}\n");
            // $"fileDirs = {fileDirs.Count}");
            // if (filePaths.Length == fileHashes.Length) Console.WriteLine("Hey, both lists are equal in length!");

            HeadLabel.Text.Replace("Version x", $"Version {hashListData[1]}");

            Application.DoEvents();

            // Start at index 2, this is weird, but necessary.
            int filesDone = 0;
            int totalFiles = filePaths.Count;
            for (var i = 0; i < fileOutPaths.Count; i++) {
                var dl = filePaths[i];
                var fl = fileOutPaths[i];

                Console.WriteLine($"Downloading file {dl}, save to {fl}");

                CurrentFileLabel.Text = $"Checking File: {fl}";
                TotalProgressLabel.Text = $"Total Progress - {filesDone + 1} of {filePaths.Count}";


                Application.DoEvents();

                string[] pathSplit = fl.Split("/");
                string path = "";
                for (var j = 0; j < pathSplit.Length - 1; j++) path += pathSplit[j] + "/";
                if (path == "") path = ".";
                Console.WriteLine($"does dir ({path}) exist? {Directory.Exists(path)}");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                if (fileHashes[i].ToUpper() != GetUserHash(fl).ToUpper()) {
                    using (var client = new HttpClientDownloadWithProgress(dl, fl)) {
                        client.ProgressChanged += (totalFileSize, totalBytesDownloaded, progressPercentage) => {
                            CurrentFileProgress.Maximum = (int)totalFileSize;
                            CurrentFileProgressPercent.Text = $"{progressPercentage}%";
                            CurrentFileProgress.Value = (int)totalBytesDownloaded;
                        };
                        CurrentFileLabel.Text = $"Downloading File: {fl}";
                        await client.StartDownload();
                    }
                }

                filesDone++;
                TotalProgress.Value = filesDone;

                double totalProgressSoFar = ((double)TotalProgress.Value / (double)TotalProgress.Maximum) * 100;
                Console.WriteLine($"current progress: {totalProgressSoFar}%");
                TotalProgressPercent.Text = $"{totalProgressSoFar.ToString("0.00")}%";
                this.Text = $"GHWT: Definitive Edition Updater - V{VERSION} - Updated {filesDone} of {filePaths.Count} Files ({totalProgressSoFar.ToString("0.00")}%)";

                Application.DoEvents();
            }
            if (filesDone >= filePaths.Count) {
                CurrentFileLabel.Text = "Download Complete!";
                EndUpdateButton.Text = "Awesome, Thanks!";
                HeadLabel.Text = "Your copy of GHWT: DE is completely\nUP TO DATE!\nEnjoy the definitive experience!";

                this.Text = $"GHWT: Definitive Edition Updater - V{VERSION} - Update Complete!";
                return;
            }
        }

        public void WriteUpdaterINI(string ghwtPath) {
            using (StreamWriter sw = new StreamWriter("Updater.ini", false)) {
                sw.WriteLine($"[Updater]\nGameDirectory={ghwtPath}\nAutoUpdate=1\nStartAfterFinish=1");
            }
        }

        public string GetUpdaterINIPath() {
            IniFile file = new IniFile();
            file.Load("Updater.ini");
            return file.Sections["Updater"].Keys["GameDirectory"].Value;
        }

        public void AttemptGHWTInstallPath() {
            // Attempt to guess the installation path from the Windows Registry.
            if (!File.Exists("Updater.ini")) {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Aspyr\\Guitar Hero World Tour")) {
                    if (key != null) {
                        string ghwtPath = key.GetValue("Path").ToString().Replace("\\", "/").TrimEnd('/');

                        string detectedPathFound = "We found a possible install of GHWT at the following location:\n\n" +
                                                   $"{ghwtPath}\n\nIs this correct?";
                        if (MessageBox.Show(detectedPathFound, "Detected GHWT Install", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                            if (File.Exists($"{ghwtPath}/GHWT.exe")) {
                                WriteUpdaterINI(ghwtPath);
                                return;
                            } else {
                                MessageBox.Show("This folder did not contain GHWT.exe!", "GHWT.exe Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                        while (!File.Exists($"{folderBrowser.SelectedPath}/GHWT.exe")) {
                            if (folderBrowser.ShowDialog() == DialogResult.OK) {
                                if (File.Exists($"{folderBrowser.SelectedPath}/GHWT.exe")) {
                                    MessageBox.Show("GHWT.exe was detected!", "GHWT.exe Found", MessageBoxButtons.OK);
                                    WriteUpdaterINI(folderBrowser.SelectedPath);
                                    return;
                                } else {
                                    MessageBox.Show("This folder did not contain GHWT.exe!\nNavigate to a folder that contains the GHWT.exe executable.",
                                                    "GHWT.exe Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            } else {
                                Close();
                                Environment.Exit(0);
                            }
                        }
                    }
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            if (EndUpdateButton.Text == "Cancel Update") {
                string updateInProgressInfo = "The updater has not yet finished downloading files.\n" +
                                                "Are you sure you want to abort the update?";
                if (MessageBox.Show(updateInProgressInfo, "Abort Update?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    e.Cancel = false;
                    Environment.Exit(0);
                } else e.Cancel = true;
            }
        }

        public static double ApproachValue(double value, double end, double amount) {
            // Moving in the positive direction.
            if (value < end) {

                value += amount;

                if (value > end) return end;

                // Moving in the negative direction.
            } else {
                value -= amount;

                if (value < end) return end;
            }

            // Return the resulting value.
            return value;
        }

        private void BeginUpdate_Click(object sender, EventArgs e) {
            ExecuteDownload(GetUpdaterINIPath());
        }

        private void BackgroundWorkerMain_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            while (EndUpdateButton.Text == "Cancel Update" && !BeginUpdate.Enabled) {
                Random random = new Random();
                int msgID = random.Next(0, TipMessages.Length);

                string textToSet = TipMessages[msgID];

                // Console.WriteLine("Fading the text");
                // TipLabel.ForeColor = Color.FromArgb(0, Color.White);
                TipLabel.Text = "";
                foreach (char c in textToSet) {
                    TipLabel.Text += c;
                    Thread.Sleep(50);
                }

                Thread.Sleep(10000);

                while (TipLabel.Text.Length > 0) {
                    TipLabel.Text = TipLabel.Text.Remove(TipLabel.Text.Length - 1, 1);
                    Thread.Sleep(15);
                }
            }
            TipLabel.Text = "We're finished updating!";
        }

        private void CurrentFileProgressPercent_Click(object sender, EventArgs e) {

        }

        private void EndUpdateButton_Click(object sender, EventArgs e) {
            if (EndUpdateButton.Text == "Cancel Update") {
                string updateInProgressInfo = "The updater has not yet finished downloading files.\n" +
                                              "Are you sure you want to abort the update?";
                if (MessageBox.Show(updateInProgressInfo, "Abort Update?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    Environment.Exit(0);
                }
            }
            if (EndUpdateButton.Text == "Awesome, Thanks!") {
                // MessageBox.Show("Your copy of Guitar Hero World Tour: Definitive Edition is now UP TO DATE!\n\nEnjoy the definitive experience!", "Update Complete!");
                Directory.SetCurrentDirectory(OWD);

                IniFile file = new IniFile();
                file.Load("Updater.ini");
                if (file.Sections["Updater"].Keys["StartAfterFinish"].Value == "1") {
                    Directory.SetCurrentDirectory(file.Sections["Updater"].Keys["GameDirectory"].Value);

                    Process.Start("GHWT_Definitive.exe");
                }

                Close();
                Environment.Exit(0);
            }
        }

        string[] TipMessages = {
            "Guitar Hero: World Tour © 2009 Activision Publishing, Inc.",
            "GHWT: DE is a free, community based mod. It is not affiliated with any companies.",
            "GHWT: DE and Fretworks are not assoicated with Activision or any related entity.",
            "Pro Tip: Hit the notes to keep from failing the song.",
            "Did you know that when you strum notes, it gives you points?",
            "Visit our Discord server if you have any issues!",
            "Mods go into the DATA/MODS directory of the game folder.",
            "Making GHWT better, one update at a time!",
            "Sit tight; we'll be done soon!",
            "Visit our website for song packs and other useful information!",
            "Make sure you visit Career Mode to view new characters included in the mod!",
            "Wanna enable key debugging on the fly? Push Shift + 1!",
            "The mod includes holiday themes during specific months of the year!",
            "Be sure to check out the various INI configuration settings for the mod.",
            "When asking for help, never forget your debug.txt file!",
            "Huge thanks to all of our community for your support!",
            "Keeping the plastic guitar scene alive!",
            "Also check out GH Podcast!",
            "If you're playing this mod, you are a based individual.",
            "If you're installing this, uninstall Clone Hero already.",
            "Want a dose of hyperspeed? Here's the cheat: G-B-R-Y-Y-R-G-G",
            "No original game files are touched, so you can always enjoy the vanilla game!",
            "The mod supports basically any type of controller, thanks to SDL2!",
            "Fun Fact: \"Hyperguitar\" in the Cheats menu is spelled as \"HyperSguitar\".",
            "Head to the Options menu for all sorts of fun tweaks!",
            "Want an easy source of WTDE related news? Join the Discord server!",
            "Pro Tip: An entire Star Power meter lasts 8 measures.",
            "Do not use homemade pyrotechnics.",
            "Remember: Dropping your pants on stage does NOT deploy Star Power.",
            "Use whammy in Star Power phrases for that extra edge!"
        };

        private void Main_Load(object sender, EventArgs e) {
            UpdateAutoExecute();
        }

        private void JoinDiscordButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Do you want to join or open the Discord server for GHWT: DE?", "Open Discord",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                var url = "https://discord.gg/HVECPzkV4u";
                var psi = new System.Diagnostics.ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = url;
                System.Diagnostics.Process.Start(psi);
            }
        }

        private void WTDESiteButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Do you want to open the GHWT: DE website?", "Open Website",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                var url = "https://ghwt.de";
                var psi = new System.Diagnostics.ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = url;
                System.Diagnostics.Process.Start(psi);
            }
        }
    }
}
