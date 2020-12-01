namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Properties for a key execution.</summary>
    public partial class ServerKeyProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKeyProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKeyPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreationDate" /> property.</summary>
        private global::System.DateTime? _creationDate;

        /// <summary>The key creation date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public global::System.DateTime? CreationDate { get => this._creationDate; }

        /// <summary>Internal Acessors for CreationDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKeyPropertiesInternal.CreationDate { get => this._creationDate; set { {_creationDate = value;} } }

        /// <summary>Internal Acessors for ServerKeyType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKeyPropertiesInternal.ServerKeyType { get => this._serverKeyType; set { {_serverKeyType = value;} } }

        /// <summary>Backing field for <see cref="ServerKeyType" /> property.</summary>
        private string _serverKeyType= @"AzureKeyVault";

        /// <summary>The key type like 'AzureKeyVault'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string ServerKeyType { get => this._serverKeyType; }

        /// <summary>Backing field for <see cref="Uri" /> property.</summary>
        private string _uri;

        /// <summary>The URI of the key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string Uri { get => this._uri; set => this._uri = value; }

        /// <summary>Creates an new <see cref="ServerKeyProperties" /> instance.</summary>
        public ServerKeyProperties()
        {

        }
    }
    /// Properties for a key execution.
    public partial interface IServerKeyProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>The key creation date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The key creation date.",
        SerializedName = @"creationDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreationDate { get;  }
        /// <summary>The key type like 'AzureKeyVault'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The key type like 'AzureKeyVault'.",
        SerializedName = @"serverKeyType",
        PossibleTypes = new [] { typeof(string) })]
        string ServerKeyType { get;  }
        /// <summary>The URI of the key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI of the key.",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string Uri { get; set; }

    }
    /// Properties for a key execution.
    internal partial interface IServerKeyPropertiesInternal

    {
        /// <summary>The key creation date.</summary>
        global::System.DateTime? CreationDate { get; set; }
        /// <summary>The key type like 'AzureKeyVault'.</summary>
        string ServerKeyType { get; set; }
        /// <summary>The URI of the key.</summary>
        string Uri { get; set; }

    }
}