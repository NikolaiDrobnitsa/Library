using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class C_Book : IDisposable
    {
        public Image book_img { get; set; }
        protected int id;
        public Rectangle cords { get; set; }
        public C_Book(Image book_image, int id, int cord_book_x, int cord_book_y)
        {
            this.book_img = book_image;
            this.id = id;
            this.cords = new Rectangle(new Point(cord_book_x, cord_book_y), new Size(30, 165));
        }
        public void Dispose()
        {
            GC.Collect(GC.GetGeneration(this.book_img));
            GC.Collect(GC.GetGeneration(this.id));
            GC.Collect(GC.GetGeneration(this.cords));

        }
    }
}
