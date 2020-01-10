namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Result of the request to list WebApplicationFirewallPolicies. It contains a list of WebApplicationFirewallPolicy objects
    /// and a URL link to get the next set of results.
    /// </summary>
    public partial class WebApplicationFirewallPolicyListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicy[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>
        /// URL to get the next set of WebApplicationFirewallPolicy objects if there are any.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicy[] _value;

        /// <summary>List of WebApplicationFirewallPolicies within a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicy[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="WebApplicationFirewallPolicyListResult" /> instance.</summary>
        public WebApplicationFirewallPolicyListResult()
        {

        }
    }
    /// Result of the request to list WebApplicationFirewallPolicies. It contains a list of WebApplicationFirewallPolicy objects
    /// and a URL link to get the next set of results.
    public partial interface IWebApplicationFirewallPolicyListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// URL to get the next set of WebApplicationFirewallPolicy objects if there are any.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL to get the next set of WebApplicationFirewallPolicy objects if there are any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>List of WebApplicationFirewallPolicies within a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of WebApplicationFirewallPolicies within a resource group.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicy[] Value { get;  }

    }
    /// Result of the request to list WebApplicationFirewallPolicies. It contains a list of WebApplicationFirewallPolicy objects
    /// and a URL link to get the next set of results.
    internal partial interface IWebApplicationFirewallPolicyListResultInternal

    {
        /// <summary>
        /// URL to get the next set of WebApplicationFirewallPolicy objects if there are any.
        /// </summary>
        string NextLink { get; set; }
        /// <summary>List of WebApplicationFirewallPolicies within a resource group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicy[] Value { get; set; }

    }
}