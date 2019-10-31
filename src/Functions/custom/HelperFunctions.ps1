# Load Az.Functions module constants
$constants = @{}
$constants["LinuxRuntimes"] = @('DotNet', 'Node', 'Node_8', 'Node_10', 'Python', 'Python_3.6', 'Python_3.7')
$constants["WindowsRuntimes"] = @('Dotnet', 'Node', 'Node_8', 'Node_10', 'Java', 'PowerShell')
$constants["AllowedStorageTypes"] = @('Standard_GRS', 'Standard_RAGRS', 'Standard_LRS', 'Standard_ZRS', 'Premium_LRS')
$constants["RequiredStorageEndpoints"] = @('PrimaryEndpointFile', 'PrimaryEndpointQueue', 'PrimaryEndpointTable')
$constants["RuntimeToDefaultVersion"] = @{'Node' = '8'; 'DotNet' = '2'; 'Python' = '3.6'}
$constants["DefaultHostRuntimeVersion"] = '~2'
$constants["NodeDefaultVersion"] = '~10'
$constants["RuntimeToImageFunctionApp"] = @{
    'Node' = @{
     '8' = 'mcr.microsoft.com/azure-functions/node:2.0-node8-appservice'
    '10' = 'mcr.microsoft.com/azure-functions/node:2.0-node10-appservice'
    }
    'python'= @{
        '3.6' = 'mcr.microsoft.com/azure-functions/python:2.0-python3.6-appservice'
        '3.7' = 'mcr.microsoft.com/azure-functions/python:2.0-python3.7-appservice'
    }
    'dotnet'= @{
        '2' = 'mcr.microsoft.com/azure-functions/dotnet:2.0-appservice'
    }
}
$constants["RuntimeToFormattedName"] = @{
    'node' = 'Node'
    'dotnet' = 'DotNet'
    'python' = 'Python'
    'java' = 'Java'
    'powershell' = 'PowerShell'
}

foreach ($variableName in $constants.Keys)
{
    if (-not (Get-Variable $variableName -ErrorAction SilentlyContinue))
    {
        Set-Variable $variableName -value $constants[$variableName]
    }
}

function GetConnectionString
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $StorageAccountName
    )

    $storageAccountInfo = GetStorageAccount -Name $StorageAccountName -ErrorAction SilentlyContinue
    if (-not $storageAccountInfo)
    {
        $errorMessage = "Storage account '$StorageAccountName' does not exist."
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
    $keys = Az.Functions.internal\Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageAccountInfo.Name -ErrorAction SilentlyContinue
    if ([string]::IsNullOrEmpty($keys[0].Value))
    {
        throw "Storage account '$StorageAccountName' has no key value."
    }

    $accountKey = $keys[0].Value
    $connectionString = "DefaultEndpointsProtocol=https;AccountName=$StorageAccountName;AccountKey=$accountKey"

    return $connectionString
}

function NewAppSetting
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Value
    )

    $setting = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150801.NameValuePair
    $setting.Name = $Name
    $setting.Value = $Value

    return $setting
}

function GetServicePlan
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name
    )

    $plans = @(Az.Functions\Get-AzFunctionAppPlan)
    foreach ($plan in $plans)
    {
        if ($plan.Name -eq $Name)
        {
            return $plan
        }
    }
}

function GetStorageAccount
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name
    )

    $storageAccounts = @(Az.Functions.internal\Get-AzStorageAccount)
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
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name
    )

    $projects = @(Az.Functions.internal\Get-AzAppInsights)
    
    foreach ($project in $projects)
    {
        if ($project.Name -eq $Name)
        {
            return $project
        }
    }
}

function AddFunctionAppSettings
{
    param(
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [Object]
        $App
    )

    $App.AppServicePlan = ($App.ServerFarmId -split "/")[-1]
    $App.OSType = if ($App.kind.Contains("linux", [StringComparison]::OrdinalIgnoreCase)){ "Linux" } else { "Windows" }
    
    $currentSubscription = $null
    $resetDefaultSubscription = $false
    
    try
    {
        $settings = Get-AzWebAppApplicationSetting -Name $App.Name -ResourceGroupName $App.ResourceGroup -ErrorAction SilentlyContinue
        if ($null -eq $settings)
        {
            $resetDefaultSubscription = $true
            $currentSubscription = (Get-AzContext).Subscription.Id
            $null = Select-AzSubscription $App.SubscriptionId

            $settings = Az.Functions.internal\Get-AzWebAppApplicationSetting -Name $App.Name -ResourceGroupName $App.ResourceGroup -ErrorAction SilentlyContinue
            if ($null -eq $settings)
            {
                # We are unable to get the app settings, return the app
                return $App
            }
        }
    }
    finally
    {
        if ($resetDefaultSubscription)
        {
            $null = Select-AzSubscription $currentSubscription
        }
    }

    # Create a key value pair to hold the function app settings
    $applicationSettings = @{}
    foreach ($keyName in $settings.Property.Keys)
    {
        $applicationSettings[$keyName] = $settings.Property[$keyName]
    }

    # Add application settings, RuntimeName, and HostVersion
    $App.ApplicationSettings = $applicationSettings

    $runtimeName = $settings.Property["FUNCTIONS_WORKER_RUNTIME"]
    $App.RuntimeName = $RuntimeToFormattedName[$runtimeName]
    $App.HostVersion = $settings.Property["FUNCTIONS_EXTENSION_VERSION"]

    return $App
}

function GetFunctionApps
{
    param
    (
        [Parameter(Mandatory=$true)]
        [AllowEmptyCollection()]
        [Object[]]
        $Apps,

        [System.String]
        $Location
    )

    if ($Apps.Count -eq 0)
    {
        return
    }

    for ($index = 0; $index -lt $Apps.Count; $index++)
    {
        $app = $Apps[$index]

        $percentageCompleted = [int]((100 * ($index + 1)) / $Apps.Count)
        $status = "Complete: $($index + 1)/$($Apps.Count) function apps processed."
        Write-Progress -Activity "Getting function apps" -Status $status -PercentComplete $percentageCompleted
        
        if ($app.kind.Contains("functionapp", [StringComparison]::OrdinalIgnoreCase))
        {
            if ($Location)
            {
                if ($app.Location -eq $Location)
                {
                    $app = AddFunctionAppSettings -App $app
                    $app
                }
            }
            else
            {
                $app = AddFunctionAppSettings -App $app
                $app
            }
        }
    }
}

function AddFunctionAppPlanWorkerType
{
    param(
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        $AppPlan
    )

    $currentSubscription = $null
    $resetDefaultSubscription = $false

    # The GetList api for service plan that does not set the Reserved property, which is needed to figure out if the OSType is Linux.
    # TODO: Remove this code once  https://msazure.visualstudio.com/Antares/_workitems/edit/5623226 is fixed.
    if ($null -eq $AppPlan.Reserved)
    {
        try
        {
            # Get the service plan by name does set the Reserved property
            $planObject = Az.Functions.internal\Get-AzFunctionAppPlan -Name $AppPlan.Name -ResourceGroupName $AppPlan.ResourceGroup -SubscriptionId $AppPlan.SubscriptionId -ErrorAction SilentlyContinue

            if ($null -eq $planObject)
            {
                $resetDefaultSubscription = $true
                $currentSubscription = (Get-AzContext).Subscription.Id
                $null = Select-AzSubscription $App.SubscriptionId

                $planObject = Az.Functions.internal\Get-AzFunctionAppPlan -Name $AppPlan.Name -ResourceGroupName $AppPlan.ResourceGroup -SubscriptionId $AppPlan.SubscriptionId -ErrorAction SilentlyContinue
            }

            $AppPlan = $planObject
        }
        finally
        {
            if ($resetDefaultSubscription)
            {
                $null = Select-AzSubscription $currentSubscription
            }
        }

        $AppPlan = $planObject
    }

    $AppPlan.WorkerType = if ($AppPlan.Reserved){ "Linux" } else { "Windows" }

    return $AppPlan
}

function GetFunctionAppPlans
{
    param
    (
        [Parameter(Mandatory=$true)]
        [AllowEmptyCollection()]
        [Object[]]
        $Plans,

        [System.String]
        $Location
    )

    if ($Plans.Count -eq 0)
    {
        return
    }

    for ($index = 0; $index -lt $Plans.Count; $index++)
    {
        $plan = $Plans[$index]
        
        $percentageCompleted = [int]((100 * ($index + 1)) / $Plans.Count)
        $status = "Complete: $($index + 1)/$($Plans.Count) function apps plans processed."
        Write-Progress -Activity "Getting function app plans" -Status $status -PercentComplete $percentageCompleted

        if ($Location)
        {
            if ($plan.Location -eq $Location)
            {
                $plan = AddFunctionAppPlanWorkerType -AppPlan $plan
                $plan
            }
        }
        else
        {
            $plan = AddFunctionAppPlanWorkerType -AppPlan $plan
            $plan
        }
    }
}

function ValidateLocation
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Location,

        [Parameter(Mandatory=$false)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Sku
    )

    $Location = $Location.Trim()
    $availableLocations = @(Az.Functions.internal\Get-AzFunctionAppAvailableLocation | ForEach-Object { $_.Name })
    if (-not ($availableLocations -contains $Location))
    {
        $errorMessage = "Location is invalid. Use: 'Get-AzFunctionAppAvailableLocation' to see available locations."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "LocationIsInvalid" `
                              -ErrorMessage $errorMessage `
                              -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                              -Exception $exception
    }
}

function ValidateFunctionName
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name
    )

    $result = Test-AzNameAvailability -Type Site -Name $Name

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

function CreateObjectFromPipeline
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        $InputObject
    )

    if ($InputObject.Name -and $InputObject.ResourceGroupName -and $InputObject.SubscriptionId)
    {
        $functionsIdentity = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.FunctionsIdentity
        $functionsIdentity.Name = $InputObject.Name
        $functionsIdentity.SubscriptionId = $InputObject.SubscriptionId
        $functionsIdentity.ResourceGroupName = $InputObject.ResourceGroupName

        return $functionsIdentity
    }
    
    return $null
}

function GetSkuName
{
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

    $guidanceUrl = 'https://docs.microsoft.com/en-us/azure/azure-functions/functions-premium-plan#plan-and-sku-settings'

    $errorMessage = "Invalid sku (pricing tier), please refer to '$guidanceUrl' for valid values."
    $exception = [System.InvalidOperationException]::New($errorMessage)
    ThrowTerminatingError -ErrorId "InvalidSkuPricingTier" `
                          -ErrorMessage $errorMessage `
                          -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                          -Exception $exception
}

function ThrowTerminatingError
{
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
    throw $errorRecord
}

function GetFunctionAppDefaultNodeVersion
{
    param
    (
        [System.String]
        $Runtime,

        [System.String]
        $RuntimeVersion
    )

    if ((-not $Runtime) -or ($Runtime -ne "node"))
    {
        return $NodeDefaultVersion
    }

    if ($RuntimeVersion)
    {
        return "~$RuntimeVersion"
    }

    return $NodeDefaultVersion
}

function GetLinuxFxVersion
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $RuntimeName,

        [System.String]
        $RuntimeVersion,

        [Switch]
        $IsConsumption
    )
    
    if (-not $RuntimeVersion)
    {
        $RuntimeVersion = $RuntimeToDefaultVersion[$RuntimeName]
    }

    if ($IsConsumption)
    {
        return "$runtimeName|$runtimeVersion"
    }

    # App service or Elastic Premium
    $containerImage = [string]$RuntimeToImageFunctionApp[$RuntimeName][$RuntimeVersion]
    if (-not $containerImage)
    {
        $errorMessage = "Cannot find container image for '$RuntimeName' version '$RuntimeVersion'."
        $exception = [System.InvalidOperationException]::New($errorMessage)
        ThrowTerminatingError -ErrorId "NoContainerImageFoundForTheGivenRuntime" `
                                -ErrorMessage $errorMessage `
                                -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                -Exception $exception
    }

    $containerImage = $containerImage.ToLower()
    
    return "DOCKER|$containerImage"
}

function GetErrorMessage
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNull()]
        $Response
    )

    if ($Response.Exception.ResponseBody)
    {
        $details = ConvertFrom-Json $Response.Exception.ResponseBody
        if ($details.Message)
        {
            return $details.Message
        }
    }
}
function GetRuntimeName
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Runtime
    )

    if ($Runtime.Contains("_"))
    {
        $parts = $Runtime -split "_"
        return $parts[0]
    }

    return  $Runtime
}

function GetRuntimeVersion
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Runtime
    )

    if ($Runtime.Contains("_"))
    {
        $parts = $Runtime -split "_"
        return $parts[1]
    }
    
    return $null
}
