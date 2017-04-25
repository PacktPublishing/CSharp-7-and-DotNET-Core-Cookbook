using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchronousFileIO
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cts;
        int elapsedTime = 0;
        public Form1()
        {
            InitializeComponent();

            lblTimer.Text = "Timer Stopped";
        }

        private async void btnCopyFilesAsync_Click(object sender, EventArgs e)
        {
            if (btnCopyFilesAsync.Text.Equals("Copy Files Async"))
            {
                string sourceDirectory = @"C:\temp\AsyncSource";
                string destinationDirectory = @"C:\temp\AsyncDestination";
                btnCopyFilesAsync.Text = "Cancel Async Copy";
                cts = new CancellationTokenSource();
                elapsedTime = 0;
                asyncTimer.Start();

                IEnumerable<string> fileEntries = Directory.EnumerateFiles(sourceDirectory);

                //foreach (string sourceFile in Directory.EnumerateFiles(sourceDirectory))
                foreach (string sourceFile in fileEntries)
                {
                    using (FileStream sfs = File.Open(sourceFile, FileMode.Open))
                    {
                        string destinationFilePath = $"{destinationDirectory}\\{Path.GetFileName(sourceFile)}";
                        using (FileStream dfs = File.Create(destinationFilePath))
                        {
                            try
                            {
                                await sfs.CopyToAsync(dfs, 81920, cts.Token);
                            }
                            catch (OperationCanceledException ex)
                            {
                                asyncTimer.Stop();
                                lblTimer.Text = $"Cancelled after {elapsedTime} seconds";
                            }
                        }
                    }
                }

                if (!cts.IsCancellationRequested)
                {
                    asyncTimer.Stop();
                    lblTimer.Text = $"Completed in {elapsedTime} seconds";
                }
            }
            if (btnCopyFilesAsync.Text.Equals("Cancel Async Copy"))
            {
                btnCopyFilesAsync.Text = "Copy Files Async";
                cts.Cancel();
            }
        }

        private void asyncTimer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = $"Duration = {elapsedTime += 1} seconds";
        }
    }
}
