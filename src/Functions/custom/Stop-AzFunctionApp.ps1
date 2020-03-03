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
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20180201.ISite]
        [ValidateNotNullOrEmpty()]
        ${InputObject},

        [Parameter(HelpMessage='Returns true when the command succeeds.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${PassThru},

        [Parameter(HelpMessage='Forces the cmdlet to stop the function app without prompting for confirmation.')]
        [System.Management.Automation.SwitchParameter]
        ${Force},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
        [System.Management.Automation.PSObject]
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

        # The input object is an ISite. This needs to be transformed into a FunctionsIdentity.
        if ($PsCmdlet.ParameterSetName -eq "ByObjectInput")
        {            
            if ($PSBoundParameters.ContainsKey("InputObject"))
            {
                $null = $PSBoundParameters.Remove("InputObject")
            }

            $functionsIdentity = CreateFunctionsIdentity -InputObject $InputObject
            $null = $PSBoundParameters.Add("InputObject", $functionsIdentity)

            # Set the name of the function app for the ShouldProcess and ShouldContinue calls.
            $Name = $InputObject.Name
        }

        if ($PsCmdlet.ShouldProcess($Name, "Stopping function app"))
        {
            if ($Force.IsPresent -or $PsCmdlet.ShouldContinue("Stop function app '$Name'?", "Stopping function app"))
            {
                # Remove bound parameters from the dictionary that cannot be process by the intenal cmdlets.
                if ($PSBoundParameters.ContainsKey("Force"))
                {
                    $null = $PSBoundParameters.Remove("Force")
                }

                Az.Functions.internal\Stop-AzFunctionApp @PSBoundParameters
            }
        }
    }
}
