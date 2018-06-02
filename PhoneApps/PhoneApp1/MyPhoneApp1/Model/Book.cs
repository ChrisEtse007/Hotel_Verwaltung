using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyPhoneApp1.Model
{
    public class Book
    {
        public int Bookid { get; set; }
        public string Titel { get; set; }
        public string Author { get; set; }
        //public string CoverImage { get; set; }
    }

    public class BookManager
    {
        public static List<Book> GetBooks()
        {
            var books = new List<Book>();

            books.Add(new Book { Bookid = 1, Titel = "Vulpate", Author = "Futurum" });
            books.Add(new Book { Bookid = 1, Titel = "Vulpate", Author = "Futurum" });
            books.Add(new Book { Bookid = 1, Titel = "Vulpate", Author = "Futurum" });
            books.Add(new Book { Bookid = 1, Titel = "Vulpate", Author = "Futurum" });

            return books;
        }
}


}
