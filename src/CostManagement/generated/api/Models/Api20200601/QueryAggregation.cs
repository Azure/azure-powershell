namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The aggregation expression to be used in the query.</summary>
    public partial class QueryAggregation :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregationInternal
    {

        /// <summary>Backing field for <see cref="Function" /> property.</summary>
        private string _function= @"Sum";

        /// <summary>The name of the aggregation function to use.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Function { get => this._function; }

        /// <summary>Internal Acessors for Function</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregationInternal.Function { get => this._function; set { {_function = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the column to aggregate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="QueryAggregation" /> instance.</summary>
        public QueryAggregation()
        {

        }
    }
    /// The aggregation expression to be used in the query.
    public partial interface IQueryAggregation :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The name of the aggregation function to use.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The name of the aggregation function to use.",
        SerializedName = @"function",
        PossibleTypes = new [] { typeof(string) })]
        string Function { get;  }
        /// <summary>The name of the column to aggregate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the column to aggregate.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// The aggregation expression to be used in the query.
    public partial interface IQueryAggregationInternal

    {
        /// <summary>The name of the aggregation function to use.</summary>
        string Function { get; set; }
        /// <summary>The name of the column to aggregate.</summary>
        string Name { get; set; }

    }
}