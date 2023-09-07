namespace ParquetViewer.Classes
{
    public class ParquetInner
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int Rate { get; set; }

        public ParquetInner()
        {

        }
        public ParquetInner(int id, int value, int rate)
        {
            Id = id;
            Value = value;
            Rate = rate;
        }
    }
}
