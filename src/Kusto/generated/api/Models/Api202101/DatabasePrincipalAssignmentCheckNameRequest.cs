namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>A principal assignment check name availability request.</summary>
    public partial class DatabasePrincipalAssignmentCheckNameRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IDatabasePrincipalAssignmentCheckNameRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IDatabasePrincipalAssignmentCheckNameRequestInternal
    {

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IDatabasePrincipalAssignmentCheckNameRequestInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Principal Assignment resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type= @"Microsoft.Kusto/Clusters/Databases/principalAssignments";

        /// <summary>The type of resource, Microsoft.Kusto/Clusters/Databases/principalAssignments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

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
        ReadOnly = true,
        Description = @"The type of resource, Microsoft.Kusto/Clusters/Databases/principalAssignments.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// A principal assignment check name availability request.
    internal partial interface IDatabasePrincipalAssignmentCheckNameRequestInternal

    {
        /// <summary>Principal Assignment resource name.</summary>
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.Kusto/Clusters/Databases/principalAssignments.</summary>
        string Type { get; set; }

    }
}