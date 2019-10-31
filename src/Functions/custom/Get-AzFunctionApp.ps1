function Get-AzFunctionApp {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20180201.ISite])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Description('Gets function apps in a subscription.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Profile('latest-2019-04-30')]
    [CmdletBinding(DefaultParametersetname="GetAll")]
    param(
        [Parameter(Mandatory=$true, ParameterSetName="ByName", HelpMessage='The Azure subscription ID.')]
        [Parameter(ParameterSetName="BySubscriptionId")]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [ValidateNotNullOrEmpty()]
        [System.String[]]
        ${SubscriptionId},
        
        [Parameter(Mandatory=$true, ParameterSetName="ByName", HelpMessage='The name of the resource group.')]
        [Parameter(ParameterSetName="ByResourceGroupName")]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory=$true, ParameterSetName="ByName", HelpMessage='The name of the function app.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Name},

        [Parameter(Mandatory=$true, ParameterSetName="ByLocation", HelpMessage='The location of the function app.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Location},
        
        [Parameter(Mandatory=$false, ParameterSetName="ByName", HelpMessage='Use to specify whether to include deployment slots in results.')]
        [System.Management.Automation.SwitchParameter]
        ${IncludeSlot},

        [Parameter(HelpMessage=' The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile}
    )
    
    process {

        $apps = $null
        $locationToUse = $null
        $parameterSetName = $PsCmdlet.ParameterSetName

        if (($parameterSetName -eq "GetAll") -or ($parameterSetName -eq "ByLocation"))
        {
            if ($PSBoundParameters.ContainsKey("Location"))
            {
                $locationToUse = $Location
                $null = $PSBoundParameters.Remove("Location")
            }

            $apps = @(Az.Functions.internal\Get-AzFunctionApp)
        }
        else
        {
            $apps = @(Az.Functions.internal\Get-AzFunctionApp @PSBoundParameters)
        }

        if ($apps.Count -gt 0)
        {
            GetFunctionApps -Apps $apps -Location $locationToUse
        }
    }
}
