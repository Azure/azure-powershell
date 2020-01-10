namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Details of PrepareNetworkPolicies for Subnet.</summary>
    public partial class PrepareNetworkPoliciesRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPrepareNetworkPoliciesRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPrepareNetworkPoliciesRequestInternal
    {

        /// <summary>Backing field for <see cref="NetworkIntentPolicyConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration[] _networkIntentPolicyConfiguration;

        /// <summary>A list of NetworkIntentPolicyConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration[] NetworkIntentPolicyConfiguration { get => this._networkIntentPolicyConfiguration; set => this._networkIntentPolicyConfiguration = value; }

        /// <summary>Backing field for <see cref="ResourceGroupName" /> property.</summary>
        private string _resourceGroupName;

        /// <summary>The name of the resource group where the Network Intent Policy will be stored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => this._resourceGroupName; set => this._resourceGroupName = value; }

        /// <summary>Backing field for <see cref="ServiceName" /> property.</summary>
        private string _serviceName;

        /// <summary>The name of the service for which subnet is being prepared for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ServiceName { get => this._serviceName; set => this._serviceName = value; }

        /// <summary>Creates an new <see cref="PrepareNetworkPoliciesRequest" /> instance.</summary>
        public PrepareNetworkPoliciesRequest()
        {

        }
    }
    /// Details of PrepareNetworkPolicies for Subnet.
    public partial interface IPrepareNetworkPoliciesRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>A list of NetworkIntentPolicyConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of NetworkIntentPolicyConfiguration.",
        SerializedName = @"networkIntentPolicyConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration[] NetworkIntentPolicyConfiguration { get; set; }
        /// <summary>The name of the resource group where the Network Intent Policy will be stored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource group where the Network Intent Policy will be stored.",
        SerializedName = @"resourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGroupName { get; set; }
        /// <summary>The name of the service for which subnet is being prepared for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the service for which subnet is being prepared for.",
        SerializedName = @"serviceName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceName { get; set; }

    }
    /// Details of PrepareNetworkPolicies for Subnet.
    internal partial interface IPrepareNetworkPoliciesRequestInternal

    {
        /// <summary>A list of NetworkIntentPolicyConfiguration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration[] NetworkIntentPolicyConfiguration { get; set; }
        /// <summary>The name of the resource group where the Network Intent Policy will be stored.</summary>
        string ResourceGroupName { get; set; }
        /// <summary>The name of the service for which subnet is being prepared for.</summary>
        string ServiceName { get; set; }

    }
}