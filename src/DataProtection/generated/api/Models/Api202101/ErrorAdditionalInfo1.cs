namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>The resource management error additional info.</summary>
    public partial class ErrorAdditionalInfo1 :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo1,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo1Internal
    {

        /// <summary>Backing field for <see cref="Info" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo2 _info;

        /// <summary>The additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo2 Info { get => (this._info = this._info ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ErrorAdditionalInfo2()); }

        /// <summary>Internal Acessors for Info</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo2 Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo1Internal.Info { get => (this._info = this._info ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ErrorAdditionalInfo2()); set { {_info = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo1Internal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The additional info type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="ErrorAdditionalInfo1" /> instance.</summary>
        public ErrorAdditionalInfo1()
        {

        }
    }
    /// The resource management error additional info.
    public partial interface IErrorAdditionalInfo1 :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>The additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The additional info.",
        SerializedName = @"info",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo2) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo2 Info { get;  }
        /// <summary>The additional info type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The additional info type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// The resource management error additional info.
    internal partial interface IErrorAdditionalInfo1Internal

    {
        /// <summary>The additional info.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo2 Info { get; set; }
        /// <summary>The additional info type.</summary>
        string Type { get; set; }

    }
}