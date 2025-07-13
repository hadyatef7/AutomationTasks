using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationTask
{
	public class Test
	{
		IWebDriver driver;

		[Test]
		public void BasicMethods()
		{
			driver = new ChromeDriver();

			// 1. Open the Chrome browser and navigate to url
			driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");

			// 2. Print the current URL, page title, and HTML source code
			Console.WriteLine("URL: " + driver.Url);
			Console.WriteLine("Title: " + driver.Title);
			Console.WriteLine("Page Source (first 500 chars): \n" + driver.PageSource.Substring(0, 500));

			// 3. Print the unique ID of the current browser window
			Console.WriteLine("Window Handle: " + driver.CurrentWindowHandle);

			// 4. Navigate to https://www.saucedemo.com
			driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");

			// 5. Go back, forward, then refresh
			driver.Navigate().Back();
			driver.Navigate().Forward();
			driver.Navigate().Refresh();

			// 6. Print current window size and position
			Console.WriteLine("Window Size: " + driver.Manage().Window.Size);
			Console.WriteLine("Window Position: " + driver.Manage().Window.Position);

			// 7. Resize window to 1024x768
			driver.Manage().Window.Size = new System.Drawing.Size(1024, 768);

			// 8. Move window to X = 200, Y = 150
			driver.Manage().Window.Position = new System.Drawing.Point(200, 150);

			// 9. Maximize then fullscreen
			driver.Manage().Window.Maximize();
			driver.Manage().Window.FullScreen();

			// 10. Close current tab
			driver.Close();

			// 11. Launch again and open new site, then quit
			driver = new ChromeDriver(); // re-launch
			driver.Navigate().GoToUrl("https://github.com");

			driver.Quit();
		}
		[Test]
		public void LocatorsExamples() {
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://www.facebook.com/r.php?entry_point=login");
			driver.Manage().Window.Maximize();

			// Locate by Name
			driver.FindElement(By.Name("firstname")).SendKeys("TestFirst");

			// Locate by Name
			driver.FindElement(By.Name("lastname")).SendKeys("TestLast");

			// Locate by Name
			driver.FindElement(By.Name("reg_email__")).SendKeys("testemail@example.com");

			// Wait for confirmation field to appear and locate by Name
			System.Threading.Thread.Sleep(1000);
			driver.FindElement(By.Name("reg_email_confirmation__")).SendKeys("testemail@example.com");

			// Locate by ID
			driver.FindElement(By.Id("password_step_input")).SendKeys("Test@12345");

			// Locate by TagName (Dropdown for birth day)
			var days = driver.FindElement(By.TagName("select"));
			var birthDay = driver.FindElement(By.Name("birthday_day"));
			birthDay.SendKeys("13");

			// Locate by CSS Selector for birth month
			driver.FindElement(By.CssSelector("select#month")).SendKeys("Jul");

			// Locate by XPath for birth year
			driver.FindElement(By.XPath("//select[@id='year']")).SendKeys("1990");

			// Locate by ClassName for gender selection (Male)
			var genderOptions = driver.FindElements(By.ClassName("_8esa"));
			foreach (var option in genderOptions)
			{
				if (option.Text.Contains("Male"))
				{
					option.Click();
					break;
				}
			}

			// Optionally, click the Sign Up button (not recommended in test)
			// driver.FindElement(By.Name("websubmit")).Click();

			Assert.Pass("Form filled with test data successfully.");
			driver.Quit();

		}
	}

}