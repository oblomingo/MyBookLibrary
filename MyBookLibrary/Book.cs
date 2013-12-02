using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MyBookLibrary
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Categories Category { get; set; }
        public string Publisher { get; set; }
        public Languages Language { get; set; }
        public string ImageName { get; set; }
        public bool AlreadyRead { get; set; }
    }
}
