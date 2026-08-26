# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Promote a replica mongo cluster to a primary role.
.Description
Promote a replica mongo cluster to a primary role. As a safety check, the expected source
(primary) cluster must be provided and is validated against the replica's actual source
cluster; promotion only proceeds when they match.
.Example
Invoke-AzDocumentDBPromoteMongoCluster -Name MyReplica -ResourceGroupName MyResourceGroup -SourceCluster MySourceCluster -Mode Switchover
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster
.Link
https://learn.microsoft.com/powershell/module/az.documentdb/invoke-azdocumentdbpromotemongocluster
#>
function Invoke-AzDocumentDBPromoteMongoCluster {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('Name')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Path')]
    [System.String]
    # The name of the replica mongo cluster to promote.
    ${MongoClusterName},

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
    # Name or resource ID of the expected source (primary) cluster of this replica.
    # Promotion only proceeds if it matches the replica's actual source cluster; otherwise the operation fails.
    ${SourceCluster},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Switchover")]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Body')]
    [System.String]
    # The mode to apply to the promote operation.
    # Value is optional and default value is 'Switchover'.
    ${Mode},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds.
    ${PassThru},

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

            # Resolve the expected source cluster to a full ARM resource ID. A bare name
            # assumes the current subscription and resource group.
            if ($SourceCluster -match '^/subscriptions/') {
                $expectedSource = $SourceCluster
            } else {
                $expectedSource = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.DocumentDB/mongoClusters/$SourceCluster"
            }

            # Guard: the replica's actual source cluster must match the provided source before
            # a promote is allowed. This ensures the caller has referenced the correct primary.
            $getParams = @{ SubscriptionId = $SubscriptionId; ResourceGroupName = $ResourceGroupName; Name = $MongoClusterName }
            if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) { $getParams['HttpPipelineAppend'] = $HttpPipelineAppend }
            if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) { $getParams['HttpPipelinePrepend'] = $HttpPipelinePrepend }
            $replica = Get-AzDocumentDBMongoCluster @getParams -ErrorAction Stop
            $actualSource = $replica.ReplicaSourceResourceId
            if (-not $actualSource -or $actualSource.ToLower() -ne $expectedSource.ToLower()) {
                throw "The replica's actual source cluster '$actualSource' does not match the provided -SourceCluster '$expectedSource'. Promotion aborted."
            }

            $null = $PSBoundParameters.Remove('SourceCluster')
            foreach ($commonParam in 'WhatIf', 'Confirm') { $null = $PSBoundParameters.Remove($commonParam) }
            $PSBoundParameters['SubscriptionId'] = $SubscriptionId

            if ($PSCmdlet.ShouldProcess($MongoClusterName, "Promote the replica to primary")) {
                Az.DocumentDB.internal\Invoke-AzDocumentDBPromoteMongoCluster @PSBoundParameters
            }
        } catch {
            throw
        }
    }
}
