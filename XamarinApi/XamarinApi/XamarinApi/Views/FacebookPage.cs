using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinApi.Models;
using XamarinApi.Provider;

namespace XamarinApi.Views
{
   public  class FacebookPage :ContentPage
    {
        private string ClientID = "498266130647640";
        public FacebookPage()
        {
            this.BackgroundColor = Color.White;
            //&display=popup mobilde acacagımdan ekranı popup seklınde acmasını ıstedıgımden
            var apiRequest = "https://www.facebook.com/dialog/oauth?client_id=" +
                ClientID + "&display=popup&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html";

            var webview = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };
            webview.Navigated += Webview_Navigated;
            Content = webview;

        }
    //    EAAHFK5ZB4ilgBALVAXJZCcVg1i6HxLB4u10bjoZCZCA6yiw5XLiuFPKr5vg41QHTCwa4GPy1MWturubmNHTbU0ZBxIe6mRhBhIS59ff9yPrYgTkndYRA1RA6X7G55U6135H5k7Mgw0ciIXnpZBZCzqUIXiqWENJ4CgH5lrShGslTRdZBSJMNvBuGJEWj1liIoxsZD
        private async void Webview_Navigated(object sender, WebNavigatedEventArgs e)
        {
            var accesstoken = ExtractAccestokenFromUri(e.Url);

            if (!string.IsNullOrEmpty(accesstoken))
            {
                //artık get istegi bu tipte bana cevap vericek
                ServiceManager<FacebookProfile> manager = new ServiceManager<FacebookProfile>();
                var profile =  await manager.GetFacebookProfile(accesstoken);

                var name = profile.Name;
                //burada sımdı bı post ıslemı gerceklestırıp bunun uzerınde ıslem yapıcaz
            }
        }
        private string ExtractAccestokenFromUri(string uri)
        {

            if (uri.Contains("access_token")&&uri.Contains("&expires_in="))
            {
                var https = "https";
                if (Xamarin.Forms.Device.OS==TargetPlatform.Windows|| Xamarin.Forms.Device.OS==TargetPlatform.WinPhone)
                {
                    https = "https";
                }
                uri = uri.Replace(https + "://www.facebook.com/connect/login.success.html#access_token=", "");
                var accesstoken = uri.Remove(uri.IndexOf("&expires_in"));
                return accesstoken;

            }
            return "";
        }
    }
    
}
