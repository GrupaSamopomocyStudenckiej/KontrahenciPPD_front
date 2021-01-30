using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC
{
    public static class ZmienneGlobalne
    {
        public static HttpClient WebApiClient = new HttpClient();
    static ZmienneGlobalne()
    {
        WebApiClient.BaseAddress = new Uri("https://localhost:44306/api/Firmy");
        WebApiClient.DefaultRequestHeaders.Clear();
        WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("appication/json"));
    }
}
}