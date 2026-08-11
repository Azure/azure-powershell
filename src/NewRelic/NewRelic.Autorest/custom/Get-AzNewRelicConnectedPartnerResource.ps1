<#
.Synopsis
List active deployments associated with the marketplace subscription linked to a New Relic monitor.
.Description
Lists active deployments associated with the marketplace subscription linked to the specified New Relic monitor.
#>
function Get-AzNewRelicConnectedPartnerResource {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IConnectedPartnerResourcesListFormat])]
    [CmdletBinding(PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Category('Path')]
        [string]
        ${MonitorName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Category('Path')]
        [string]
        ${ResourceGroupName},

        [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [string[]]
        ${SubscriptionId},

        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Category('Azure')]
        [psobject]
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Runtime.SendAsyncStep[]]
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Runtime.SendAsyncStep[]]
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Category('Runtime')]
        [uri]
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Category('Runtime')]
        [pscredential]
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Category('Runtime')]
        [switch]
        ${ProxyUseDefaultCredentials}
    )

    process {
        if ($PSCmdlet.ShouldProcess("Call remote 'ConnectedPartnerResourcesList' operation")) {
            $parameters = $PSBoundParameters
            $parameters.Remove('Confirm') | Out-Null
            $parameters.Remove('WhatIf') | Out-Null
            Az.NewRelic.internal\Get-AzNewRelicConnectedPartnerResource @parameters -JsonString '{}'
        }
    }
}
