namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class SkuZoneDetail :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuZoneDetail,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuZoneDetailInternal
    {

        /// <summary>Backing field for <see cref="Capability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapability[] _capability;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapability[] Capability { get => this._capability; set => this._capability = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string[] _name;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="SkuZoneDetail" /> instance.</summary>
        public SkuZoneDetail()
        {

        }
    }
    public partial interface ISkuZoneDetail :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapability[] Capability { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string[] Name { get; set; }

    }
    internal partial interface ISkuZoneDetailInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapability[] Capability { get; set; }

        string[] Name { get; set; }

    }
}