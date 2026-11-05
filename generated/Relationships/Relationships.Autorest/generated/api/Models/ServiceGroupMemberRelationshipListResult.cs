// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Extensions;

    /// <summary>The response of a ServiceGroupMemberRelationship list operation.</summary>
    public partial class ServiceGroupMemberRelationshipListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationship> _value;

        /// <summary>The ServiceGroupMemberRelationship items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationship> Value { get => this._value; set => this._value = value; }

        /// <summary>
        /// Creates an new <see cref="ServiceGroupMemberRelationshipListResult" /> instance.
        /// </summary>
        public ServiceGroupMemberRelationshipListResult()
        {

        }
    }
    /// The response of a ServiceGroupMemberRelationship list operation.
    public partial interface IServiceGroupMemberRelationshipListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.IJsonSerializable
    {
        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The link to the next page of items",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The ServiceGroupMemberRelationship items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ServiceGroupMemberRelationship items on this page",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationship) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationship> Value { get; set; }

    }
    /// The response of a ServiceGroupMemberRelationship list operation.
    internal partial interface IServiceGroupMemberRelationshipListResultInternal

    {
        /// <summary>The link to the next page of items</summary>
        string NextLink { get; set; }
        /// <summary>The ServiceGroupMemberRelationship items on this page</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationship> Value { get; set; }

    }
}