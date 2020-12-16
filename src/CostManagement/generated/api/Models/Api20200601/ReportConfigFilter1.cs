namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The filter expression to be used in the report.</summary>
    public partial class ReportConfigFilter1 :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1Internal
    {

        /// <summary>Backing field for <see cref="And" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1[] _and;

        /// <summary>The logical "AND" expression. Must have at least 2 items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1[] And { get => this._and; set => this._and = value; }

        /// <summary>Backing field for <see cref="Dimension" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigComparisonExpression _dimension;

        /// <summary>Has comparison expression for a dimension</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigComparisonExpression Dimension { get => (this._dimension = this._dimension ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigComparisonExpression()); set => this._dimension = value; }

        /// <summary>Backing field for <see cref="Not" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1 _not;

        /// <summary>The logical "NOT" expression.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1 Not { get => (this._not = this._not ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigFilter1()); set => this._not = value; }

        /// <summary>Backing field for <see cref="Or" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1[] _or;

        /// <summary>The logical "OR" expression. Must have at least 2 items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1[] Or { get => this._or; set => this._or = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigComparisonExpression _tag;

        /// <summary>Has comparison expression for a tag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigComparisonExpression Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigComparisonExpression()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="ReportConfigFilter1" /> instance.</summary>
        public ReportConfigFilter1()
        {

        }
    }
    /// The filter expression to be used in the report.
    public partial interface IReportConfigFilter1 :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The logical "AND" expression. Must have at least 2 items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The logical ""AND"" expression. Must have at least 2 items.",
        SerializedName = @"and",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1[] And { get; set; }
        /// <summary>Has comparison expression for a dimension</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Has comparison expression for a dimension",
        SerializedName = @"dimension",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigComparisonExpression) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigComparisonExpression Dimension { get; set; }
        /// <summary>The logical "NOT" expression.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The logical ""NOT"" expression.",
        SerializedName = @"not",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1 Not { get; set; }
        /// <summary>The logical "OR" expression. Must have at least 2 items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The logical ""OR"" expression. Must have at least 2 items.",
        SerializedName = @"or",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1[] Or { get; set; }
        /// <summary>Has comparison expression for a tag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Has comparison expression for a tag",
        SerializedName = @"tag",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigComparisonExpression) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigComparisonExpression Tag { get; set; }

    }
    /// The filter expression to be used in the report.
    public partial interface IReportConfigFilter1Internal

    {
        /// <summary>The logical "AND" expression. Must have at least 2 items.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1[] And { get; set; }
        /// <summary>Has comparison expression for a dimension</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigComparisonExpression Dimension { get; set; }
        /// <summary>The logical "NOT" expression.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1 Not { get; set; }
        /// <summary>The logical "OR" expression. Must have at least 2 items.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter1[] Or { get; set; }
        /// <summary>Has comparison expression for a tag</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigComparisonExpression Tag { get; set; }

    }
}