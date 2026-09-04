# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Restore a mongo cluster to a new cluster from a point in time.
.Description
Restore a mongo cluster to a new cluster from a point in time. Creates a new mongo cluster
from the backup of an existing (or deleted) source cluster at the requested point in time.
.Example
Restore-AzDocumentDBMongoCluster -Name RestoredCluster -ResourceGroupName MyResourceGroup -Location eastus2 -SourceCluster MySourceCluster -RestoreTime "2026-06-30T10:00:00Z" -AdministratorUserName dbadmin -AdministratorPassword (ConvertTo-SecureString "MyP@ssw0rd123!" -AsPlainText -Force)
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster
.Link
https://learn.microsoft.com/powershell/module/az.documentdb/restore-azdocumentdbmongocluster
#>
function Restore-AzDocumentDBMongoCluster {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('MongoClusterName')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Path')]
    [System.String]
    # The name of the mongo cluster to create from the restore.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Body')]
    [System.String]
    # The geo-location where the restored cluster lives.
    ${Location},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Body')]
    [System.String]
    # Name or resource ID of the source mongo cluster to restore from.
    # If a name is given, the current subscription and resource group are assumed.
    ${SourceCluster},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Body')]
    [System.DateTime]
    # UTC point in time to restore from.
    ${RestoreTime},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Body')]
    [System.String]
    # The administrator user name of the restored cluster.
    ${AdministratorUserName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Body')]
    [System.Security.SecureString]
    # The administrator password of the restored cluster.
    ${AdministratorPassword},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The DefaultProfile parameter is not functional.
    # Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job.
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach.
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline.
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline.
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously.
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use.
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call.
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy.
    ${ProxyUseDefaultCredentials}
)

    process {
        try {
            if (-not $PSBoundParameters.ContainsKey('SubscriptionId')) {
                $SubscriptionId = (Get-AzContext).Subscription.Id
            }

            # Resolve the source cluster to a full ARM resource ID. A bare name assumes the
            # current subscription and resource group.
            if ($SourceCluster -match '^/subscriptions/') {
                $sourceId = $SourceCluster
            } else {
                $sourceId = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.DocumentDB/mongoClusters/$SourceCluster"
            }

            $null = $PSBoundParameters.Remove('SourceCluster')
            $null = $PSBoundParameters.Remove('RestoreTime')
            foreach ($commonParam in 'WhatIf', 'Confirm') { $null = $PSBoundParameters.Remove($commonParam) }
            $PSBoundParameters['SubscriptionId'] = $SubscriptionId
            $PSBoundParameters['CreateMode'] = 'PointInTimeRestore'
            $PSBoundParameters['RestoreParameterSourceResourceId'] = $sourceId
            $PSBoundParameters['RestoreParameterPointInTimeUtc'] = $RestoreTime.ToUniversalTime()

            if ($PSCmdlet.ShouldProcess($Name, "Restore a mongo cluster from source '$SourceCluster'")) {
                Az.DocumentDB\New-AzDocumentDBMongoCluster @PSBoundParameters
            }
        } catch {
            throw
        }
    }
}
