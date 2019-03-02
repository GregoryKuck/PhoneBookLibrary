using PhonebookLibrary.Models.DataModels;
using System.Collections.Generic;


namespace PhonebookLibrary.Services.StaticData
{
    public static class PhoneBookData
    {
        private static PhoneBook phoneBook1 = new PhoneBook()
        {
            Id = 1,
                Name = "Family Phonebook",
                Entry = new List<Entry>()
            };
        private static PhoneBook phoneBook2 = new PhoneBook()
        {
            Id = 1,
            Name = "Work Phonebook",
            Entry = new List<Entry>()
        };

        public static List<PhoneBook> PhoneBooks = new List<PhoneBook>()
        {
           phoneBook1,
           phoneBook2
        };
        public static List<Entry> Entries = new List<Entry>()
            {
                new Entry()
                {
                    Id = 1,
                    Name = "Bob",
                    PhoneBookId = 1,
                    PhoneNumber = "0111231234",
                    PhoneBook = phoneBook1
                },
                new Entry() {
                    Id = 1,
                    Name = "Fred",
                    PhoneBookId = 1,
                    PhoneNumber = "0111231235",
                    PhoneBook = phoneBook1
                },
                new Entry()
                {
                    Id = 1,
                    Name = "Frank",
                    PhoneBookId = 1,
                    PhoneNumber = "0111231235",
                    PhoneBook = phoneBook1
                },
                new Entry() {
                    Id = 1,
                    Name = "Francesca",
                    PhoneBookId = 1,
                    PhoneNumber = "0111231236",
                    PhoneBook = phoneBook1
                },
                new Entry()
                {
                    Id = 1,
                    Name = "Bob",
                    PhoneBookId = 1,
                    PhoneNumber = "0111231234",
                    PhoneBook = phoneBook1
                },
                new Entry() {
                    Id = 1,
                    Name = "Fred",
                    PhoneBookId = 1,
                    PhoneNumber = "0111231235",
                    PhoneBook = phoneBook1
                },
                new Entry()
                {
                    Id = 1,
                    Name = "Frank",
                    PhoneBookId = 1,
                    PhoneNumber = "0111231235",
                    PhoneBook = phoneBook1
                },
                new Entry() {
                    Id = 1,
                    Name = "Francesca",
                    PhoneBookId = 1,
                    PhoneNumber = "0111231236",
                    PhoneBook = phoneBook1
                }
            };
    }
}
