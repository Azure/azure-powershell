# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Remove user-assigned managed identities from a mongo cluster.
.Description
Remove one or more user-assigned managed identities from a mongo cluster. Only the
supplied identities are removed; any other identities already assigned to the cluster
are preserved. Only user-assigned managed identities are supported.
.Example
Remove-AzDocumentDBMongoClusterIdentity -Name MyCluster -ResourceGroupName MyResourceGroup -UserAssignedIdentity /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myIdentity
.Outputs
System.Management.Automation.PSObject
.Link
https://learn.microsoft.com/powershell/module/az.documentdb/remove-azdocumentdbmongoclusteridentity
#>
function Remove-AzDocumentDBMongoClusterIdentity {
[OutputType([System.Management.Automation.PSObject])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('ClusterName', 'MongoClusterName')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Path')]
    [System.String]
    # The name of the mongo cluster.
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
    [Alias('UserAssigned', 'MiUserAssigned')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Body')]
    [System.String[]]
    # Resource ID(s) of the user-assigned managed identities to remove from the mongo cluster.
    ${UserAssignedIdentity},

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

            # Read the currently assigned identities and drop only the ones requested so the
            # remaining identities are preserved.
            $getParams = @{ ResourceGroupName = $ResourceGroupName; Name = $Name; SubscriptionId = $SubscriptionId }
            if ($PSBoundParameters.ContainsKey('DefaultProfile')) { $getParams['DefaultProfile'] = $DefaultProfile }
            if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) { $getParams['HttpPipelineAppend'] = $HttpPipelineAppend }
            if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) { $getParams['HttpPipelinePrepend'] = $HttpPipelinePrepend }
            $cluster = Az.DocumentDB\Get-AzDocumentDBMongoCluster @getParams -ErrorAction Stop

            $existing = @($cluster.IdentityUserAssignedIdentity.Keys)
            $remaining = @($existing | Where-Object { $_ -notin $UserAssignedIdentity })

            $null = $PSBoundParameters.Remove('UserAssignedIdentity')
            foreach ($commonParam in 'WhatIf', 'Confirm') { $null = $PSBoundParameters.Remove($commonParam) }
            $PSBoundParameters['SubscriptionId'] = $SubscriptionId
            $PSBoundParameters['UserAssignedIdentity'] = $remaining

            if ($PSCmdlet.ShouldProcess($Name, "Remove user-assigned managed identities from mongo cluster")) {
                $updated = Az.DocumentDB\Update-AzDocumentDBMongoCluster @PSBoundParameters
                if ($null -ne $updated -and $updated -is [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster]) {
                    [PSCustomObject]@{
                        PrincipalId          = $updated.IdentityPrincipalId
                        TenantId             = $updated.IdentityTenantId
                        Type                 = $updated.IdentityType
                        UserAssignedIdentity = $updated.IdentityUserAssignedIdentity
                    }
                } else {
                    $updated
                }
            }
        } catch {
            throw
        }
    }
}
