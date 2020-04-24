using System.Configuration;

namespace BDDAutotests.Settings
{
	public class Configuration
	{
		public static string GetEnviromentVar(string var, string defaultValue)
		{
			return ConfigurationManager.AppSettings[var] ?? defaultValue;
		}

		public static string GetElementTimeout()
		{
			return GetEnviromentVar("ElementTimeout", "30");
		}

		public static string GetBrowser()
		{
			return GetEnviromentVar("Browser", "Chrome");
		}
	}
}
