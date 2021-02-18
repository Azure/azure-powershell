namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The comparison expression to be used in the query.</summary>
    public partial class QueryComparisonExpression :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryComparisonExpression,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryComparisonExpressionInternal
    {

        /// <summary>Internal Acessors for Operator</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryComparisonExpressionInternal.Operator { get => this._operator; set { {_operator = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the column to use in comparison.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Operator" /> property.</summary>
        private string _operator= @"In";

        /// <summary>The operator to use for comparison.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Operator { get => this._operator; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string[] _value;

        /// <summary>Array of values to use for comparison</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="QueryComparisonExpression" /> instance.</summary>
        public QueryComparisonExpression()
        {

        }
    }
    /// The comparison expression to be used in the query.
    public partial interface IQueryComparisonExpression :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The name of the column to use in comparison.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the column to use in comparison.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The operator to use for comparison.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The operator to use for comparison.",
        SerializedName = @"operator",
        PossibleTypes = new [] { typeof(string) })]
        string Operator { get;  }
        /// <summary>Array of values to use for comparison</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Array of values to use for comparison",
        SerializedName = @"values",
        PossibleTypes = new [] { typeof(string) })]
        string[] Value { get; set; }

    }
    /// The comparison expression to be used in the query.
    public partial interface IQueryComparisonExpressionInternal

    {
        /// <summary>The name of the column to use in comparison.</summary>
        string Name { get; set; }
        /// <summary>The operator to use for comparison.</summary>
        string Operator { get; set; }
        /// <summary>Array of values to use for comparison</summary>
        string[] Value { get; set; }

    }
}