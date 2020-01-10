namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ApplicationGatewayAvailableSslOptions API service call.</summary>
    public partial class ApplicationGatewayAvailableSslPredefinedPolicies :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAvailableSslPredefinedPolicies,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAvailableSslPredefinedPoliciesInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslPredefinedPolicy[] _value;

        /// <summary>List of available Ssl predefined policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslPredefinedPolicy[] Value { get => this._value; set => this._value = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayAvailableSslPredefinedPolicies" /> instance.
        /// </summary>
        public ApplicationGatewayAvailableSslPredefinedPolicies()
        {

        }
    }
    /// Response for ApplicationGatewayAvailableSslOptions API service call.
    public partial interface IApplicationGatewayAvailableSslPredefinedPolicies :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>List of available Ssl predefined policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of available Ssl predefined policy.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslPredefinedPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslPredefinedPolicy[] Value { get; set; }

    }
    /// Response for ApplicationGatewayAvailableSslOptions API service call.
    internal partial interface IApplicationGatewayAvailableSslPredefinedPoliciesInternal

    {
        /// <summary>URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>List of available Ssl predefined policy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslPredefinedPolicy[] Value { get; set; }

    }
}