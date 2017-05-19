using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeOffloadingServer.Controllers
{
    public class MergeSortController : ApiController
    {
        // POST api/values
        public HttpResponseMessage Post()
        {
            var json = Request.Content.ReadAsStringAsync().Result;

            var josnArray = JArray.Parse(json);

            String[] strings = josnArray.ToObject<String[]>();

            sort(strings);

            return Request.CreateResponse(strings);
        }

        private static void merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
        {
            int i = lo, j = mid;
            for (int k = lo; k < hi; k++)
            {
                if (i == mid) aux[k] = a[j++];
                else if (j == hi) aux[k] = a[i++];
                else if (a[j].CompareTo(a[i]) < 0) aux[k] = a[j++];
                else aux[k] = a[i++];
            }

            // copy back
            for (int k = lo; k < hi; k++)
                a[k] = aux[k];
        }


        /***************************************************************************
         *  Mergesort the subarray a[lo] .. a[hi-1], using the
         *  auxilliary array aux[] as scratch space.
         ***************************************************************************/
        public static void sort(IComparable[] a, IComparable[] aux, int lo, int hi)
        {

            // base case
            if (hi - lo <= 1) return;

            // sort each half, recursively
            int mid = lo + (hi - lo) / 2;
            sort(a, aux, lo, mid);
            sort(a, aux, mid, hi);

            // merge back together
            merge(a, aux, lo, mid, hi);
        }


        /***************************************************************************
         *  Sort the array a using mergesort.
         ***************************************************************************/
        public static void sort(IComparable[] a)
        {
            int n = a.Length;
            IComparable[] aux = new IComparable[n];
            sort(a, aux, 0, n);
        }

        /***************************************************************************
         *  Sort the subarray a[lo..hi] using mergesort.
         ***************************************************************************/
        public static void sort(IComparable[] a, int lo, int hi)
        {
            int n = hi - lo + 1;
            IComparable[] aux = new IComparable[n];
            sort(a, aux, lo, hi);
        }


        /***************************************************************************
         *  Check if array is sorted - useful for debugging.
         ***************************************************************************/
        private static bool isSorted(IComparable[] a)
        {
            for (int i = 1; i < a.Length; i++)
                if (a[i].CompareTo(a[i - 1]) < 0) return false;
            return true;
        }
    }
}
