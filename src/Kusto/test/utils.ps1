function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # If you want to record a single test do the following for exmple pwsh test-module.ps1 --Record --TestName Update-AzKustoDataConnection
    # 1. comment cleanupEnv- you don't want clean up of the resource group
    # 2. run playback and create the resources
    # 3. comment all content of setupEnv, you want to reuse the resources.
    # 4. leave only $env = Get-Content .\test\env.json | ConvertFrom-Json, to load the $env 
    
    $env.subscriptionId = "e8257c73-24c5-4791-94dc-8b7901c90dbf" # Kusto_Dev_Kusto_Ilay_04_Test
    $env.location = 'East US'
    Write-Host "Setting up and connection to subcription " $env.SubscriptionId -ForegroundColor Green
    Connect-AzAccount -Subscription $env.SubscriptionId
    $env.Tenant = (Get-AzContext).Tenant.Id
    
    # Generate some random strings for use in the tests.
    $rstr1 = RandomString -allChars $false -len 6	
    $rstr2 = RandomString -allChars $false -len 6
    $rstr3 = RandomString -allChars $false -len 6
    $rstr4 = RandomString -allChars $false -len 6
    $rstr5 = RandomString -allChars $false -len 6
    $rstr6 = RandomString -allChars $false -len 6
    $env["rstr1"] = $rstr1
    $env["rstr2"] = $rstr2
    $env["rstr3"] = $rstr3
    $env["rstr4"] = $rstr4
    $env["rstr5"] = $rstr5
    $env["rstr6"] = $rstr6
    
    #setup additional parameters required for tests
    $env["principalAppId"] = "713c3475-5021-4f3b-a650-eaa9a83f25a4"
    $env["principalAadObjectId"] = "3c634984-c431-4b6a-ad59-f27ccd22708b" # objectId of principalAppId 713c3475-5021-4f3b-a650-eaa9a83f25a4
    $env["principalAppIdSecondary"] = "18778869-0a89-4c08-a241-561036bd0ac7"

    # Create the test resource group
    $resourceGroupName = "PS-SDK-" + $rstr1
    $env["resourceGroupName"] = $resourceGroupName
    Write-Host "Start to create test resource group" $resourceGroupName -ForegroundColor Green
    New-AzResourceGroup -Name $resourceGroupName -Location $env.location

    # Prepare arm template paramters
    Write-Host "Preparing parameters for ARM template deploymet" -ForegroundColor Green
    $params = Get-Content .\test\deployment-templates\all-resources\parameters.json | ConvertFrom-Json
    $params.parameters.kustoApiVersion.value = "2022-12-29"
    $params.parameters.kustoSkuName.value = "Dev(No SLA)_Standard_E2a_v4"
    $params.parameters.kustoClusterTier.value = "Basic"
    $params.parameters.kustoClusterName.value = "pssdk" + $rstr1
    $params.parameters.kustoFollowerClusterName.value = "pssdkfollow" + $rstr1
    $params.parameters.kustoDatabaseName.value = "TestDb"
    $params.parameters.kustoDatabaseScriptName.value = "CreateTableScript"
    $params.parameters.kustoTableName.value = "TestTable"
    $params.parameters.principalAppId.value = $env.principalAppId
    $params.parameters.eventHubNameSpaceName.value = "EHNamespace" + $rstr1
    $params.parameters.eventHubName.value = "eh" + $rstr1
    $params.parameters.iotHubName.value = "iot" + $rstr1
    $params.parameters.cosmosDbAccountName.value = "cosmos" + $rstr1
    $params.parameters.cosmosDbDatabaseName.value = "cosmostestdb"
    $params.parameters.cosmosDbContainerName.value = "cosmostestcontainer"
    $params.parameters.storageAccountName.value = "sa" + $rstr1
    $params.parameters.virtualNetworkName.value = "vnet" + $rstr1
    $params.parameters.subnetName.value = "subnet" + $rstr1
    $params.parameters.privateEndpointName.value = "pe" + $rstr1

    # Copy all parameters to env
    $params.parameters.psobject.Properties| ForEach-Object { $env[$_.Name] = $_.Value.value }

    # Update the parameter file
    set-content -Path .\test\deployment-templates\all-resources\parameters.json -Value (ConvertTo-Json $params)
    
    # Deploy the ARM template
    Write-Host "Deploying the ARM template" -ForegroundColor Green
    $deploymentName = "ps-sdk-deploymet" + $rstr1
    $deploymetResult = New-AzResourceGroupDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\all-resources\template.json -TemplateParameterFile .\test\deployment-templates\all-resources\parameters.json -Name $deploymentName -ResourceGroupName $resourceGroupName
    Write-Host "ARM template completed with state" $deploymetResult.ProvisioningState 
    
    # Collect outputs from dempolymet
    $env.kustoClusterResourceId = $deploymetResult.Outputs.kustoClusterResourceId.value
    $env.kustoFolowerClusterResourceId = $deploymetResult.Outputs.kustoFolowerClusterResourceId.value
    $env.eventHubNameSpaceResourceId = $deploymetResult.Outputs.eventHubNameSpaceResourceId.value
    $env.eventHubResourceId = $deploymetResult.Outputs.eventHubResourceId.value
    $env.iotHubResourceId = $deploymetResult.Outputs.iotHubResourceId.value
    $env.cosmosDbResourceId = $deploymetResult.Outputs.cosmosDbResourceId.value
    $env.storageAccountResourceId = $deploymetResult.Outputs.storageAccountResourceId.value
    
    # copy $env to env.json file 
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function cleanupEnv() {
    # If you want to keep the resources after recording - disable remove of RG
    Remove-AzResourceGroup -Name $env.resourceGroupName
}
