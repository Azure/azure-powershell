using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json;

namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    public partial class CloudServiceExtensionPropertiesSettings
    {
        private IDictionary<string, object> Settings { get; set; }
 
        partial void AfterDeserializeDictionary(System.Collections.IDictionary content)
        {
            Settings = PowershellConverter.ConvertFromHashTableToGenericDictionary(content);
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
