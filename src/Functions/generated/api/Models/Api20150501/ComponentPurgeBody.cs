namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Describes the body of a purge request for an App Insights component</summary>
    public partial class ComponentPurgeBody :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBody,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyInternal
    {

        /// <summary>Backing field for <see cref="Filter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFilters[] _filter;

        /// <summary>
        /// The set of columns and filters (queries) to run over them to purge the resulting data.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFilters[] Filter { get => this._filter; set => this._filter = value; }

        /// <summary>Backing field for <see cref="Table" /> property.</summary>
        private string _table;

        /// <summary>Table from which to purge data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Table { get => this._table; set => this._table = value; }

        /// <summary>Creates an new <see cref="ComponentPurgeBody" /> instance.</summary>
        public ComponentPurgeBody()
        {

        }
    }
    /// Describes the body of a purge request for an App Insights component
    public partial interface IComponentPurgeBody :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The set of columns and filters (queries) to run over them to purge the resulting data.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The set of columns and filters (queries) to run over them to purge the resulting data.",
        SerializedName = @"filters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFilters) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFilters[] Filter { get; set; }
        /// <summary>Table from which to purge data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Table from which to purge data.",
        SerializedName = @"table",
        PossibleTypes = new [] { typeof(string) })]
        string Table { get; set; }

    }
    /// Describes the body of a purge request for an App Insights component
    internal partial interface IComponentPurgeBodyInternal

    {
        /// <summary>
        /// The set of columns and filters (queries) to run over them to purge the resulting data.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFilters[] Filter { get; set; }
        /// <summary>Table from which to purge data.</summary>
        string Table { get; set; }

    }
}