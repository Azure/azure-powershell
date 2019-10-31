function New-AzFunctionAppPlan {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20180201.IAppServicePlan])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Description('Creates a function app service plan.')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Profile('latest-2019-04-30')]
    param(
        [Parameter(Mandatory=$true, HelpMessage='Name of the App Service plan.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [System.String]
        ${Name},

        [Parameter(Mandatory=$true, HelpMessage='Name of the resource group to which the resource belongs.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(HelpMessage='The Azure subscription ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory=$true, HelpMessage='The plan sku. Valid inputs are: EP1, P2, EP3')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuType])]
        [System.String]
        # Sku (EP1, EP2 or EP3)
        ${Sku},

        [Parameter(Mandatory=$true, HelpMessage='The worker type for the plan. Valid inputs are: Windows or Linux.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerType])]
        [System.String]
        # Worker type (Linux or Windows)
        ${WorkerType},

        [Parameter(Mandatory=$true, HelpMessage='The location for the consumption plan.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Location},

        [Parameter(HelpMessage='The maximum number of workers for the app service plan.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
        [System.Int32]
        [ValidateRange(0,20)]
        [Alias("MaxBurst")]
        ${MaximumWorkerCount},

        [Parameter(HelpMessage='The minimum number of workers for the app service plan.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
        [System.Int32]
        [Alias("MinInstances")]
        [ValidateRange(0,20)]
        ${MinimumWorkerCount},

        [Parameter(HelpMessage='Resource tags.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150801Preview.IResourceTags]))]
        [System.Collections.Hashtable]
        ${Tag},  

        [Parameter(HelpMessage='Run the command as a job.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${AsJob},

        [Parameter(HelpMessage='Run the command asynchronously.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${NoWait},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile}
    )
    process {

        # Remove bound parameters from the dictionary that cannot be process by the intenal cmdlets.
        foreach ($paramName in @("Sku", "WorkerType", "MaximumWorkerCount", "MinimumWorkerCount", "Location"))
        {
            if ($PSBoundParameters.ContainsKey($paramName))
            {
                $null = $PSBoundParameters.Remove($paramName)
            }
        }

        $Sku = NormalizeSku -Sku $Sku
        $tier = GetSkuName -Sku $Sku

        if (($MaximumWorkerCount -gt 0) -and ($tier -ne "ElasticPremium"))
        {
            $errorMessage = "MaximumWorkerCount is only supported for Elastic Premium (EP) plans."
            $exception = [System.InvalidOperationException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "MaximumWorkerCountIsOnlySupportedForElasticPremiumPlan" `
                                  -ErrorMessage $errorMessage `
                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                  -Exception $exception
        }

        if ($MaximumWorkerCount -lt $MinimumWorkerCount)
        {
            $errorMessage = "MinimumWorkerCount '$($MinimumWorkerCount)' cannot be less than '$($MaximumWorkerCount)'."
            $exception = [System.InvalidOperationException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "MaximumWorkerCountIsOnlySupportedForElasticPremiumPlan" `
                                  -ErrorMessage $errorMessage `
                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                  -Exception $exception
        }

        # Validate location for a Premium plan
        $Location = $Location.Trim()
        $availableLocations = @(Get-AzFunctionAppAvailableLocation -OSType $WorkerType -PlanType Premium | ForEach-Object { $_.Name })
        if (-not ($availableLocations -contains $Location))
        {
            $locationOptions = $availableLocations -join ", "
            $errorMessage = "Location is invalid. Currently supported locations are: $locationOptions"
            $exception = [System.InvalidOperationException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "LocationIsInvalid" `
                                  -ErrorMessage $errorMessage `
                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                  -Exception $exception
        }

        $servicePlan = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20180201.AppServicePlan

        # Plan settings
        $servicePlan.SkuTier = $tier
        $servicePlan.SkuName = $Sku
        $servicePlan.Location = $Location
        $servicePlan.Tag = $Tag
        $servicePlan.Reserved = ($WorkerType -eq "Linux")

        if ($MinimumWorkerCount -gt 0)
        {
            $servicePlan.Capacity = $MinimumWorkerCount
        }

        if ($MaximumWorkerCount -gt 0)
        {
            $servicePlan.MaximumElasticWorkerCount = $MaximumWorkerCount
        }

        $null = $PSBoundParameters.Add("AppServicePlan", $servicePlan)
        $null = $PSBoundParameters.Add("ErrorAction", "Stop")

        try
        {
            $createdPlan = Az.Functions.internal\New-AzFunctionAppPlan @PSBoundParameters

            if ($createdPlan)
            {
                $servicePlan.WorkerType = $WorkerType
                $servicePlan
            }
        }
        catch
        {
            $errorMessage = GetErrorMessage -Response $_
            if ($errorMessage)
            {
                $exception = [System.InvalidOperationException]::New($errorMessage)            
                ThrowTerminatingError -ErrorId "FailedToCreateFunctionAppPlan" `
                                    -ErrorMessage $errorMessage `
                                    -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                    -Exception $exception
            }

            throw $_
        }
    }
}
