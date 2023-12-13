namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ServiceTreeInfo :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfoInternal
    {

        /// <summary>Backing field for <see cref="ComponentId" /> property.</summary>
        private string _componentId;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string ComponentId { get => this._componentId; set => this._componentId = value; }

        /// <summary>Backing field for <see cref="ServiceId" /> property.</summary>
        private string _serviceId;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string ServiceId { get => this._serviceId; set => this._serviceId = value; }

        /// <summary>Creates an new <see cref="ServiceTreeInfo" /> instance.</summary>
        public ServiceTreeInfo()
        {

        }
    }
    public partial interface IServiceTreeInfo :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"componentId",
        PossibleTypes = new [] { typeof(string) })]
        string ComponentId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"serviceId",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceId { get; set; }

    }
    internal partial interface IServiceTreeInfoInternal

    {
        string ComponentId { get; set; }

        string ServiceId { get; set; }

    }
}