namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>A principal assignment check name availability request.</summary>
    public partial class ClusterPrincipalAssignmentCheckNameRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPrincipalAssignmentCheckNameRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPrincipalAssignmentCheckNameRequestInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Principal Assignment resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type _type;

        /// <summary>The type of resource, Microsoft.Kusto/Clusters/principalAssignments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type Type { get => this._type; set => this._type = value; }

        /// <summary>
        /// Creates an new <see cref="ClusterPrincipalAssignmentCheckNameRequest" /> instance.
        /// </summary>
        public ClusterPrincipalAssignmentCheckNameRequest()
        {

        }
    }
    /// A principal assignment check name availability request.
    public partial interface IClusterPrincipalAssignmentCheckNameRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>Principal Assignment resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Principal Assignment resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.Kusto/Clusters/principalAssignments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of resource, Microsoft.Kusto/Clusters/principalAssignments.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type Type { get; set; }

    }
    /// A principal assignment check name availability request.
    internal partial interface IClusterPrincipalAssignmentCheckNameRequestInternal

    {
        /// <summary>Principal Assignment resource name.</summary>
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.Kusto/Clusters/principalAssignments.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type Type { get; set; }

    }
}