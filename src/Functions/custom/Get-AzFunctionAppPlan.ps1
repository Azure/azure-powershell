function Get-AzFunctionAppPlan {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20180201.IAppServicePlan])]
[Microsoft.Azure.PowerShell.Cmdlets.Functions.Description('Get function apps plans in a subscription.')]
[CmdletBinding(DefaultParameterSetName='GetAll')]
[Microsoft.Azure.PowerShell.Cmdlets.Functions.Profile('latest-2019-04-30')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory = $true, HelpMessage='The Azure subscription ID.')]
    [Parameter(ParameterSetName="BySubscriptionId")]
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
    ${DefaultProfile}
    )
    
    process {

        $plans = $null
        $locationToUse = $null
        $parameterSetName = $PsCmdlet.ParameterSetName

        if (($parameterSetName -eq "GetAll") -or ($parameterSetName -eq "ByLocation"))
        {
            if ($PSBoundParameters.ContainsKey("Location"))
            {
                $locationToUse = $Location
                $null = $PSBoundParameters.Remove("Location")
            }

            $plans = @(Az.Functions.internal\Get-AzFunctionAppPlan)
        }
        else
        {
            $plans = @(Az.Functions.internal\Get-AzFunctionAppPlan @PSBoundParameters)
        }

        if ($plans.Count -gt 0)
        {
            GetFunctionAppPlans -Plans $plans -Location $locationToUse
        }
    }
}
