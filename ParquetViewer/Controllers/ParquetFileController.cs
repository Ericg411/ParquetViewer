using Microsoft.AspNetCore.Mvc;
using Parquet.Serialization;
using ParquetViewer.Classes;

namespace ParquetViewer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParquetFileController : ControllerBase
    {
        [HttpGet]
        public async Task<IList<IList<ParquetFile>>> Get()
        {
            var locationStrings = Directory.EnumerateFiles("C:\\Users\\erdog\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\");
            IList<IList<ParquetFile>> parquetList = new List<IList<ParquetFile>>();
            foreach (string location in locationStrings)
            {
                using (FileStream fs = System.IO.File.OpenRead(location))
                {
                    parquetList.Add(await ParquetSerializer.DeserializeAsync<ParquetFile>(fs));

                }
            }
            return parquetList;
        }

        [HttpGet]
        [Route("{fileName}")]
        public async Task<IList<ParquetFile>> GetOneFile(string fileName)
        {
            IList<ParquetFile> parquetList = new List<ParquetFile>();
            using (FileStream fs = System.IO.File.OpenRead($"C:\\Users\\erdog\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\{fileName}.parquet"))
            {
                parquetList = await ParquetSerializer.DeserializeAsync<ParquetFile>(fs);

            }

            return parquetList;
        }

        [HttpPost]
        [Route("{fileName}/{length}")]
        public async Task Create(string fileName, int length)
        {
            List<ParquetFile> parquetFiles = new List<ParquetFile>();
            foreach (int i in Enumerable.Range(0, length))
            {
                parquetFiles.Add(new ParquetFile($"{fileName}.parquet", i, i % 2 == 0 ? "me" : "you", i * 2));
            }
            await ParquetSerializer.SerializeAsync(parquetFiles, $"C:\\Users\\erdog\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\{fileName}.parquet");

        }

        [HttpPut]
        [Route("{fileName}/{id}/{name}/{value}")]
        public async Task Update(string fileName, int id, string name, int value)
        {
            IList<ParquetFile> parquetList = new List<ParquetFile>();
            using (FileStream fs = System.IO.File.OpenRead($"C:\\Users\\erdog\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\{fileName}.parquet"))
            {
                parquetList = await ParquetSerializer.DeserializeAsync<ParquetFile>(fs);

            }

            parquetList[id].Name = name;
            parquetList[id].Value = value;

            System.IO.File.Delete($"C:\\Users\\erdog\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\{fileName}.parquet");
            await ParquetSerializer.SerializeAsync(parquetList, $"C:\\Users\\erdog\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\{fileName}.parquet");

        }

        [HttpDelete]
        [Route("{fileName}")]
        public async Task Delete(string fileName)
        {
            if (System.IO.File.Exists($"C:\\Users\\erdog\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\{fileName}.parquet"))
            {
                System.IO.File.Delete($"C:\\Users\\erdog\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\{fileName}.parquet");
            }
            else if (System.IO.File.Exists($"C:\\Users\\erdog\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\{fileName}.parquet".ToLower()))
            {
                System.IO.File.Delete($"C:\\Users\\erdog\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\{fileName}.parquet".ToLower());
            }
        }

    }
}
