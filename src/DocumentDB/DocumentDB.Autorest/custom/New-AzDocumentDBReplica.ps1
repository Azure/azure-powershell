# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a read replica of an existing mongo cluster.
.Description
Create a read replica of an existing mongo cluster. The source cluster must have the
"GeoReplicas" preview feature enabled. The replica is provisioned as a new mongo cluster
and inherits its configuration (compute, storage, sharding) from the source cluster. A
replica in the same region as the source is created as an in-region 'AsyncReplica'; a
replica in a different region is created as a cross-region 'GeoAsyncReplica'.
.Example
New-AzDocumentDBReplica -Name MyReplica -ResourceGroupName MyResourceGroup -Location centralus -SourceCluster MySourceCluster
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster
.Link
https://learn.microsoft.com/powershell/module/az.documentdb/new-azdocumentdbreplica
#>
function New-AzDocumentDBReplica {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('MongoClusterName')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Path')]
    [System.String]
    # The name of the replica mongo cluster to create.
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
    # The geo-location where the replica lives.
    ${Location},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Body')]
    [System.String]
    # Name or resource ID of the source (primary) mongo cluster to replicate from.
    # If a name is given, the current subscription and resource group are assumed.
    # Provide a full ARM ID for a source in another resource group or subscription.
    ${SourceCluster},

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

            # The source location is derived from the source cluster (not exposed as a
            # parameter); look it up so a cross-region replica is placed correctly.
            $idSegments = $sourceId.Trim('/') -split '/'
            $sourceSubscriptionId = $idSegments[1]
            $sourceResourceGroupName = $idSegments[3]
            $sourceName = $idSegments[7]
            $sourceParams = @{ SubscriptionId = $sourceSubscriptionId; ResourceGroupName = $sourceResourceGroupName; Name = $sourceName }
            if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) { $sourceParams['HttpPipelineAppend'] = $HttpPipelineAppend }
            if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) { $sourceParams['HttpPipelinePrepend'] = $HttpPipelinePrepend }
            $source = Get-AzDocumentDBMongoCluster @sourceParams -ErrorAction Stop
            $sourceLocation = $source.Location

            $null = $PSBoundParameters.Remove('SourceCluster')
            foreach ($commonParam in 'WhatIf', 'Confirm') { $null = $PSBoundParameters.Remove($commonParam) }
            $PSBoundParameters['SubscriptionId'] = $SubscriptionId
            $PSBoundParameters['CreateMode'] = 'GeoReplica'
            $PSBoundParameters['ReplicaParameterSourceResourceId'] = $sourceId
            $PSBoundParameters['ReplicaParameterSourceLocation'] = $sourceLocation

            if ($PSCmdlet.ShouldProcess($Name, "Create a replica of source cluster '$SourceCluster'")) {
                Az.DocumentDB\New-AzDocumentDBMongoCluster @PSBoundParameters
            }
        } catch {
            throw
        }
    }
}
