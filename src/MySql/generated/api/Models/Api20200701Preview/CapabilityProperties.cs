namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Location capabilities.</summary>
    public partial class CapabilityProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ICapabilityProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ICapabilityPropertiesInternal
    {

        /// <summary>Internal Acessors for SupportedFlexibleServerEdition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerEditionCapability[] Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ICapabilityPropertiesInternal.SupportedFlexibleServerEdition { get => this._supportedFlexibleServerEdition; set { {_supportedFlexibleServerEdition = value;} } }

        /// <summary>Internal Acessors for Zone</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ICapabilityPropertiesInternal.Zone { get => this._zone; set { {_zone = value;} } }

        /// <summary>Backing field for <see cref="SupportedFlexibleServerEdition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerEditionCapability[] _supportedFlexibleServerEdition;

        /// <summary>A list of supported flexible server editions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerEditionCapability[] SupportedFlexibleServerEdition { get => this._supportedFlexibleServerEdition; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private string _zone;

        /// <summary>zone name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string Zone { get => this._zone; }

        /// <summary>Creates an new <see cref="CapabilityProperties" /> instance.</summary>
        public CapabilityProperties()
        {

        }
    }
    /// Location capabilities.
    public partial interface ICapabilityProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>A list of supported flexible server editions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of supported flexible server editions.",
        SerializedName = @"supportedFlexibleServerEditions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerEditionCapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerEditionCapability[] SupportedFlexibleServerEdition { get;  }
        /// <summary>zone name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
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
        /// <summary>A list of supported flexible server editions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerEditionCapability[] SupportedFlexibleServerEdition { get; set; }
        /// <summary>zone name</summary>
        string Zone { get; set; }

    }
}