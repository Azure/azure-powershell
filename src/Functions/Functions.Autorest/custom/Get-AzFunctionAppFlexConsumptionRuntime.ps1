function Get-AzFunctionAppFlexConsumptionRuntime {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.FunctionAppFlexConsumptionRuntime])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Description('Gets the Flex Consumption function app runtimes supported at the specified location.')]
    [CmdletBinding(DefaultParameterSetName='AllRuntimes', PositionalBinding=$false)]
    param(
        [Parameter(ParameterSetName='AllRuntimes', HelpMessage='The Azure subscription ID.')]
        [Parameter(ParameterSetName='AllVersions')]
        [Parameter(ParameterSetName='ByVersion')]
        [Parameter(ParameterSetName='DefaultOrLatest')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${SubscriptionId},

        [Parameter(ParameterSetName='AllRuntimes', Mandatory=$true, HelpMessage='The location where Flex Consumption function apps are supported.')]
        [Parameter(ParameterSetName='AllVersions', Mandatory=$true)]
        [Parameter(ParameterSetName='ByVersion', Mandatory=$true)]
        [Parameter(ParameterSetName='DefaultOrLatest', Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Location},

        [Parameter(ParameterSetName='ByVersion', Mandatory=$true, HelpMessage='The Flex Consumption function app runtime.')]
        [Parameter(ParameterSetName='AllVersions', Mandatory=$true)]
        [Parameter(ParameterSetName='DefaultOrLatest', Mandatory=$true)]
        [ValidateSet("DotNet-Isolated", "Node", "Java", "PowerShell", "Python", "Custom")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Runtime},

        [Parameter(ParameterSetName='ByVersion', Mandatory=$true, HelpMessage='The function app runtime version.')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Version},

        [Parameter(ParameterSetName='DefaultOrLatest', Mandatory=$true, HelpMessage='Get the default or latest version of the specified runtime.')]
        [switch]
        $DefaultOrLatest
    )
    
    process {

        # Validate active Azure session (required each invocation for endpoint calls)
        $context = Get-AzContext -ErrorAction SilentlyContinue
        if (-not $context) {
            $errorMessage = "There is no active Azure PowerShell session. Please run 'Connect-AzAccount'."
            $exception    = [System.InvalidOperationException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "LoginToAzureViaConnectAzAccount" `
                                  -ErrorMessage $errorMessage `
                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                  -Exception $exception
        }

        # Switch subscription only if explicitly provided AND different.
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            $SubscriptionId = $SubscriptionId.Trim()
            if ([string]::IsNullOrWhiteSpace($SubscriptionId)) {
                $errorMessage = "SubscriptionId cannot be null or empty."
                $exception    = [System.ArgumentException]::New($errorMessage)
                ThrowTerminatingError -ErrorId "InvalidSubscriptionId" `
                                    -ErrorMessage $errorMessage `
                                    -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidArgument) `
                                    -Exception $exception
            }

            $sameSubscription = ($context.Subscription.Id -ieq $SubscriptionId) -or ($context.Subscription.Name -ieq $SubscriptionId)
            if (-not $sameSubscription) {
                Write-Verbose "Switching context to subscription: $SubscriptionId"
                Set-AzContext -SubscriptionId $SubscriptionId -ErrorAction Stop | Out-Null
                $context = Get-AzContext
            }
            else {
                Write-Verbose "Subscription already set to $SubscriptionId; skipping context switch."
            }
        }

        RegisterFunctionsTabCompleters

        # Normalize location.
        $Location = $Location.Trim()
        if ([string]::IsNullOrWhiteSpace($Location)) {
            $errorMessage = "Location cannot be empty or whitespace."
            $exception    = [System.ArgumentException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "InvalidLocation" `
                                  -ErrorMessage $errorMessage `
                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidArgument) `
                                  -Exception $exception
        }
        Validate-FlexConsumptionLocation -Location $Location

        switch ($PSCmdlet.ParameterSetName) {
            'AllRuntimes' {
                # Return all runtimes
                $activity = "Retrieving Flex Consumption runtimes"
                try {
                    $total = $FlexConsumptionSupportedRuntimes.Count
                    for ($i = 0; $i -lt $total; $i++) {
                        $runtimeName = $FlexConsumptionSupportedRuntimes[$i]
                        $pct    = [int](($i + 1) * 100 / $total)
                        $status = "Fetching $runtimeName ($($i + 1)/$total)"
                        Write-Progress -Activity "Fetching $runtimeName" -Status $status -PercentComplete $pct -Id 1
                        Get-FlexFunctionAppRuntime -Location $Location -Runtime $runtimeName
                    }
                }
                finally {
                    Write-Progress -Activity $activity -Id 1 -Completed -Status "Done"
                }
            }
            'AllVersions' {
                # Return all versions for the specified runtime
                Get-FlexFunctionAppRuntime -Location $Location -Runtime $Runtime
            }
            'ByVersion' {
                # Return specific version
                Get-FlexFunctionAppRuntime -Location $Location -Runtime $Runtime -Version $Version
            }
            'DefaultOrLatest' {
                # Return default/latest version
                Get-FlexFunctionAppRuntime -Location $Location -Runtime $Runtime -DefaultOrLatest:$true
            }
        }
    }
}
