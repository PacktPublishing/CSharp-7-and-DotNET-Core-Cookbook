using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformRx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ////var searchTerm = Observable.FromEventPattern<EventArgs>(textBox1, "TextChanged").Select(x => ((TextBox)x.Sender).Text);

            ////searchTerm.Subscribe(trm => label1.Text = trm);

            //var searchTerm = Observable.FromEventPattern<EventArgs>(textBox1, "TextChanged").Select(x => ((TextBox)x.Sender).Text).Where(text => text.EndsWith("."));

            //searchTerm.Subscribe(trm => label1.Text = trm);

            var searchTerm = Observable.FromEventPattern<EventArgs>(textBox1, "TextChanged").Select(x => ((TextBox)x.Sender).Text).Throttle(TimeSpan.FromMilliseconds(5000));

            //searchTerm.Subscribe(trm => label1.Text = trm);
            searchTerm.ObserveOn(new ControlScheduler(this)).Subscribe(trm => label1.Text = trm);
        }
    }
}
