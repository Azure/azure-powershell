// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>MoboBroker resource.</summary>
    public partial class MoboBrokerResource :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResourceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>
        /// The fully qualified resource ID of the MoboBroker resource.
        /// Example: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}`
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResourceInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Creates an new <see cref="MoboBrokerResource" /> instance.</summary>
        public MoboBrokerResource()
        {

        }
    }
    /// MoboBroker resource.
    public partial interface IMoboBrokerResource :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The fully qualified resource ID of the MoboBroker resource.
        /// Example: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}`
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The fully qualified resource ID of the MoboBroker resource.
        Example: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}`",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }

    }
    /// MoboBroker resource.
    internal partial interface IMoboBrokerResourceInternal

    {
        /// <summary>
        /// The fully qualified resource ID of the MoboBroker resource.
        /// Example: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}`
        /// </summary>
        string Id { get; set; }

    }
}