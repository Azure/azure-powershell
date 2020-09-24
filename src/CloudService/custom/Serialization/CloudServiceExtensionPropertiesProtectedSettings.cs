using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json;

namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    public partial class CloudServiceExtensionPropertiesProtectedSettings
    {
        private IDictionary<string, object> Settings { get; set; } = new Dictionary<string, object>();
 
        partial void AfterDeserializeDictionary(System.Collections.IDictionary content)
        {
            Settings = PowershellConverter.ConvertFromHashTableToGenericDictionary(content);
        }
 
        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject json, ref bool returnNow)
        {
            IDictionary<string, object> tmp = new Dictionary<string, object>();
            foreach (var item in json.Keys)
            {
                tmp.Add(item, json[item]);
            }
            Settings = tmp;
        }
 
        partial void AfterToJson(ref JsonObject container)
        {
            foreach (var item in Settings.Keys)
            {
                container.Add(
                    item.ToString(),
                    Runtime.JsonSerializable.ToJsonValue(Settings[item]));
            }
        }
    }
}
