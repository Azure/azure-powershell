namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>A principal assignment check name availability request.</summary>
    public partial class DatabasePrincipalAssignmentCheckNameRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabasePrincipalAssignmentCheckNameRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabasePrincipalAssignmentCheckNameRequestInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Principal Assignment resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type _type;

        /// <summary>The type of resource, Microsoft.Kusto/Clusters/Databases/principalAssignments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type Type { get => this._type; set => this._type = value; }

        /// <summary>
        /// Creates an new <see cref="DatabasePrincipalAssignmentCheckNameRequest" /> instance.
        /// </summary>
        public DatabasePrincipalAssignmentCheckNameRequest()
        {

        }
    }
    /// A principal assignment check name availability request.
    public partial interface IDatabasePrincipalAssignmentCheckNameRequest :
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
        /// <summary>The type of resource, Microsoft.Kusto/Clusters/Databases/principalAssignments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of resource, Microsoft.Kusto/Clusters/Databases/principalAssignments.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type Type { get; set; }

    }
    /// A principal assignment check name availability request.
    internal partial interface IDatabasePrincipalAssignmentCheckNameRequestInternal

    {
        /// <summary>Principal Assignment resource name.</summary>
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.Kusto/Clusters/Databases/principalAssignments.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type Type { get; set; }

    }
}