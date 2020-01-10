namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Details of NetworkIntentPolicyConfiguration for PrepareNetworkPoliciesRequest.</summary>
    public partial class NetworkIntentPolicyConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal
    {

        /// <summary>Internal Acessors for SourceNetworkIntentPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicy Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal.SourceNetworkIntentPolicy { get => (this._sourceNetworkIntentPolicy = this._sourceNetworkIntentPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkIntentPolicy()); set { {_sourceNetworkIntentPolicy = value;} } }

        /// <summary>Internal Acessors for SourceNetworkIntentPolicyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal.SourceNetworkIntentPolicyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)SourceNetworkIntentPolicy).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)SourceNetworkIntentPolicy).Name = value; }

        /// <summary>Internal Acessors for SourceNetworkIntentPolicyType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal.SourceNetworkIntentPolicyType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)SourceNetworkIntentPolicy).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)SourceNetworkIntentPolicy).Type = value; }

        /// <summary>Backing field for <see cref="NetworkIntentPolicyName" /> property.</summary>
        private string _networkIntentPolicyName;

        /// <summary>The name of the Network Intent Policy for storing in target subscription.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NetworkIntentPolicyName { get => this._networkIntentPolicyName; set => this._networkIntentPolicyName = value; }

        /// <summary>Backing field for <see cref="SourceNetworkIntentPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicy _sourceNetworkIntentPolicy;

        /// <summary>Source network intent policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicy SourceNetworkIntentPolicy { get => (this._sourceNetworkIntentPolicy = this._sourceNetworkIntentPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkIntentPolicy()); set => this._sourceNetworkIntentPolicy = value; }

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SourceNetworkIntentPolicyEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyInternal)SourceNetworkIntentPolicy).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyInternal)SourceNetworkIntentPolicy).Etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SourceNetworkIntentPolicyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)SourceNetworkIntentPolicy).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)SourceNetworkIntentPolicy).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SourceNetworkIntentPolicyLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)SourceNetworkIntentPolicy).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)SourceNetworkIntentPolicy).Location = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SourceNetworkIntentPolicyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)SourceNetworkIntentPolicy).Name; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags SourceNetworkIntentPolicyTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)SourceNetworkIntentPolicy).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)SourceNetworkIntentPolicy).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SourceNetworkIntentPolicyType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)SourceNetworkIntentPolicy).Type; }

        /// <summary>Creates an new <see cref="NetworkIntentPolicyConfiguration" /> instance.</summary>
        public NetworkIntentPolicyConfiguration()
        {

        }
    }
    /// Details of NetworkIntentPolicyConfiguration for PrepareNetworkPoliciesRequest.
    public partial interface INetworkIntentPolicyConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The name of the Network Intent Policy for storing in target subscription.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Network Intent Policy for storing in target subscription.",
        SerializedName = @"networkIntentPolicyName",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkIntentPolicyName { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string SourceNetworkIntentPolicyEtag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string SourceNetworkIntentPolicyId { get; set; }
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string SourceNetworkIntentPolicyLocation { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SourceNetworkIntentPolicyName { get;  }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags SourceNetworkIntentPolicyTag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string SourceNetworkIntentPolicyType { get;  }

    }
    /// Details of NetworkIntentPolicyConfiguration for PrepareNetworkPoliciesRequest.
    internal partial interface INetworkIntentPolicyConfigurationInternal

    {
        /// <summary>The name of the Network Intent Policy for storing in target subscription.</summary>
        string NetworkIntentPolicyName { get; set; }
        /// <summary>Source network intent policy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicy SourceNetworkIntentPolicy { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string SourceNetworkIntentPolicyEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string SourceNetworkIntentPolicyId { get; set; }
        /// <summary>Resource location.</summary>
        string SourceNetworkIntentPolicyLocation { get; set; }
        /// <summary>Resource name.</summary>
        string SourceNetworkIntentPolicyName { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags SourceNetworkIntentPolicyTag { get; set; }
        /// <summary>Resource type.</summary>
        string SourceNetworkIntentPolicyType { get; set; }

    }
}