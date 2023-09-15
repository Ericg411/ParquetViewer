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
        _testController.Create("test", 3);
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
        _testController.Create("test", 3);
        System.IO.File.Delete($"C:\\Users\\eg014903\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\test.parquet");
        IList<IList<ParquetFile>> files = _testController.Get().Result;
        bool created = files.Where(x => x[0].FileName == "test.parquet").Any();
        Assert.IsFalse(created);
    }

    [TestMethod]
    public async Task IGetOneFile_VerifyOnlyOneFile()
    {
        _testController.Create("test", 3);
        IList<IList<ParquetFile>> test = _testController.Get().Result;
        int howMany = test.Where(x => x[0].FileName == "test.parquet").Count();
        Assert.AreEqual(1, howMany);
        System.IO.File.Delete($"C:\\Users\\eg014903\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\test.parquet");
    }
    [TestMethod]
    public async Task IUpdateNameAndValue_IGetUpdatedFile()
    {
        _testController.Create("testTwo", 3);
        _testController.Update("testTwo", 0, "HOTDOGS", 100);
        IList<ParquetFile> test = _testController.GetOneFile("testTwo").Result;
        bool updated = false;
        if (test[0].Name == "HOTDOGS" && test[0].Value == 100)
        {
            updated = true;
        }

        Assert.IsTrue(updated);

        System.IO.File.Delete($"C:\\Users\\eg014903\\source\\repos\\ParquetViewer\\ParquetViewer\\TestFiles\\testTwo.parquet");
    }
}