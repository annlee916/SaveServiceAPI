using ServiceAPI;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private const string teststring = "123456789";

        [TestMethod]
        public void TestMethod1()
        {
            string FileName = "Test1.txt";
            string result = "";
            Task taskSave = SaveService.SaveToFileAsync(FileName, teststring);


            result = File.ReadAllText(FileName);
            Assert.AreEqual(teststring, result);

        }

        [TestMethod]
        public void TestMethod2()
        {
            string FileName = "Test1.txt";
            string result = "";
            Task taskSave = SaveService.SaveToFileAsync(FileName, teststring+" ");

            result = File.ReadAllText(FileName);
            Assert.AreEqual(teststring, result);

        }
    }
}