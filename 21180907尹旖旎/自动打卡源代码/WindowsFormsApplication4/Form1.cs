using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace WindowsFormsApplication4
{
    public partial class 永不迟到 : Form
    {
        public 永不迟到()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //这里填自己的账号密码
            textBox1.Text = "2313121";
            textBox2.Text = "21331241";
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunWithMachine("WindowsFormsApplication4.exe", true);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (!AutoLogin(textBox1.Text.ToString(), textBox2.Text.ToString()))
                timer1.Enabled = true;
        }
        bool AutoLogin(string username,string password)
        {
            try
            {
                webBrowser1.Document.GetElementById("TextBox1").InnerText=textBox1.Text;     
                webBrowser1.Document.GetElementById("TextBox2").InnerText =textBox2.Text;
                webBrowser1.Document.GetElementById("Button1").InvokeMember("click");
                return (true);
            }
            catch (Exception e)
            {
                return (false);
            }
        }

        private void RunWithMachine(string strExeName, bool isRunMachine) 
        {
            string dir = Directory.GetCurrentDirectory();
            string exeDir = dir + "\\" + strExeName;

            RegistryKey key1 = Registry.LocalMachine;
            RegistryKey key2 = key1.CreateSubKey("SOFTWARE");
            RegistryKey key3 = key2.CreateSubKey("Microsoft");
            RegistryKey key4 = key3.CreateSubKey("Windows");
            RegistryKey key5 = key4.CreateSubKey("CurrentVersion");
            RegistryKey key6 = key5.CreateSubKey("Run");

            if (isRunMachine)
            {
                key6.SetValue(strExeName, exeDir);
            }
            else
            {
                key6.SetValue(strExeName, false);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://ehall.jlu.edu.cn/");
        }

    }
}
