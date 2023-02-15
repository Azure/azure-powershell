using System.Collections;
using Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json;

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310
{
    public partial class MachineExtensionUpdate : Hashtable
    {
        partial void AfterDeserializeDictionary(IDictionary content)
        {
            foreach (var key in content.Keys)
            {
                this[key] = content[key];
            }
        }

        partial void AfterToJson(ref JsonObject container)
        {
            foreach (var key in this.Keys)
            {
                if (!container.ContainsKey(key.ToString()))
                {
                    container.Add(
                        key.ToString(),
                        Runtime.JsonSerializable.ToJsonValue(this[key]));
                }
            }
        }

        partial void AfterFromJson(JsonObject json)
        {
            foreach (var key in json.Keys)
            {
                this[key] = json[key].ToValue();
            }
        }
    }
}
