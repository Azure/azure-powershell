// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The response of a Artifact list operation.</summary>
    public partial class ArtifactListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactListResult,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact> _value;

        /// <summary>The Artifact items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact> Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ArtifactListResult" /> instance.</summary>
        public ArtifactListResult()
        {

        }
    }
    /// The response of a Artifact list operation.
    public partial interface IArtifactListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The link to the next page of items",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The Artifact items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Artifact items on this page",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact> Value { get; set; }

    }
    /// The response of a Artifact list operation.
    internal partial interface IArtifactListResultInternal

    {
        /// <summary>The link to the next page of items</summary>
        string NextLink { get; set; }
        /// <summary>The Artifact items on this page</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact> Value { get; set; }

    }
}