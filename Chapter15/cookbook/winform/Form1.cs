using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace winform
{
    public partial class Form1 : Form
    {
        double timerTtl = 10.0D;
        private DateTime timeToLive;
        private int cacheValue;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTimer.Text = $"Timer TTL {timerTtl} sec (Stopped)";            
        }

        
        private async void btnTestAsync_Click(object sender, EventArgs e)
        {
            int iVal = await LoadReadCache(out bool isCachedValue);
            if (isCachedValue)
                txtOutput.Text = $"Cached value {iVal} read";
            else
                txtOutput.Text = $"New value {iVal} read";
        }

        public ValueTask<int> LoadReadCache(out bool blnCached)
        {
            if (timeToLive < DateTime.Now)
            {
                blnCached = false;
                return new ValueTask<int>(GetValue());
            }
            else
            {
                blnCached = true;
                return new ValueTask<int>(cacheValue);
            }                
        }

        public async Task<int> GetValue()
        {
            await Task.Delay(1000);

            Random r = new Random();
            cacheValue = r.Next();
            timeToLive = DateTime.Now.AddSeconds(timerTtl);
            timer1.Start();
            return cacheValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerTtl == 0)
            {
                timerTtl = 10;
            }
            else
            {
                timerTtl -= 1;                
            }
            lblTimer.Text = $"Timer TTL {timerTtl} sec (Running)";
        }
    }
}
