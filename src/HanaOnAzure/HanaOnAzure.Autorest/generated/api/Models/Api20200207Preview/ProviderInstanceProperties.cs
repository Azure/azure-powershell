namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Describes the properties of a provider instance.</summary>
    public partial class ProviderInstanceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstanceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstancePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private string _metadata;

        /// <summary>A JSON string containing metadata of the provider instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Metadata { get => this._metadata; set => this._metadata = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstancePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private string _property;

        /// <summary>A JSON string containing the properties of the provider instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Property { get => this._property; set => this._property = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? _provisioningState;

        /// <summary>State of provisioning of the provider instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of provider instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ProviderInstanceProperties" /> instance.</summary>
        public ProviderInstanceProperties()
        {

        }
    }
    /// Describes the properties of a provider instance.
    public partial interface IProviderInstanceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>A JSON string containing metadata of the provider instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A JSON string containing metadata of the provider instance.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(string) })]
        string Metadata { get; set; }
        /// <summary>A JSON string containing the properties of the provider instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A JSON string containing the properties of the provider instance.",
        SerializedName = @"properties",
        PossibleTypes = new [] { typeof(string) })]
        string Property { get; set; }
        /// <summary>State of provisioning of the provider instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of provisioning of the provider instance",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? ProvisioningState { get;  }
        /// <summary>The type of provider instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of provider instance.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Describes the properties of a provider instance.
    internal partial interface IProviderInstancePropertiesInternal

    {
        /// <summary>A JSON string containing metadata of the provider instance.</summary>
        string Metadata { get; set; }
        /// <summary>A JSON string containing the properties of the provider instance.</summary>
        string Property { get; set; }
        /// <summary>State of provisioning of the provider instance</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? ProvisioningState { get; set; }
        /// <summary>The type of provider instance.</summary>
        string Type { get; set; }

    }
}