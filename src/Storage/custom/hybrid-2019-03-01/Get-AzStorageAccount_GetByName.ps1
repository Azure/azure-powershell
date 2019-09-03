function Get-AzStorageAccount_GetByName {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IStorageAccount')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.Storage.Profile('hybrid-2019-03-01')]
    param(
        [Parameter(Mandatory, HelpMessage='Gets subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # Gets subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The name of the resource group within the user''s subscription. The name is case insensitive.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [System.String]
        # The name of the resource group within the user's subscription. The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The name of the storage account.')]
        [System.String]
        ${Name},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        Az.Storage.internal\Get-AzStorageAccountProperty @PSBoundParameters
    }
}
    