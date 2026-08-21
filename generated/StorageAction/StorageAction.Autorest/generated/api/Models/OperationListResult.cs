// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Runtime.Extensions;

    /// <summary>
    /// A list of REST API operations supported by an Azure Resource Provider. It contains an URL link to get the next set of
    /// results.
    /// </summary>
    public partial class OperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IOperationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IOperationListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IOperationListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IOperation> Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IOperationListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageAction.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IOperation> _value;

        /// <summary>The Operation items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageAction.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IOperation> Value { get => this._value; }

        /// <summary>Creates an new <see cref="OperationListResult" /> instance.</summary>
        public OperationListResult()
        {

        }
    }
    /// A list of REST API operations supported by an Azure Resource Provider. It contains an URL link to get the next set of
    /// results.
    public partial interface IOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Runtime.IJsonSerializable
    {
        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The link to the next page of items",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>The Operation items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The Operation items on this page",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IOperation) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IOperation> Value { get;  }

    }
    /// A list of REST API operations supported by an Azure Resource Provider. It contains an URL link to get the next set of
    /// results.
    internal partial interface IOperationListResultInternal

    {
        /// <summary>The link to the next page of items</summary>
        string NextLink { get; set; }
        /// <summary>The Operation items on this page</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IOperation> Value { get; set; }

    }
}