
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Page;
using OpenQA.Selenium.Edge;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCartBDD.Utilities
{
    internal class CoreCodes
    {
        public void TakeScreenshot(IWebDriver driver)
        {
            ITakesScreenshot its = (ITakesScreenshot)driver;
            Screenshot ss = its.GetScreenshot();
            string currDir = Directory.GetParent(@"../../../").FullName;
            string filepath = currDir + "/Screenshots/ss_" + DateTime.Now.ToString("yyyyy-MM-dd_hh-mm-ss") + ".png";
            ss.SaveAsFile(filepath);
        }
        protected void LogTestResult(string testName, string result, string errorMessage = null)
        {
            Log.Information(result);
           
            if (errorMessage == null)
            {
                Log.Information(testName + "passed");
               
            }
            else
            {
                Log.Error($"Test failed for{testName}. \n Exception: \n {errorMessage}");

               
            }
        }
    }

}
