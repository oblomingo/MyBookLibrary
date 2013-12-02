using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MyBookLibrary
{
    public partial class MainPage : UserControl
    {
        ObservableCollection<Book> _bookCollection;
        bool _cellEditing = false;
        private PagedCollectionView view;

        public MainPage()
        {
            InitializeComponent();
            LoadBooks();
            
            view = new PagedCollectionView(_bookCollection);
            view.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Descending));
            view.GroupDescriptions.Add(new PropertyGroupDescription("Language"));
            BookDataGrid.ItemsSource = view;

            //BookDataGrid.ItemsSource = _bookCollection;
        }

        private void LoadBooks()
        {
            _bookCollection = new ObservableCollection<Book> 
            {
                new Book
                {
                    Title = "1984",
                    Author = "George Orwell",
                    Language = Languages.English,
                    Category = Categories.Utopia,
                    PageCount = 310,
                    Publisher = "Oberon Books Ltd",
                    PurchaseDate = new DateTime(2013, 1, 5),
                    ImageName = "Images/1984.jpg",
                    AlreadyRead = true
                },
                new Book
                {
                    Title = "Война и Мир",
                    Author = "Лев Толстой",
                    Language = Languages.Russian,
                    Category = Categories.History,
                    PageCount = 100500,
                    Publisher = "Московская типпография",
                    PurchaseDate = new DateTime(1895, 10, 11),
                    ImageName = "Images/WarAndPeace.jpg",
                    AlreadyRead = false,
                },
                new Book
                {
                    Title = "Fight Club",
                    Author = "Chuck Palahniuk",
                    Language = Languages.English,
                    Category = Categories.Philosofy,
                    PageCount = 224,
                    Publisher = "Vintage; New Ed edition",
                    PurchaseDate = new DateTime(1997, 10, 02),
                    ImageName = "Images/FightClub.jpg",
                    AlreadyRead = false,
                },
                new Book
                {
                    Title = "The Shining",
                    Author = "Stephen King",
                    Language = Languages.English,
                    Category = Categories.Thriller,
                    PageCount = 512,
                    Publisher = "Hodder Paperbacks",
                    PurchaseDate = new DateTime(2011, 11, 10),
                    ImageName = "Images/Shining.jpg",
                    AlreadyRead = false,
                },
                new Book
                {
                    Title = "Three Comrades",
                    Author = "Erich Maria Remarque",
                    Language = Languages.Deutch,
                    Category = Categories.History,
                    PageCount = 432,
                    Publisher = "Fawcett; 1st Ballantine Books Ed edition",
                    PurchaseDate = new DateTime(2013, 12, 20),
                    ImageName = "Images/ThreeComrades.jpg",
                    AlreadyRead = true,
                },
                new Book
                {
                    Title = "The Three Musketeers",
                    Author = "Alexandre Dumas",
                    Language = Languages.French,
                    Category = Categories.History,
                    PageCount = 678,
                    Publisher = "Vintage Classics",
                    PurchaseDate = new DateTime(2013, 11, 28),
                    ImageName = "Images/ThreeM.jpg",
                    AlreadyRead = true,
                }
        
            };
        }

        private void BookDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Book loadedBook = e.Row.DataContext as Book;
            if (loadedBook.Category == Categories.Thriller)
            {
                e.Row.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void BookDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && !_cellEditing)
            {
                RemoveBook();
            }
            else if (e.Key == Key.Insert && !_cellEditing)
            {
                AddEmptyBook();
            }
        }

        private void AddEmptyBook()
        {
            Book newBook = new Book();
            _bookCollection.Add(newBook);
        }

        private void RemoveBook()
        {
            if (BookDataGrid.SelectedItem != null)
            {
                Book deletedBook = BookDataGrid.SelectedItem as Book;
                _bookCollection.Remove(deletedBook);
            }
        }

        private void BookDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            _cellEditing = true;
        }

        private void BookDataGrid_CellEditEnded(object sender, DataGridCellEditEndedEventArgs e)
        {
            _cellEditing = false;
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveBook();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddEmptyBook();
        }
    }
}
