using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAM天空音樂下載器
{

    
    public partial class Form1 : Form
    {
        


        public static int num;
        //函式定義
        private static int add(int a)
        {
            num = a;
          return num;
        }

        
        public Form1()
        {
            InitializeComponent();

            
        }
  

        private void button1_Click(object sender, EventArgs e)
        
        {
            folderBrowserDialog1.ShowDialog();
            txtpath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  textBox1.Text = add(2).ToString();
            textBox1.Text = "5";
         }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = add(3).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] aryString = (!String.IsNullOrEmpty(textBox1.Text.Trim())) ? textBox1.Lines : null;
 

        }


        
    }
}
