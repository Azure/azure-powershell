using System;
using Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json;

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802
{
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
            // The PUT operation doesn't like when the TypeHandlerVersion is more than 2 decimals in the version.
            // This trims it to be just Major and Minor.
            if (container.TryGetValue(typeHandlerVersionPropertyName, out JsonNode node))
            {
                var version = Version.Parse((string) node.ToValue());
                container.Remove(typeHandlerVersionPropertyName);
                container.Add(typeHandlerVersionPropertyName, $"{version.Major}.{version.Minor}");
            }
        }
    }

    /// <summary>Describes a Machine Extension.</summary>
    public partial class MachineExtensionUpdateProperties
    {
        private const string typeHandlerVersionPropertyName = "typeHandlerVersion";

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        partial void AfterToJson(ref JsonObject container)
        {
            // The PATCH operation (aka Update) doesn't like when a version is specified so we remove it entirely.
            if (container.TryGetValue(typeHandlerVersionPropertyName, out JsonNode node))
            {
                container.Remove(typeHandlerVersionPropertyName);
            }
        }
    }

    public partial class MachineExtensionProperties1
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
                // The PUT operation doesn't like when the TypeHandlerVersion is more than 2 decimals in the version.
                // This trims it to be just Major and Minor.
                var version = Version.Parse((string) node.ToValue());
                container.Remove(typeHandlerVersionPropertyName);
                container.Add(typeHandlerVersionPropertyName, $"{version.Major}.{version.Minor}");
            }
        }
    }

    public partial class MachineExtensionUpdateProperties1
    {
        private const string typeHandlerVersionPropertyName = "typeHandlerVersion";

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        partial void AfterToJson(ref JsonObject container)
        {
            // The PATCH operation (aka Update) doesn't like when a version is specified so we remove it entirely.
            if (container.TryGetValue(typeHandlerVersionPropertyName, out JsonNode node))
            {
                container.Remove(typeHandlerVersionPropertyName);
            }
        }
    }
}
