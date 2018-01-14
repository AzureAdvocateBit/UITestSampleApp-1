﻿using System;
using System.Collections.Generic;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Distribute;

namespace UITestSampleApp
{
    public static class AppCenterHelpers
    {
        public static void Start()
        {
            switch (Xamarin.Forms.Device.RuntimePlatform)
            {
                case Xamarin.Forms.Device.iOS:
                    Start(AppCenterConstants.AppCenteriOSApiKey);
                    break;
                case Xamarin.Forms.Device.Android:
                    Start(AppCenterConstants.AppCenterDroidApiKey);
                    break;
                default:
                    throw new NotSupportedException("Runtime Platform Not Supported");
            }
        }

        public static void TrackEvent(string trackIdentifier, IDictionary<string, string> table = null) =>
            Analytics.TrackEvent(trackIdentifier, table);

        public static void TrackEvent(string trackIdentifier, string key, string value)
        {
            IDictionary<string, string> table = new Dictionary<string, string> { { key, value } };

            if (string.IsNullOrWhiteSpace(key) && string.IsNullOrWhiteSpace(value))
                table = null;

            TrackEvent(trackIdentifier, table);
        }

        public static void LogException(Exception exception)
        {
            var exceptionType = exception.GetType().ToString();
            var message = exception.Message;

            System.Diagnostics.Debug.WriteLine(exceptionType);
            System.Diagnostics.Debug.WriteLine($"Error: {message}");
        }

        static void Start(string appSecret) =>
            AppCenter.Start(appSecret, typeof(Analytics), typeof(Crashes), typeof(Distribute));
    }
}
