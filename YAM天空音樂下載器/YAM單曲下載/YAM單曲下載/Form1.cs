using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
namespace YAM單曲下載
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string str = textBox1.Text;
                string substrURL = str.Substring(25, textBox1.TextLength - 25);
                string sHTML;
                byte[] bHTML;

                //取得下載標題
                HttpWebClient title = new HttpWebClient(new CookieContainer());
                title.Encoding = Encoding.UTF8;
                bHTML = title.DownloadData(textBox1.Text);
                sHTML = Encoding.UTF8.GetString(bHTML);
                richTextBox1.Text += sHTML;


                int first = sHTML.IndexOf("<title>");
                int last = sHTML.IndexOf("</title>");
                string titlename = sHTML.Substring(first + 7, last - first - 7);
                label5.Text = titlename;


                //取得下載連結
                HttpWebClient httpWebClient = new HttpWebClient(new CookieContainer());
                httpWebClient.Encoding = Encoding.UTF8;
                bHTML = httpWebClient.DownloadData("http://mymedia.yam.com/api/a/?pID=" + substrURL);
                sHTML = Encoding.UTF8.GetString(bHTML);
                richTextBox1.Text = sHTML;

                int start = sHTML.IndexOf("=");
                int end = sHTML.IndexOf("&");

                string downloadURL = sHTML.Substring(start + 1, end - start - 1);

                download downAction = new download();
                if(checkBox2.Checked==true)
                {
                    if(radioButton1.Checked==true)
                    {
                        downAction.webClient.DownloadFileAsync(new Uri(downloadURL), ".\\YamDownload_File\\" + titlename + ".mp3");
                    }
                    else 
                    {
                        downAction.webClient.DownloadFileAsync(new Uri(downloadURL), ".\\YamDownload_File\\" + titlename + ".mp4");
                    }
                 }

                if (checkBox3.Checked == true)
                {
                    if (radioButton1.Checked == true)
                    {
                        downAction.webClient.DownloadFileAsync(new Uri(downloadURL), textBox2.Text + "\\" + titlename + ".mp3");
                    }
                    else
                    {
                        downAction.webClient.DownloadFileAsync(new Uri(downloadURL), textBox2.Text + "\\" + titlename + ".mp4");
                    }
                
                }
              
            
            }
            catch
            {
                MessageBox.Show("出入網址有誤，請確認!");
            }
         
           
          
        }

        public class downloadmethod
        {
           download downAction= new download();

           public void mp3download(string URL, string title, string location)
           {
               downAction.webClient.DownloadFileAsync(new Uri(URL), location + "\\" + title + ".mp3");
           }

            public   void mp4download(string URL, string title, string location)
            {
                downAction.webClient.DownloadFileAsync(new Uri(URL), location + "\\" + title + ".mp4");
            }

        }

        public class download
        {
            public WebClient webClient = new WebClient();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox2.Text = folderBrowserDialog1.SelectedPath;
        }

        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
         
        }

        private void textBox1_TextAlignChanged(object sender, EventArgs e)
        {
           
        }

     

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //執行自動下載
            if(checkBox1.Checked==true)
            {
                if (textBox1.TextLength > 25)
                {
                    button1.PerformClick();
                    textBox1.Text = "";
                }
            }
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked==true)
            {
                checkBox3.Checked = false;
                textBox2.Enabled = false;
            }
            else
            {
                checkBox3.Checked = true;
                textBox2.Enabled = true;
            }
           
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Checked = false;
                textBox2.Enabled = true;
            }
            else
            {
                checkBox2.Checked = true;
                textBox2.Enabled = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://unromanticman.pixnet.net/blog");
        }


    }
}
