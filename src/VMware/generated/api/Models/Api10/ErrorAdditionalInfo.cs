namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>The resource management error additional info.</summary>
    public partial class ErrorAdditionalInfo :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfo,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfoInternal
    {

        /// <summary>Backing field for <see cref="Info" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IAny _info;

        /// <summary>The additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IAny Info { get => (this._info = this._info ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Any()); }

        /// <summary>Internal Acessors for Info</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IAny Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfoInternal.Info { get => (this._info = this._info ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Any()); set { {_info = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfoInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The additional info type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="ErrorAdditionalInfo" /> instance.</summary>
        public ErrorAdditionalInfo()
        {

        }
    }
    /// The resource management error additional info.
    public partial interface IErrorAdditionalInfo :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>The additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The additional info.",
        SerializedName = @"info",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IAny Info { get;  }
        /// <summary>The additional info type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The additional info type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// The resource management error additional info.
    internal partial interface IErrorAdditionalInfoInternal

    {
        /// <summary>The additional info.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IAny Info { get; set; }
        /// <summary>The additional info type.</summary>
        string Type { get; set; }

    }
}