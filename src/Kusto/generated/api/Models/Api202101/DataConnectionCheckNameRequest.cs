namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>A data connection check name availability request.</summary>
    public partial class DataConnectionCheckNameRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IDataConnectionCheckNameRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IDataConnectionCheckNameRequestInternal
    {

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IDataConnectionCheckNameRequestInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Data Connection name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type= @"Microsoft.Kusto/Clusters/Databases/dataConnections";

        /// <summary>The type of resource, Microsoft.Kusto/Clusters/Databases/dataConnections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="DataConnectionCheckNameRequest" /> instance.</summary>
        public DataConnectionCheckNameRequest()
        {

        }
    }
    /// A data connection check name availability request.
    public partial interface IDataConnectionCheckNameRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>Data Connection name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Data Connection name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.Kusto/Clusters/Databases/dataConnections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The type of resource, Microsoft.Kusto/Clusters/Databases/dataConnections.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// A data connection check name availability request.
    internal partial interface IDataConnectionCheckNameRequestInternal

    {
        /// <summary>Data Connection name.</summary>
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.Kusto/Clusters/Databases/dataConnections.</summary>
        string Type { get; set; }

    }
}