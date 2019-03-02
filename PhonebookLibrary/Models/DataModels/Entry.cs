using System;
using System.Collections.Generic;

namespace PhonebookLibrary.Models.DataModels
{
    public partial class Entry : IIdentifiable
    {
        public int Id { get; set; }
        public int PhoneBookId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public PhoneBook PhoneBook { get; set; }
    }
}
