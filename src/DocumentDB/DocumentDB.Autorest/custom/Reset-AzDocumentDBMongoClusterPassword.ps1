# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Reset the administrator password of a mongo cluster.
.Description
Reset the administrator password of a mongo cluster. The update runs as an HTTP PATCH that
only sends the properties provided. The service requires the administrator login to be
included whenever the password is updated, so the cluster's existing administrator user name
is resolved and included in the request automatically.
.Example
Reset-AzDocumentDBMongoClusterPassword -Name MyCluster -ResourceGroupName MyResourceGroup -AdministratorPassword (ConvertTo-SecureString "NewP@ssw0rd123!" -AsPlainText -Force)
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster
.Link
https://learn.microsoft.com/powershell/module/az.documentdb/reset-azdocumentdbmongoclusterpassword
#>
function Reset-AzDocumentDBMongoClusterPassword {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('MongoClusterName')]
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
    [Alias('Password')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Body')]
    [System.Security.SecureString]
    # The new administrator password.
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

            # The update is an HTTP PATCH that only sends the properties provided. The service
            # requires the administrator login to be included whenever the password changes, so
            # resolve the cluster's existing administrator user name and include it.
            $getParams = @{ SubscriptionId = $SubscriptionId; ResourceGroupName = $ResourceGroupName; Name = $Name }
            if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) { $getParams['HttpPipelineAppend'] = $HttpPipelineAppend }
            if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) { $getParams['HttpPipelinePrepend'] = $HttpPipelinePrepend }
            $cluster = Get-AzDocumentDBMongoCluster @getParams -ErrorAction Stop

            $null = $PSBoundParameters.Remove('AdministratorPassword')
            foreach ($commonParam in 'WhatIf', 'Confirm') { $null = $PSBoundParameters.Remove($commonParam) }
            $PSBoundParameters['SubscriptionId'] = $SubscriptionId
            $PSBoundParameters['AdministratorUserName'] = $cluster.AdministratorUserName
            $PSBoundParameters['AdministratorPassword'] = $AdministratorPassword

            if ($PSCmdlet.ShouldProcess($Name, 'Reset the administrator password')) {
                Az.DocumentDB\Update-AzDocumentDBMongoCluster @PSBoundParameters
            }
        } catch {
            throw
        }
    }
}
