using System;
using System.Net;
using System.Threading.Tasks;
using Android.Media;
using Newtonsoft.Json;
using Org.Json;
using static System.Net.WebRequestMethods.Http;
using Stream = System.IO.Stream;
using RestSharp;
using SimpleJson;

namespace BibleRazor.Models
{
    public class Model1
    {
        public string Text { get; set; }

       public class BibleApi
       {
           public const string BaseUrl = "http://labs.bible.org/api/?passage=John+3:16-17&formatting=full&type=json";

           public T Execute<T>(RestRequest request) where T : new()
           {
               var client = new RestClient();
               client.BaseUrl = new System.Uri(BaseUrl);
               var response = client.Execute<T>(request);

               if (response.ErrorException != null)
               {
                   const string message = "Error retrieving response.  Check inner details for more info.";
                   var bibleException = new ApplicationException(message, response.ErrorException);
                   throw bibleException;
               }
               return response.Data;
           }
       }
    }
}
