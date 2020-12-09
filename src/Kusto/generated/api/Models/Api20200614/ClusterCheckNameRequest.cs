namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The result returned from a cluster check name availability request.</summary>
    public partial class ClusterCheckNameRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterCheckNameRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterCheckNameRequestInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Cluster name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type _type;

        /// <summary>The type of resource, Microsoft.Kusto/clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ClusterCheckNameRequest" /> instance.</summary>
        public ClusterCheckNameRequest()
        {

        }
    }
    /// The result returned from a cluster check name availability request.
    public partial interface IClusterCheckNameRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>Cluster name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Cluster name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.Kusto/clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of resource, Microsoft.Kusto/clusters.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type Type { get; set; }

    }
    /// The result returned from a cluster check name availability request.
    internal partial interface IClusterCheckNameRequestInternal

    {
        /// <summary>Cluster name.</summary>
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.Kusto/clusters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type Type { get; set; }

    }
}