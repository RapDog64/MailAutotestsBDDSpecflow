﻿using OpenQA.Selenium;
using System;

namespace BDDAutotests.Settings
{
	public class Browser
	{
		private static Browser _currentInstane;
		private static IWebDriver _driver;
		public static BrowserFactory.BrowserType CurrentBrowser;
		public static int ImplWait;
		public static double TimeoutForElement;
		private static string _browser;

		private Browser()
		{
			InitParamas();
			_driver = BrowserFactory.GetDriver(CurrentBrowser, ImplWait);
		}

		private static void InitParamas()
		{
			ImplWait = Convert.ToInt32(Configuration.GetElementTimeout());
			TimeoutForElement = Convert.ToDouble(Configuration.GetElementTimeout());
			_browser = Configuration.GetBrowser();
			Enum.TryParse(_browser, out CurrentBrowser);
		}

		public static Browser GetInstance()
		{
			return _currentInstane ?? (_currentInstane = new Browser());
		}

		public static void WindowMaximise()
		{
			_driver.Manage().Window.Maximize();
		}

		public static void NavigateTo(string url)
		{
			_driver.Navigate().GoToUrl(url);
		}

		public static IWebDriver GetDriver()
		{
			return _driver;
		}

		public static void Quit()
		{
			_driver.Quit();
			_currentInstane = null;
			_driver = null;
			_browser = null;
		}
	}
}
