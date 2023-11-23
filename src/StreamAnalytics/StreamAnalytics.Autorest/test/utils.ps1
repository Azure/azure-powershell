function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}

<# Pre-Step:
  1. Create azure machine learing workspace and deploy model in azure portal. Doc links:https://learn.microsoft.com/en-us/azure/machine-learning/tutorial-first-experiment-automated-ml
  2. Get endpoint of the deployment model that type into the .\test\template-json\MachineLearningServices.json
#>
function setupEnv() {
    Write-Warning "
    Pre-step:
    1. Create azure machine learing workspace and deploy model in azure portal. Doc links:https://learn.microsoft.com/en-us/azure/machine-learning/tutorial-first-experiment-automated-ml
    2. Get endpoint of the deployment model that type into the .\test\template-json\MachineLearningServices.json
    "
    # Import modules for test.
    Import-Module -Name Az.IotHub
    Import-Module -Name Az.Storage
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.subscriptionId = (Get-AzContext).Subscription.Id
    $env.tenant = (Get-AzContext).Tenant.Id
    $env.location = 'westcentralus'
    # For any resources you created for test, you should add it to $env here.

    $env.resourceGroup = 'streamanalytics-rg-' + (RandomString -allChars $false -len 6)

    $env.cluster00 = 'sac-' + (RandomString -allChars $false -len 6)
    $env.cluster01 = 'sac-' + (RandomString -allChars $false -len 6)
    $env.cluster02 = 'sac-' + (RandomString -allChars $false -len 6)
    $env.cluster03 = 'sac-' + (RandomString -allChars $false -len 6)

    $env.job01 = 'job' + (RandomString -allChars $false -len 6)
    $env.job02 = 'job' + (RandomString -allChars $false -len 6)
    $env.job03 = 'job' + (RandomString -allChars $false -len 6)

    $env.input01 = 'input' + (RandomString -allChars $false -len 6)
    $env.input02 = 'input' + (RandomString -allChars $false -len 6)
    $env.input03 = 'input' + (RandomString -allChars $false -len 6)

    $env.output01 = 'output' + (RandomString -allChars $false -len 6)
    $env.output02 = 'output' + (RandomString -allChars $false -len 6)
    $env.output03 = 'output' + (RandomString -allChars $false -len 6)

    $env.function01 = 'function' + (RandomString -allChars $false -len 6)
    $env.function02 = 'function' + (RandomString -allChars $false -len 6)
    $env.function03 = 'function' + (RandomString -allChars $false -len 6)
    $env.mlsfunction = 'mlsfunction'

    $env.trnasf01 = 'transf' + (RandomString -allChars $false -len 6)
    $env.trnasf02 = 'transf' + (RandomString -allChars $false -len 6)
    $env.trnasf03 = 'transf' + (RandomString -allChars $false -len 6)

    $env.storageAccount00 = 'storageaccount' + (RandomString -allChars $false -len 6)
    
    $env.iothub00 = 'iothub' + (RandomString -allChars $false -len 6)

    # Create resource group
    Write-Host -ForegroundColor Green "Create resource group for test."
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location
    
    # Deploy storage account and Iot hub
    Write-Host -ForegroundColor Green "Deploy storage account for test."
    $storageAccountParam = Get-Content .\test\deployment-templates\storage-account\parameters.json | ConvertFrom-Json
    $storageAccountParam.parameters.storageAccounts_lucasstorageaccount01_name.value = $env.storageAccount00
    Set-Content -Path .\test\deployment-templates\storage-account\parameters.json -Value (ConvertTo-Json $storageAccountParam)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\storage-account\template.json -TemplateParameterFile .\test\deployment-templates\storage-account\parameters.json -Name $env.storageAccount00 -ResourceGroupName $env.resourceGroup

    Write-Host -ForegroundColor Green "Deploy iothub for test."
    # $iothubParam = Get-Content .\test\deployment-templates\Iothub\parameters.json | ConvertFrom-Json
    # $iothubParam.parameters.IotHubs_lucasiothub02_name.value = $env.iothub00
    # $iothubParam.parameters.IotHubs_lucasiothub02_containerName.value = $env.iothub00 + 'container'
    # $iothubParam.parameters.IotHubs_lucasiothub02_connectionString.value = $env.iothub00 + 'connect'
    # Set-Content -Path .\test\deployment-templates\Iothub\parameters.json -Value (ConvertTo-Json $iothubParam)
    # New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\Iothub\template.json -TemplateParameterFile .\test\deployment-templates\iothub\parameters.json -Name $env.iothub00 -ResourceGroupName $env.resourceGroup
    New-AzIotHub -ResourceGroupName $env.resourceGroup -Name $env.iothub00 -SkuName "S1" -Units 1 -Location $env.location

    # Get primary key of resource group
    $resourceKey = Get-AzStorageAccountKey -ResourceGroupName $env.resourceGroup -AccountName $env.storageAccount00
    $storageAccountKey = $resourceKey[0].Value
    $resourceKey = Get-AzIotHubKey -ResourceGroupName $env.resourceGroup -Name $env.iothub00 -KeyName 'iothubowner'
    $iothubKey = $resourceKey.PrimaryKey

    # Update value of the template json.
    $storageAccountParam = Get-Content .\test\template-json\StroageAccount.json | ConvertFrom-Json
    $storageAccountParam.properties.datasource.properties.storageAccounts[0].accountName = $env.storageAccount00
    $storageAccountParam.properties.datasource.properties.storageAccounts[0].accountKey = $storageAccountKey
    Set-Content -Path .\test\template-json\StroageAccount.json -Value (ConvertTo-Json -InputObject $storageAccountParam -Depth 10)

    $iothubParam = Get-Content .\test\template-json\IotHub.json | ConvertFrom-Json
    $iothubParam.properties.datasource.properties.iotHubNamespace = $env.iothub00
    $iothubParam.properties.datasource.properties.sharedAccessPolicyKey = $iothubKey
    Set-Content -Path .\test\template-json\IotHub.json -Value (ConvertTo-Json -InputObject $iothubParam -Depth 10)

    Write-Host -ForegroundColor Green "Create three stream analytics clusters for test"
    Write-Host -ForegroundColor Yellow "Deploying stream analytics cluster could take around an hour to complete. "
    $cluster00 = New-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup -Name $env.cluster00 -Location $env.location -SkuName "Default" -SkuCapacity 36
    $cluster01 = New-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup -Name $env.cluster01 -Location $env.location -SkuName "Default" -SkuCapacity 36
    Write-Host -ForegroundColor Green "Create completed"

    Write-Host -ForegroundColor Green "Create job, input, output, function, transformation for test"
    New-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01 -Location $env.location -SkuName 'Standard' -ClusterId $cluster00.Id 
    New-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job02 -Location $env.location -SkuName 'Standard' -ClusterId $cluster00.Id
    
    New-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.input01 -File .\test\template-json\IotHub.json
    New-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.output01 -File .\test\template-json\StroageAccount.json
    
    New-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.function01 -File .\test\template-json\Function_JavascriptUdf.json
    New-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.mlsfunction -File .\test\template-json\MachineLearningServices.json

    New-AzStreamAnalyticsTransformation -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.trnasf01 -StreamingUnit 6 -Query "SELECT * INTO $($env.output01) FROM $($env.input01) HAVING Temperature > 27"
    

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
}

