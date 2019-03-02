using Newtonsoft.Json;
using PhonebookLibrary.Models.DataModels;
using System.Collections.Generic;

namespace PhonebookLibrary.Models
{
    public class EntriesViewModel
    {
        [JsonProperty(PropertyName = "index")]
        public char Index { get; set; }
        [JsonProperty(PropertyName = "contacts")]
        public IEnumerable<Entry> Contacts { get; set; }
    }
}
