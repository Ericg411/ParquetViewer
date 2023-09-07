using ParquetViewer.Classes;
using ParquetViewer.Controllers;

namespace ParquetViewer.Tests;

[TestClass]
public class ApiTest
{
    private readonly ParquetFile _test;
    private readonly ParquetFileController _testController;

    public ApiTest()
    {
        _test = new ParquetFile();
        _testController = new ParquetFileController();
    }
    [TestMethod]
    public async Task IGetFiles_AssertFilesArePopulated()
    {
        IList<IList<ParquetFile>> files = _testController.Get().Result;
        bool notEmpty = false;
        if (files[0][0].FileName != null && files[0][0].Id != null && files[0][0].Value != null && files[0][0].Name != null)
        {
            notEmpty = true;
        }
        Assert.IsTrue(notEmpty);
    }
    [TestMethod]
    public async Task ICreateNewFile_VerifyFileCreated()
    {
        _testController.Post("test", 3);
        IList<IList<ParquetFile>> files = _testController.Get().Result;
        bool created = files.Where(x => x[0].FileName == "test.parquet").Any();
        if (created)
        {
            System.IO.File.Delete($"C:\\Users\\eg014903\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\test.parquet");
            Assert.IsTrue(created);
        }
    }

    [TestMethod]
    public async Task IDeleteAFile_VerifyGone()
    {
        _testController.Post("test", 3);
        System.IO.File.Delete($"C:\\Users\\eg014903\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\test.parquet");
        IList<IList<ParquetFile>> files = _testController.Get().Result;
        bool created = files.Where(x => x[0].FileName == "test.parquet").Any();
        Assert.IsFalse(created);
    }
}