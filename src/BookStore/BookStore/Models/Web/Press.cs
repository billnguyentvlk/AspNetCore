using System.Collections.Generic;

namespace BookStore.Models.Web
{
    public class Press
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Category Category { get; set; }

        public IDictionary<string, object> DynamicProperties { get; set; }
    }
}