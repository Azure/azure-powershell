// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    public partial class PolicyIdentity
    {
        /// <summary>Backing field for <see cref="PolicyAssignmentId" /> property.</summary>
        private string _policyAssignmentId;

        /// <summary>
        /// The ID of the policy assignment. Restored for backward compatibility: this identity
        /// property existed in the pre-migration surface and was dropped when the policy cmdlets
        /// were migrated to TypeSpec generation. It is re-exposed here so existing scripts that set
        /// the policy assignment ID on an <see cref="IPolicyIdentity"/> continue to compile and run.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyAssignmentId { get => this._policyAssignmentId; set => this._policyAssignmentId = value; }
    }

    public partial interface IPolicyIdentity
    {
        /// <summary>
        /// The ID of the policy assignment. Restored to the pre-migration identity surface
        /// (previously removed during the TypeSpec migration).
        /// </summary>
        string PolicyAssignmentId { get; set; }
    }
}
