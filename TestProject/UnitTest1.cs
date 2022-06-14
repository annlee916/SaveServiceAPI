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

        [TestMethod]
        public void TestMethod3()
        {
            // threads interact with some object - either 
       
            var t1 = new Thread(AddStringToFile1);
            var t2 = new Thread(AddStringToFile2);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            string result1 = File.ReadAllText("Test1.txt");
            Assert.AreEqual("123456789", result1);

            string result2 = File.ReadAllText("Test2.txt");
            Assert.AreEqual("987654321", result2);
        }
        
        private void AddStringToFile1()
        {
            string teststring = "123456789";
            for (int x = 0; x < 1000; x++)
            {                
                SaveService.SaveToFileAsync("Test1.txt", teststring);
            }
        }

        private void AddStringToFile2()
        {
            string teststring = "987654321";
            for (int x = 0; x < 1000; x++)
            {
                SaveService.SaveToFileAsync("Test2.txt", teststring);
            }
        }
    }
}