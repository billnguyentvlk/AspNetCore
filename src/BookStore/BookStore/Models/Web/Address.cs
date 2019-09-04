using System.Collections.Generic;

namespace BookStore.Models.Web
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }

        public IDictionary<string, object> DynamicProperties { get; set; }
    }
}