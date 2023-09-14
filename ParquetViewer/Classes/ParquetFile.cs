namespace ParquetViewer.Classes
{
    public class ParquetFile
    {
        public string FileName { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public ParquetFile()
        {
            FileName = "Default";
            Id = 0;
            Name = "Default";
            Value = 0;
        }
        public ParquetFile(string fileName, int id, string name, int value)
        {
            FileName = fileName;
            Id = id;
            Name = name;
            Value = value;
        }
    }
}
