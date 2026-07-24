// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    public partial class DiscoveryIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal
    {

        /// <summary>Backing field for <see cref="BookshelfName" /> property.</summary>
        private string _bookshelfName;

        /// <summary>The name of the Bookshelf</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string BookshelfName { get => this._bookshelfName; set => this._bookshelfName = value; }

        /// <summary>Backing field for <see cref="ChatModelDeploymentName" /> property.</summary>
        private string _chatModelDeploymentName;

        /// <summary>The name of the ChatModelDeployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ChatModelDeploymentName { get => this._chatModelDeploymentName; set => this._chatModelDeploymentName = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource identity path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="NodePoolName" /> property.</summary>
        private string _nodePoolName;

        /// <summary>The name of the NodePool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string NodePoolName { get => this._nodePoolName; set => this._nodePoolName = value; }

        /// <summary>Backing field for <see cref="PrivateEndpointConnectionName" /> property.</summary>
        private string _privateEndpointConnectionName;

        /// <summary>The name of the private endpoint connection associated with the Azure resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string PrivateEndpointConnectionName { get => this._privateEndpointConnectionName; set => this._privateEndpointConnectionName = value; }

        /// <summary>Backing field for <see cref="PrivateLinkResourceName" /> property.</summary>
        private string _privateLinkResourceName;

        /// <summary>The name of the private link associated with the Azure resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string PrivateLinkResourceName { get => this._privateLinkResourceName; set => this._privateLinkResourceName = value; }

        /// <summary>Backing field for <see cref="ProjectName" /> property.</summary>
        private string _projectName;

        /// <summary>The name of the Project</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ProjectName { get => this._projectName; set => this._projectName = value; }

        /// <summary>Backing field for <see cref="ResourceGroupName" /> property.</summary>
        private string _resourceGroupName;

        /// <summary>The name of the resource group. The name is case insensitive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => this._resourceGroupName; set => this._resourceGroupName = value; }

        /// <summary>Backing field for <see cref="StorageAssetName" /> property.</summary>
        private string _storageAssetName;

        /// <summary>The name of the StorageAsset</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string StorageAssetName { get => this._storageAssetName; set => this._storageAssetName = value; }

        /// <summary>Backing field for <see cref="StorageContainerName" /> property.</summary>
        private string _storageContainerName;

        /// <summary>The name of the StorageContainer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string StorageContainerName { get => this._storageContainerName; set => this._storageContainerName = value; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string SubscriptionId { get => this._subscriptionId; set => this._subscriptionId = value; }

        /// <summary>Backing field for <see cref="SupercomputerName" /> property.</summary>
        private string _supercomputerName;

        /// <summary>The name of the Supercomputer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string SupercomputerName { get => this._supercomputerName; set => this._supercomputerName = value; }

        /// <summary>Backing field for <see cref="ToolName" /> property.</summary>
        private string _toolName;

        /// <summary>The name of the Tool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ToolName { get => this._toolName; set => this._toolName = value; }

        /// <summary>Backing field for <see cref="WorkspaceName" /> property.</summary>
        private string _workspaceName;

        /// <summary>The name of the Workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string WorkspaceName { get => this._workspaceName; set => this._workspaceName = value; }

        /// <summary>Creates an new <see cref="DiscoveryIdentity" /> instance.</summary>
        public DiscoveryIdentity()
        {

        }
    }
    public partial interface IDiscoveryIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>The name of the Bookshelf</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the Bookshelf",
        SerializedName = @"bookshelfName",
        PossibleTypes = new [] { typeof(string) })]
        string BookshelfName { get; set; }
        /// <summary>The name of the ChatModelDeployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the ChatModelDeployment",
        SerializedName = @"chatModelDeploymentName",
        PossibleTypes = new [] { typeof(string) })]
        string ChatModelDeploymentName { get; set; }
        /// <summary>Resource identity path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource identity path",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The name of the NodePool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the NodePool",
        SerializedName = @"nodePoolName",
        PossibleTypes = new [] { typeof(string) })]
        string NodePoolName { get; set; }
        /// <summary>The name of the private endpoint connection associated with the Azure resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the private endpoint connection associated with the Azure resource.",
        SerializedName = @"privateEndpointConnectionName",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateEndpointConnectionName { get; set; }
        /// <summary>The name of the private link associated with the Azure resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the private link associated with the Azure resource.",
        SerializedName = @"privateLinkResourceName",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkResourceName { get; set; }
        /// <summary>The name of the Project</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the Project",
        SerializedName = @"projectName",
        PossibleTypes = new [] { typeof(string) })]
        string ProjectName { get; set; }
        /// <summary>The name of the resource group. The name is case insensitive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the resource group. The name is case insensitive.",
        SerializedName = @"resourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGroupName { get; set; }
        /// <summary>The name of the StorageAsset</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the StorageAsset",
        SerializedName = @"storageAssetName",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAssetName { get; set; }
        /// <summary>The name of the StorageContainer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the StorageContainer",
        SerializedName = @"storageContainerName",
        PossibleTypes = new [] { typeof(string) })]
        string StorageContainerName { get; set; }
        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ID of the target subscription. The value must be an UUID.",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        string SubscriptionId { get; set; }
        /// <summary>The name of the Supercomputer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the Supercomputer",
        SerializedName = @"supercomputerName",
        PossibleTypes = new [] { typeof(string) })]
        string SupercomputerName { get; set; }
        /// <summary>The name of the Tool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the Tool",
        SerializedName = @"toolName",
        PossibleTypes = new [] { typeof(string) })]
        string ToolName { get; set; }
        /// <summary>The name of the Workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the Workspace",
        SerializedName = @"workspaceName",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceName { get; set; }

    }
    internal partial interface IDiscoveryIdentityInternal

    {
        /// <summary>The name of the Bookshelf</summary>
        string BookshelfName { get; set; }
        /// <summary>The name of the ChatModelDeployment</summary>
        string ChatModelDeploymentName { get; set; }
        /// <summary>Resource identity path</summary>
        string Id { get; set; }
        /// <summary>The name of the NodePool</summary>
        string NodePoolName { get; set; }
        /// <summary>The name of the private endpoint connection associated with the Azure resource.</summary>
        string PrivateEndpointConnectionName { get; set; }
        /// <summary>The name of the private link associated with the Azure resource.</summary>
        string PrivateLinkResourceName { get; set; }
        /// <summary>The name of the Project</summary>
        string ProjectName { get; set; }
        /// <summary>The name of the resource group. The name is case insensitive.</summary>
        string ResourceGroupName { get; set; }
        /// <summary>The name of the StorageAsset</summary>
        string StorageAssetName { get; set; }
        /// <summary>The name of the StorageContainer</summary>
        string StorageContainerName { get; set; }
        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        string SubscriptionId { get; set; }
        /// <summary>The name of the Supercomputer</summary>
        string SupercomputerName { get; set; }
        /// <summary>The name of the Tool</summary>
        string ToolName { get; set; }
        /// <summary>The name of the Workspace</summary>
        string WorkspaceName { get; set; }

    }
}