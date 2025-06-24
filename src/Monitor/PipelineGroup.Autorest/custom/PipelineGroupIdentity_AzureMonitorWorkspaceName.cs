// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models
{
    public partial class PipelineGroupIdentity
    {
        /// <summary>Backing field for <see cref="AzureMonitorWorkspaceName" /> property.</summary>
        private string _azureMonitorWorkspaceName;

        /// <summary>The name of the Azure Monitor workspace. The name is case insensitive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Origin(Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.PropertyOrigin.Owned)]
        public string AzureMonitorWorkspaceName { get => this._azureMonitorWorkspaceName; set => this._azureMonitorWorkspaceName = value; }
    }

    public partial interface IPipelineGroupIdentity
    {
        /// <summary>The name of the Azure Monitor workspace. The name is case insensitive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the Azure Monitor workspace. The name is case insensitive.",
        SerializedName = @"azureMonitorWorkspaceName",
        PossibleTypes = new [] { typeof(string) })]
        string AzureMonitorWorkspaceName { get; set; }
    }

    internal partial interface IPipelineGroupIdentityInternal
    {
        /// <summary>The name of the Azure Monitor workspace. The name is case insensitive.</summary>
        string AzureMonitorWorkspaceName { get; set; }
    }
}