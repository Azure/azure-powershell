namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    public partial class AvailableRuntimeVersions :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAvailableRuntimeVersions,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAvailableRuntimeVersionsInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISupportedRuntimeVersion[] Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAvailableRuntimeVersionsInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISupportedRuntimeVersion[] _value;

        /// <summary>A list of all supported runtime versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISupportedRuntimeVersion[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="AvailableRuntimeVersions" /> instance.</summary>
        public AvailableRuntimeVersions()
        {

        }
    }
    public partial interface IAvailableRuntimeVersions :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>A list of all supported runtime versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of all supported runtime versions.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISupportedRuntimeVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISupportedRuntimeVersion[] Value { get;  }

    }
    public partial interface IAvailableRuntimeVersionsInternal

    {
        /// <summary>A list of all supported runtime versions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISupportedRuntimeVersion[] Value { get; set; }

    }
}