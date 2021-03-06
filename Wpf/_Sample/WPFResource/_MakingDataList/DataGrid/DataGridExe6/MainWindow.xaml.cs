﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGridExe6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // ... Create.
            var items = new List<Dog>();
            items.Add(new Dog("Fido", 10));
            items.Add(new Dog("Spark", 20));
            items.Add(new Dog("Fluffy", 4));
            items.Add(new Dog("Rover", 100));
            items.Add(new Dog("Mister Mars", 30));

            // ... Assign.
            var grid = sender as DataGrid;
            grid.ItemsSource = items;
        }

        private void DataGrid_SelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            // ... Get SelectedItems from DataGrid.
            var grid = sender as DataGrid;
            var selected = grid.SelectedItems;

            // ... Add all Names to a List.
            List<string> names = new List<string>();
            foreach (var item in selected)
            {
                var dog = item as Dog;
                names.Add(dog.Name);
            }
            // ... Set Title to selected names.
            this.Title = string.Join(", ", names);
        }

        private void DataGrid_CellEditEnding(object sender,
            DataGridCellEditEndingEventArgs e)
        {
            // ... Get the TextBox that was edited.
            var element = e.EditingElement as TextBox;
            var text = element.Text;

            // ... See if the text edit should be canceled.
            //     We cancel if the user typed a question mark.
            if (text == "?")
            {
                // ... Cancel the edit.
                this.Title = "Invalid";
                e.Cancel = true;
            }
            else
            {
                // ... Show the cell value in the title.
                this.Title = "You typed: " + text;
            }
        }
    }

    class Dog
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public Dog(string name, int size)
        {
            this.Name = name;
            this.Size = size;
        }
    }
}
