﻿using Xamarin.UITest;

namespace UITestSampleApp.UITests
{
    static class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            switch (platform)
            {
                case Platform.Android:
                    return ConfigureApp.Android.StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);

                case Platform.iOS:
                    return ConfigureApp.iOS.StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);

                default:
                    throw new System.NotSupportedException();
            }
        }
    }
}

