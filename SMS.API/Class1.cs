using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SMS.API
{
    public class SMSAPI
    {
        //private string _customerId;
        //public SMSAPI(string customerId)
        //{
        //    _customerId = customerId;
        //}

        class TokenResponse
        {
            public string Token { get; set; }
        }
        class SendSmsRequest
        {
            public string content { get; set; }
            public string schedule {get;set;}
            public string destination {get;set;}
            public string sender {get;set;}
            

        }
        public async Task<string> SendSmsAsync(string number, string message)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.thesmsworks.co.uk/v1");

           
            var loginContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("customerid", "8dab-f6aa-909a-4d13-a11d-8456e3436710"),
                new KeyValuePair<string, string>("key", "de3543e3-02f2-4c7d-a721-ab274f50f601"),
                new KeyValuePair<string, string>("secret", "ff463aca181f3627f7aa0694b3b054c4274c3ec7b95bb3ce2e97cb063fc02a59")
            });
            var loginResult = await httpClient.PostAsync("/auth/token", loginContent);
            string loginResultContent = await loginResult.Content.ReadAsStringAsync();

            //var sendSmsContent = new FormUrlEncodedContent(new[]
            //{
            //    new KeyValuePair<string, string>("destination", number),
            //    new KeyValuePair<string, string>("content", message),
            //    new KeyValuePair<string, string>("sender", "Pixelon")
            //});

            var jsonContent = 
                
                Newtonsoft.Json.JsonConvert.SerializeObject(new SendSmsRequest() { content = message, destination = number, schedule = "false", sender = "PIXELON" });

            var deserializedTokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(loginResultContent);
            
            var rawContent =new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var splitArrayOfDeserializedTokenResponse = deserializedTokenResponse.Token.Split(' ');
            var scheme = splitArrayOfDeserializedTokenResponse[0];
            var tokenValue = splitArrayOfDeserializedTokenResponse[1];
            //return "";
            httpClient.DefaultRequestHeaders.AcceptCharset.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("UTF-8"));
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //httpClient.DefaultRequestHeaders.
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(scheme, tokenValue);
            //httpClient.BaseAddress = new Uri("https://api.thesmsworks.co.uk/v1");

            var sendSmsResult = await httpClient.PostAsync("https://api.thesmsworks.co.uk/v1/message/send", rawContent);
            var smsResultContent = await sendSmsResult.Content.ReadAsStringAsync();

            return smsResultContent;

            //Console.WriteLine(resultContent);

            //await httpClient.PostAsync("/auth/token", )
            //var loginRequest = new RestRequest("/auth/token", Method.POST);
            //loginRequest.AddParameter("customerId", "8dab-f6aa-909a-4d13-a11d-8456e3436710"); // adds to POST or URL querystring based on Method
            //loginRequest.AddParameter("key", "de3543e3-02f2-4c7d-a721-ab274f50f601"); // adds to POST or URL querystring based on Method
            //loginRequest.AddParameter("secret", "ff463aca181f3627f7aa0694b3b054c4274c3ec7b95bb3ce2e97cb063fc02a59"); // adds to POST or URL querystring based on Method
            //IRestResponse loginResponse = client.Execute(loginRequest);
            //var loginResponseContent = loginResponse.Content;

            //var smsSendRequest = new RestRequest("/message/send", Method.POST);

            //var sender = "Pixelon";
            //var destination = number;


            //smsSendRequest.AddParameter("sender", sender); // adds to POST or URL querystring based on Method
            //smsSendRequest.AddParameter("destination", destination); // adds to POST or URL querystring based on Method
            //smsSendRequest.AddParameter("content", message); // adds to POST or URL querystring based on Method

            //IRestResponse smsSendResponse = client.Execute(loginRequest);
            //var smsSendResponseContent = loginResponse.Content;

            //return smsSendResponseContent;

            ////request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            //// easily add HTTP Headers
            //request.AddHeader("header", "value");

            // add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
        }

    }
}
