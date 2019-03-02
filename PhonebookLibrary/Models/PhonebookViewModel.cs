using Newtonsoft.Json;
using PhonebookLibrary.Models.DataModels;
using System.Collections.Generic;

namespace PhonebookLibrary.Models
{
    public class PhoneBookViewModel
    {
        [JsonProperty(PropertyName = "index")]
        public char Index { get; set; }
        [JsonProperty(PropertyName = "phonebooks")]
        public IEnumerable<PhoneBook> PhoneBooks { get; set; }
    }
}
