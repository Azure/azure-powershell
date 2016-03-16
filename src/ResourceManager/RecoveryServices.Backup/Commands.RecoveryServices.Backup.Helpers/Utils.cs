using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public class HelperUtils
    {
        public static List<T> GetEnumListFromStringList<T>(IList<string> strList)
        {
            if (strList == null || strList.Count == 0)
            {
                return null;
            }
            var ret = new List<T>();

            foreach (string str in strList)
            {
                ret.Add((T)Enum.Parse(typeof(T), str));
            }

            return ret;
        }

        public static List<string> GetStringListFromEnumList<T>(IList<T> enumList)
        {
            if (enumList == null || enumList.Count == 0)
            {
                return null;
            }
            var ret = new List<string>();

            foreach (T item in enumList)
            {
                ret.Add(item.ToString());
            }

            return ret;
        }
    }
}
