using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Assignment9
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public RelayCommand NewContactCmd { get; }
        public RelayCommand DeleteContactCmd { get; }
        public RelayCommand SaveContactCmd { get; }
        public RelayCommand EditContactCmd { get; }

        public ObservableCollection<ContactViewModel> ContactList { get; } = new();

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        private ContactViewModel? _CurrentContact;
        public ContactViewModel CurrentContact
        {
            get => _CurrentContact!;
            set => SetProperty(ref _CurrentContact, value);
        }

        private bool _InEdit;
        public bool InEdit
        {
            get => _InEdit;
            set => SetProperty(ref _InEdit, value);
        }

        public MainWindowViewModel()
        {
            NewContactCmd = new RelayCommand(CreateNewContact, () => true);
            DeleteContactCmd = new RelayCommand(DeleteContact, () => true);
            SaveContactCmd = new RelayCommand(SaveContact, () => true);
            EditContactCmd = new RelayCommand(EditContact, () => true);

            ContactList.Add(new()
            {
                FirstName = "Inigo",
                LastName = "Montoya",
                PhoneNumber = "424-424-4242",
                EmailAddress = "MontoyaI@email.com",
                TwitterName = "@42%",
                LastModifiedTime = DateTime.Now
            });

            CurrentContact = ContactList.First();
        }


        private void EditContact()
        {
            InEdit = CanEdit();
        }

        private void SaveContact()
        {
            if (CanEdit() && InEdit) 
            {
                InEdit = false;
                CurrentContact.LastModifiedTime = DateTime.Now;
            }
            else
            {
                CreateNewContact();
            }

        }

        private void DeleteContact()
        {

            ContactList.Remove(CurrentContact);
            if (CanEdit())
            {
                CurrentContact = ContactList.First();
            }
        }

        public bool CanEdit()
        {
            if (ContactList.Count > 0)
                return true;
            return false;
        }

        private void CreateNewContact()
        {
            ContactViewModel newContact = new ContactViewModel() 
            {
                FirstName = "TO", 
                LastName = "DO", 
                LastModifiedTime = DateTime.Now 
            };
            ContactList.Add(newContact);
            CurrentContact = newContact;
            InEdit = true;
        }
    }

}