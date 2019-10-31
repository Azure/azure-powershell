function Stop-AzFunctionApp {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='StopByName', SupportsShouldProcess=$true, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Description('Stops a function app.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Profile('latest-2019-04-30')]
    param(
        [Parameter(ParameterSetName='StopByName', Mandatory=$true, HelpMessage='The name of function app.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        ${Name},

        [Parameter(ParameterSetName='StopByName',  Mandatory=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        ${ResourceGroupName},

        [Parameter(ParameterSetName='StopByName', HelpMessage='The Azure subscription ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        ${SubscriptionId},

        [Parameter(ParameterSetName='ByObjectInput', Mandatory=$true, ValueFromPipeline=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20180201.ISite[]]
        [ValidateNotNullOrEmpty()]
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
                    Az.Functions.internal\Stop-AzFunctionApp @PSBoundParameters
                }
            }
        }
        else
        {
            Az.Functions.internal\Stop-AzFunctionApp @PSBoundParameters
        }
    }
}
