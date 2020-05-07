namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>An API key used for authenticating with a configuration store endpoint.</summary>
    public partial class ApiKey :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IApiKey,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IApiKeyInternal
    {

        /// <summary>Backing field for <see cref="ConnectionString" /> property.</summary>
        private string _connectionString;

        /// <summary>A connection string that can be used by supporting clients for authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string ConnectionString { get => this._connectionString; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The key ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="LastModified" /> property.</summary>
        private global::System.DateTime? _lastModified;

        /// <summary>The last time any of the key's properties were modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public global::System.DateTime? LastModified { get => this._lastModified; }

        /// <summary>Internal Acessors for ConnectionString</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IApiKeyInternal.ConnectionString { get => this._connectionString; set { {_connectionString = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IApiKeyInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for LastModified</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IApiKeyInternal.LastModified { get => this._lastModified; set { {_lastModified = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IApiKeyInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for ReadOnly</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IApiKeyInternal.ReadOnly { get => this._readOnly; set { {_readOnly = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IApiKeyInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>A name for the key describing its usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="ReadOnly" /> property.</summary>
        private bool? _readOnly;

        /// <summary>Whether this key can only be used for read operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public bool? ReadOnly { get => this._readOnly; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>The value of the key that is used for authentication purposes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Value { get => this._value; }

        /// <summary>Creates an new <see cref="ApiKey" /> instance.</summary>
        public ApiKey()
        {

        }
    }
    /// An API key used for authenticating with a configuration store endpoint.
    public partial interface IApiKey :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>A connection string that can be used by supporting clients for authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A connection string that can be used by supporting clients for authentication.",
        SerializedName = @"connectionString",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionString { get;  }
        /// <summary>The key ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The key ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The last time any of the key's properties were modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The last time any of the key's properties were modified.",
        SerializedName = @"lastModified",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastModified { get;  }
        /// <summary>A name for the key describing its usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A name for the key describing its usage.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Whether this key can only be used for read operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Whether this key can only be used for read operations.",
        SerializedName = @"readOnly",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ReadOnly { get;  }
        /// <summary>The value of the key that is used for authentication purposes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The value of the key that is used for authentication purposes.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get;  }

    }
    /// An API key used for authenticating with a configuration store endpoint.
    internal partial interface IApiKeyInternal

    {
        /// <summary>A connection string that can be used by supporting clients for authentication.</summary>
        string ConnectionString { get; set; }
        /// <summary>The key ID.</summary>
        string Id { get; set; }
        /// <summary>The last time any of the key's properties were modified.</summary>
        global::System.DateTime? LastModified { get; set; }
        /// <summary>A name for the key describing its usage.</summary>
        string Name { get; set; }
        /// <summary>Whether this key can only be used for read operations.</summary>
        bool? ReadOnly { get; set; }
        /// <summary>The value of the key that is used for authentication purposes.</summary>
        string Value { get; set; }

    }
}