using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Book_img = Image.FromFile("f_book.png");
            this.Book_img = imageList1.Images[currentImage];
            //this.Paint += ;
        }
        public Image Book_img;
        private int siz = 70;
        private int currentImage = 0;
        public void button1_Click(object sender, EventArgs e)
        {
            book_collection.Add(new C_Book(Book_img, 1,siz,33));
            pictureBox1.Image = imageList1.Images[1];
            siz += 30;
            this.Invalidate();

        }
        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Flush();
            GC.Collect();
            label1.Text = book_collection.Count.ToString();
            DrawImage2FloatRectF(e);
        }
        public void DrawImage2FloatRectF(PaintEventArgs e)
        {



            foreach (C_Book Book in book_collection)
            {
                currentImage++;
                e.Graphics.DrawImage(Book.book_img,Book.cords);
                    
            }
                

        }
            List<C_Book> book_collection = new List<C_Book>();

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
