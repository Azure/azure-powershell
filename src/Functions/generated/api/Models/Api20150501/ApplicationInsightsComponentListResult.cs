namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Describes the list of Application Insights Resources.</summary>
    public partial class ApplicationInsightsComponentListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>
        /// The URI to get the next set of Application Insights component definitions if too many components where returned in the
        /// result set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent[] _value;

        /// <summary>List of Application Insights component definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ApplicationInsightsComponentListResult" /> instance.</summary>
        public ApplicationInsightsComponentListResult()
        {

        }
    }
    /// Describes the list of Application Insights Resources.
    public partial interface IApplicationInsightsComponentListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The URI to get the next set of Application Insights component definitions if too many components where returned in the
        /// result set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI to get the next set of Application Insights component definitions if too many components where returned in the result set.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>List of Application Insights component definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"List of Application Insights component definitions.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent[] Value { get; set; }

    }
    /// Describes the list of Application Insights Resources.
    internal partial interface IApplicationInsightsComponentListResultInternal

    {
        /// <summary>
        /// The URI to get the next set of Application Insights component definitions if too many components where returned in the
        /// result set.
        /// </summary>
        string NextLink { get; set; }
        /// <summary>List of Application Insights component definitions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent[] Value { get; set; }

    }
}