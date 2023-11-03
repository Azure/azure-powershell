# Load Az.Functions module constants
$constants = @{}
$constants["AllowedStorageTypes"] = @('Standard_GRS', 'Standard_RAGRS', 'Standard_LRS', 'Standard_ZRS', 'Premium_LRS', 'Standard_GZRS')
$constants["RequiredStorageEndpoints"] = @('PrimaryEndpointFile', 'PrimaryEndpointQueue', 'PrimaryEndpointTable')
$constants["DefaultFunctionsVersion"] = '4'
$constants["RuntimeToFormattedName"] = @{
    'node' = 'Node'
    'dotnet' = 'DotNet'
    'python' = 'Python'
    'java' = 'Java'
    'powershell' = 'PowerShell'
}
$constants["RuntimeToDefaultOSType"] = @{
    'DotNet'= 'Windows'
    'Node' = 'Windows'
    'Java' = 'Windows'
    'PowerShell' = 'Windows'
    'Python' = 'Linux'
}
$constants["ReservedFunctionAppSettingNames"] = @(
    'FUNCTIONS_WORKER_RUNTIME'
    'DOCKER_CUSTOM_IMAGE_NAME'
    'FUNCTION_APP_EDIT_MODE'
    'WEBSITES_ENABLE_APP_SERVICE_STORAGE'
    'DOCKER_REGISTRY_SERVER_URL'
    'DOCKER_REGISTRY_SERVER_USERNAME'
    'DOCKER_REGISTRY_SERVER_PASSWORD'
    'WEBSITES_ENABLE_APP_SERVICE_STORAGE'
    'WEBSITE_NODE_DEFAULT_VERSION'
    'AzureWebJobsStorage'
    'AzureWebJobsDashboard'
    'FUNCTIONS_EXTENSION_VERSION'
    'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING'
    'WEBSITE_CONTENTSHARE'
    'APPINSIGHTS_INSTRUMENTATIONKEY'
)
$constants["SupportedFunctionsVersion"] = @('3', '4')
$constants["FunctionsNoV2Version"] = @(
    "USNat West"
    "USNat East"
    "USSec West"
    "USSec East"
)

$constants["SetDefaultValueParameterWarningMessage"] = "This default value is subject to change over time. Please set this value explicitly to ensure the behavior is not accidentally impacted by future changes."

foreach ($variableName in $constants.Keys)
{
    if (-not (Get-Variable $variableName -ErrorAction SilentlyContinue))
    {
        Set-Variable $variableName -value $constants[$variableName] -option ReadOnly
    }
}

function GetConnectionString
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $StorageAccountName,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    if ($PSBoundParameters.ContainsKey("StorageAccountName"))
    {
        $PSBoundParameters.Remove("StorageAccountName") | Out-Null
    }

    $storageAccountInfo = GetStorageAccount -Name $StorageAccountName @PSBoundParameters
    if (-not $storageAccountInfo)
    {
        $errorMessage = "Storage account '$StorageAccountName' does not exist."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "StorageAccountNotFound" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    if ($storageAccountInfo.ProvisioningState -ne "Succeeded")
    {
        $errorMessage = "Storage account '$StorageAccountName' is not ready. Please run 'Get-AzStorageAccount' and ensure that the ProvisioningState is 'Succeeded'"
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "StorageAccountNotFound" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }
    
    $skuName = $storageAccountInfo.SkuName
    if (-not ($AllowedStorageTypes -contains $skuName))
    {
        $storageOptions = $AllowedStorageTypes -join ", "
        $errorMessage = "Storage type '$skuName' is not allowed'. Currently supported storage options: $storageOptions"
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "StorageTypeNotSupported" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    foreach ($endpoint in $RequiredStorageEndpoints)
    {
        if ([string]::IsNullOrEmpty($storageAccountInfo.$endpoint))
        {
            $errorMessage = "Storage account '$StorageAccountName' has no '$endpoint' endpoint. It must have table, queue, and blob endpoints all enabled."
            $exception = [System.InvalidOperationException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "StorageAccountRequiredEndpointNotAvailable" `
                                  -ErrorMessage $errorMessage `
                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                  -Exception $exception
        }
    }

    $resourceGroupName = ($storageAccountInfo.Id -split "/")[4]
    $keys = Az.Functions.internal\Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageAccountInfo.Name @PSBoundParameters -ErrorAction SilentlyContinue

    if (-not $keys)
    {
        $errorMessage = "Failed to get key for storage account '$StorageAccountName'."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "FailedToGetStorageAccountKey" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    if ([string]::IsNullOrEmpty($keys[0].Value))
    {
        $errorMessage = "Storage account '$StorageAccountName' has no key value."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "StorageAccountHasNoKeyValue" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    $suffix = GetEndpointSuffix
    $accountKey = $keys[0].Value

    $connectionString = "DefaultEndpointsProtocol=https;AccountName=$StorageAccountName;AccountKey=$accountKey" + $suffix

    return $connectionString
}

function GetEndpointSuffix
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param()

    $environmentName = (Get-AzContext).Environment.Name

    switch ($environmentName)
    {
        "AzureUSGovernment" { ';EndpointSuffix=core.usgovcloudapi.net' }
        "AzureChinaCloud"   { ';EndpointSuffix=core.chinacloudapi.cn' }
        "AzureCloud"        { ';EndpointSuffix=core.windows.net' }
        default { '' }
    }
}

function NewAppSetting
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory=$false)]
        [System.String]
        $Value
    )

    $setting = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePair
    $setting.Name = $Name
    $setting.Value = $Value

    return $setting
}

function GetServicePlan
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    if ($PSBoundParameters.ContainsKey("Name"))
    {
        $PSBoundParameters.Remove("Name") | Out-Null
    }

    $plans = @(Az.Functions\Get-AzFunctionAppPlan @PSBoundParameters)

    foreach ($plan in $plans)
    {
        if ($plan.Name -eq $Name)
        {
            return $plan
        }
    }

    # The plan name was not found, error out
    $errorMessage = "Service plan '$Name' does not exist."
    $exception = [System.InvalidOperationException]::New($errorMessage)
    ThrowTerminatingError -ErrorId "ServicePlanDoesNotExist" `
                          -ErrorMessage $errorMessage `
                          -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                          -Exception $exception
}

function GetStorageAccount
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    if ($PSBoundParameters.ContainsKey("Name"))
    {
        $PSBoundParameters.Remove("Name") | Out-Null
    }

    $storageAccounts = @(Az.Functions.internal\Get-AzStorageAccount @PSBoundParameters -ErrorAction SilentlyContinue)
    foreach ($account in $storageAccounts)
    {
        if ($account.Name -eq $Name)
        {
            return $account
        }
    }
}

function GetApplicationInsightsProject
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    if ($PSBoundParameters.ContainsKey("Name"))
    {
        $PSBoundParameters.Remove("Name") | Out-Null
    }

    $projects = @(Az.Functions.internal\Get-AzAppInsights @PSBoundParameters)
    
    foreach ($project in $projects)
    {
        if ($project.Name -eq $Name)
        {
            return $project
        }
    }
}

function CreateApplicationInsightsProject
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceName,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Location,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    $paramsToRemove = @(
        "ResourceGroupName",
        "ResourceName",
        "Location"
    )
    foreach ($paramName in $paramsToRemove)
    {
        if ($PSBoundParameters.ContainsKey($paramName))
        {
            $PSBoundParameters.Remove($paramName)  | Out-Null
        }
    }

    # Create a new ApplicationInsights
    $maxNumberOfTries = 3
    $tries = 1

    while ($true)
    {
        try
        {
            $newAppInsightsProject = Az.Functions.internal\New-AzAppInsights -ResourceGroupName $ResourceGroupName `
                                                                             -ResourceName $ResourceName  `
                                                                             -Location $Location `
                                                                             -Kind web `
                                                                             -RequestSource "AzurePowerShell" `
                                                                             -ErrorAction Stop `
                                                                             @PSBoundParameters
            if ($newAppInsightsProject)
            {
                return $newAppInsightsProject
            }
        }
        catch
        {
            # Ignore the failure and continue
        }

        if ($tries -ge $maxNumberOfTries)
        {
            break
        }

        # Wait for 2^(tries-1) seconds between retries. In this case, it would be 1, 2, and 4 seconds, respectively.
        $waitInSeconds = [Math]::Pow(2, $tries - 1)
        Start-Sleep -Seconds $waitInSeconds

        $tries++
    }
}

function ConvertWebAppApplicationSettingToHashtable
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [Object]
        $ApplicationSetting
    )

    # Create a key value pair to hold the function app settings
    $applicationSettings = @{}
    foreach ($keyName in $ApplicationSetting.Property.Keys)
    {
        $applicationSettings[$keyName] = $ApplicationSetting.Property[$keyName]
    }

    return $applicationSettings
}

function AddFunctionAppSettings
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [Object]
        $App,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    if ($PSBoundParameters.ContainsKey("App"))
    {
        $PSBoundParameters.Remove("App") | Out-Null
    }

    $App.AppServicePlan = ($App.ServerFarmId -split "/")[-1]
    $App.OSType = if ($App.kind.ToLower().Contains("linux")){ "Linux" } else { "Windows" }

    if ($App.Type -eq "Microsoft.Web/sites/slots")
    {
        return $App
    }
    
    $currentSubscription = $null
    $resetDefaultSubscription = $false
    
    try
    {
        $settings = Az.Functions.internal\Get-AzWebAppApplicationSetting -Name $App.Name `
                                                                         -ResourceGroupName $App.ResourceGroup `
                                                                         -ErrorAction SilentlyContinue `
                                                                         @PSBoundParameters
        if ($null -eq $settings)
        {
            Write-Warning -Message "Failed to retrieve function app settings. 1st attempt"
            Write-Warning -Message "Setting session context to subscription id '$($App.SubscriptionId)'"

            $resetDefaultSubscription = $true
            $currentSubscription = (Get-AzContext).Subscription.Id
            $null = Select-AzSubscription $App.SubscriptionId

            $settings = Az.Functions.internal\Get-AzWebAppApplicationSetting -Name $App.Name `
                                                                             -ResourceGroupName $App.ResourceGroup `
                                                                             -ErrorAction SilentlyContinue `
                                                                             @PSBoundParameters
            if ($null -eq $settings)
            {
                # We are unable to get the app settings, return the app
                Write-Warning -Message "Failed to retrieve function app settings. 2nd attempt."
                return $App
            }
        }
    }
    finally
    {
        if ($resetDefaultSubscription)
        {
            Write-Warning -Message "Resetting session context to subscription id '$currentSubscription'"
            $null = Select-AzSubscription $currentSubscription
        }
    }

    # Add application settings
    $App.ApplicationSettings = ConvertWebAppApplicationSettingToHashtable -ApplicationSetting $settings

    $runtimeName = $App.ApplicationSettings["FUNCTIONS_WORKER_RUNTIME"]
    $App.Runtime = if (($null -ne $runtimeName) -and ($RuntimeToFormattedName.ContainsKey($runtimeName)))
                   {
                       $RuntimeToFormattedName[$runtimeName]
                   }
                   elseif ($App.ApplicationSettings.ContainsKey("DOCKER_CUSTOM_IMAGE_NAME"))
                   {
                       "Custom Image"
                   }
                   else {""}

    # Get the app site config
    $config = GetAzWebAppConfig -Name $App.Name -ResourceGroupName $App.ResourceGroup @PSBoundParameters
    # Add all site config properties as a hash table
    $SiteConfig = @{}
    foreach ($property in $config.PSObject.Properties)
    {
        if ($property.Name)
        {
            $SiteConfig.Add($property.Name, $property.Value)
        }
    }

    $App.SiteConfig = $SiteConfig

    return $App
}

function GetFunctionApps
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [AllowEmptyCollection()]
        [Object[]]
        $Apps,

        [System.String]
        $Location,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    $paramsToRemove = @(
        "Apps",
        "Location"
    )
    foreach ($paramName in $paramsToRemove)
    {
        if ($PSBoundParameters.ContainsKey($paramName))
        {
            $PSBoundParameters.Remove($paramName)  | Out-Null
        }
    }

    if ($Apps.Count -eq 0)
    {
        return
    }

    $activityName = "Getting function apps"

    for ($index = 0; $index -lt $Apps.Count; $index++)
    {
        $app = $Apps[$index]

        $percentageCompleted = [int]((100 * ($index + 1)) / $Apps.Count)
        $status = "Complete: $($index + 1)/$($Apps.Count) function apps processed."
        Write-Progress -Activity "Getting function apps" -Status $status -PercentComplete $percentageCompleted
        
        if ($app.kind.ToLower().Contains("functionapp"))
        {
            if ($Location)
            {
                if ($app.Location -eq $Location)
                {
                    $app = AddFunctionAppSettings -App $app @PSBoundParameters
                    $app
                }
            }
            else
            {
                $app = AddFunctionAppSettings -App $app @PSBoundParameters
                $app
            }
        }
    }

    Write-Progress -Activity $activityName -Status "Completed" -Completed
}

function AddFunctionAppPlanWorkerType
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        $AppPlan,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    if ($PSBoundParameters.ContainsKey("AppPlan"))
    {
        $PSBoundParameters.Remove("AppPlan") | Out-Null
    }

    # The GetList api for service plan that does not set the Reserved property, which is needed to figure out if the OSType is Linux.
    # TODO: Remove this code once  https://msazure.visualstudio.com/Antares/_workitems/edit/5623226 is fixed.
    if ($null -eq $AppPlan.Reserved)
    {
        # Get the service plan by name does set the Reserved property
        $planObject = Az.Functions.internal\Get-AzFunctionAppPlan -Name $AppPlan.Name `
                                                                  -ResourceGroupName $AppPlan.ResourceGroup `
                                                                  -ErrorAction SilentlyContinue `
                                                                  @PSBoundParameters
        $AppPlan = $planObject
    }

    $AppPlan.WorkerType = if ($AppPlan.Reserved){ "Linux" } else { "Windows" }

    return $AppPlan
}

function GetFunctionAppPlans
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [AllowEmptyCollection()]
        [Object[]]
        $Plans,

        [System.String]
        $Location,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    $paramsToRemove = @(
        "Plans",
        "Location"
    )
    foreach ($paramName in $paramsToRemove)
    {
        if ($PSBoundParameters.ContainsKey($paramName))
        {
            $PSBoundParameters.Remove($paramName)  | Out-Null
        }
    }

    if ($Plans.Count -eq 0)
    {
        return
    }

    $activityName = "Getting function app plans"

    for ($index = 0; $index -lt $Plans.Count; $index++)
    {
        $plan = $Plans[$index]
        
        $percentageCompleted = [int]((100 * ($index + 1)) / $Plans.Count)
        $status = "Complete: $($index + 1)/$($Plans.Count) function apps plans processed."
        Write-Progress -Activity $activityName -Status $status -PercentComplete $percentageCompleted

        try {
            if ($Location)
            {
                if ($plan.Location -eq $Location)
                {
                    $plan = AddFunctionAppPlanWorkerType -AppPlan $plan @PSBoundParameters
                    $plan
                }
            }
            else
            {
                $plan = AddFunctionAppPlanWorkerType -AppPlan $plan @PSBoundParameters
                $plan
            }
        }
        catch {
            continue;
        }
    }

    Write-Progress -Activity $activityName -Status "Completed" -Completed
}

function ValidateFunctionName
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    $result = Az.Functions.internal\Test-AzNameAvailability -Type Site @PSBoundParameters

    if (-not $result.NameAvailable)
    {
        $errorMessage = "Function name '$Name' is not available.  Please try a different name."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "FunctionAppNameIsNotAvailable" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }
}

function NormalizeSku
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Sku
    )    
    if ($Sku -eq "SHARED")
    {
        return "D1"
    }
    return $Sku
}

function CreateFunctionsIdentity
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        $InputObject
    )

    if (-not ($InputObject.Name -and $InputObject.ResourceGroupName -and $InputObject.SubscriptionId))
    {
        $errorMessage = "Input object '$InputObject' is missing one or more of the following properties: Name, ResourceGroupName, SubscriptionId"
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "FailedToCreateFunctionsIdentity" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    $functionsIdentity = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.FunctionsIdentity
    $functionsIdentity.Name = $InputObject.Name
    $functionsIdentity.SubscriptionId = $InputObject.SubscriptionId
    $functionsIdentity.ResourceGroupName = $InputObject.ResourceGroupName

    return $functionsIdentity
}

function GetSkuName
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Sku
    )

    if (($Sku -eq "D1") -or ($Sku -eq "SHARED"))
    {
        return "SHARED"
    }
    elseif (($Sku -eq "B1") -or ($Sku -eq "B2") -or ($Sku -eq "B3") -or ($Sku -eq "BASIC"))
    {
        return "BASIC"
    }
    elseif (($Sku -eq "S1") -or ($Sku -eq "S2") -or ($Sku -eq "S3"))
    {
        return "STANDARD"
    }
    elseif (($Sku -eq "P1") -or ($Sku -eq "P2") -or ($Sku -eq "P3"))
    {
        return "PREMIUM"
    }
    elseif (($Sku -eq "P1V2") -or ($Sku -eq "P2V2") -or ($Sku -eq "P3V2"))
    {
        return "PREMIUMV2"
    }
    elseif (($Sku -eq "PC2") -or ($Sku -eq "PC3") -or ($Sku -eq "PC4"))
    {
        return "PremiumContainer"
    }
    elseif (($Sku -eq "EP1") -or ($Sku -eq "EP2") -or ($Sku -eq "EP3"))
    {
        return "ElasticPremium"
    }
    elseif (($Sku -eq "I1") -or ($Sku -eq "I2") -or ($Sku -eq "I3"))
    {
        return "Isolated"
    }

    $guidanceUrl = 'https://learn.microsoft.com/azure/azure-functions/functions-premium-plan#plan-and-sku-settings'

    $errorMessage = "Invalid sku (pricing tier), please refer to '$guidanceUrl' for valid values."
    $exception = [System.InvalidOperationException]::New($errorMessage)
    ThrowTerminatingError -ErrorId "InvalidSkuPricingTier" `
                          -ErrorMessage $errorMessage `
                          -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                          -Exception $exception
}

function ThrowTerminatingError
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param 
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ErrorId,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ErrorMessage,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.Management.Automation.ErrorCategory]
        $ErrorCategory,

        [Exception]
        $Exception,

        [object]
        $TargetObject
    )

    if (-not $Exception)
    {
        $Exception = New-Object -TypeName System.Exception -ArgumentList $ErrorMessage
    }

    $errorRecord = New-Object -TypeName System.Management.Automation.ErrorRecord -ArgumentList ($Exception, $ErrorId, $ErrorCategory, $TargetObject)
    #$PSCmdlet.ThrowTerminatingError($errorRecord)
    throw $errorRecord
}

function GetErrorMessage
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNull()]
        $Response
    )

    if ($Response.Exception.ResponseBody)
    {
        try
        {
            $details = ConvertFrom-Json $Response.Exception.ResponseBody
            if ($details.Message)
            {
                return $details.Message
            }
        }
        catch 
        {
            # Ignore the deserialization error
        }
    }
}

function GetSupportedRuntimes
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $OSType
    )

    if ($OSType -eq "Linux")
    {
        return $LinuxRuntimes
    }
    elseif ($OSType -eq "Windows")
    {
        return $WindowsRuntimes
    }

    throw "Unknown OS type '$OSType'"
}

function ValidateFunctionsVersion
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $FunctionsVersion
    )

    if ($SupportedFunctionsVersion -notcontains $FunctionsVersion)
    {
        $currentlySupportedFunctionsVersions = $SupportedFunctionsVersion -join ' and '
        $errorMessage = "Functions version not supported. Currently supported version are: $($currentlySupportedFunctionsVersions)."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "FunctionsVersionNotSupported" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }
}

function ValidateFunctionsV2NotAvailableLocation
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Location
    )

    $Location = $Location.Trim()

    $locationsWithNoV2Version = $FunctionsNoV2Version

    if (-not $Location.Contains(" "))
    {
        $locationsWithNoV2Version = @($FunctionsNoV2Version | ForEach-Object { $_.Replace(" ", "") })
    }

    if ($locationsWithNoV2Version -contains $Location)
    {
        $errorMessage = "Functions version 2 is not supported in this region. To create a version 3 function, specify -FunctionsVersion 3"
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "FunctionsV2IsNotSuportedInThisRegion" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }
}

function GetDefaultOSType
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Runtime
    )

    $defaultOSType = $RuntimeToDefaultOSType[$Runtime]

    if (-not $defaultOSType)
    {
        # The specified runtime did not match, error out
        $runtimeOptions = FormatListToString -List @($RuntimeToDefaultOSType.Keys | Sort-Object)
        $errorMessage = "Runtime '$Runtime' is not supported. Currently supported runtimes: " + $runtimeOptions + "."
        ThrowRuntimeNotSupportedException -Message $errorMessage -ErrorId "RuntimeNotSupported"
    }

    return $defaultOSType
}

function GetRuntimeJsonDefinition
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $FunctionsVersion,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Runtime,

        [Parameter(Mandatory=$false)]
        [System.String]
        $RuntimeVersion,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $OSType
    )

    $functionsExtensionVersion = "~$FunctionsVersion"
    $supportedRuntimes = GetSupportedRuntimes -OSType $OSType

    if (-not $supportedRuntimes.ContainsKey($Runtime))
    {
        $runtimeOptions = FormatListToString -List @($supportedRuntimes.Keys | ForEach-Object { $RuntimeToFormattedName[$_]} | Sort-Object)
        $errorMessage = "Runtime '$Runtime' in Functions version '$FunctionsVersion' on '$OSType' is not supported. Currently supported runtimes: " + $runtimeOptions + "."

        ThrowRuntimeNotSupportedException -Message $errorMessage -ErrorId "RuntimeNotSupported"
    }

    # If runtime version is not provided, iterate through the SupportedRuntimes to get the default version
    # based the function extension version, os type and runtime. 
    if (-not $RuntimeVersion)
    {
        $latestVersion = [Version]::new("0.0")
        $defaultVersionFound = $false
        $versionIsInt = $false

        foreach ($version in $supportedRuntimes[$Runtime].MajorVersions.Keys)
        {
            $majorVersion = $supportedRuntimes[$Runtime].MajorVersions[$version]

            if ($majorVersion.IsDefault -and ($majorVersion.SupportedFunctionsExtensionVersions -contains $functionsExtensionVersion))
            {
                if (-not $version.Contains("."))
                {
                    $versionIsInt = $true
                    $version = $version + ".0"
                }

                $thisVersion = $null
                [Version]::TryParse($version, [ref]$thisVersion)

                if (($null -ne $thisVersion ) -and ($thisVersion -gt $latestVersion))
                {
                    $latestVersion = $thisVersion
                    $defaultVersionFound = $true
                }
            }
        }

        # Error out if we could not find a default version for the given runtime, functions extension version, and os type
        if (-not $defaultVersionFound)
        {
            $errorMessage = "Runtime '$Runtime' in Functions version '$FunctionsVersion' on '$OSType' is not supported."
            ThrowRuntimeNotSupportedException -Message $errorMessage -ErrorId "RuntimeVersionNotSupported"
        }

        if ($versionIsInt)
        {
            $RuntimeVersion = $latestVersion.Major
        }
        else
        {
            $RuntimeVersion = $latestVersion.ToString()
        }

        Write-Warning "RuntimeVersion not specified. Setting default value to '$RuntimeVersion'. $SetDefaultValueParameterWarningMessage"
    }

    # Get the RuntimeJsonDefinition
    $runtimeJsonDefinition = $supportedRuntimes[$Runtime].MajorVersions[$RuntimeVersion]
    
    if ((-not $runtimeJsonDefinition) -or (-not ($runtimeJsonDefinition.SupportedFunctionsExtensionVersions -contains $functionsExtensionVersion)))
    {
        $errorMessage = "Runtime '$Runtime' version '$RuntimeVersion' in Functions version '$FunctionsVersion' on '$OSType' is not supported."
        $supporedVersions = @(GetSupportedRuntimeVersions -FunctionsVersion $FunctionsVersion -Runtime $Runtime -OSType $OSType)

        if ($supporedVersions.Count -gt 0)
        {
            $runtimeVersionOptions = FormatListToString -List @($supporedVersions | Sort-Object)
            $errorMessage += " Currently supported runtime versions for '$($Runtime)' are: $runtimeVersionOptions."
        }

        ThrowRuntimeNotSupportedException -Message $errorMessage -ErrorId "RuntimeVersionNotSupported"
    }
    
    if ($runtimeJsonDefinition.IsPreview)
    {
        # Write a verbose message to the user if the current runtime is in Preview
        Write-Verbose "Runtime '$Runtime' version '$RuntimeVersion' is in Preview for '$OSType'." -Verbose
    }

    return $runtimeJsonDefinition
}

function ThrowRuntimeNotSupportedException
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Message,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ErrorId
    )

    $Message += [System.Environment]::NewLine
    $Message += "For supported languages, please visit 'https://learn.microsoft.com/azure/azure-functions/functions-versions#languages'."

    $exception = [System.InvalidOperationException]::New($Message)
    ThrowTerminatingError -ErrorId $ErrorId `
                          -ErrorMessage $Message `
                          -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                          -Exception $exception
}

function GetSupportedRuntimeVersions
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $FunctionsVersion,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Runtime,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $OSType
    )

    $functionsExtensionVersion = "~$FunctionsVersion"
    $supportedRuntimes = GetSupportedRuntimes -OSType $OSType

    $result = @()

    foreach ($runtimeVersion in $supportedRuntimes[$Runtime].MajorVersions.Keys)
    {
        $majorVersion = $supportedRuntimes[$Runtime].MajorVersions[$runtimeVersion]
        if ($majorVersion.SupportedFunctionsExtensionVersions -contains $functionsExtensionVersion)
        {
            $result += $runtimeVersion
        }
    }

    return ($result | Sort-Object)
}

function FormatListToString
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [System.String[]]
        $List
    )
    
    if ($List.Count -eq 0)
    {
        return
    }

    $result = ""

    if ($List.Count -eq 1)
    {
        $result = "'" + $List[0] + "'"
    }
    
    else
    {
        for ($index = 0; $index -lt ($List.Count - 1); $index++)
        {
            $item = $List[$index]
            $result += "'" + $item + "', "
        }

        $result += "'" + $List[$List.Count - 1] + "'"
    }
    
    return $result
}

function ValidatePlanLocation
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Location,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        [ValidateSet("Dynamic", "ElasticPremium")]
        $PlanType,

        [Parameter(Mandatory=$false)]
        [System.Management.Automation.SwitchParameter]
        $OSIsLinux,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    $paramsToRemove = @(
        "PlanType",
        "OSIsLinux",
        "Location"
    )
    foreach ($paramName in $paramsToRemove)
    {
        if ($PSBoundParameters.ContainsKey($paramName))
        {
            $PSBoundParameters.Remove($paramName)  | Out-Null
        }
    }

    $Location = $Location.Trim()
    $locationContainsSpace = $Location.Contains(" ")

    $availableLocations = @(Az.Functions.internal\Get-AzFunctionAppAvailableLocation -Sku $PlanType `
                                                                                     -LinuxWorkersEnabled:$OSIsLinux `
                                                                                     @PSBoundParameters | ForEach-Object { $_.Name })

    if (-not $locationContainsSpace)
    {
        $availableLocations = @($availableLocations | ForEach-Object { $_.Replace(" ", "") })
    }

    if (-not ($availableLocations -contains $Location))
    {
        $errorMessage = "Location is invalid. Use 'Get-AzFunctionAppAvailableLocation' to see available locations for running function apps."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "LocationIsInvalid" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }
}

function ValidatePremiumPlanLocation
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Location,

        [Parameter(Mandatory=$false)]
        [System.Management.Automation.SwitchParameter]
        $OSIsLinux,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    ValidatePlanLocation -PlanType ElasticPremium @PSBoundParameters
}

function ValidateConsumptionPlanLocation
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Location,

        [Parameter(Mandatory=$false)]
        [System.Management.Automation.SwitchParameter]
        $OSIsLinux,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    ValidatePlanLocation -PlanType Dynamic @PSBoundParameters
}

function GetParameterKeyValues
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [System.Collections.Generic.Dictionary[string, object]]
        [ValidateNotNull()]
        $PSBoundParametersDictionary,

        [Parameter(Mandatory=$true)]
        [System.String[]]
        [ValidateNotNull()]
        $ParameterList
    )

    $params = @{}
    if ($ParameterList.Count -gt 0)
    {
        foreach ($paramName in $ParameterList)
        {
            if ($PSBoundParametersDictionary.ContainsKey($paramName))
            {
                $params[$paramName] = $PSBoundParametersDictionary[$paramName]
            }
        }
    }
    return $params
}

function NewResourceTag
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [hashtable]
        $Tag
    )

    $resourceTag = [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResourceTags]::new()

    foreach ($tagName in $Tag.Keys)
    {
        $resourceTag.Add($tagName, $Tag[$tagName])
    }
    return $resourceTag
}

function ParseDockerImage
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $DockerImageName
    )

    # Sample urls:
    # myacr.azurecr.io/myimage:tag
    # mcr.microsoft.com/azure-functions/powershell:2.0
    if ($DockerImageName.Contains("/"))
    {
        $index = $DockerImageName.LastIndexOf("/")
        $value = $DockerImageName.Substring(0,$index)
        if ($value.Contains(".") -or $value.Contains(":"))
        {
            return $value
        }
    }
}

function GetFunctionAppServicePlanInfo
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ServerFarmId,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    if ($PSBoundParameters.ContainsKey("ServerFarmId"))
    {
        $PSBoundParameters.Remove("ServerFarmId") | Out-Null
    }

    $planInfo = $null

    if ($ServerFarmId.Contains("/"))
    {
        $parts = $ServerFarmId -split "/"

        $planName = $parts[-1]
        $resourceGroupName = $parts[-5]

        $planInfo = Az.Functions\Get-AzFunctionAppPlan -Name $planName `
                                                       -ResourceGroupName $resourceGroupName `
                                                       @PSBoundParameters
    }

    if (-not $planInfo)
    {
        $errorMessage = "Could not determine the current plan of the functionapp."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "CouldNotDetermineFunctionAppPlan" `
                            -ErrorMessage $errorMessage `
                            -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                            -Exception $exception

    }

    return $planInfo
}

function ValidatePlanSwitchCompatibility
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        $CurrentServicePlan,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        $NewServicePlan
    )

    if (-not (($CurrentServicePlan.SkuTier -eq "ElasticPremium") -or ($CurrentServicePlan.SkuTier -eq "Dynamic") -or
              ($NewServicePlan.SkuTier -eq "ElasticPremium") -or ($NewServicePlan.SkuTier -eq "Dynamic")))
    {
        $errorMessage = "Currently the switch is only allowed between a Consumption or an Elastic Premium plan."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "InvalidFunctionAppPlanSwitch" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }
}

function NewAppSettingObject
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [Hashtable]
        $CurrentAppSetting
    )

    # Create StringDictionaryProperties (hash table) with the app settings
    $properties = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StringDictionaryProperties

    foreach ($keyName in $currentAppSettings.Keys)
    {
        $properties.Add($keyName, $currentAppSettings[$keyName])
    }

    $appSettings = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StringDictionary
    $appSettings.Property = $properties

    return $appSettings
}

function ContainsReservedFunctionAppSettingName
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [String[]]
        $AppSettingName
    )

    foreach ($name in $AppSettingName)
    {
        if ($ReservedFunctionAppSettingNames.Contains($name))
        {
            return $true
        }
    }

    return $false
}

function GetFunctionAppByName
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $Name,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ResourceGroupName,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    $paramsToRemove = @(
        "Name",
        "ResourceGroupName"
    )
    foreach ($paramName in $paramsToRemove)
    {
        if ($PSBoundParameters.ContainsKey($paramName))
        {
            $PSBoundParameters.Remove($paramName)  | Out-Null
        }
    }

    $existingFunctionApp = Az.Functions\Get-AzFunctionApp -ResourceGroupName $ResourceGroupName `
                                                          -Name $Name `
                                                          -ErrorAction SilentlyContinue `
                                                          @PSBoundParameters

    if (-not $existingFunctionApp)
    {
        $errorMessage = "Function app name '$Name' in resource group name '$ResourceGroupName' does not exist."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "FunctionAppDoesNotExist" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    return $existingFunctionApp
}
function GetAzWebAppConfig
{

    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $Name,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ResourceGroupName,

        [Switch]
        $ErrorIfResultIsNull,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    if ($PSBoundParameters.ContainsKey("ErrorIfResultIsNull"))
    {
        $PSBoundParameters.Remove("ErrorIfResultIsNull") | Out-Null
    }

    $resetDefaultSubscription = $false
    $webAppConfig = $null
    $currentSubscription = $null
    try
    {
        $webAppConfig = Az.Functions.internal\Get-AzWebAppConfiguration -ErrorAction SilentlyContinue `
                                                                        @PSBoundParameters

        if ($null -eq $webAppConfig)
        {
            Write-Warning -Message "Failed to retrieve function app site config. 1st attempt"
            Write-Warning -Message "Setting session context to subscription id '$($SubscriptionId)'"

            $resetDefaultSubscription = $true
            $currentSubscription = (Get-AzContext).Subscription.Id
            $null = Select-AzSubscription $SubscriptionId

            $webAppConfig = Az.Functions.internal\Get-AzWebAppConfiguration -ResourceGroupName $ResourceGroupName `
                                                                            -Name $Name `
                                                                            -ErrorAction SilentlyContinue `
                                                                            @PSBoundParameters
            if ($null -eq $webAppConfig)
            {
                Write-Warning -Message "Failed to retrieve function app site config. 2nd attempt."
            }
        }
    }
    finally
    {
        if ($resetDefaultSubscription)
        {
            Write-Warning -Message "Resetting session context to subscription id '$currentSubscription'"
            $null = Select-AzSubscription $currentSubscription
        }
    }

    if ((-not $webAppConfig) -and $ErrorIfResultIsNull)
    {
        $errorMessage = "Falied to get config for function app name '$Name' in resource group name '$ResourceGroupName'."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "FaliedToGetFunctionAppConfig" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    return $webAppConfig
}

function NewIdentityUserAssignedIdentity
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String[]]
        $IdentityID
    )

    # If creating user assigned identities, only alphanumeric characters (0-9, a-z, A-Z), the underscore (_) and the hyphen (-) are supported.
    $msiUserAssignedIdentities = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ManagedServiceIdentityUserAssignedIdentities

    foreach ($id in $IdentityID)
    {
        $functionAppUserAssignedIdentitiesValue = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Components1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties
        $msiUserAssignedIdentities.Add($IdentityID, $functionAppUserAssignedIdentitiesValue)
    }

    return $msiUserAssignedIdentities
}

function GetShareSuffix
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Int]
        $Length = 8
    )

    # Create char array from 'a' to 'z'
    $letters = 97..122 | ForEach-Object { [char]$_ }
    $numbers = 0..9
    $alphanumericLowerCase = $letters + $numbers

    $suffix = [System.Text.StringBuilder]::new()

    for ($index = 0; $index -lt $Length; $index++)
    {
        $value = $alphanumericLowerCase | Get-Random
        $suffix.Append($value) | Out-Null
    }

    $suffix.ToString()
}

function GetShareName
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $FunctionAppName
    )

    $FunctionAppName = $FunctionAppName.ToLower()

    if ($env:FunctionsTestMode)
    {
        # To support the tests' playback mode, we need to have the same values for each function app creation payload.
        # Adding this test hook will allows us to have a constant share name when creation an app.

        return $FunctionAppName
    }

    <#
    Share name restrictions:
        - A share name must be a valid DNS name.
        - Share names must start with a letter or number, and can contain only letters, numbers, and the dash (-) character.
        - Every dash (-) character must be immediately preceded and followed by a letter or number; consecutive dashes are not permitted in share names.
        - All letters in a share name must be lowercase.
        - Share names must be from 3 through 63 characters long.

    Docs: https://learn.microsoft.com/en-us/rest/api/storageservices/naming-and-referencing-shares--directories--files--and-metadata#share-names
    #>

    # Share name will be function app name + 8 random char suffix with a max length of 60
    $MAXLENGTH = 60
    $SUFFIXLENGTH = 8
    if (($FunctionAppName.Length + $SUFFIXLENGTH) -lt $MAXLENGTH)
    {
        $name = $FunctionAppName
    }
    else
    {
        $endIndex = $MAXLENGTH - $SUFFIXLENGTH - 1
        $name = $FunctionAppName.Substring(0, $endIndex)
    }

    $suffix = GetShareSuffix -Length $SUFFIXLENGTH
    $shareName = $name + $suffix

    return $shareName
}

# Set Linux and Windows supported runtimes
Class Runtime {
    [string]$Name
    [hashtable]$MajorVersions
}

Class MajorVersion {
    [string]$DisplayVersion
    [string]$RuntimeVersion
    [string[]]$SupportedFunctionsExtensionVersions
    [hashtable]$AppSettingsDictionary
    [hashtable]$SiteConfigPropertiesDictionary
    [bool]$IsPreview
    [bool]$IsDeprecated
    [bool]$IsHidden
    [bool]$IsDefault
}

$LinuxRuntimes = @{}
$WindowsRuntimes = @{}
$RuntimeVersions = @{}

function SetLinuxandWindowsSupportedRuntimes
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
    )
    foreach ($fileName in @("LinuxFunctionsStacks.json", "WindowsFunctionsStacks.json"))
    {
        $filePath = Join-Path "$PSScriptRoot/FunctionsStack" $fileName

        if (-not (Test-Path $filePath))
        {
            throw "Unable to create list of supported runtimes. File path '$filePath' does not exist."
        }

        $functionsStack = Get-Content -Path $filePath -Raw | ConvertFrom-Json

        foreach ($stack in $functionsStack.value)
        {
            $runtime = [Runtime]::new()
            $runtime.name = $stack.name
            $majorVersions = @{}

            foreach ($version in $stack.properties.majorVersions)
            {
                if ([String]::IsNullOrEmpty($version.displayVersion))
                {
                    throw "DisplayVersion cannot be null or empty for '$($runtime.name)."
                }

                $majorVersion = [MajorVersion]::new()

                # For DotNet, the runtime version is the same as FunctionsVersion, e.g., 3 for 3.1 and 2 for 2.2
                $displayVersion = $version.displayVersion
                
                if ($runtime.name -eq "DotNet")
                {
                    $displayVersion = [int]$displayVersion
                }

                $majorVersion.DisplayVersion = $displayVersion
                $majorVersion.RuntimeVersion = $version.runtimeVersion
                $majorVersion.SupportedFunctionsExtensionVersions = $version.supportedFunctionsExtensionVersions

                # Add the optional properties if available
                foreach ($propertyName in @("isPreview", "isDeprecated", "isHidden", "isDefault"))
                {
                    if (-not [String]::IsNullOrEmpty($version.$propertyName))
                    {
                        $majorVersion.$propertyName = $version.$propertyName
                    }
                }

                # Skip deprecated runtimes
                if ($majorVersion.IsDeprecated)
                {
                    continue
                }

                # Skip hidden runtimes if $env:FunctionsDisplayHiddenRuntimes is set to false
                if ($majorVersion.isHidden -and (-not $env:FunctionsDisplayHiddenRuntimes))
                {
                    continue
                }

                # Add AppSettingsDictionary properties
                if (-not $version.appSettingsDictionary)
                {
                    throw "AppSettingsDictionary for $($runtime.name) $($majorVersion.DisplayVersion) cannot be null or empty"
                }

                $appSettings = @{}
                foreach ($property in $version.appSettingsDictionary.PSObject.Properties)
                {
                    $appSettings.Add($property.Name, $property.Value)
                }

                $majorVersion.appSettingsDictionary = $appSettings

                # Add siteConfigPropertiesDictionary properties
                if (-not $version.siteConfigPropertiesDictionary)
                {
                    throw "SiteConfigPropertiesDictionary for $($runtime.name) $($majorVersion.DisplayVersion) cannot be null or empty"
                }

                $siteConfigProperties = @{}
                foreach ($property in $version.siteConfigPropertiesDictionary.PSObject.Properties)
                {
                    $siteConfigProperties.Add($property.Name, $property.Value)
                }

                $majorVersion.SiteConfigPropertiesDictionary = $siteConfigProperties

                # Add the major version as a key value pair. These properties will be retrieved via $supportedRuntimes[$Runtime].MajorVersions[$RuntimeVersion]
                $majorVersions[[string]$displayVersion] = $majorVersion

                # Create a dictionary where the key is the runtime and the value is a list of runtime versions.
                # This will be used to register the tab completer for -RuntimeVersion based on the selection of -Runtime parameter.
                if ($RuntimeVersions.ContainsKey($runtime.name))
                {
                    $list = $RuntimeVersions[$runtime.name]
                }
                else
                {
                    $list = @()
                }

                # Sort-Object works differently when sorting strings vs numeric values.
                # Because of this, if the runtimeVersion value contains a ".", we cast this to [double]; otherwise, we cast it to an [int].
                # For the case when the Runtime is PowerShell, we cast the value to string. Otherwise, casting 7.0 to [double] results in 7, which is not correct for our scenario. 
                if ($runtime.name -eq "PowerShell")
                {
                    $displayVersion = [string]$displayVersion
                }
                elseif (([string]$displayVersion).Contains("."))
                {
                    $displayVersion = [double]$displayVersion
                }
                else
                {
                    $displayVersion = [int]$displayVersion
                }

                if (-not $list.Contains($displayVersion))
                {
                    $list += $displayVersion
                    $list = @($list | Sort-Object -Descending)
                    $RuntimeVersions[$runtime.name] = $list
                }
            }

            $runtime.MajorVersions = $majorVersions

            if ($stack.type -like "*LinuxFunctions")
            {
                if (-not $LinuxRuntimes.ContainsKey($runtime.name))
                {
                    $LinuxRuntimes[$runtime.name] = $runtime
                }
            }
            elseif ($stack.type -like "*WindowsFunctions")
            {
                if (-not $WindowsRuntimes.ContainsKey($runtime.name))
                {
                    $WindowsRuntimes[$runtime.name] = $runtime
                }
            }
            else
            {
                throw "Unknown stack type '$($stack.type)'"
            }
        }
    }
}
SetLinuxandWindowsSupportedRuntimes

# New-AzFunction app ArgumentCompleter for the RuntimeVersion parameter
# The values of RuntimeVersion depend on the selection of the Runtime parameter
$GetRuntimeVersionCompleter = {

    param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameters)

    if ($fakeBoundParameters.ContainsKey('Runtime'))
    {
        # RuntimeVersions is defined in SetLinuxandWindowsSupportedRuntimes
        $RuntimeVersions[$fakeBoundParameters.Runtime] | Where-Object {
            $_ -like "$wordToComplete*"
        } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }
    }
    else
    {
        $RuntimeVersions.RuntimeVersion | Sort-Object -Descending | ForEach-Object { $_ }
    }
}
Register-ArgumentCompleter -CommandName New-AzFunctionApp -ParameterName RuntimeVersion -ScriptBlock $GetRuntimeVersionCompleter
