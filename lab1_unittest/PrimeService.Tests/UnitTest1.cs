namespace Prime.Service.Tests;

public class Tests
{

   [OneTimeSetUp]
    public void init() {
        //Console.WriteLine("銝�甈⊥�抒�韏瑕��");
        TestContext.Progress.WriteLine("一次性的啟動");
    }
    [OneTimeTearDown]
    public void finalize() {
        //Console.WriteLine("銝�甈⊥�抒�皜��膄");
        TestContext.Progress.WriteLine("一次性的清理");
    }


    [SetUp]
    public void Setup()
    {
        Console.WriteLine("測試前準備");
    }

      [TearDown]
    public void StoreData()
    {
        Console.WriteLine("儲存資料，及清理資料");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
     [Ignore("還沒寫好！")]
    public void Test2() {
        Assert.Fail("這是一個應該發生的錯誤！");
    }

     
}

