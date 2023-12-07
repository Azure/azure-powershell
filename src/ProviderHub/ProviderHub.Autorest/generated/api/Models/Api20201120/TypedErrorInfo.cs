namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class TypedErrorInfo :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITypedErrorInfo,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITypedErrorInfoInternal
    {

        /// <summary>Backing field for <see cref="Info" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny _info;

        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Info { get => (this._info = this._info ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Any()); }

        /// <summary>Internal Acessors for Info</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITypedErrorInfoInternal.Info { get => (this._info = this._info ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Any()); set { {_info = value;} } }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="TypedErrorInfo" /> instance.</summary>
        public TypedErrorInfo()
        {

        }
    }
    public partial interface ITypedErrorInfo :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Any object",
        SerializedName = @"info",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Info { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    internal partial interface ITypedErrorInfoInternal

    {
        /// <summary>Any object</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Info { get; set; }

        string Type { get; set; }

    }
}