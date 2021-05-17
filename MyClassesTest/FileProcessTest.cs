using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private string _GoodFileName;

        public TestContext TestContext { get; set; }

        #region TestInitialize and Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName == "FileNameDoesExists")
            {
                SetGoodFileName();

                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating file");
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == "FileNameDoesExists")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting file");
                    File.Delete(_GoodFileName);
                }
            }
        }

        #endregion

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];

            if (_GoodFileName.Contains("[AppPath]"))
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }

        [TestMethod] 
        [Owner("Ruan")]
        [Description("Check if a file does exist.")]
        [Timeout(300)]
        [Priority(1)]
        [TestCategory("NoException")]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine("Testing file");
            fromCall = fp.FileExists(_GoodFileName);
     
            Assert.IsTrue(fromCall);
        }

        public const string DEPLOYMENT_FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [Owner("Ruan")]
        [DeploymentItem(DEPLOYMENT_FILE_NAME)]
        public void FileNameDoesExistUsingDeploymentItem()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            string fileName = $@"{TestContext.DeploymentDirectory}\{DEPLOYMENT_FILE_NAME}";

            TestContext.WriteLine($"Checking file: {fileName}");
            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Owner("Ana")]
        [Priority(1)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Regedit.exe");

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [Owner("Ana")]
        [ExpectedException(typeof(ArgumentNullException))]
        [Priority(2)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

        [TestMethod]
        [Owner("Ana")]
        [Priority(2)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try 
            {
                fp.FileExists(""); 
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail("Fail expected");
        }
    }
}
