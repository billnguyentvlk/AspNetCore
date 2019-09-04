namespace BookStore.Models.Utils
{
    public static class UpdateUtil
    {
        public static void CopyData(Book source, Book destination)
        {
            destination.Author = source.Author;
            destination.Location = source.Location;
            destination.Press = source.Press;
            destination.Price = source.Price;
            destination.Title = source.Title;
            destination.DynamicProperties = source.DynamicProperties;
            destination.ISBN = source.ISBN;
        }
    }
}