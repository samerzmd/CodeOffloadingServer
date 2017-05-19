using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CodeOffloadingServer.Controllers
{
    public class QuickSortController : ApiController
    {
        // POST api/values
        public HttpResponseMessage Post()
        {
            var json = Request.Content.ReadAsStringAsync().Result;

            var josnArray=JArray.Parse(json);

            String[] strings = josnArray.ToObject<String[]>();

            Sorting(strings, 0, strings.Length-1);

            return Request.CreateResponse(strings);
        }
        public void Sorting(String[] array, int start, int end)
        {
            int i = start;
            int k = end;
            if (end - start >= 1)
            {
                String pivot = array[start];
                while (k > i)
                {
                    while (array[i].CompareTo(pivot) <= 0 && i <= end && k > i)
                        i++;
                    while (array[k].CompareTo(pivot) > 0 && k >= start && k >= i)
                        k--;
                    if (k > i)
                        Swap(array, i, k);
                }
                Swap(array, start, k);
                Sorting(array, start, k - 1);
                Sorting(array, k + 1, end);
            }
            else { return; }
        }
        private void Swap(String[] array, int index1, int index2)
        {
            String temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
