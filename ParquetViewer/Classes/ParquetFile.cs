using Parquet.Serialization;

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

        public async Task Seed()
        {
            foreach (int j in Enumerable.Range(1, 4))
            {
                List<ParquetFile> parquetFiles = new List<ParquetFile>();
                foreach (int i in Enumerable.Range(0, 25))
                {
                    parquetFiles.Add(new ParquetFile($"{j}.parquet", i, i % 2 == 0 ? "yes" : "no", i * 2));
                }
                await ParquetSerializer.SerializeAsync(parquetFiles, $"C:\\Users\\eg014903\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\{j}.parquet");
            }
        }
    }
}
