using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApi.Provider
{
    public class ServiceManager<T> where T : class //generic bi yapı oldu cunku hep twitterda hem facede hemde instada kullanabıleyım
    {
        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            return client;
        }

        //buradada  isterler gerceklestirip ona gore islem yapıcam

        public async Task<T> GetFacebookProfile(string accessToken)
        {

            var httpclient = await GetClient();

            var requestURL = "https://graph.facebook.com/v2.7/me?fields=name,picture,work,website,religion,location,locale,link,cover,age_range,birthday,devices,email,first_name,last_name,gender,hometown,is_verified,languages&access_token="
                    + accessToken;
            var userJson = await httpclient.GetStringAsync(requestURL);
            var profile = JsonConvert.DeserializeObject<T>(userJson);//hangi claassta yaratıldıysa kendını ona cast edicek
            return profile;
        }
    }
}
