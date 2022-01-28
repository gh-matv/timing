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

namespace timing
{
    public partial class Form1 : Form
    {

        DateTime shownAt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            Params p = new Params();
            p.ShowDialog();
            Close();
            

            return;

            Db.load();
            timer1.Interval = 2000;
            timer1.Start();
            timer1.Enabled = true;

            this.Visible = false;
            ShowInTaskbar = false;

            TopMost = true;
            AcceptButton = button1;

        }

        string seconds_to_hms(long inp)
        {
            long hours, mins, seconds;
            hours = inp / 3600;
            mins = (inp - hours * 3600) / 60;
            seconds = inp % 60;

            return $"{(hours>0?$"{hours}h":"")}{(mins>0?$"{mins}m":"")}{seconds}s";
        }

        private void UpdateUi()
        {
            listBox1.Items.Clear();
            foreach(var item in Db._instance.works)
                listBox1.Items.Add((string)$"{item.Key}\t\t{seconds_to_hms(item.Value.seconds_worked)}");
            Application.DoEvents();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Show();
            timer1.Stop();
            UpdateUi();
            shownAt = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure no misclick 
            if ((DateTime.Now - shownAt).TotalSeconds < 1) return;

            timer1.Start();
            this.Hide();

            var works = Db._instance.works;
            var name = textBox1.Text;

            if (!works.ContainsKey(name))
                works.Add(name, new Work() { name = name });

            works[name].seconds_worked += timer1.Interval / 1000;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Db.save();
        }

        private void Form1_Validated(object sender, EventArgs e)
        {

        }
    }
}
