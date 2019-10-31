function Get-AzFunctionAppAvailableLocation {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20160301.IGeoRegion])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Description('Gets the location where a function app for the given os and plan type is available.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Profile('latest-2019-04-30')]
    param(    
        [Parameter(Mandatory=$true, HelpMessage="The plan type. Valid inputs: 'Premium'")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PlanType])]    
        [ValidateNotNullOrEmpty()]
        [System.String]
        # Plan type (Premium)
        ${PlanType},

        [Parameter(Mandatory=$true, HelpMessage='The OS type for the service plan.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerType])]
        [ValidateNotNullOrEmpty()]
        [System.String]
        # OS type (Linux or Windows)
        ${OSType},

        [Parameter(HelpMessage=' The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile}
    )
    
    process {

        if ($PSBoundParameters.ContainsKey("OSType"))
        {
            $null = $PSBoundParameters.Remove("OSType")

            if ($OSType -eq "Linux")
            {
                $null = $PSBoundParameters.Add("LinuxWorkersEnabled", $true)
            }
        }

        if ($PSBoundParameters.ContainsKey("PlanType"))
        {
            $null = $PSBoundParameters.Remove("PlanType")

            if ($PlanType -eq "Premium")
            {
                $PSBoundParameters.Add("Sku", 'ElasticPremium')
            }
        }

        Az.Functions.internal\Get-AzFunctionAppAvailableLocation @PSBoundParameters
    }
}
