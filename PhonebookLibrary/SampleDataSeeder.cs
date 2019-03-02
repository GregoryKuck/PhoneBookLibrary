using PhonebookLibrary.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookLibrary
{
    public class SampleDataSeeder
    {
        private readonly PhonebookContext _db;

        public SampleDataSeeder(PhonebookContext db)
        {
            _db = db;
        }

        //TODO: This is just to easily populate some data in SQLEXPRESS for dev puposes, I have not gone with code first
        public void SeedData()
        {
            var count = _db.PhoneBook.Where(x => x.Id == 1).Count();
            if (count == 0)
            {
                PhoneBook phoneBook1 = new PhoneBook()
                {
                    Name = "Family"
                };

                PhoneBook phoneBook2 = new PhoneBook()
                {
                    Name = "Work"
                };

                PhoneBook phoneBook3 = new PhoneBook()
                {
                    Name = "Friends"
                };

                List<PhoneBook> phoneBooks = new List<PhoneBook>()
                {
                   phoneBook1,
                   phoneBook2,
                   phoneBook3
                };


                _db.PhoneBook.AddRange(phoneBooks);
                _db.SaveChanges();

                List<Entry> entries = new List<Entry>()
                {
                    new Entry()
                    {
                        Name = "Bob",
                        PhoneBookId = phoneBook1.Id,
                        PhoneNumber = "0111231234"
                    },
                    new Entry() {
                        Name = "Fred",
                        PhoneBookId = phoneBook1.Id,
                        PhoneNumber = "0111231235"
                    },
                    new Entry()
                    {
                        Name = "Frank",
                        PhoneBookId = phoneBook1.Id,
                        PhoneNumber = "0111231235"
                    },
                    new Entry() {
                        Name = "Francesca",
                        PhoneBookId = phoneBook1.Id,
                        PhoneNumber = "0111231236"
                    },
                    new Entry() {
                        Name = "William",
                        PhoneBookId = phoneBook1.Id,
                        PhoneNumber = "0111231236"
                    },
                    new Entry()
                    {
                        Name = "Kate",
                        PhoneBookId = phoneBook2.Id,
                        PhoneNumber = "0111231234"
                    },
                    new Entry() {
                        Name = "Catherine",
                        PhoneBookId = phoneBook2.Id,
                        PhoneNumber = "0111231235"
                    },
                    new Entry()
                    {
                        Name = "Chelsea",
                        PhoneBookId = phoneBook2.Id,
                        PhoneNumber = "0111231235"
                    },
                    new Entry() {
                        Name = "Charles",
                        PhoneBookId = phoneBook2.Id,
                        PhoneNumber = "0111231236"
                    },
                    new Entry()
                    {
                        Name = "Graham",
                        PhoneBookId = phoneBook3.Id,
                        PhoneNumber = "0111231234"
                    },
                    new Entry() {
                        Name = "Susan",
                        PhoneBookId = phoneBook3.Id,
                        PhoneNumber = "0111231235"
                    },
                    new Entry()
                    {
                        Name = "Sheridan",
                        PhoneBookId = phoneBook3.Id,
                        PhoneNumber = "0111231235"
                    },
                    new Entry() {
                        Name = "George",
                        PhoneBookId = phoneBook3.Id,
                        PhoneNumber = "0111231236"
                    },
                    new Entry() {
                        Name = "Gregory",
                        PhoneBookId = phoneBook3.Id,
                        PhoneNumber = "0111231236"
                    }

                };

                _db.Entry.AddRange(entries);
                _db.SaveChanges();
            }
            
        }
    }
}
