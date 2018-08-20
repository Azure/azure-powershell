using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.BotService.Utilities
{
    public static class TagBuilder
    {
        public static KeyValuePair<string, string> Create(Hashtable hashtable)
        {
            if (hashtable == null ||
                !hashtable.ContainsKey("Name"))
            {
                return new KeyValuePair<string, string>();
            }


            return new KeyValuePair<string, string>(
                hashtable["Name"].ToString(),
                hashtable.ContainsKey("Value") ? hashtable["Value"].ToString() : string.Empty);
        }

        public static Dictionary<string, string> CreateTagDictionary(Hashtable[] hashtableArray)
        {
            Dictionary<string, string> tagDictionary = null;
            if (hashtableArray != null && hashtableArray.Length > 0)
            {
                tagDictionary = new Dictionary<string, string>();
                foreach (var tag in hashtableArray)
                {
                    var tagValuePair = Create(tag);
                    if (!string.IsNullOrEmpty(tagValuePair.Key))
                    {
                        if (tagValuePair.Value != null)
                        {
                            tagDictionary[tagValuePair.Key] = tagValuePair.Value;
                        }
                        else
                        {
                            tagDictionary[tagValuePair.Value] = "";
                        }
                    }
                }
            }

            return tagDictionary;
        }

        public static Hashtable[] CreateTagHashtable(IDictionary<string, string> dictionary)
        {
            if (dictionary == null)
            {
                return new Hashtable[0];
            }

            List<Hashtable> tagHashtable = new List<Hashtable>();
            foreach (string key in dictionary.Keys)
            {
                tagHashtable.Add(new Hashtable
                {
                    {"Name", key},
                    {"Value", dictionary[key]}
                });
            }
            return tagHashtable.ToArray();
        }
    }
}