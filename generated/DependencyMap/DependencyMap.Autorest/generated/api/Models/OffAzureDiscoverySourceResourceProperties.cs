// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Extensions;

    /// <summary>OffAzure discovery source resource properties</summary>
    public partial class OffAzureDiscoverySourceResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IOffAzureDiscoverySourceResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IOffAzureDiscoverySourceResourcePropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourceProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourceProperties __discoverySourceResourceProperties = new Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.DiscoverySourceResourceProperties();

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal)__discoverySourceResourceProperties).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal)__discoverySourceResourceProperties).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for SourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal.SourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal)__discoverySourceResourceProperties).SourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal)__discoverySourceResourceProperties).SourceType = value ?? null; }

        /// <summary>Provisioning state of Discovery Source resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inherited)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal)__discoverySourceResourceProperties).ProvisioningState; }

        /// <summary>Source ArmId of Discovery Source resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inherited)]
        public string SourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal)__discoverySourceResourceProperties).SourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal)__discoverySourceResourceProperties).SourceId = value ?? null; }

        /// <summary>Source type of Discovery Source resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Constant]
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inherited)]
        public string SourceType { get => "OffAzure"; }

        /// <summary>
        /// Creates an new <see cref="OffAzureDiscoverySourceResourceProperties" /> instance.
        /// </summary>
        public OffAzureDiscoverySourceResourceProperties()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__discoverySourceResourceProperties), __discoverySourceResourceProperties);
            await eventListener.AssertObjectIsValid(nameof(__discoverySourceResourceProperties), __discoverySourceResourceProperties);
        }
    }
    /// OffAzure discovery source resource properties
    public partial interface IOffAzureDiscoverySourceResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourceProperties
    {

    }
    /// OffAzure discovery source resource properties
    internal partial interface IOffAzureDiscoverySourceResourcePropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal
    {

    }
}