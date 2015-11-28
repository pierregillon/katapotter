namespace KataPotter.Test.Domain
{
    public class Book
    {
        public Book()
        {
            Price = 8;
        }

        public decimal Price { get; private set; }
        public int VolumeNumber { get; set; }

        public override bool Equals(object obj)
        {
            var book = obj as Book;
            if (book != null == false) {
                return base.Equals(obj);
            }
            return book.VolumeNumber == VolumeNumber;
        }
        public override int GetHashCode()
        {
            return VolumeNumber.GetHashCode();
        }
    }
}