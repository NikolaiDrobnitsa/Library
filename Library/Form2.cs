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

namespace Library
{
    public partial class Form2 : Form
    {
        public string num_book { get; set; }
        private int next_page = 41;
        private bool check_end = false;
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //string book_text = File.ReadAllText(num_book);
            //textBox1.Text = File.ReadAllText(num_book);

            //StreamReader sr = new StreamReader(num_book, System.Text.Encoding.Default);


            //while (!sr.EndOfStream)
            //{



            //    //}
            //    //textBox1.Text += sr.ReadLine() + Environment.NewLine;

            //    if (textBox1.Lines.Length == 40)
            //    {
            //        textBox2.Text += sr.ReadLine() + Environment.NewLine;
            //        //if (textBox2.Lines.Length == 45)
            //        //{
            //        //    break;
            //        //}
            //    }
            //    textBox1.Text += sr.ReadLine() + Environment.NewLine;

            //}
            //sr.Close();
            read_text();

        }
        string Base_stream = "0";

        private void read_text()
        {

            StreamReader sr = new StreamReader(num_book, System.Text.Encoding.Default);
            int result = Int32.Parse(Base_stream);
            sr.BaseStream.Position = result;

            
                for (int i = 0; i < next_page; i++)
                {
                    textBox1.Text += sr.ReadLine() + Environment.NewLine;
                }
                for (int i = 0; i < next_page; i++)
                {
                    textBox2.Text += sr.ReadLine() + Environment.NewLine;
                    
                }
             Base_stream = sr.BaseStream.Position.ToString();
            
            if (sr.BaseStream.Length == result)
            {
                MessageBox.Show("check");
                button1.Enabled = false;
            }
                label1.Text = "pos" + sr.BaseStream.Position.ToString()+"\nlen" + sr.BaseStream.Length.ToString() +"\nres :" + result + "base" + Base_stream; 
            

        }

        private void textBox1_MultilineChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox2.Text = textBox1.Lines.Length.ToString();
            //if (textBox1.Lines.Length == 51)
            //{
            //    textBox2.Text = File.ReadAllText(num_book);
            //}
            //textBox2.Text = textBox1.Lines.
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            read_text();



        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
