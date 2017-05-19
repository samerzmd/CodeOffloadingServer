using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeOffloadingServer.Controllers
{
    public class InsertionSortController : ApiController
    {
        // POST api/values
        public HttpResponseMessage Post()
        {
            var json = Request.Content.ReadAsStringAsync().Result;

            var josnArray = JArray.Parse(json);

            String[] strings = josnArray.ToObject<String[]>();

            Sorting(strings);

            return Request.CreateResponse(strings);
        }
        
        public static void Sorting(IComparable[] a)
        {
            int n = a.Length;
            for (int i = 1; i < n; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (a[j - 1].CompareTo(a[j]) > 0)
                    {
                        exch(a, j - 1, j);
                    }
                    else break;
                }
            }
        }

        // exchange a[i] and a[j]
        private static void exch(IComparable[] a, int i, int j)
        {
            IComparable swap = a[i];
            a[i] = a[j];
            a[j] = swap;
        }
    }
}
