namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ExtendedLocationOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptionsInternal
    {

        /// <summary>Backing field for <see cref="SupportedPolicy" /> property.</summary>
        private string _supportedPolicy;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string SupportedPolicy { get => this._supportedPolicy; set => this._supportedPolicy = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ExtendedLocationOptions" /> instance.</summary>
        public ExtendedLocationOptions()
        {

        }
    }
    public partial interface IExtendedLocationOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"supportedPolicy",
        PossibleTypes = new [] { typeof(string) })]
        string SupportedPolicy { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    internal partial interface IExtendedLocationOptionsInternal

    {
        string SupportedPolicy { get; set; }

        string Type { get; set; }

    }
}