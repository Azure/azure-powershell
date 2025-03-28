// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    public partial class AgriculturePlatformIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriculturePlatformIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriculturePlatformIdentityInternal
    {

        /// <summary>Backing field for <see cref="AgriServiceResourceName" /> property.</summary>
        private string _agriServiceResourceName;

        /// <summary>The name of the AgriService resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string AgriServiceResourceName { get => this._agriServiceResourceName; set => this._agriServiceResourceName = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource identity path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="ResourceGroupName" /> property.</summary>
        private string _resourceGroupName;

        /// <summary>The name of the resource group. The name is case insensitive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => this._resourceGroupName; set => this._resourceGroupName = value; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string SubscriptionId { get => this._subscriptionId; set => this._subscriptionId = value; }

        /// <summary>Creates an new <see cref="AgriculturePlatformIdentity" /> instance.</summary>
        public AgriculturePlatformIdentity()
        {

        }
    }
    public partial interface IAgriculturePlatformIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IJsonSerializable
    {
        /// <summary>The name of the AgriService resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the AgriService resource.",
        SerializedName = @"agriServiceResourceName",
        PossibleTypes = new [] { typeof(string) })]
        string AgriServiceResourceName { get; set; }
        /// <summary>Resource identity path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource identity path",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The name of the resource group. The name is case insensitive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the resource group. The name is case insensitive.",
        SerializedName = @"resourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGroupName { get; set; }
        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ID of the target subscription. The value must be an UUID.",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        string SubscriptionId { get; set; }

    }
    internal partial interface IAgriculturePlatformIdentityInternal

    {
        /// <summary>The name of the AgriService resource.</summary>
        string AgriServiceResourceName { get; set; }
        /// <summary>Resource identity path</summary>
        string Id { get; set; }
        /// <summary>The name of the resource group. The name is case insensitive.</summary>
        string ResourceGroupName { get; set; }
        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        string SubscriptionId { get; set; }

    }
}