namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The result returned from a database check name availability request.</summary>
    public partial class CheckNameRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ICheckNameRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ICheckNameRequestInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type _type;

        /// <summary>The type of resource, for instance Microsoft.Kusto/Clusters/databases.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="CheckNameRequest" /> instance.</summary>
        public CheckNameRequest()
        {

        }
    }
    /// The result returned from a database check name availability request.
    public partial interface ICheckNameRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The type of resource, for instance Microsoft.Kusto/Clusters/databases.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of resource, for instance Microsoft.Kusto/Clusters/databases.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type Type { get; set; }

    }
    /// The result returned from a database check name availability request.
    internal partial interface ICheckNameRequestInternal

    {
        /// <summary>Resource name.</summary>
        string Name { get; set; }
        /// <summary>The type of resource, for instance Microsoft.Kusto/Clusters/databases.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Type Type { get; set; }

    }
}