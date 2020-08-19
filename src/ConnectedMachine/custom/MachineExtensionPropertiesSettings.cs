using System.Collections;
using Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json;

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api201912
{
    public partial class MachineExtensionPropertiesSettings
    {
        public IDictionary Settings { get; private set; }

        partial void AfterDeserializeDictionary(IDictionary content)
        {
            Settings = content;
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
