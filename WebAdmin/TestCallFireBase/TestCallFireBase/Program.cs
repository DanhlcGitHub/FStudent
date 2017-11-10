using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestCallFireBase
{
    class Program
    {
        static void Main(string[] args)
        {
           /* try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://fcm.googleapis.com/");
                    var token = "emJhKhhCfr8:APA91bHF3lUcn7fmWVUdZVLqpFyajcrqKUJEApnpQnJQ2uHrxm64VZwdw4B3fN8-nADtXrbgibs9G_apnE6FP2DfXFuP5pNj95_zzXNHDQGgHpBNiZqSbddm5zhF39UOzGuJa65gElKl";

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
                    var requestContent = new
                    {
                        to = "/topics/absence-letter",
                        data = new
                        {
                            title = "Absence Letter",
                            message = string.Format("You have new absence letters from {0}.", "123")
                        }
                    };
                    StringContent request = new StringContent(JsonConvert.SerializeObject(requestContent),
                        Encoding.UTF8,
                        "application/json");

                    var response = client.PostAsync("/fcm/send", request).Result;

                    //abRepo.Create(model);

                }
            }
            catch (Exception e)
            {
               
            }*/
            SendMessage();
            Console.WriteLine("call success!..........");
            Console.ReadKey();
        }

        static void SendMessage()
        {
            string serverKey = "AIzaSyB049detSV0BLjmsDM32cma3h0fY2s1cSw";
            string mainToken = "cQdiow0g480:APA91bHz6PO0GzXvnI360GEr2m7nIAh1DWqP9spWRc_bb1WRhjMAeBtD8N1Wz5F_fQzCtex35XSllghnNggVFYgryf5ui8tvicdaw33FcocagaWVWXocuuRfg_ORpxuFkMCqJyGb9Rnz";
            string token1 = "dHovYmszJ1o:APA91bHBaiFNviNtjL4Lcm90jfXLpst0acrpgyb-_FwQx5XykBdFqffDRNwH8RGfljnAFA846cEmhK6fJBVRZZHDw2suKBT0xaha2ycX26x9xgM0fP82DpxvlFV6SaztnodhrPkCRDQp";
            string token = "emJhKhhCfr8:APA91bHF3lUcn7fmWVUdZVLqpFyajcrqKUJEApnpQnJQ2uHrxm64VZwdw4B3fN8-nADtXrbgibs9G_apnE6FP2DfXFuP5pNj95_zzXNHDQGgHpBNiZqSbddm5zhF39UOzGuJa65gElKl";
            string token2 = "eXWLk2VnH88:APA91bEjFgGJeia9IVLb-jJErU8ukBGtBiC7Iq1v4deW4rFqx3MGfzkwDyEXidKY2qYajChl0o-fgQZT8PjBWlLoyJUtmoIBlta_I2zJedKxdptmZoOxYmXqhTSxohOcwFWtb_Pascym";
            try
            {
                var result = "-1";
                var webAddr = "https://fcm.googleapis.com/fcm/send";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization:key=" + serverKey);
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"to\": \" " + mainToken + "\",\"data\": {\"message\": \"This is a Firebase Cloud Messaging Topic Message!\",}}";
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                // return result;
            }
            catch (Exception ex)
            {
                //  Response.Write(ex.Message);
            }
        }
    }
}
