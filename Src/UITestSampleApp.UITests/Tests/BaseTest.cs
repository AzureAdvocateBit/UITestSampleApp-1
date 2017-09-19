﻿using NUnit.Framework;

using Xamarin.UITest;

namespace UITestSampleApp.UITests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]

	public abstract class BaseTest
	{
		protected IApp App;
		protected Platform Platform;

		protected FirstPage FirstPage;
		protected ListPage ListPage;
		protected LoginPage LoginPage;
		protected NewUserSignUpPage NewUserSignUpPage;

		protected BaseTest (Platform platform) => Platform = platform;

		[SetUp]
		virtual public void BeforeEachTest()
		{
			App = AppInitializer.StartApp(Platform);
			App.Screenshot("App Initialized");

			FirstPage = new FirstPage(App, Platform);
			ListPage = new ListPage(App, Platform);
			LoginPage = new LoginPage(App, Platform);
			NewUserSignUpPage = new NewUserSignUpPage(App, Platform);

			LoginPage.WaitForPageToLoad();
		}
	}
}

