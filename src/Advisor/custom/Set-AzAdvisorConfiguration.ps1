function Set-AzAdvisorConfiguration {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IConfigData])]
    [CmdletBinding(DefaultParameterSetName='CreateByLCT', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='CreateByRG', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Path')]
        [System.String]
        # The name of the Azure resource group.
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='CreateByLCT')]
        [Parameter(ParameterSetName='CreateByRG')]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The Azure subscription ID.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='CreateByInputObject', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAdvisorIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},
    
        [Parameter(ParameterSetName='CreateByLCT')]
        [Parameter(ParameterSetName='CreateByRG')]
        [Parameter(ParameterSetName='CreateByInputObject')]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Exclude the resource from Advisor evaluations.
        # Valid values: False (default) or True.
        ${Exclude},
    
        [Parameter(ParameterSetName='CreateByLCT')]
        [Parameter(ParameterSetName='CreateByInputObject')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Advisor.Support.CpuThreshold])]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Support.CpuThreshold]
        # Minimum percentage threshold for Advisor low CPU utilization evaluation.
        # Valid only for subscriptions.
        # Valid values: 5 (default), 10, 15 or 20.
        ${LowCpuThreshold},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        if (!$Exclude) {$PSBoundParameters['Exclude'] = $False}
        . Az.advisor.internal\New-AzAdvisorConfiguration @PSBoundParameters
    }
}