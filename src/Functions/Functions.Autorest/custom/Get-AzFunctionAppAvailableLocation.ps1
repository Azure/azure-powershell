function Get-AzFunctionAppAvailableLocation {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.IGeoRegion])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Description('Gets the location where a function app for the given os and plan type is available.')]
    [CmdletBinding()]
    param(
        [Parameter(HelpMessage='The Azure subscription ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [ValidateNotNullOrEmpty()]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(HelpMessage="The plan type. Valid inputs: Consumption or Premium")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AvailablePlanType])]
        [ValidateNotNullOrEmpty()]
        [System.String]
        [ValidateSet("Consumption", "FlexConsumption", "Premium")]
        ${PlanType},

        [Parameter(HelpMessage='The OS type for the service plan.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerType])]
        [ValidateNotNullOrEmpty()]
        [System.String]
        [ValidateSet("Linux", "Windows")]
        ${OSType},

        [Parameter(HelpMessage='Filter the list to return only locations which support zone redundancy.')]
        [System.Management.Automation.SwitchParameter]
        ${ZoneRedundancy},

        [Parameter(HelpMessage=' The credentials, account, tenant, and subscription used for communication with Azure.')]
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

        RegisterFunctionsTabCompleters

        # Remove bound parameters from the dictionary that cannot be process by the intenal cmdlets
        $paramsToRemove = @(
            "OSType",
            "PlanType",
            "ZoneRedundancy"
        )
        foreach ($paramName in $paramsToRemove)
        {
            if ($PSBoundParameters.ContainsKey($paramName))
            {
                $PSBoundParameters.Remove($paramName)  | Out-Null
            }
        }

        # Set default PlanType to Premium if not specified
        if (-not $PlanType)
        {
            $PlanType = "Premium"
            Write-Verbose "PlanType not specified. Setting default PlanType to '$PlanType'." -Verbose
        }

        # Set default OSType to Windows if not specified
        if (($PlanType -ne 'FlexConsumption') -and (-not $OSType))
        {
            $OSType = "Windows"
            Write-Verbose "OSType not specified. Setting default OSType to '$OSType'." -Verbose
        }

        # Set Linux flag
        if (($PlanType -ne 'FlexConsumption') -and ($OSType -eq "Linux"))
        {
            $PSBoundParameters.Add("LinuxWorkersEnabled", $true)  | Out-Null
        }

        # Set plan sku
        if ($PlanType -eq "Premium")
        {
            $PSBoundParameters.Add("Sku", 'ElasticPremium')  | Out-Null
        }
        elseif ($PlanType -eq "Consumption")
        {
            $PSBoundParameters.Add("Sku", 'Dynamic')  | Out-Null
        }
        elseif ($PlanType -eq "FlexConsumption")
        {
            $PSBoundParameters.Add("Sku", 'FlexConsumption')  | Out-Null
        }
        else
        {
            $errorMessage = "PlanType '$PlanType' not supported. Valid inputs: Consumption, Premium, or FlexConsumption."
            $exception = [System.InvalidOperationException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "PlanTypeNotSupported" `
                                  -ErrorMessage $errorMessage `
                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                  -Exception $exception
        }

        # FlexConsumption is only supported on Linux
        if (($PlanType -eq 'FlexConsumption') -and ($OSType -eq 'Windows'))
        {
            $errorMessage = "FlexConsumption plan type is only supported on Linux OS type."
            $exception = [System.InvalidOperationException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "FlexConsumptionIsOnlySupportedOnLinux" `
                                  -ErrorMessage $errorMessage `
                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                  -Exception $exception
        }

        if ($ZoneRedundancy.IsPresent -and ($PlanType -ne 'FlexConsumption'))
        {
            $errorMessage = "The ZoneRedundancy parameter is only applicable for FlexConsumption plan type."
            $exception = [System.InvalidOperationException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "ZoneRedundancyIsOnlyApplicableForFlexConsumption" `
                                  -ErrorMessage $errorMessage `
                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                  -Exception $exception
        }

        $regions = Az.Functions.internal\Get-AzFunctionAppAvailableLocation @PSBoundParameters

        if ($ZoneRedundancy.IsPresent -and ($PlanType -eq 'FlexConsumption'))
        {
            $regions | ForEach-Object { if ($_.OrgDomain -match "FCZONEREDUNDANCY") { $_ }}
        }
        else
        {
            $regions
        }
    }
}
