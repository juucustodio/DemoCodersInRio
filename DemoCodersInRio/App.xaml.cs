using System;
using System.Collections.Generic;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoCodersInRio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {

            AppCenter.Start("android=bd6f0f15-6bcc-4b07-944e-b9f3cc14ce26;" +
                  "ios=d8ebaddc-426b-40b1-a7a0-bbdf52d2a8b1;",
                  typeof(Analytics), typeof(Crashes));

            try
            {
                throw new Exception("Erro proposital");
            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>
                {
                    { "ErrorMessage", ex.Message }
                };
                Crashes.TrackError(ex, properties);
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
