namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the resource to query the troubleshooting result.</summary>
    public partial class QueryTroubleshootingParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IQueryTroubleshootingParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IQueryTroubleshootingParametersInternal
    {

        /// <summary>Backing field for <see cref="TargetResourceId" /> property.</summary>
        private string _targetResourceId;

        /// <summary>The target resource ID to query the troubleshooting result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TargetResourceId { get => this._targetResourceId; set => this._targetResourceId = value; }

        /// <summary>Creates an new <see cref="QueryTroubleshootingParameters" /> instance.</summary>
        public QueryTroubleshootingParameters()
        {

        }
    }
    /// Parameters that define the resource to query the troubleshooting result.
    public partial interface IQueryTroubleshootingParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The target resource ID to query the troubleshooting result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The target resource ID to query the troubleshooting result.",
        SerializedName = @"targetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetResourceId { get; set; }

    }
    /// Parameters that define the resource to query the troubleshooting result.
    internal partial interface IQueryTroubleshootingParametersInternal

    {
        /// <summary>The target resource ID to query the troubleshooting result.</summary>
        string TargetResourceId { get; set; }

    }
}