using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    public static class PowershellConverter
    {
        public static IDictionary<string, object> ConvertFromHashTableToGenericDictionary(IDictionary hashtable)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            foreach (var item in hashtable.Keys) {
                var value = hashtable[item];
                if (value is Hashtable subHashtable) {
                    result.Add(item.ToString(), ConvertFromHashTableToGenericDictionary(subHashtable));
                } else {
                    result.Add(item.ToString(), hashtable[item]);
                }
            }

            return result;
        }
    }
}