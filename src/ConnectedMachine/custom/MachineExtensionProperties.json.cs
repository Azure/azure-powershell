using System;
using Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json;

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview
{
    /// <summary>Describes a Machine Extension.</summary>
    public partial class MachineExtensionProperties
    {
        private const string typeHandlerVersionPropertyName = "typeHandlerVersion";

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        partial void AfterToJson(ref JsonObject container)
        {
            if (container.TryGetValue(typeHandlerVersionPropertyName, out JsonNode node))
            {
                var version = Version.Parse((string) node.ToValue());
                container.Remove(typeHandlerVersionPropertyName);
                container.Add(typeHandlerVersionPropertyName, $"{version.Major}.{version.Minor}");
            }
        }
    }
}
