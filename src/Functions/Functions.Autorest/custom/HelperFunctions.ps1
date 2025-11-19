# Load Az.Functions module constants
$constants = @{}
$constants["AllowedStorageTypes"] = @('Standard_GRS', 'Standard_RAGRS', 'Standard_LRS', 'Standard_ZRS', 'Premium_LRS', 'Standard_GZRS')
$constants["RequiredStorageEndpoints"] = @('PrimaryEndpointBlob', 'PrimaryEndpointFile', 'PrimaryEndpointQueue', 'PrimaryEndpointTable')
$constants["DefaultFunctionsVersion"] = '4'
$constants["RuntimeToFormattedName"] = @{
    'dotnet' = 'DotNet'
    'dotnet-isolated' = 'DotNet-Isolated'
    'custom' = 'Custom'
    'node' = 'Node'
    'python' = 'Python'
    'java' = 'Java'
    'powershell' = 'PowerShell'
}
$constants["RuntimeToDefaultOSType"] = @{
    'DotNet'= 'Windows'
    'DotNet-Isolated' = 'Windows'
    'Custom' = 'Windows'
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
$constants["SetDefaultValueParameterWarningMessage"] = "This default value is subject to change over time. Please set this value explicitly to ensure the behavior is not accidentally impacted by future changes."
$constants["DEBUG_PREFIX"] = '[Stacks API] - '
$constants["DefaultCentauriImage"] = 'mcr.microsoft.com/azure-functions/dotnet8-quickstart-demo:1.0'
$constants["FlexConsumptionSupportedRuntimes"] = @('DotNet-Isolated', 'Node', 'Java', 'PowerShell', 'Python','Custom')

foreach ($variableName in $constants.Keys)
{
    if (-not (Get-Variable $variableName -ErrorAction SilentlyContinue))
    {
        Set-Variable $variableName -value $constants[$variableName] -option ReadOnly
    }
}

# These are used to hold the types for the tab completers
$RuntimeToVersionLinux = @{}
$RuntimeToVersionWindows = @{}
$AllRuntimeVersions = @{}
$global:StacksAndTabCompletersInitialized = $false
$AllFunctionsExtensionVersions = New-Object System.Collections.Generic.List[[String]]

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

    $setting = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.NameValuePair
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
        $ApplicationSetting,

        [System.Management.Automation.SwitchParameter]
        $ShowAllAppSettings,

        [System.Management.Automation.SwitchParameter]
        $RedactAppSettings,

        [System.Management.Automation.SwitchParameter]
        $ShowOnlySpecificAppSettings,

        [Parameter(Mandatory=$false)]
        [ValidateNotNullOrEmpty()]
        [String[]]
        $AppSettingsToShow
    )

    if ($RedactAppSettings.IsPresent)
    {
        Write-Warning "App settings have been redacted. Use the Get-AzFunctionAppSetting cmdlet to view them."
    }

    # Create a key value pair to hold the function app settings
    $applicationSettings = @{}

    foreach ($keyName in $ApplicationSetting.Property.Keys)
    {
        if($ShowAllAppSettings.IsPresent)
        {
            $applicationSettings[$keyName] = $ApplicationSetting.Property[$keyName]
        }
        elseif ($RedactAppSettings.IsPresent)
        {
            # When RedactAppSettings is present, all app settings are set to null
            $applicationSettings[$keyName] = $null
        }
        elseif($ShowOnlySpecificAppSettings.IsPresent)
        {
            # When ShowOnlySpecificAppSettings is present, only show the app settings in this list AppSettingsToShow
            if ($AppSettingsToShow.Contains($keyName))
            {
                $applicationSettings[$keyName] = $ApplicationSetting.Property[$keyName]
            }
        }
    }

    return $applicationSettings
}

function GetRuntime
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [Object]
        $Settings,

        [Parameter(Mandatory=$false)]
        [String]
        $AppKind
    )

    $appSettings = ConvertWebAppApplicationSettingToHashtable -ApplicationSetting $Settings -ShowAllAppSettings
    $runtimeName = $appSettings["FUNCTIONS_WORKER_RUNTIME"]

    $runtime = ""
    if (($null -ne $runtimeName) -and ($RuntimeToFormattedName.ContainsKey($runtimeName)))
    {
        $runtime = $RuntimeToFormattedName[$runtimeName]
    }
    elseif ($appSettings.ContainsKey("DOCKER_CUSTOM_IMAGE_NAME"))
    {
        if ($AppKind -match "azurecontainerapps")
        {
            $runtime = "Container App"
        }
        else
        {
            $runtime = "Custom Image"
        }
    }

    return $runtime
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

    if ($App.kind.ToString() -match "azurecontainerapps")
    {
        if ($App.ManagedEnvironmentId)
        {
            $App.AppServicePlan = ($App.ManagedEnvironmentId -split "/")[-1]
        }
    }
    else
    {
        $App.AppServicePlan = ($App.ServerFarmId -split "/")[-1]
    }

    $App.OSType = if ($App.kind.ToString() -match "linux" -or $App.Reserved){ "Linux" } else { "Windows" }

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

    # Add application settings and runtime
    $App.ApplicationSettings = ConvertWebAppApplicationSettingToHashtable -ApplicationSetting $settings -RedactAppSettings

    # Add runtime
    $theRuntimeName = [string]$App.RuntimeName
    $App.Runtime = if ((-not [string]::IsNullOrEmpty($theRuntimeName)) -and ($RuntimeToFormattedName.ContainsKey($theRuntimeName)))
    {
        $RuntimeToFormattedName[$theRuntimeName]
    }
    else
    {
        GetRuntime -Settings $settings -AppKind $App.kind
    }

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
        
        if ($app.kind -match "functionapp")
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

function ValidateFunctionAppNameAvailability
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [System.String]
        $Name,
        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    # Check if the function app name is available
    if ([string]::IsNullOrEmpty($Name))
    {
        $errorMessage = "Function app name cannot be null or empty."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "FunctionAppNameIsNullOrEmpty" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    $result = Az.Functions.internal\Test-AzNameAvailability -Name $Name -Type Site @PSBoundParameters

    if (-not $result.NameAvailable)
    {
        $errorMessage = "Function app name '$Name' is not available.  Please try a different name."
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
        return $RuntimeToVersionLinux
    }
    elseif ($OSType -eq "Windows")
    {
        return $RuntimeToVersionWindows
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

    # if ($SupportedFunctionsVersion -notcontains $FunctionsVersion)
    if ($AllFunctionsExtensionVersions -notcontains $FunctionsVersion)
    {
        $currentlySupportedFunctionsVersions = $AllFunctionsExtensionVersions -join ' and '
        $errorMessage = "Functions version not supported. Currently supported version are: $($currentlySupportedFunctionsVersions)."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "FunctionsVersionNotSupported" `
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

# Returns the stack definition for the given runtime name
#
function GetStackDefinitionForRuntime
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

    $supportedRuntimes = GetSupportedRuntimes -OSType $OSType
    $runtimeJsonDefinition = $null

    $functionsExtensionVersion = "~$FunctionsVersion"
    if (-not $supportedRuntimes.ContainsKey($Runtime))
    {
        $runtimeOptions = FormatListToString -List @($supportedRuntimes.Keys | Sort-Object)
        $errorMessage = "Runtime '$Runtime' on '$OSType' is not supported. Currently supported runtimes: " + $runtimeOptions + "."

        ThrowRuntimeNotSupportedException -Message $errorMessage -ErrorId "RuntimeNotSupported"
    }

    # If runtime version is not provided, iterate through the list to find the default version (if available)
    if (($Runtime -ne 'Custom') -and (-not $RuntimeVersion))
    {
        $versionFound = $false
        $version = GetDefaultOrLatestRuntimeVersion -SupportedRuntimes $supportedRuntimes -Runtime $Runtime -FunctionsExtensionVersion $functionsExtensionVersion
        if (-not [string]::IsNullOrWhiteSpace($version))
        {
            $RuntimeVersion = $version
            $versionFound = $true
        }
        # Error out if we could not find a default or latest version for the given runtime (except for 'Custom'), functions extension version, and os type
        if (-not $versionFound -and ($Runtime -ne 'Custom'))
        {
            $errorMessage = "Runtime '$Runtime' in Functions version '$FunctionsVersion' on '$OSType' is not supported."
            ThrowRuntimeNotSupportedException -Message $errorMessage -ErrorId "RuntimeVersionNotSupported"
        }

        Write-Warning "RuntimeVersion not specified. Setting default value to '$RuntimeVersion'. $SetDefaultValueParameterWarningMessage"
    }

    if ($Runtime -eq 'Custom')
    {
        # Custom runtime does not have a version
        $runtimeJsonDefinition = $supportedRuntimes[$Runtime]
    }
    else
    {
        $runtimeJsonDefinition = $supportedRuntimes[$Runtime] |  Where-Object { $_.Version -eq $RuntimeVersion }
    }

    if (-not $runtimeJsonDefinition)
    {
        $errorMessage = "Runtime '$Runtime' version '$RuntimeVersion' in Functions version '$FunctionsVersion' on '$OSType' is not supported."

        $supporedVersions = @($supportedRuntimes[$Runtime] |
                                Sort-Object -Property Version -Descending |
                                Where-Object { $_.SupportedFunctionsExtensionVersions -contains $functionsExtensionVersion } |
                                Select-Object -ExpandProperty Version)

        if ($supporedVersions.Count -gt 0)
        {
            $runtimeVersionOptions = $supporedVersions -join ", "
            $errorMessage += " Currently supported runtime versions for '$($Runtime)' are: $runtimeVersionOptions."
        }

        ThrowRuntimeNotSupportedException -Message $errorMessage -ErrorId "RuntimeVersionNotSupported"
    }
    
    if ($runtimeJsonDefinition.IsPreview)
    {
        # Write a verbose message to the user if the current runtime is in Preview
        Write-Verbose "Runtime '$Runtime' version '$RuntimeVersion' is in Preview for '$OSType'." -Verbose
    }

    if ($runtimeJsonDefinition.EndOfLifeDate)
    {
        $defaultRuntimeVersion = GetDefaultOrLatestRuntimeVersion -SupportedRuntimes $supportedRuntimes `
                                                                  -Runtime $Runtime `
                                                                  -FunctionsExtensionVersion $functionsExtensionVersion

        Validate-EndOfLifeDate -EndOfLifeDate $runtimeJsonDefinition.EndOfLifeDate `
                               -Runtime $Runtime `
                               -RuntimeVersion $RuntimeVersion `
                               -DefaultRuntimeVersion $defaultRuntimeVersion
    }

    return $runtimeJsonDefinition
}

function GetDefaultOrLatestRuntimeVersion {
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [Hashtable]
        $SupportedRuntimes,
        [Parameter(Mandatory=$true)]
        [String]
        $Runtime,
        [Parameter(Mandatory=$true)]
        [String]
        $FunctionsExtensionVersion
    )

    $defaultVersion = $SupportedRuntimes[$Runtime] |
        Where-Object { $_.IsDefault -and ($_.SupportedFunctionsExtensionVersions -contains $FunctionsExtensionVersion) } |
        Select-Object -First 1 -ExpandProperty Version

    if ($defaultVersion) {
        Write-Debug "$DEBUG_PREFIX Runtime '$Runtime' has a default version '$defaultVersion'"
        return $defaultVersion
    }

    Write-Debug "$DEBUG_PREFIX Runtime '$Runtime' does not have a default version. Finding the latest version."

    $latestVersion = $SupportedRuntimes[$Runtime] |
        Sort-Object -Property Version -Descending |
        Where-Object { $_.SupportedFunctionsExtensionVersions -contains $FunctionsExtensionVersion -and (-not $_.IsPreview) } |
        Select-Object -First 1 -ExpandProperty Version

    if ($latestVersion) {
        Write-Debug "$DEBUG_PREFIX Latest version for runtime '$Runtime' is '$latestVersion'"
    }
    else {
        Write-Debug "$DEBUG_PREFIX No latest version found for runtime '$Runtime'"
    }

    return $latestVersion
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

    $resourceTag = [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ResourceTags]::new()

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
    $properties = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.StringDictionaryProperties

    foreach ($keyName in $currentAppSettings.Keys)
    {
        $properties.Add($keyName, $currentAppSettings[$keyName])
    }

    $appSettings = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.StringDictionary
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
    $msiUserAssignedIdentities = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ManagedServiceIdentityUserAssignedIdentities

    foreach ($id in $IdentityID)
    {
        $functionAppUserAssignedIdentitiesValue = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ManagedServiceIdentityUserAssignedIdentities
        $msiUserAssignedIdentities.Add($id, $functionAppUserAssignedIdentitiesValue)
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

Class Runtime
{
    [string]$Name
    [string]$FullName
    [string]$Version
    [bool]$IsPreview
    [string[]]$SupportedFunctionsExtensionVersions
    [hashtable]$AppSettingsDictionary
    [hashtable]$SiteConfigPropertiesDictionary
    [bool]$IsHidden
    [bool]$IsDefault
    [string]$PreferredOs
    [hashtable]$AppInsightsSettings
    [Nullable[datetime]]$EndOfLifeDate
}

function GetBuiltInFunctionAppStacksDefinition
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$false)]
        [Switch]
        $DoNotShowWarning
    )

    if (-not $DoNotShowWarning)
    {
        $warmingMessage = "Failed to retrieve Function App stack definitions from the ARM API. "
        $warmingMessage += "Please open an issue at https://github.com/Azure/azure-powershell/issues, including the region, and use the following title: "
        $warmingMessage += "[Az.Functions] Failed to retrieve Function App stack definitions from ARM API."
        Write-Warning $warmingMessage
    }

    $filePath = "$PSScriptRoot/FunctionsStack/functionAppStacks.json"
    $json = Get-Content -Path $filePath -Raw

    return $json
}

# Get the Function App Stack definition from the ARM API using the current Azure session
#
function GetFunctionAppStackDefinition
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param (
        [Parameter(Mandatory=$false)]
        [ValidateSet("PremiumAndConsumption", "FlexConsumption")]
        $StackType = "PremiumAndConsumption",

        [Parameter(Mandatory=$false)]
        [System.String]
        $Location,

        [Parameter(Mandatory=$false)]
        [System.String]
        $Runtime
    )

    if ($env:FunctionsTestMode -or ($null -ne $env:SYSTEM_DEFINITIONID -or $null -ne $env:Release_DefinitionId -or $null -ne $env:AZUREPS_HOST_ENVIRONMENT))
    {
        if ($StackType -eq "PremiumAndConsumption")
        {
            Write-Debug "$DEBUG_PREFIX Running on test mode. Using built in json file definition."
            $json = GetBuiltInFunctionAppStacksDefinition -DoNotShowWarning
            return $json
        }
    }

    # Make sure there is an active Azure session
    $context = Get-AzContext -ErrorAction SilentlyContinue
    if (-not $context)
    {
        $errorMessage = "There is no active Azure PowerShell session. Please run 'Connect-AzAccount'"
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "LoginToAzureViaConnectAzAccount" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    # Get the ResourceManagerUrl
    $resourceManagerUrl = $context.Environment.ResourceManagerUrl
    if ([string]::IsNullOrWhiteSpace($resourceManagerUrl))
    {
        Write-Debug "$DEBUG_PREFIX context does not have a ResourceManagerUrl. Using built in json file definition."
        $json = GetBuiltInFunctionAppStacksDefinition
        return $json
    }

    if (-not $resourceManagerUrl.EndsWith('/'))
    {
        $resourceManagerUrl += '/'
    }

    Write-Debug "$DEBUG_PREFIX Get AccessToken."
    $token =  . "$PSScriptRoot/../utils/Unprotect-SecureString.ps1" (Get-AzAccessToken -AsSecureString).Token

    $headers = @{
        Authorization="Bearer $token"
    }

    $apiEndPoint = $null
    $params = @{}
    $apiVersion = '2020-10-01'

    if ($StackType -eq "PremiumAndConsumption")
    {
        $params = @{
            stackOsType = 'All'
            removeDeprecatedStacks = 'true'
        }

        $apiEndPoint = $resourceManagerUrl + "providers/Microsoft.Web/functionAppStacks?api-version={0}" -f $apiVersion
    }
    elseif ($StackType -eq "FlexConsumption")
    {
        $removeHiddenStacks = if ($env:FunctionsTestMode) { $false } else { $true }
        $removeDeprecatedStacks = $true

        $apiEndPoint = $resourceManagerUrl +
            "providers/Microsoft.Web/locations/{0}/functionAppStacks?api-version={1}&removeHiddenStacks={2}&removeDeprecatedStacks={3}&stack={4}&sku=FC1" -f `
            $Location,
            $apiVersion,
            $removeHiddenStacks.ToString().ToLower(),
            $removeDeprecatedStacks.ToString().ToLower(),
            $Runtime.ToString().ToLower()
    }

    Write-Debug "$DEBUG_PREFIX Target API endpoint: $apiEndPoint"

    $maxNumberOfTries = 3
    $currentCount = 1

    Write-Debug "$DEBUG_PREFIX Set TLS 1.2"
    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

    do
    {
        $result = $null
        try
        {
            Write-Debug "$DEBUG_PREFIX Get Function App Stack definitions from ARM API. Attempt $currentCount of $maxNumberOfTries."
            if ($StackType -eq "FlexConsumption")
            {
                $result = Invoke-WebRequest -Uri $apiEndPoint -Method Get -Headers $headers -ErrorAction Stop
            }
            else
            {
                $result = Invoke-WebRequest -Uri $apiEndPoint -Method Get -Headers $headers -body $params -ErrorAction Stop
            }
        }
        catch
        {
            $exception = $_
            Write-Debug "$DEBUG_PREFIX Failed to get Function App Stack definitions from ARM API. Attempt $currentCount of $maxNumberOfTries. Error: $($exception.Message)"
        }

        if ($result)
        {
            # Unauthorized
            if ($result.StatusCode -eq 401)
            {
                # Get a new access token, create new headers and retry
                $token =  . "$PSScriptRoot/../utils/Unprotect-SecureString.ps1" (Get-AzAccessToken -AsSecureString).Token

                $headers = @{
                    Authorization = "Bearer $token"
                }
            }

            if ($result.StatusCode -eq 200)
            {
                $stackDefinition = $result.Content | ConvertFrom-Json

                return $stackDefinition.value | ConvertTo-Json -Depth 100
            }
        }

        $currentCount++

    } while ($currentCount -le $maxNumberOfTries)

    if ($StackType -eq "PremiumAndConsumption")
    {
        # At this point, we failed to get the stack definition from the ARM API.
        # Return the built in json file definition
        $json = GetBuiltInFunctionAppStacksDefinition
        return $json
    }
}

function ContainsProperty
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.Object]
        $Object,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $PropertyName
    )

    $result = $Object | Get-Member -MemberType Properties | Where-Object { $_.Name -eq $PropertyName }
    return ($null -ne $result)
}

function ParseMinorVersion
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$false)]
        [System.String]
        $StackMinorVersion,

        [Parameter(Mandatory=$false)]
        [System.String]
        $PreferredOs,

        [Parameter(Mandatory=$true)]
        [PSCustomObject]
        $RuntimeSettings,

        [Parameter(Mandatory=$false)]
        [System.String]
        $RuntimeFullName,

        [Parameter(Mandatory=$false)]
        [Bool]
        $StackIsLinux
    )

    # If this FunctionsVersion is not supported, skip it
    if ($RuntimeSettings.supportedFunctionsExtensionVersions -notcontains "~$DefaultFunctionsVersion")
    {
        $supportedFunctionsExtensionVersions = $RuntimeSettings.supportedFunctionsExtensionVersions -join ", "
        Write-Debug "$DEBUG_PREFIX Minimium required Functions version '$DefaultFunctionsVersion' is not supported. Runtime supported Functions versions: $supportedFunctionsExtensionVersions. Skipping..."
        return
    }
    else
    {
        Write-Debug "$DEBUG_PREFIX Minimium required Functions version '$DefaultFunctionsVersion' is supported."
    }

    $runtimeName = GetRuntimeName -AppSettingsDictionary $RuntimeSettings.AppSettingsDictionary

    $version = $null
    if ($RuntimeName -eq "Java" -and $RuntimeSettings.RuntimeVersion -eq "1.8")
    {
        # Java 8 is only supported in Windows. The display value is 8; however, the actual SiteConfig.JavaVersion is 1.8
        $version = $StackMinorVersion
    }
    else
    {
        $version = $RuntimeSettings.RuntimeVersion
    }

    $runtimeVersion = GetRuntimeVersion -Version $version -StackIsLinux $StackIsLinux

    # For Java function app, the version from the Stacks API is 8.0, 11.0, and 17.0. However, this is a breaking change which cannot be supported in the current release.
    # We will convert the version to 8, 11, and 17. This change will be reverted for the May 2024 breaking release.
    if ($RuntimeName -eq "Java")
    {
        $runtimeVersion = [int]$runtimeVersion
        Write-Debug "$DEBUG_PREFIX Runtime version for Java is modified to be compatible with the current release. Current version '$runtimeVersion'"
    }

    # For DotNet function app, the version from the Stacks API is 6.0. 7.0, and 8.0. However, this is a breaking change which cannot be supported in the current release.
    # We will convert the version to 6, 7, and 8. This change will be reverted for the May 2024 breaking release.
    if ($RuntimeName -like "DotNet*")
    {
        if ($runtimeVersion.EndsWith(".0"))
        {
            $runtimeVersion = [int]$runtimeVersion
        }
        Write-Debug "$DEBUG_PREFIX Runtime version for $runtimeName is modified to be compatible with the current release. Current version '$runtimeVersion'"
    }

    $runtime = [Runtime]::new()
    $runtime.Name = $runtimeName
    $runtime.AppSettingsDictionary = GetDictionary -SettingsDictionary $RuntimeSettings.AppSettingsDictionary
    $runtime.SiteConfigPropertiesDictionary = GetDictionary -SettingsDictionary $RuntimeSettings.SiteConfigPropertiesDictionary
    $runtime.AppInsightsSettings = GetDictionary -SettingsDictionary $RuntimeSettings.AppInsightsSettings
    $runtime.SupportedFunctionsExtensionVersions = GetSupportedFunctionsExtensionVersion -SupportedFunctionsExtensionVersions $RuntimeSettings.SupportedFunctionsExtensionVersions
    $runtime.EndOfLifeDate = $null

    if (![string]::IsNullOrWhiteSpace($RuntimeSettings.EndOfLifeDate))
    {
        $runtime.EndOfLifeDate = ParseEndOfLifeDate -Runtime $runtimeName -DateString $RuntimeSettings.EndOfLifeDate
    }

    foreach ($propertyName in @("isPreview", "isHidden", "isDefault"))
    {
        if (ContainsProperty -Object $RuntimeSettings -PropertyName $propertyName)
        {
            Write-Debug "$DEBUG_PREFIX Runtime setting contains '$propertyName'"
            $runtime.$propertyName = $RuntimeSettings.$propertyName
        }
    }

    # When $env:FunctionsDisplayHiddenRuntimes is set to true, we will display all runtimes
    if ($runtime.IsHidden -and (-not $env:FunctionsDisplayHiddenRuntimes))
    {
        Write-Debug "$DEBUG_PREFIX Runtime $runtimeName is hidden. Skipping..."
        return
    }

    if ($runtimeVersion -and ($runtimeName -ne "custom"))
    {
        Write-Debug "$DEBUG_PREFIX Runtime version: $runtimeVersion"
        $runtime.Version = $runtimeVersion
    }
    else
    {
        Write-Debug "$DEBUG_PREFIX Runtime $runtimeName does not have a version."
        $runtime.Version = ""
    }

    if ($RuntimeFullName)
    {
        $runtime.FullName = $RuntimeFullName
    }

    if ($PreferredOs)
    {
        $runtime.PreferredOs = $PreferredOs
    }

    $targetOs = if ($StackIsLinux) { 'Linux' } else { 'Windows' }
    Write-Debug "$DEBUG_PREFIX Runtime '$runtimeName' for '$targetOs' parsed successfully."

    return $runtime
}


function GetRuntimeVersion
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$false)]
        [System.String]
        $Version,

        [Parameter(Mandatory=$false)]
        [Bool]
        $StackIsLinux
    )

    if (-not $Version)
    {
        # Some runtimes do not have a version like custom handler
        return
    }

    if ($StackIsLinux)
    {
        $Version = $Version.Split('|')[1]
    }
    else
    {
        $valuesToReplace = @('v', '~')
        foreach ($value in $valuesToReplace)
        {
            if ($Version.Contains($value))
            {
                $Version = $Version.Replace($value, '')
            }
        }
    }

    $Version =  $Version.Trim()
    return $Version
}

function GetDictionary
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [PSCustomObject]
        $SettingsDictionary
    )

    $dictionary = @{}
    foreach ($property in $SettingsDictionary.PSObject.Properties)
    {
        $dictionary.Add($property.Name, $property.Value)
    }

    return $dictionary
}

function GetRuntimeName
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [PSCustomObject]
        $AppSettingsDictionary
    )

    $settingHashTable = GetDictionary -SettingsDictionary $AppSettingsDictionary

    $name = $settingHashTable['FUNCTIONS_WORKER_RUNTIME']

    if ($RuntimeToFormattedName.ContainsKey($name))
    {
        return $RuntimeToFormattedName[$name]
    }

    return $name
}

function GetSupportedFunctionsExtensionVersion
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String[]]
        $SupportedFunctionsExtensionVersions
    )

    $supportedExtensionsVersions = @()

    foreach ($extensionVersion in $SupportedFunctionsExtensionVersions)
    {
        if ($extensionVersion -ge "~$DefaultFunctionsVersion")
        {
            $supportedExtensionsVersions += $extensionVersion
        }
    }

    return $supportedExtensionsVersions
}

function AddRuntimeToDictionary
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        $Runtime,

        [Parameter(Mandatory=$true)]
        [hashtable]
        [Ref]$RuntimeToVersionDictionary
    )

    if ($RuntimeToVersionDictionary.ContainsKey($Runtime.Name))
    {
        $list = $RuntimeToVersionDictionary[$Runtime.Name]
    }
    else
    {
        $list = New-Object System.Collections.Generic.List[[Runtime]]
    }

    # Only add runtime versions that are not in the list already
    foreach ($existingRuntime in $list)
    {
        if ($existingRuntime.Version -eq $Runtime.Version)
        {
            Write-Debug "$DEBUG_PREFIX Runtime version $($Runtime.Version) for runtime $($Runtime.Name) already exists. Skipping..."
            return
        }
    }

    Write-Debug "$DEBUG_PREFIX Adding runtime version $($Runtime.Version) for runtime $($Runtime.Name)."
    $list.Add($Runtime)
    $RuntimeToVersionDictionary[$Runtime.Name] = $list

    # Add the runtime name and version to the all runtimes list. This is used for the tab completers
    if ($AllRuntimeVersions.ContainsKey($runtime.Name))
    {
        $allVersionsList = $AllRuntimeVersions[$Runtime.Name]
    }
    else
    {
        $allVersionsList = @()
    }

    if (-not $allVersionsList.Contains($Runtime.Version))
    {
        $allVersionsList += $Runtime.Version
        $AllRuntimeVersions[$Runtime.name] = $allVersionsList
    }

    # Add Functions extension version to AllFunctionsExtensionVersions. This is used for the tab completers
    foreach ($extensionVersion in $Runtime.SupportedFunctionsExtensionVersions)
    {
        $version = $extensionVersion.Replace("~", "")
        if (-not $AllFunctionsExtensionVersions.Contains($version))
        {
            $AllFunctionsExtensionVersions.Add($version)
        }
    }
}

function SetLinuxandWindowsSupportedRuntimes
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param ()

    Write-Debug "$DEBUG_PREFIX Build function stack definitions."

    # Get Function App Runtime Definitions
    $json = GetFunctionAppStackDefinition
    $functionAppStackDefinition = $json | ConvertFrom-Json

    # Build a map of runtime -> runtime version -> runtime version properties
    foreach ($stackDefinition in $functionAppStackDefinition)
    {
        $preferredOs = $stackDefinition.properties.preferredOs

        $stackName = $stackDefinition.properties.value
        Write-Debug "$DEBUG_PREFIX Parsing stack name: $stackName"

        foreach ($majorVersion in $stackDefinition.properties.majorVersions)
        {
            foreach ($minorVersion in $majorVersion.minorVersions)
            {
                $runtimeFullName = $minorVersion.DisplayText
                Write-Debug "$DEBUG_PREFIX runtime full name: $runtimeFullName"

                $stackMinorVersion = $minorVersion.value
                Write-Debug "$DEBUG_PREFIX stack minor version: $stackMinorVersion"
                $runtime = $null

                if (ContainsProperty -Object $minorVersion.stackSettings -PropertyName "windowsRuntimeSettings")
                {
                    $runtime = ParseMinorVersion -RuntimeSettings $minorVersion.stackSettings.windowsRuntimeSettings `
                                                 -RuntimeFullName $runtimeFullName `
                                                 -PreferredOs $preferredOs `
                                                 -StackMinorVersion $stackMinorVersion

                    if ($runtime)
                    {
                        AddRuntimeToDictionary -Runtime $runtime -RuntimeToVersionDictionary ([Ref]$RuntimeToVersionWindows)
                    }
                }

                if (ContainsProperty -Object $minorVersion.stackSettings -PropertyName "linuxRuntimeSettings")
                {
                    $runtime = ParseMinorVersion -RuntimeSettings $minorVersion.stackSettings.linuxRuntimeSettings `
                                                 -RuntimeFullName $runtimeFullName `
                                                 -PreferredOs $preferredOs `
                                                 -StackIsLinux $true

                    if ($runtime)
                    {
                        AddRuntimeToDictionary -Runtime $runtime -RuntimeToVersionDictionary ([Ref]$RuntimeToVersionLinux)
                    }
                }
            }
        }
    }
}

# This method pulls down the Functions stack definitions from the ARM API and builds a list of supported runtimes and runtime versions.
# This is used to build the tab completers for the New-AzFunctionApp cmdlet.
function RegisterFunctionsTabCompleters
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param ()

    if (-not $global:StacksAndTabCompletersInitialized)
    {
        SetLinuxandWindowsSupportedRuntimes

        # New-AzFunction app ArgumentCompleter for the RuntimeVersion parameter
        # The values of RuntimeVersion depend on the selection of the Runtime parameter
        $GetRuntimeVersionCompleter = {

            param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameters)

            if ($fakeBoundParameters.ContainsKey('Runtime'))
            {
                # RuntimeVersions is defined in SetLinuxandWindowsSupportedRuntimes
                $AllRuntimeVersions[$fakeBoundParameters.Runtime] | Where-Object {
                    $_ -like "$wordToComplete*"
                } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }
            }
        }

        # New-AzFunction app ArgumentCompleter for the Runtime parameter
        $GetAllRuntimesCompleter = {

            param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameters)

            $runtimeValues = $AllRuntimeVersions.Keys | Sort-Object | ForEach-Object { $_ }

            $runtimeValues | Where-Object { $_ -like "$wordToComplete*" }
        }

        # New-AzFunction app ArgumentCompleter for the FunctionsVersion parameter
        $GetAllFunctionsVersionsCompleter = {

            param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameters)

            $functionsVersions = $AllFunctionsExtensionVersions | Sort-Object | ForEach-Object { $_ }

            $functionsVersions | Where-Object { $_ -like "$wordToComplete*" }
        }

        # Get-AzFunctionFlexConsumptionRuntime app ArgumentCompleter for the Runtime parameter
        $GetFlexConsumptionRuntimeCompleter = {

            param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameters)

            $runtimeValues = $AllRuntimeVersions.Keys | Sort-Object | ForEach-Object { if ($_ -ne "dotnet") { $_ } }

            $runtimeValues | Where-Object { $_ -like "$wordToComplete*" }
        }

        # Register tab completers
        Register-ArgumentCompleter -CommandName New-AzFunctionApp -ParameterName FunctionsVersion -ScriptBlock $GetAllFunctionsVersionsCompleter
        Register-ArgumentCompleter -CommandName New-AzFunctionApp -ParameterName Runtime -ScriptBlock $GetAllRuntimesCompleter
        Register-ArgumentCompleter -CommandName New-AzFunctionApp -ParameterName RuntimeVersion -ScriptBlock $GetRuntimeVersionCompleter

        Register-ArgumentCompleter -CommandName Get-AzFunctionAppFlexConsumptionRuntime -ParameterName Runtime -ScriptBlock $GetFlexConsumptionRuntimeCompleter

        $global:StacksAndTabCompletersInitialized = $true
    }
}

function ValidateCpuAndMemory
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$false)]
        [Double]
        $ResourceCpu,

        [Parameter(Mandatory=$false)]
        [System.String]
        $ResourceMemory
    )

    if (-not $ResourceCpu -and -not $ResourceMemory)
    {
        return
    }

    if ($ResourceCpu -and -not $ResourceMemory)
    {
        $errorMessage = "ResourceMemory must be specified when ResourceCpu is specified."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "ResourceMemoryNotSpecified" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    if ($ResourceMemory -and -not $ResourceCpu)
    {
        $errorMessage = "ResourceCpu must be specified when ResourceMemory is specified."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "ResourceCpuNotSpecified" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    try
    {
        if (-not $ResourceMemory.ToLower().EndsWith("gi"))
        {
            throw
        }

        # Attempt to parse the numerical part of ResourceMemory to ensure it's a valid format.
        [double]::Parse($ResourceMemory.Substring(0, $ResourceMemory.Length - 2)) | Out-Null
    }
    catch
    {
        $errorMessage = "ResourceMemory must be specified in Gi. Please provide a correct value. e.g., 4.0Gi."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "InvalidResourceMemory" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }
}

function FormatFxVersion
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Image
    )

    $fxVersion = $Image

    # Normalize case and remove HTTP(s) prefixes if present.
    $normalizedImage = $Image -replace '^(https?://)', '' -replace ' ', ''

    # Prepend "DOCKER|" if not already prefixed with "docker|" (case-insensitive).
    if (-not $normalizedImage.StartsWith('docker|', [StringComparison]::OrdinalIgnoreCase))
    {
        $fxVersion = "DOCKER|$Image"
    }

    return $fxVersion
}

function GetManagedEnvironment
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $Environment,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ResourceGroupName
    )

    $azAppModuleName = "Az.App"
    if (-not (Get-Module -ListAvailable -Name $azAppModuleName))
    {
        $errorMessage = "The '$azAppModuleName' module is required when creating Function Apps ACA. Please install the module and try again."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "RequiredModuleNotAvailable" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    Import-Module -Name $azAppModuleName -Force -ErrorAction Stop

    $managedEnv = Get-AzContainerAppManagedEnv -Name $Environment `
                                               -ResourceGroupName $ResourceGroupName `
                                               -ErrorAction SilentlyContinue

    if (-not $managedEnv)
    {
        $errorMessage = "Failed to get the managed environment '$Environment' in resource group name '$ResourceGroupName'."
        $errorMessage += " Please make sure the managed environment is valid."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "FailedToGetEnvironment" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    return $managedEnv
}

function ParseEndOfLifeDate
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Runtime,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $DateString
    )

    try
    {
        $dateTime = [DateTime]::ParseExact($DateString, "ddd MMM dd yyyy HH:mm:ss 'GMT'K '(Coordinated Universal Time)'",
                                           [System.Globalization.CultureInfo]::InvariantCulture)
    }
    catch
    {
        $message = "Failed to parse the EndOfLifeDate '$DateString' for '$Runtime' runtime. Skipping..."
        Write-Warning $message
    }

    return $dateTime
}

function Get-Today {
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param ()

    if ($env:FunctionsTestMode)
    {
        # Test hook to support running the tests in playback mode.
        return [datetime]"2024-01-01"
    }
    return Get-Date
}

function New-PlanName
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceGroupName
    )

    if ($env:FunctionsTestMode -and $env:FunctionsUseFlexStackTestData)
    {
        $suffix = "-0000"
    }
    else
    {
        $suffix = "-" + ([guid]::NewGuid().ToString().Substring(0,4))
    }

    $name = $ResourceGroupName -replace '[^a-zA-Z0-9]', ''
    $prefix = "ASP-$name"
    return $prefix.Substring(0, [Math]::Min(35, $prefix.Length)) + $suffix
}

function New-FlexConsumptionAppPlan
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Location,

        [System.Management.Automation.SwitchParameter]
        $EnableZoneRedundancy,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    foreach ($paramName in @("Location", "EnableZoneRedundancy"))
    {
        if ($PSBoundParameters.ContainsKey($paramName))
        {
            $PSBoundParameters.Remove($paramName)  | Out-Null
        }
    }

    $servicePlan = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.AppServicePlan
    $servicePlan.Location = $Location
    $servicePlan.Reserved = $true
    $servicePlan.Kind = "functionapp"
    $servicePlan.SkuName = "FC1"
    $servicePlan.SkuTier = "FlexConsumption"
    $servicePlan.SkuSize = "FC"
    $servicePlan.SkuFamily = "FC"

    if ($EnableZoneRedundancy.IsPresent)
    {
        $servicePlan.ZoneRedundant = $true
        $servicePlan.Capacity = 3
    }

    # Add plan definition
    $PSBoundParameters.Add("AppServicePlan", $servicePlan)  | Out-Null

    # Save the ErrorActionPreference
    $currentErrorActionPreference = $ErrorActionPreference
    $ErrorActionPreference = 'Stop'
    $plan = $null

    $activityName = "Creating Flex Consumption Plan"

    try
    {
        Write-Progress -Activity $activityName `
                       -Status "Creating plan $Name in resource group $ResourceGroupName" `
                       -PercentComplete 50

        $plan = Az.Functions.internal\New-AzFunctionAppPlan @PSBoundParameters

        Write-Progress -Activity $activityName `
                       -Status "Plan creation completed successfully." `
                       -Completed
    }
    catch
    {
        $errorMessage = GetErrorMessage -Response $_
        if ($errorMessage)
        {
            $exception = [System.InvalidOperationException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "FailedToCreateFunctionAppFlexConsumPlan" `
                                    -ErrorMessage $errorMessage `
                                    -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                    -Exception $exception
        }

        throw $_
    }
    finally
    {
        $ErrorActionPreference = $currentErrorActionPreference
    }

    return $plan
}

function Get-StorageAccountInfo
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory = $true)]
        [System.String]
        $Name,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    $paramsToRemove = @(
        "Name"
    )
    foreach ($paramName in $paramsToRemove)
    {
        if ($PSBoundParameters.ContainsKey($paramName))
        {
            $PSBoundParameters.Remove($paramName)  | Out-Null
        }
    }

    # Get storage account
    $storageAccountInfo = GetStorageAccount -Name $Name @PSBoundParameters

    if (-not $storageAccountInfo)
    {
        $errorMessage = "Storage account '$Name' does not exist."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "StorageAccountNotFound" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    if ($storageAccountInfo.ProvisioningState -ne "Succeeded")
    {
        $errorMessage = "Storage account '$Name' is not ready. Please run 'Get-AzStorageAccount' and ensure that the ProvisioningState is 'Succeeded'"
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

    # Validate endpoints
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

    return $storageAccountInfo
}

function Get-ConnectionString
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        $StorageAccountInfo
    )

    if (-not $StorageAccountInfo)
    {
        throw "StorageAccountInfo cannot be null."
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

function Format-FlexConsumptionLocation
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param (
        [Parameter(Mandatory = $true)]
        [System.String]
        $Location
    )

    $normalizedLocation = $Location.ToLower().Replace(" ", "")
    return $normalizedLocation
}

function Resolve-UserAssignedIdentity
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory = $true)]
        [System.String]
        $IdentityResourceId,

        $SubscriptionId,
        $HttpPipelineAppend,
        $HttpPipelinePrepend
    )

    $paramsToRemove = @(
        "IdentityResourceId"
    )
    foreach ($paramName in $paramsToRemove)
    {
        if ($PSBoundParameters.ContainsKey($paramName))
        {
            $PSBoundParameters.Remove($paramName)  | Out-Null
        }
    }

    # Parse the resource ID using regex
    if ($IdentityResourceId -match "^/subscriptions/(?<SubscriptionId>[^/]+)/resourceGroups/(?<ResourceGroup>[^/]+)/providers/Microsoft\.ManagedIdentity/userAssignedIdentities/(?<IdentityName>[^/]+)$") {
        $subscriptionId = $matches['SubscriptionId']
        $resourceGroup = $matches['ResourceGroup']
        $identityName   = $matches['IdentityName']

        if ([string]::IsNullOrEmpty($resourceGroup) -or [string]::IsNullOrEmpty($identityName) -or [string]::IsNullOrEmpty($subscriptionId))
        {
            $errorMessage = "Invalid identity resource ID: '$IdentityResourceId'. Unable to parse resource group name and identity name."
            $exception = [System.InvalidOperationException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "InvalidIdentityResourceId" `
                                -ErrorMessage $errorMessage `
                                -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                -Exception $exception
        }

        # Check if identity exists
        $identity = Az.Functions.internal\Get-AzUserAssignedIdentity -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroup -ResourceName $identityName -ErrorAction SilentlyContinue @PSBoundParameters

        if (-not $identity)
        {
            $errorMessage = "User-assigned identity '$identityName' does not exist in resource group '$resourceGroup' in subscription '$subscriptionId'."
            $exception = [System.InvalidOperationException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "StorageAccountHasNoKeyValue" `
                                -ErrorMessage $errorMessage `
                                -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                -Exception $exception

        }

        return $identity
    }
    else
    {
        $errorMessage = "Invalid resource ID format: '$IdentityResourceId'."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "InvalidIdentityResourceIdFormat" `
                            -ErrorMessage $errorMessage `
                            -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                            -Exception $exception
    }
}

function Get-FlexFunctionAppRuntime
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(ParameterSetName = 'AllVersions', Mandatory = $true)]
        [Parameter(ParameterSetName = 'ByVersion', Mandatory = $true)]
        [Parameter(ParameterSetName = 'DefaultOrLatest', Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Location,

        [Parameter(ParameterSetName = 'AllVersions', Mandatory = $true)]
        [Parameter(ParameterSetName = 'ByVersion', Mandatory = $true)]
        [Parameter(ParameterSetName = 'DefaultOrLatest', Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Runtime,

        [Parameter(ParameterSetName = 'ByVersion', Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Version,

        [Parameter(ParameterSetName = 'DefaultOrLatest', Mandatory = $true)]
        [switch]
        $DefaultOrLatest
    )

    # Map dotnet-isolated -> dotnet for this endpoint
    $runtimeForAPI = if ($Runtime -eq 'dotnet-isolated') { 'dotnet' } else { $Runtime }

    $json = $null

    # Format location for Flex Consumption (remove spaces and make lowercase)
    $formattedLocation = Format-FlexConsumptionLocation -Location $Location

    if ($env:FunctionsTestMode -and $env:FunctionsUseFlexStackTestData)
    {
        # Test hook to use mock Flex Consumption stacks during playback mode.
        if ($formattedLocation -ne "eastasia")
        {
            $message = "In test mode, only 'East Asia' location is supported for Flex Consumption stack definitions."
            throw $message
        }

        $filePath = Join-Path -Path $PSScriptRoot "FunctionsStackFlexData/$formattedLocation/$runtimeForAPI.json"
        $json = Get-Content $filePath -Raw -ErrorAction Stop
    }

    # Get Flex Consumption Function App Runtime Definitions
    else
    {
        $json = GetFunctionAppStackDefinition -StackType FlexConsumption -Location $formattedLocation -Runtime $runtimeForAPI
    }

    if (-not $json)
    {
        $errorMessage = "Failed to retrieve Flex Consumption Function App stack definitions from the ARM API for runtime '{0}' in location '{1}'. Please try a different region." -f
                        $Runtime, $Location
        $exception = [System.InvalidOperationException]::new($errorMessage)
        ThrowTerminatingError -ErrorId "FlexConsumptionStackRetrievalFailed" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    $functionAppStackDefinition = $json | ConvertFrom-Json
    $stacks = New-Object -TypeName 'System.Collections.Generic.List[PSCustomObject]'

    # Flatten: runtime -> majorVersions -> minorVersions
    foreach ($item in $functionAppStackDefinition)
    {
        $runtimeName = $item.name
        foreach ($maj in ($item.properties.majorVersions | Where-Object { $_ }))
        {
            foreach ($min in ($maj.minorVersions | Where-Object { $_ }))
            {
                # We only consider linuxRuntimeSettings for Flex Consumption
                $linux = $min.stackSettings.linuxRuntimeSettings

                if (-not $linux) { continue }

                # Only FC1 (Flex Consumption)
                $sku = @($linux.Sku) | Where-Object {
                    $_.skuCode -eq 'FC1'
                }

                if (-not $sku) { continue }

                # Name preference: FUNCTIONS_WORKER_RUNTIME if present
                $runtimeName = if ($linux.appSettingsDictionary.FUNCTIONS_WORKER_RUNTIME) {
                    $linux.appSettingsDictionary.FUNCTIONS_WORKER_RUNTIME
                }

                # Set runtime name and version
                if ($sku.skuCode -eq 'FC1') {
                    if (-not $runtimeName) {
                        $runtimeName = $sku.functionAppConfigProperties.Runtime.Name
                    }
                    $runtimeVersion = $sku.functionAppConfigProperties.Runtime.Version
                }

                # Parse end of life date
                $runtimeEndOfLifeDate = if ($linux.endOfLifeDate) {  ParseEndOfLifeDate -Runtime $runtimeName -DateString $linux.endOfLifeDate } else { $null }

                # Create runtime object
                $result = [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.FunctionAppFlexConsumptionRuntime]::new()
                $result.Name          = $runtimeName
                $result.Version       = $runtimeVersion
                $result.IsDefault     = [bool]$linux.isDefault
                $result.EndOfLifeDate = $runtimeEndOfLifeDate
                $result.Sku           = [PSCustomObject]$sku

                if (-not $result.PSTypeNames.Contains('Az.Functions.FunctionAppFlexConsumptionRuntime.Display'))
                {
                    # Insert synthetic PSTypeName so our custom view (with Sku summary) overrides
                    # the autorest-generated runtime view which omits Sku.
                    $result.PSTypeNames.Insert(0,'Az.Functions.FunctionAppFlexConsumptionRuntime.Display') | Out-Null
                }

                $stacks.Add($result)
            }
        }

        switch ($PSCmdlet.ParameterSetName) {

            'AllVersions' {
                # Return all versions for $Runtime
                return $stacks
            }

            'ByVersion' {
                # Return specific version
                $matched = $stacks | Where-Object { $_.Version -eq $Version } | Select-Object -First 1
                if (-not $matched)
                {
                    $map = @{
                        '11'  = '11.0'
                        '8'   = '8.0'
                        '8.0' = '8'
                        '7'   = '7.0'
                        '6.0' = '6'
                        '1.8' = '8.0'
                        '17'  = '17.0'
                    }

                    if ($map.ContainsKey($Version))
                    {
                        $newVersion = $map[$Version]
                        $matched = $stacks | Where-Object { $_.Version -eq $newVersion } | Select-Object -First 1
                    }
                }

                if (-not $matched)
                {
                    $supportedVersions = $stacks | ForEach-Object { $_.Version } | Sort-Object | Get-Unique
                    $supportedVersionsString = $supportedVersions -join ", "
                    $errorMessage = "Invalid version {0} for runtime {1} for function apps on the Flex Consumption plan. Supported versions for runtime {1} are {2}." -f
                                    $Version, $Runtime, $supportedVersionsString
                    $exception = [System.InvalidOperationException]::New($errorMessage)
                    ThrowTerminatingError -ErrorId "RuntimeVersionNotSupportedInFlexConsumption" `
                                          -ErrorMessage $errorMessage `
                                          -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                          -Exception $exception
                }

                return $matched
            }

            'DefaultOrLatest' {
                # Return default/latest version, which ever is the newest one
                $defaultStack = $stacks | Where-Object { $_.IsDefault } | Sort-Object -Property Version -Descending | Select-Object -First 1

                if (-not $defaultStack)
                {
                    # Fallback: get latest version
                    $defaultStack = $stacks | Sort-Object -Property Version -Descending | Select-Object -First 1

                    if (-not $defaultStack)
                    {
                        $errorMessage = "No runtime versions found for runtime '$Runtime' in location '$Location'."
                        $exception = [System.InvalidOperationException]::New($errorMessage)
                        ThrowTerminatingError -ErrorId "NoRuntimeVersionsFoundInFlexConsumption" `
                                            -ErrorMessage $errorMessage `
                                            -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                            -Exception $exception
                    }
                }

                return $defaultStack
            }
        }
    }
}

function Validate-InstanceMemoryMB
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory=$true)]
        [PSCustomObject]
        $SkuInstanceMemoryMB,

        [Parameter(Mandatory=$false)]
        [int]
        $InstanceMemoryMB
    )

    $skuMemEntries = @($SkuInstanceMemoryMB) | Where-Object { $_ -ne $null }

    if (-not $skuMemEntries)
    {
        $errorMessage = "No instance memory sizes were returned by the SKU payload. Unable to determine a default size."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "NoInstanceMemorySizesFound" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    # Normalize and dedupe sizes (ints)
    $allowedSizes = $skuMemEntries | ForEach-Object { [int]$_.size } | Where-Object { $_ -gt 0 } | Sort-Object -Unique

    # Find default; if none is flagged, fall back to the smallest size (common platform pattern)
    $defaultSize = $skuMemEntries | Where-Object { $_.isDefault -eq $true } | Select-Object -ExpandProperty size -First 1

    if ($null -eq $defaultSize)
    {
        $defaultSize = $allowedSizes | Select-Object -First 1
    }

    if ($InstanceMemoryMB -gt 0)
    {
        # Strict validation: must be one of the discrete supported sizes for this runtime/region
        if ($allowedSizes -notcontains [int]$InstanceMemoryMB)
        {
            $errorMessage = "Invalid InstanceMemoryMB '{0}'. Allowed values for this runtime are: {1}. " +
                            "Use one of the supported sizes." -f $InstanceMemoryMB, ($allowedSizes -join ', ')
            $exception = [System.ArgumentOutOfRangeException]::New($errorMessage)
            ThrowTerminatingError -ErrorId "InstanceMemoryMBNotSupported" `
                                  -ErrorMessage $errorMessage `
                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidArgument) `
                                  -Exception $exception
        }
    }
    else
    {
        # If not provided, set to default size
        $InstanceMemoryMB = [int]$defaultSize
        Write-Warning "InstanceMemoryMB not specified. Setting default value to '$InstanceMemoryMB'. $SetDefaultValueParameterWarningMessage"
    }

    return $InstanceMemoryMB
}

function Validate-MaximumInstanceCount
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory = $true)]
        [PSCustomObject]
        $SkuMaximumInstanceCount,   # expects keys: lowestMaximumInstanceCount, highestMaximumInstanceCount, defaultValue

        [Parameter(Mandatory = $false)]
        [int]
        $MaximumInstanceCount
    )

    # Validate SKU payload
    if (-not $SkuMaximumInstanceCount -or
        -not $SkuMaximumInstanceCount.lowestMaximumInstanceCount -or
        -not $SkuMaximumInstanceCount.highestMaximumInstanceCount) {
        $errorMessage = "No maximum instance count range was returned by the SKU payload. Unable to determine a default value."
        $exception = [System.InvalidOperationException]::new($errorMessage)
        ThrowTerminatingError -ErrorId "NoMaximumInstanceCountFound" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }

    # Extract range and default
    $min = [int]$SkuMaximumInstanceCount.lowestMaximumInstanceCount
    $max = [int]$SkuMaximumInstanceCount.highestMaximumInstanceCount
    $default = [int]$SkuMaximumInstanceCount.defaultValue

    if ($MaximumInstanceCount -gt 0)
    {
        # Validate range
        if ($MaximumInstanceCount -lt $min -or $MaximumInstanceCount -gt $max) {
            $errorMessage = "Invalid MaximumInstanceCount '{0}'. Allowed range for this runtime is {1} - {2}. " +
                            "Use a value within the supported range." -f $MaximumInstanceCount, $min, $max
            $exception = [System.ArgumentOutOfRangeException]::new('MaximumInstanceCount', $MaximumInstanceCount, $errorMessage)
            ThrowTerminatingError -ErrorId "MaximumInstanceCountOutOfRange" `
                                  -ErrorMessage $errorMessage `
                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidArgument) `
                                  -Exception $exception
        }
    }
    else
    {
        # If not provided, set to default
        $MaximumInstanceCount = $default
        Write-Warning "MaximumInstanceCount not specified. Setting default value to '$MaximumInstanceCount'. $SetDefaultValueParameterWarningMessage"
    }

    return $MaximumInstanceCount
}

function Test-FlexConsumptionLocation
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $Location,

        [Parameter(Mandatory = $false)]
        [System.Management.Automation.SwitchParameter]
        $ZoneRedundancy
    )

    # Validate Flex Consumption location
    $formattedLocation = Format-FlexConsumptionLocation -Location $Location
    $flexConsumptionRegions = Get-AzFunctionAppAvailableLocation -PlanType FlexConsumption -ZoneRedundancy:$ZoneRedundancy

    $found = $false
    foreach ($region in $flexConsumptionRegions)
    {
        $regionName = Format-FlexConsumptionLocation -Location $region.Name

        if ($region.Name -eq $Location)
        {
            $found = $true
            break
        }
        elseif ($regionName -eq $formattedLocation)
        {
            $found = $true
            break
        }
    }

    return $found
}

function Validate-FlexConsumptionLocation
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $Location,

        [Parameter(Mandatory = $false)]
        [System.Management.Automation.SwitchParameter]
        $ZoneRedundancy
    )

    $isRegionSupported = Test-FlexConsumptionLocation -Location $Location -ZoneRedundancy:$ZoneRedundancy

    if (-not $isRegionSupported)
    {
        $errorMessage = $null
        $errorId = $null
        if ($ZoneRedundancy.IsPresent)
        {
            $errorMessage = "The specified location '$Location' doesn't support zone redundancy in Flex Consumption. "
            $errorMessage += "Use: 'Get-AzFunctionAppAvailableLocation -PlanType FlexConsumption -ZoneRedundancy' for the list of supported locations."
            $errorId = "RegionNotSupportedForZoneRedundancyInFlexConsumption"
        }
        else
        {
            $errorMessage = "The specified location '$Location' doesn't support Flex Consumption. "
            $errorMessage += "Use: 'Get-AzFunctionAppAvailableLocation -PlanType FlexConsumption' for the list of supported locations."
            $errorId = "RegionNotSupportedForFlexConsumption"
        }

        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId $errorId `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }
}

function Validate-EndOfLifeDate
{
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotExportAttribute()]
    param
    (
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [DateTime]
        $EndOfLifeDate,
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $Runtime,
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $RuntimeVersion,
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $DefaultRuntimeVersion
    )

    $today = Get-Today
    $sixMonthsFromToday = (Get-Today).AddMonths(6)
    $endOfLifeDate = [DateTime]::Parse($EndOfLifeDate)
    $formattedEOLDate = $endOfLifeDate.ToString("MMMM dd yyyy")

    if ($endOfLifeDate -le $today)
    {
        $errorMsg = "Use $Runtime $DefaultRuntimeVersion as $Runtime $RuntimeVersion has reached end-of-life "
        $errorMsg += "on $formattedEOLDate and is no longer supported. Learn more: aka.ms/FunctionsStackUpgrade."

        $exception = [System.InvalidOperationException]::New($errorMsg)
        ThrowTerminatingError -ErrorId "RuntimeVersionEndOfLife" `
                                -ErrorMessage $errorMsg `
                                -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                -Exception $exception
    }
    elseif ($endOfLifeDate -lt $sixMonthsFromToday)
    {
        $warningMsg = "Use $Runtime $DefaultRuntimeVersion as $Runtime $RuntimeVersion will reach end-of-life on $formattedEOLDate"
        $warningMsg += " and will no longer be supported. Learn more: aka.ms/FunctionsStackUpgrade."
        Write-Warning $warningMsg
    }
}
