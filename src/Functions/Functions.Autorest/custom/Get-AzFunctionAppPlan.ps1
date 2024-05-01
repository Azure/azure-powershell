function Get-AzFunctionAppPlan {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Description('Get function apps plans in a subscription.')]
    [CmdletBinding(DefaultParameterSetName='GetAll')]
    param(
        [Parameter(ParameterSetName='ByName', Mandatory = $true, HelpMessage='The Azure subscription ID.')]
        [Parameter(ParameterSetName="GetAll")]
        [Parameter(ParameterSetName="ByResourceGroupName")]
        [Parameter(ParameterSetName="ByLocation")]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [ValidateNotNullOrEmpty()]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(ParameterSetName='ByName', Mandatory = $true, HelpMessage='The name of the resource group.')]
        [Parameter(ParameterSetName="ByResourceGroupName")]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [ValidateNotNullOrEmpty()]
        [System.String]    
        ${ResourceGroupName},

        [Parameter(ParameterSetName="ByName", Mandatory = $true, HelpMessage='The service plan name.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        ${Name},

        [Parameter(Mandatory=$true, ParameterSetName="ByLocation", HelpMessage='The location of the function app plan.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        ${Location},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
        [System.Management.Automation.PSObject]
        [ValidateNotNull()]
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}        
    )
    
    process {

        RegisterFunctionsTabCompleters

        $plans = $null
        $locationToUse = $null
        $parameterSetName = $PsCmdlet.ParameterSetName

        if (($parameterSetName -eq "GetAll") -or ($parameterSetName -eq "ByLocation"))
        {
            if ($PSBoundParameters.ContainsKey("Location"))
            {
                $locationToUse = $Location
                $PSBoundParameters.Remove("Location")  | Out-Null
            }
        }

        $plans = @(Az.Functions.internal\Get-AzFunctionAppPlan @PSBoundParameters)

        if ($plans.Count -gt 0)
        {
            $params = GetParameterKeyValues -PSBoundParametersDictionary $PSBoundParameters `
                                            -ParameterList @("SubscriptionId", "HttpPipelineAppend", "HttpPipelinePrepend")
            GetFunctionAppPlans -Plans $plans -Location $locationToUse @params
        }
    }
}
