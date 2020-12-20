namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The group by expression to be used in the query.</summary>
    public partial class QueryGrouping :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryGrouping,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryGroupingInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the column to group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.QueryColumnType _type;

        /// <summary>Has type of the column to group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.QueryColumnType Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="QueryGrouping" /> instance.</summary>
        public QueryGrouping()
        {

        }
    }
    /// The group by expression to be used in the query.
    public partial interface IQueryGrouping :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The name of the column to group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the column to group.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Has type of the column to group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Has type of the column to group.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.QueryColumnType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.QueryColumnType Type { get; set; }

    }
    /// The group by expression to be used in the query.
    public partial interface IQueryGroupingInternal

    {
        /// <summary>The name of the column to group.</summary>
        string Name { get; set; }
        /// <summary>Has type of the column to group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.QueryColumnType Type { get; set; }

    }
}