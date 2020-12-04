namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Server version capabilities.</summary>
    public partial class ServerVersionCapability :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerVersionCapability,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerVersionCapabilityInternal
    {

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerVersionCapabilityInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for SupportedVcore</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IVcoreCapability[] Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerVersionCapabilityInternal.SupportedVcore { get => this._supportedVcore; set { {_supportedVcore = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>server version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="SupportedVcore" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IVcoreCapability[] _supportedVcore;

        /// <summary>A list of supported Vcores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IVcoreCapability[] SupportedVcore { get => this._supportedVcore; }

        /// <summary>Creates an new <see cref="ServerVersionCapability" /> instance.</summary>
        public ServerVersionCapability()
        {

        }
    }
    /// Server version capabilities.
    public partial interface IServerVersionCapability :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>server version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"server version",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>A list of supported Vcores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of supported Vcores",
        SerializedName = @"supportedVcores",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IVcoreCapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IVcoreCapability[] SupportedVcore { get;  }

    }
    /// Server version capabilities.
    internal partial interface IServerVersionCapabilityInternal

    {
        /// <summary>server version</summary>
        string Name { get; set; }
        /// <summary>A list of supported Vcores</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IVcoreCapability[] SupportedVcore { get; set; }

    }
}