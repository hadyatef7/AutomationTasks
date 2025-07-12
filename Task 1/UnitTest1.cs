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

			// By.Name: First Name
			var firstName = driver.FindElement(By.Name("firstname"));
			firstName.SendKeys("TestFirst");

			// By.Name: Last Name
			var lastName = driver.FindElement(By.Name("lastname"));
			lastName.SendKeys("TestLast");

			// By.Name: Mobile or Email
			var email = driver.FindElement(By.Name("reg_email__"));
			email.SendKeys("testuser@example.com");

			// By.Name: Re-enter Email
			var reEmail = driver.FindElement(By.Name("reg_email_confirmation__"));
			reEmail.SendKeys("testuser@example.com");

			// By.Id: New Password
			var password = driver.FindElement(By.Id("password_step_input"));
			password.SendKeys("Test@12345");

			// By.XPath: Birth Day
			var day = driver.FindElement(By.XPath("//select[@id='day']"));
			day.SendKeys("13");

			// By.CssSelector: Birth Month
			var month = driver.FindElement(By.CssSelector("select#month"));
			month.SendKeys("Jul");

			// By.TagName: Birth Year (first select tag is Day, second is Month, third is Year)
			var year = driver.FindElements(By.TagName("select"))[2];
			year.SendKeys("1995");

			// By.ClassName: Gender (Male radio button has class '_8esa')
			var maleRadio = driver.FindElements(By.ClassName("_8esa"))[1]; // second one is Male
			maleRadio.Click();

			// By.XPath: Click Sign Up button
			var signUpBtn = driver.FindElement(By.XPath("//button[@name='websubmit']"));
			signUpBtn.Click();

			Console.WriteLine("Test data filled and Sign Up clicked.");
			driver.Quit();

		}
	}

}