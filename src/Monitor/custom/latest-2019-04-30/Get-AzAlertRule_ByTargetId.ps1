
function Get-AzAlertRule_ByTargetId {
    [CmdletBinding(PositionalBinding=$false)]
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20160301.IAlertRuleResource')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Profile('latest-2019-04-30')]
    param(
        [Parameter(Mandatory, HelpMessage='The name of the resource group.')]
        [System.String]
        # The name of the resource group.
        ${ResourceGroupName},
    
        [Parameter(Mandatory, HelpMessage='The Azure subscription Id.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # The Azure subscription Id.
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The alert rule target resource id')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
        [System.String]
        # The alert rule target resource id
        ${TargetResourceId},
    
        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        $targetid = $PSBoundParameters["TargetResourceId"]
        $null = $PSBoundParameters.Remove("TargetResourceId")

        Az.Monitor\Get-AzAlertRule @PSBoundParameters | Where-Object -FilterScript { $_.Condition.DataSource.ResourceUri -eq $targetid }
    }
    
}
    