// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    using System.Linq;

    /// <summary>
    /// InMageRcm provider specific container mapping details.
    /// </summary>
    [Newtonsoft.Json.JsonObject("InMageRcm")]
    public partial class InMageRcmProtectionContainerMappingDetails : ProtectionContainerMappingProviderSpecificDetails
    {
        /// <summary>
        /// Initializes a new instance of the InMageRcmProtectionContainerMappingDetails class.
        /// </summary>
        public InMageRcmProtectionContainerMappingDetails()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the InMageRcmProtectionContainerMappingDetails class.
        /// </summary>

        /// <param name="enableAgentAutoUpgrade">A value indicating whether the flag for enable agent auto upgrade.
        /// </param>
        public InMageRcmProtectionContainerMappingDetails(string enableAgentAutoUpgrade = default(string))

        {
            this.EnableAgentAutoUpgrade = enableAgentAutoUpgrade;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets a value indicating whether the flag for enable agent auto upgrade.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "enableAgentAutoUpgrade")]
        public string EnableAgentAutoUpgrade {get; private set; }
    }
}