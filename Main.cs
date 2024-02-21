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
        /// <summary>
        ///  Version of the program.
        /// </summary>
        public const string VERSION = "2.0";

        /// <summary>
        ///  Original working directory.
        /// </summary>
        public string OWD = Directory.GetCurrentDirectory();

        /// <summary>
        ///  The form's constructor.
        /// </summary>
        public Main() {
            InitializeComponent();
            AttemptGHWTInstallPath();

            Directory.SetCurrentDirectory(GetGameDirectory());

            if (!File.Exists("GHWT.exe") || !File.Exists("AWL.dll") || !File.Exists("d3d9.dll") || !Directory.Exists("DATA")) {
                if (MessageBox.Show("This is not a GHWT installation folder!\n\nDo you want to point the program to a different folder?",
                    "Not a Valid GHWT Folder",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes) {
                    AttemptGHWTInstallPath();
                } else {
                    Application.Exit();
                    Environment.Exit(0);
                }
            }

            Directory.SetCurrentDirectory(OWD);

            this.Text = $"GHWT: Definitive Edition Updater - V{VERSION}";
            VersionInfoLabel.Text = $"GHWT: DE Updater V{VERSION} by IMF24\nBG Image: Fox (FoxInari)";

            TipLabel.Text = "";

            HeadLabel.Text = "Press the \"Start Update\" button below,\nand watch the magic happen!\n\nThen just sit back; we'll handle the rest.";
            CurrentFileLabel.Text = "Current File Progress";

            string updateStartingAlert = "The updater will now verify your installation's integrity and download " +
                                         "any missing files.\n\n" +
                                         "Be patient! This will take a while.\n\n" +
                                         "Tip: If your updater has been running for longer than 5 minutes and has been frozen " +
                                         "on one file for a long time, it's best advised to close the updater and start " +
                                         "it up again. It will pick right back up where it left off.";
            MessageBox.Show(updateStartingAlert, "Update Starting", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        ///  Attempts to automatically execute the download when the program first launches.
        /// </summary>
        public void UpdateAutoExecute() {
            try {
                IniFile file = new IniFile();
                file.Load("Updater.ini");

                if (file.Sections["Updater"].Keys.Contains("AutoUpdate") && file.Sections["Updater"].Keys["AutoUpdate"].Value == "1") {
                    ExecuteDownload(file.Sections["Updater"].Keys["GameDirectory"].Value);
                    this.Show();
                }
            } catch {
                return;
            }
        }

        /// <summary>
        ///  Returns the path where GHWT is installed to.
        /// </summary>
        /// <returns></returns>
        public string GetGameDirectory() {
            try {
                IniFile file = new IniFile();
                file.Load("Updater.ini");

                if (file.Sections["Updater"].Keys.Contains("GameDirectory") && file.Sections["Updater"].Keys["GameDirectory"].Value != null) {
                    return file.Sections["Updater"].Keys["GameDirectory"].Value;
                } else return ".";
            } catch {
                return ".";
            }
        }

        /// <summary>
        ///  Reads the MD5 hash list from the WTDE volatile repository as an array of strings.
        /// </summary>
        /// <returns></returns>
        public string[] GetHashListData() {
            using (WebClient client = new WebClient()) {
                string downloadString = client.DownloadString("https://gitgud.io/fretworks/ghwt-de-volatile/-/raw/master/GHWTDE/hashlist.dat");
                return downloadString.Split(new char[] { '\r', '\n' });
            }
        }

        /// <summary>
        ///  Reads the MD5 hash of the specified file.
        /// </summary>
        /// <param name="fileToCheck"></param>
        /// <returns></returns>
        public string GetUserHash(string fileToCheck) {
            if (!File.Exists(fileToCheck)) return "00000000000000000000000000000000";
            using (var md5 = MD5.Create()) {
                using (var file = File.OpenRead(fileToCheck)) {
                    var hash = md5.ComputeHash(file);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        /// <summary>
        ///  Main script for downloading files.
        /// </summary>
        /// <param name="workDir"></param>
        public async void ExecuteDownload(string workDir) {
            // Update button accessiblity.
            BeginUpdate.Enabled = false;
            EndUpdateButton.Enabled = true;

            // Make tip messages!
            BackgroundWorkerMain.RunWorkerAsync();

            // For our convenience, let's set our working directory to the user provided one.
            Directory.SetCurrentDirectory(workDir);

            // Get the hash list as a string array and update the header label.
            string[] hashListData = GetHashListData();
            string version = hashListData[1];
            HeadLabel.Text = "Sit tight, we're updating your mod!\n" +
                             $"Updating to Version {version}...\n\n" +
                             "Be patient, make yourself a cup of tea...";

            // This mess of logic is SUPPOSED to make it "easier" to handle
            // downloading various files... Why do we need so many lists?
            var filePaths = new List<string>();
            var fileHashes = new List<string>();
            var fileOutPaths = new List<string>();
            var fileDirs = new List<string>();

            // -- FILE PATHS ON THE REPOSITORY
            for (var i = 2; i < hashListData.Length; i += 2) {
                filePaths.Add("https://gitgud.io/fretworks/ghwt-de-volatile/-/raw/master/GHWTDE/" + hashListData[i]);
            }

            // -- FILE MD5 HASHES
            for (var i = 3; i < hashListData.Length; i += 2) {
                fileHashes.Add(hashListData[i]);
            }

            // -- FILE OUTPUT PATHS ON THE DISK
            for (var i = 0; i < filePaths.Count; i++) {
                using (WebClient wc = new WebClient()) {
                    string newOutDir = filePaths[i].Split("Content/").Last();
                    Console.WriteLine($"new out dir: {newOutDir}");
                    fileOutPaths.Add(newOutDir);
                }
            }

            // Max value of the progress bar will be number of files.
            TotalProgress.Maximum = filePaths.Count;

            Console.WriteLine($"Is there even data in hashListData? {hashListData.Length}");

            Console.WriteLine($"-- ARRAY LENGTH CHECK ---------------\n" +
                              $"filePaths = {filePaths.Count}\n" +
                              $"fileHashes = {fileHashes.Count}\n" +
                              // $"fileOuts = {fileOuts.Count}\n" +
                              $"fileOutPaths = {fileOutPaths.Count}\n");
            // $"fileDirs = {fileDirs.Count}");
            // if (filePaths.Length == fileHashes.Length) Console.WriteLine("Hey, both lists are equal in length!");

            // Change the version number on the header label.
            HeadLabel.Text.Replace("Version x", $"Version {hashListData[1]}");

            // Update idle tasks just in case.
            Application.DoEvents();

            // Number of files downloaded and the number of files TO download.
            int filesDone = 0;
            int totalFiles = filePaths.Count;

            // Now comes the mess that is the download logic...
            for (var i = 0; i < fileOutPaths.Count; i++) {
                // dl = URL of the file to download
                var dl = filePaths[i];
                // fl = Disk path to save the file to
                var fl = fileOutPaths[i];

                Console.WriteLine($"Downloading file {dl}, save to {fl}");

                // Update labels, update idle tasks again.
                CurrentFileLabel.Text = $"Checking File: {fl}";
                TotalProgressLabel.Text = $"Total Progress - {filesDone + 1} of {filePaths.Count}";
                Application.DoEvents();

                // Mess of logic to add a directory to the GHWT install
                // folder so that the updater can download to it.
                string[] pathSplit = fl.Split("/");
                string path = "";
                for (var j = 0; j < pathSplit.Length - 1; j++) path += pathSplit[j] + "/";
                if (path == "") path = ".";
                Console.WriteLine($"does dir ({path}) exist? {Directory.Exists(path)}");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                // Are the MD5 hashes mismatched?
                // If so, let's re-download the file!
                if (fileHashes[i].ToUpper() != GetUserHash(fl).ToUpper()) {
                    // This type of HttpClient extension lets us report download progress.
                    using (var client = new HttpClientDownloadWithProgress(dl, fl)) {
                        client.ProgressChanged += (totalFileSize, totalBytesDownloaded, progressPercentage) => {
                            CurrentFileProgress.Maximum = (int) totalFileSize;
                            CurrentFileProgressPercent.Text = $"{progressPercentage}%";
                            CurrentFileProgress.Value = (int) totalBytesDownloaded;
                        };
                        // Update label, start download.
                        CurrentFileLabel.Text = $"Downloading File: {fl}";
                        await client.StartDownload();           // This line seems to be problematic... It gets stuck here, it seems.
                    }
                }

                // File was OK or the file was downloaded!
                // Add 1 to the count of files done and update the progress bar(s).
                filesDone++;
                TotalProgress.Value = filesDone;
                double totalProgressSoFar = ((double) TotalProgress.Value / (double) TotalProgress.Maximum) * 100;
                Console.WriteLine($"current progress: {totalProgressSoFar}%");
                TotalProgressPercent.Text = $"{totalProgressSoFar.ToString("0.00")}%";
                this.Text = $"GHWT: Definitive Edition Updater - V{VERSION} - Updated {filesDone} of {filePaths.Count} Files ({totalProgressSoFar.ToString("0.00")}%)";

                // Update idle tasks, move on to the next file!
                Application.DoEvents();
            }

            // All files are downloaded!
            // Do some final updating of all controls, and we're done here!
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
