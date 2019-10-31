function Restart-AzFunctionApp {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='Restart', SupportsShouldProcess=$true, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Description('Restarts a function app.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Profile('latest-2019-04-30')]
    param(
        [Parameter(ParameterSetName='Restart', Mandatory=$true, HelpMessage='The name of function app.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        ${Name},

        [Parameter(ParameterSetName='Restart', Mandatory=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        ${ResourceGroupName},

        [Parameter(ParameterSetName='Restart', HelpMessage='The Azure subscription ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        ${SubscriptionId},

        [Parameter(ParameterSetName='ByObjectInput', Mandatory=$true, ValueFromPipeline=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20180201.ISite[]]
        [ValidateNotNull()]
        ${InputObject},

        [Parameter(HelpMessage='Returns true when the command succeeds.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${PassThru},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile}
    )

    process {
        
        if ($PsCmdlet.ParameterSetName -eq "ByObjectInput")
        {            
            if ($PSBoundParameters.ContainsKey("InputObject"))
            {
                $null = $PSBoundParameters.Remove("InputObject")
            }

            foreach ($input in $InputObject)
            {
                $functionsIdentity = CreateObjectFromPipeline -InputObject $input
                if ($functionsIdentity)
                {
                    $null = $PSBoundParameters.Add("InputObject", $functionsIdentity)
                    Az.Functions.internal\Restart-AzFunctionApp @PSBoundParameters
                }
            }
        }
        else
        {
            Az.Functions.internal\Restart-AzFunctionApp @PSBoundParameters
        }
    }
}
