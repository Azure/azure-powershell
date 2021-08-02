namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Location capabilities.</summary>
    public partial class CapabilityProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.ICapabilityProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.ICapabilityPropertiesInternal
    {

        /// <summary>Internal Acessors for SupportedFlexibleServerEdition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerEditionCapability[] Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.ICapabilityPropertiesInternal.SupportedFlexibleServerEdition { get => this._supportedFlexibleServerEdition; set { {_supportedFlexibleServerEdition = value;} } }

        /// <summary>Internal Acessors for Zone</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.ICapabilityPropertiesInternal.Zone { get => this._zone; set { {_zone = value;} } }

        /// <summary>Backing field for <see cref="SupportedFlexibleServerEdition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerEditionCapability[] _supportedFlexibleServerEdition;

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerEditionCapability[] SupportedFlexibleServerEdition { get => this._supportedFlexibleServerEdition; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private string _zone;

        /// <summary>zone name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public string Zone { get => this._zone; }

        /// <summary>Creates an new <see cref="CapabilityProperties" /> instance.</summary>
        public CapabilityProperties()
        {

        }
    }
    /// Location capabilities.
    public partial interface ICapabilityProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"supportedFlexibleServerEditions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerEditionCapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerEditionCapability[] SupportedFlexibleServerEdition { get;  }
        /// <summary>zone name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"zone name",
        SerializedName = @"zone",
        PossibleTypes = new [] { typeof(string) })]
        string Zone { get;  }

    }
    /// Location capabilities.
    internal partial interface ICapabilityPropertiesInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerEditionCapability[] SupportedFlexibleServerEdition { get; set; }
        /// <summary>zone name</summary>
        string Zone { get; set; }

    }
}