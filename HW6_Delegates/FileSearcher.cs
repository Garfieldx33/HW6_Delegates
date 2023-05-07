using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_Delegates
{
    static class FileSearcher
    {
        
    }

    internal class FileArgs : EventArgs
    {
        public FileArgs() { }
    }


    public static class SearchMaxExtention<T> where T : class
    {
        public static T GetMax(IEnumerable<T> e, Func<T, float> getParameter)
        { 
            Dictionary<float,T> resultDict = new Dictionary<float,T>();
            var enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                resultDict.Add(getParameter(enumerator.Current),enumerator.Current);
            }
            return resultDict.OrderByDescending(x => x.Key).First().Value;
        }
    }
    
}
