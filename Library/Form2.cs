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
using System.Speech.Synthesis;
namespace Library
{
    
    public partial class Form2 : Form
    {
        C_Singelton s1 = C_Singelton.GetInstance();
        public string num_book { get; set; }
        private int next_page = 41;
        static private bool check_end = false;
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //tmp_last_page = File.ReadAllText("last_page.txt");
            //result = Int32.Parse(tmp_last_page);
            read_text();

        }
        string tmp_last_page;
        string Base_stream ;
        static int last_pos;
        int result;
        int back_page;
        bool ch = false;
        private void read_text()
        {
            
            //StreamReader sr = new StreamReader(num_book, System.Text.Encoding.Default);
            using (StreamReader sr = new StreamReader(num_book, System.Text.Encoding.Default))
            {
                if (ch == false)
                {
                    sr.BaseStream.Position = result;
                }
                else
                {
                    sr.BaseStream.Position = back_page;
                }
                


                for (int i = 0; i < next_page; i++)
                {
                    textBox1.Text += sr.ReadLine() + Environment.NewLine;
                }
                for (int i = 0; i < next_page; i++)
                {
                    textBox2.Text += sr.ReadLine() + Environment.NewLine;

                }
                Base_stream = sr.BaseStream.Position.ToString();

                if (sr.BaseStream.Length == sr.BaseStream.Position)
                {
                    //MessageBox.Show("check");
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }

                //label1.Text = "pos" + sr.BaseStream.Position.ToString() + "\nCHECK" + last_pos.ToString() + "\nres :" + result.ToString();
                //label1.Text = Base_stream+"pos" + last_pos;
                //label1.Text ="back_page"+ back_page.ToString() + "\nbase" + Base_stream + "\nlast" + last_pos.ToString();
            }
            if (check_end == false)
            {
                last_pos = Int32.Parse(Base_stream);
            }
            check_end = true;
            if (back_page == 0)
            {
                button2.Enabled = false;
            }
            if(back_page > 0)
            {
                button2.Enabled = true;
            }


        }

        private void textBox1_MultilineChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
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
            result = Int32.Parse(Base_stream);
            back_page = Int32.Parse(Base_stream);
            read_text();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(String.Empty))
            {
                s1.someBusinessLogic(textBox1.Text);
                s1.someBusinessLogic(textBox2.Text);
            }
        }

        private void textBox2_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            
            back_page = back_page - last_pos;
            ch = true;
            read_text();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("last_page.txt", Base_stream);
        }
    }
}
