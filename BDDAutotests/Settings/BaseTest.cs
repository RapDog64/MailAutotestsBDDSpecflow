using BDDAutotests.Utility;
using log4net;
using log4net.Config;
using NUnit.Framework;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace BDDAutotests.Settings
{
    [Binding]
    public abstract class BaseTest
    {
        protected static Browser Browser;
        private static readonly ILog logger = LogManager.GetLogger(typeof(BaseTest));
        private const string pathToFailedScreenshots = @"C:\Users\RapDog\source\repos\BDDAutotests";


        
        [BeforeTestRun]
        public  static void SetUp()
        {
           // Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
            Browser = Browser.GetInstance();
            Browser.WindowMaximise();
            logger.Info("The brower is run");
        }

        [AfterTestRun]
        public static void TearDown()
        {
            Browser.Quit();
            logger.Info("Closed the browser");
        }

        [AfterFeature]
        public static void Checker()
        {
            if (TestContext.CurrentContext.Result.FailCount > 0)
            {
                ScreenshotTaker.TakeScreenshot(Path.Combine(pathToFailedScreenshots, "FailedScreenshots"), TestContext.CurrentContext.Test.Name);
            }
        }
    }
}
