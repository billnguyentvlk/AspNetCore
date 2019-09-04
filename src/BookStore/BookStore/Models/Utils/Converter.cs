namespace BookStore.Models.Utils
{
    public static class Converter
    {
        public static Press Convert(Web.Press source)
        {
            if (source == null) return null;
            return new Press
            {
                Id = source.Id,
                Name = source.Name,
                Email = source.Email,
                Category = source.Category,
                DynamicProperties = source.DynamicProperties?.SerializeToJsonStringWithTypeName()
            };
        }

        public static Web.Press Convert(Press source)
        {
            if (source == null) return null;
            return new Web.Press
            {
                Id = source.Id,
                Name = source.Name,
                Email = source.Email,
                Category = source.Category,
                DynamicProperties = source.DynamicProperties?.DeserializeToDynamicProperties()
            };
        }

        public static Web.Address Convert(Address source)
        {
            if (source == null) return null;
            return new Web.Address
            {
                City = source.City,
                Street = source.Street,
                DynamicProperties = source.DynamicProperties?.DeserializeToDynamicProperties()
            };
        }

        public static Address Convert(Web.Address source)
        {
            if (source == null) return null;
            return new Address
            {
                City = source.City,
                Street = source.Street,
                DynamicProperties = source.DynamicProperties?.SerializeToJsonStringWithTypeName()
            };
        }

        public static Web.Book Convert(Book source)
        {
            if (source == null) return null;
            return new Web.Book
            {
                Id = source.Id,
                ISBN = source.ISBN,
                Author = source.Author,
                Price = source.Price,
                Press = Convert(source.Press),
                Location = Convert(source.Location),
                DynamicProperties = source.DynamicProperties?.DeserializeToDynamicProperties()
            };
        }

        public static Book Convert(Web.Book source)
        {
            if (source == null) return null;
            return new Book
            {
                Id = source.Id,
                ISBN = source.ISBN,
                Author = source.Author,
                Price = source.Price,
                Press = Convert(source.Press),
                Location = Convert(source.Location),
                DynamicProperties = source.DynamicProperties?.SerializeToJsonStringWithTypeName()
            };
        }
    }
}