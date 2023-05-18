using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_Delegates
{
    public static class SearchMaxExtention<T> where T : class
    {
        public static T GetMax(IEnumerable<T> e, Func<T, float> getParameter)
        {
            if (e != null)
            {
                if (e.Any())
                {
                    return GetMaxElement(e.ToArray(), getParameter); 
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null; 
            }
            /*Dictionary<float, T> resultDict = new Dictionary<float, T>();
            var enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                resultDict.Add(getParameter(enumerator.Current), enumerator.Current);
            }
            if (resultDict.Count > 0)
            {
                return resultDict.OrderByDescending(x => x.Key).First().Value; 
*/
        }

        static T GetMaxElement(T[] array, Func<T, float> getParameter)
        {
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (getParameter(array[j]) < getParameter(array[j + 1]))
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return array[0];
        }
        static void Swap(ref T e1, ref T e2)
        {
            T temp = e1;
            e1 = e2;
            e2 = temp;
        }
    }
}
