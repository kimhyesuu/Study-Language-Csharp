﻿using DataGridDelete.Command;
using DataGridDelete.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataGridDelete.ViewModels
{
   public class PersonViewModel : INotifyPropertyChanged
   {
      private ObservableCollection<Person> _people;
      public ICommand DeleteCommand { get; private set; }

      public ObservableCollection<Person> People
      {
         get { return _people; }
         set { _people = value; OnPropertyChanged(nameof(People)); }
      }

      public PersonViewModel()
      {
         People = new ObservableCollection<Person>(GeneratePeople());
         DeleteCommand = new RelayCommand(DeletePerson);
      }

      private void DeletePerson(object obj)
      {
         People.Remove(obj as Person);
      }

      private List<Person> GeneratePeople()
      {
         var people = new List<Person>();

         for (int x = 0; x < 25; x++)
         {
            var person = new Person()
            {
               FirstName = $"First - {x}",
               LastName = $"Last - {x}",
               Age = x + 20
            };
            people.Add(person);
         }

         return people;
      }


      public event PropertyChangedEventHandler PropertyChanged;

      protected void OnPropertyChanged(string name = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }
   }
}
