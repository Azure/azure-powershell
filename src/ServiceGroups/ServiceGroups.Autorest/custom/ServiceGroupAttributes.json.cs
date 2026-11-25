// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.ServiceGroups.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.ServiceGroups.Runtime.Json;

    /// <summary>The attributes of the service group.</summary>
    public partial class ServiceGroupAttributes
    {
        /// <summary>
        /// Accept integral JSON numbers serialized with a decimal component, such as 1.0.
        /// </summary>
        /// <param name="json">The JSON object to deserialize.</param>
        /// <param name="returnNow">Indicates that custom deserialization is complete.</param>
        partial void BeforeFromJson(JsonObject json, ref bool returnNow)
        {
            var criticality = json?.PropertyT<JsonNumber>("criticality");
            if (criticality != null)
            {
                _criticality = decimal.ToInt32((decimal)criticality);
            }

            returnNow = true;
        }
    }
}
