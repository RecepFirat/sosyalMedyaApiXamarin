using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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
            Content = webview;
        }
    }
}
