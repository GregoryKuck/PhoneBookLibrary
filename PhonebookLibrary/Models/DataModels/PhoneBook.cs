using System;
using System.Collections.Generic;

namespace PhonebookLibrary.Models.DataModels
{
    public partial class PhoneBook:IIdentifiable
    {
        public PhoneBook()
        {
            Entry = new HashSet<Entry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Entry> Entry { get; set; }
    }
}
