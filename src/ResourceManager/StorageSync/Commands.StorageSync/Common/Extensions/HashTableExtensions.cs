using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.StorageSync.Common.Extensions
{
    public static class HashTableExtensions
    {
        public static Dictionary<string, string> ToDictionary(this Hashtable tags)
        {
            return TagsConversionHelper.CreateTagDictionary(tags, true);
        }
    }
}
