namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
    /// </summary>
    public partial class SkuCapability :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapabilityInternal
    {

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapabilityInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapabilityInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change
        /// notification, etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>
        /// A string value to indicate states of given capability. Possibly 'true' or 'false'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Value { get => this._value; }

        /// <summary>Creates an new <see cref="SkuCapability" /> instance.</summary>
        public SkuCapability()
        {

        }
    }
    /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
    public partial interface ISkuCapability :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change
        /// notification, etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>
        /// A string value to indicate states of given capability. Possibly 'true' or 'false'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A string value to indicate states of given capability. Possibly 'true' or 'false'.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get;  }

    }
    /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
    internal partial interface ISkuCapabilityInternal

    {
        /// <summary>
        /// The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change
        /// notification, etc.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// A string value to indicate states of given capability. Possibly 'true' or 'false'.
        /// </summary>
        string Value { get; set; }

    }
}