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

namespace AssaultCubeExternal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int Base = 0x00509B74;
        public static int Health = 0xF8;
        public static int GrenadeAmmo = 0x158;
        public static int Armor = 0xFC;
        public static int Ammo = 0x150;
        VAMemory vam = new VAMemory("ac_client");
        public static Process[] check = Process.GetProcessesByName("ac_client");

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("INTENDED ONLY FOR OFFLINE PLAY. USING THIS IN ONLINE MODE VIOLATES TERMS OF SERVICE.");
            VAMemory vam = new VAMemory("ac_client");
            timer3.Start();
            timer1.Interval = 1000;
            timer2.Interval = 500;
            timer4.Start();
            label7.Text = "Offline";
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int LocalPlayer = vam.ReadInt32((IntPtr)0x00509B74);
            int address = LocalPlayer + Health;
            int amount = int.Parse(textBox1.Text);
            vam.WriteInt32((IntPtr)address, amount);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check.Length == 0)
            {
                label7.Text = "Offline";
                timer2.Stop();
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                button4.Show();
                timer1.Stop();
                timer3.Stop();
            }
             else
                label7.Text = "Online";
                timer2.Start();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                check = Process.GetProcessesByName("ac_client");
                button4.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int amount = int.Parse(textBox2.Text);
            int LocalPlayer = vam.ReadInt32((IntPtr)0x00509B74);
            int address = LocalPlayer + Ammo;
            vam.WriteInt32((IntPtr)address, amount);
            int address2 = LocalPlayer + GrenadeAmmo;
            vam.WriteInt32((IntPtr)address2, amount);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int amount = int.Parse(textBox3.Text);
            int LocalPlayer = vam.ReadInt32((IntPtr)0x00509B74);
            int address = LocalPlayer + Armor;
            vam.WriteInt32((IntPtr)address, amount);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            check = Process.GetProcessesByName("ac_client");
            int LocalPlayer = vam.ReadInt32((IntPtr)0x00509B74);
                int address1 = LocalPlayer + Health;
                int address2 = LocalPlayer + Ammo;
                int address3 = LocalPlayer + GrenadeAmmo;
                int address4 = LocalPlayer + Armor;
                if (checkBox1.Checked == true)
                {
                    textBox1.ReadOnly = true;
                    button1.Enabled = false;
                    vam.WriteInt32((IntPtr)address1, 9999);
                }
                if (checkBox2.Checked == true)
                {
                    textBox2.ReadOnly = true;
                    button2.Enabled = false;
                    vam.WriteInt32((IntPtr)address2, 9999);
                    vam.WriteInt32((IntPtr)address3, 9999);
                }
                if (checkBox3.Checked == true)
                {
                    textBox3.ReadOnly = true;
                    button3.Enabled = false;
                    vam.WriteInt32((IntPtr)address4, 9999);
                }
                //----------------------------------------------------------------------\\
                if (checkBox1.Checked == false)
                {
                    textBox1.ReadOnly = false;
                    button1.Enabled = true;
                }
                if (checkBox2.Checked == false)
                {
                    textBox2.ReadOnly = false;
                    button2.Enabled = true;
                }
                if (checkBox3.Checked == false)
                {
                    textBox3.ReadOnly = false;
                    button3.Enabled = true;
                }
            }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (check.Length == 0)
            {
                timer1.Stop();
                button4.Show();
                label7.Text = "Offline";
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
            }
            else
                timer1.Start();
            if (label7.Text == "Offline")
            {
                label7.ForeColor = Color.Red;
            }
            if (label7.Text == "Online")
            {
                label7.ForeColor = Color.Lime;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process[] check2 = Process.GetProcessesByName("ac_client");
            if (check2.Length == 0)
            {
                MessageBox.Show("Game Not Detected...");
            }
            else
                check = Process.GetProcessesByName("ac_client");
            timer3.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Red;
            timer5.Start();
            timer4.Stop();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Blue;
            timer4.Start();
            timer5.Stop();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
    }
