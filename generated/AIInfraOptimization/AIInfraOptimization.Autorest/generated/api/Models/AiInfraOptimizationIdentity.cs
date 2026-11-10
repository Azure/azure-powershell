// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    public partial class AiInfraOptimizationIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IAiInfraOptimizationIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IAiInfraOptimizationIdentityInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource identity path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The name of the Azure region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string SubscriptionId { get => this._subscriptionId; set => this._subscriptionId = value; }

        /// <summary>Creates an new <see cref="AiInfraOptimizationIdentity" /> instance.</summary>
        public AiInfraOptimizationIdentity()
        {

        }
    }
    public partial interface IAiInfraOptimizationIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>Resource identity path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource identity path",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The name of the Azure region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the Azure region.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
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
    internal partial interface IAiInfraOptimizationIdentityInternal

    {
        /// <summary>Resource identity path</summary>
        string Id { get; set; }
        /// <summary>The name of the Azure region.</summary>
        string Location { get; set; }
        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        string SubscriptionId { get; set; }

    }
}