namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class SkuCapability :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapability,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapabilityInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="SkuCapability" /> instance.</summary>
        public SkuCapability()
        {

        }
    }
    public partial interface ISkuCapability :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    internal partial interface ISkuCapabilityInternal

    {
        string Name { get; set; }

        string Value { get; set; }

    }
}