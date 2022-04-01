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


namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //if (File.Exists("books.txt"))
            //    PathToFile.AddRange(File.ReadAllLines("books.txt"));
        }
        public Image Book_img;
        private int x_point = 70;
        private int y_point = 33;
        private bool activ_del = false;
        private int check_index;
        //private int currentImage = 0;
        public void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "TEXT|*.txt|All|*.*";
                openFileDialog.Title = "choose file dest";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PathToFile.Add(openFileDialog.FileName);
                    //textBox1.Text = File.ReadAllText(openFileDialog.FileName);


                    this.Book_img = imageList1.Images[rand_book.Next(0, 5)];

                    //pictureBox1.Image = imageList1.Images[1];
                    if (book_collection.Count == 33)
                    {
                        x_point = 70;
                        y_point = 230;
                    }
                    if (book_collection.Count == 66)
                    {
                        //MessageBox.Show("Вы достигли максимального количества книг!\nДля продолжения удалите любую книгу или купите ещё место!");
                        MessageBox.Show(
                    "Вы достигли максимального количества книг!\nДля продолжения удалите любую книгу или купите ещё место!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        book_collection.Add(new C_Book(Book_img, 1, x_point, y_point));
                    }
                    x_point += 33;
                    this.Invalidate();
                }
                else
                {
                    MessageBox.Show(
                    "Ошибка добавления книги!\nПопробуйте ещё раз!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }
            }

        }
        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Flush();
            GC.Collect();
            //label1.Text = book_collection.Count.ToString();
            DrawImage2FloatRectF(e);
        }
        public void DrawImage2FloatRectF(PaintEventArgs e)
        {

            foreach (C_Book Book in book_collection)
            {
                
                e.Graphics.DrawImage(Book.book_img,Book.cords);
                    
            }
                

        }
        List<C_Book> book_collection = new List<C_Book>();
        public List<string> PathToFile = new List<string>();
        Random rand_book = new Random();

        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (C_Book Book in book_collection)
            {
                
                if (Book.IsHit(e.X, e.Y))
                {
                    check_index = book_collection.IndexOf(Book);
                    show_book();
                    MessageBox.Show(check_index.ToString());
                }
                //Book.cords.X.ToString();
            }
            if (activ_del == true)
            {
                book_collection.RemoveAt(check_index);
                this.Invalidate();
            }
        }
        private void show_book()
        {
            Form2 open_book = new Form2();
            open_book.num_book = PathToFile[check_index];
            open_book.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (activ_del == false)
            {
                MessageBox.Show(
                            "Режим удаления включен!\nВыберите книгу для удаления",
                            "Удаление",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                activ_del = true;
                //button1.Enabled = false;
            }
            else
            {
                MessageBox.Show(
                            "Режим удаления выключен!",
                            "Удаление",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                activ_del = false;
                //button1.Enabled = true;
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllLines("books.txt", PathToFile);
        }
    }
    
}
