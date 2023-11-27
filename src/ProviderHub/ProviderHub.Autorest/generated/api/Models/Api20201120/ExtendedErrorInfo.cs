namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ExtendedErrorInfo :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedErrorInfo,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedErrorInfoInternal
    {

        /// <summary>Backing field for <see cref="AdditionalInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITypedErrorInfo[] _additionalInfo;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITypedErrorInfo[] AdditionalInfo { get => this._additionalInfo; set => this._additionalInfo = value; }

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedErrorInfo[] _detail;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedErrorInfo[] Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private string _target;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Target { get => this._target; set => this._target = value; }

        /// <summary>Creates an new <see cref="ExtendedErrorInfo" /> instance.</summary>
        public ExtendedErrorInfo()
        {

        }
    }
    public partial interface IExtendedErrorInfo :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"additionalInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITypedErrorInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITypedErrorInfo[] AdditionalInfo { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedErrorInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedErrorInfo[] Detail { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get; set; }

    }
    internal partial interface IExtendedErrorInfoInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITypedErrorInfo[] AdditionalInfo { get; set; }

        string Code { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedErrorInfo[] Detail { get; set; }

        string Message { get; set; }

        string Target { get; set; }

    }
}