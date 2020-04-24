using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace BDDAutotests.Settings
{
    public abstract class BasePage
    {
        protected void IsElementVisible(By element, int timeoutSecs = 15)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(timeoutSecs)).Until(ExpectedConditions.ElementIsVisible(element));
        }

        protected void ClickButton(By element)
        {
            IsElementVisible(element);
            Browser.GetDriver().FindElement(element).Click();
        }

        protected void JSClick(By element)
        {
            IsElementVisible(element);
            IWebElement driverElement = Browser.GetDriver().FindElement(element);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].click();", driverElement);
        }

        protected string GetTextByJS(By element)
        {
            IWebElement driverElement = Browser.GetDriver().FindElement(element);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();

            return executor.ExecuteScript("return arguments[0].innerHTML;", driverElement).ToString();
        }
    }
}
