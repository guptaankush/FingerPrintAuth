using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FingerPrintAuth
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void authBtn_Clicked(object sender, EventArgs e)
        {
            bool isFingerPrintAvailable = await CrossFingerprint.Current.IsAvailableAsync(false);

            if (!isFingerPrintAvailable)
            {
                await DisplayAlert("Alert", "Biometric Auth. not available or configure for this device.","Okay");
                return;
            }

            AuthenticationRequestConfiguration configuration = new AuthenticationRequestConfiguration("Authentication", "Authenticate access for login");

            var result = await CrossFingerprint.Current.AuthenticateAsync(configuration);
            if(result.Authenticated)
            {
                // Authenticate Successfully
                await DisplayAlert("Success", "Login Successfully.", "Okay");
            }
            else
            {
                // Something went wrong!!
                await DisplayAlert("Alert", "Login Failed, Please try again.", "Okay");
            }
        }
    }
}
