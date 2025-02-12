function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
function setupEnv() {
    # If you want to record a single test do the following for exmple pwsh test-module.ps1 --Record --TestName Update-AzKustoDataConnection
    # 1. comment cleanupEnv- you don't want clean up of the resource group
    # 2. run Record and create the resources
    # 3. comment all content of setupEnv, you want to reuse the resources from previous session instead of creating again
    # 4. add the following line $env = Get-Content .\test\env.json | ConvertFrom-Json, to load the $env
    # 5. Run the recording of a specific test for exmple pwsh test-module.ps1 --Record --TestName Update-AzKustoDataConnection

    $env = Get-Content .\test\env.json | ConvertFrom-Json

#    $env.subscriptionId = "e8257c73-24c5-4791-94dc-8b7901c90dbf" # Kusto_Dev_Kusto_Ilay_04_Test
#    $env.location = 'East US'
#    Write-Host "Setting up and connection to subcription " $env.SubscriptionId -ForegroundColor Green
#    Connect-AzAccount -Subscription $env.SubscriptionId
#    $env.Tenant = (Get-AzContext).Tenant.Id
#
#    # Generate some random strings for use in the tests.
#    $rstr1 = RandomString -allChars $false -len 6
#    $rstr2 = RandomString -allChars $false -len 6
#    $rstr3 = RandomString -allChars $false -len 6
#    $rstr4 = RandomString -allChars $false -len 6
#    $rstr5 = RandomString -allChars $false -len 6
#    $rstr6 = RandomString -allChars $false -len 6
#    $env["rstr1"] = $rstr1
#    $env["rstr2"] = $rstr2
#    $env["rstr3"] = $rstr3
#    $env["rstr4"] = $rstr4
#    $env["rstr5"] = $rstr5
#    $env["rstr6"] = $rstr6
#
#    #setup additional parameters required for tests
#    $env["principalAppId"] = "3c5cd8d1-b5a2-41e9-b592-533bc0a146d0"  # this is our RP e2e user. Used for no specific reason other than it exists
#    $env["principalAadObjectId"] = "92045f49-32bb-4ec1-91f7-574d7181127f" # objectId of principalAppId 3c5cd8d1-b5a2-41e9-b592-533bc0a146d0
#    $env["principalAppIdSecondary"] = "631482e1-7241-4bcc-b7b0-6d878b9849ed"  # RP e2e cleaner. 
#
#    # Create the test resource group
#    $resourceGroupName = "PWSH-SDK-" + $rstr1
#    $env["resourceGroupName"] = $resourceGroupName
#    Write-Host "Start to create test resource group" $resourceGroupName -ForegroundColor Green
#    New-AzResourceGroup -Name $resourceGroupName -Location $env.location
#
#    # Prepare arm template paramters
#    Write-Host "Preparing parameters for ARM template deploymet" -ForegroundColor Green
#    $params = Get-Content .\test\deployment-templates\all-resources\parameters.json | ConvertFrom-Json
#
#    Update-Parameter -propertyName "kustoApiVersion" -propertyValue "2024-04-13" -params $params
#    Update-Parameter -propertyName "userAssignedManagedIdentityName" -propertyValue ("uaMi" + $rstr1) -params $params
#    Update-Parameter -propertyName "kustoSkuName" -propertyValue "Standard_E2ads_v5" -params $params
#    Update-Parameter -propertyName "kustoFollowerSkuName" -propertyValue "Standard_E8as_v5+1TB_PS" -params $params #Hyper threading vm is required for sandbox custom image tests
#    Update-Parameter -propertyName "kustoClusterTier" -propertyValue "Standard" -params $params
#    Update-Parameter -propertyName "kustoFollowerClusterTier" -propertyValue "Standard" -params $params
#    Update-Parameter -propertyName "kustoClusterName" -propertyValue ("pssdk" + $rstr1) -params $params
#    Update-Parameter -propertyName "kustoFollowerClusterName" -propertyValue ("pssdkfollow" + $rstr1) -params $params
#    Update-Parameter -propertyName "kustoMigrationClusterName" -propertyValue ("pssdkmigr" + $rstr1) -params $params
#    Update-Parameter -propertyName "kustoDatabaseName" -propertyValue "TestDb" -params $params
#    Update-Parameter -propertyName "kustoMigrationDatabaseName" -propertyValue "DbToMigrate" -params $params
#    Update-Parameter -propertyName "kustoDatabaseScriptName" -propertyValue "CreateTableScript" -params $params
#    Update-Parameter -propertyName "kustoTableName" -propertyValue "TestTable" -params $params
#    Update-Parameter -propertyName "principalAppId" -propertyValue $env.principalAppId -params $params
#    Update-Parameter -propertyName "eventHubNameSpaceName" -propertyValue ("EHNamespace" + $rstr1) -params $params
#    Update-Parameter -propertyName "eventHubName" -propertyValue ("eh" + $rstr1) -params $params
#    Update-Parameter -propertyName "iotHubName" -propertyValue ("iot" + $rstr1) -params $params
#    Update-Parameter -propertyName "cosmosDbAccountName" -propertyValue ("cosmos" + $rstr1) -params $params
#    Update-Parameter -propertyName "cosmosDbDatabaseName" -propertyValue "cosmostestdb" -params $params
#    Update-Parameter -propertyName "cosmosDbContainerName" -propertyValue "cosmostestcontainer" -params $params
#    Update-Parameter -propertyName "storageAccountName" -propertyValue ("sa" + $rstr1) -params $params
#    Update-Parameter -propertyName "virtualNetworkName" -propertyValue ("vnet" + $rstr1) -params $params
#    Update-Parameter -propertyName "subnetName" -propertyValue ("subnet" + $rstr1) -params $params
#    Update-Parameter -propertyName "privateEndpointName" -propertyValue ("pe" + $rstr1) -params $params
#    Update-Parameter -propertyName "keyVaultName" -propertyValue ("kvPwsh" + $rstr1) -params $params
#    Update-Parameter -propertyName "keyName" -propertyValue ("byok" + $rstr1) -params $params
#
#    # Copy all parameters to env
#    $params.parameters.psobject.Properties| ForEach-Object { $env[$_.Name] = $_.Value.value }
#
#    # Update the parameter file
#    set-content -Path .\test\deployment-templates\all-resources\parameters.json -Value (ConvertTo-Json $params)
#
#    # Deploy the ARM template
#    Write-Host "Deploying the ARM template" -ForegroundColor Green
#    $deploymentName = "ps-sdk-deploymet" + $rstr1
#    $deploymetResult = New-AzResourceGroupDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\all-resources\template.json -TemplateParameterFile .\test\deployment-templates\all-resources\parameters.json -Name $deploymentName -ResourceGroupName $resourceGroupName
#    Write-Host "ARM template completed with state" $deploymetResult.ProvisioningState
#
#    # Collect outputs from deployment
#    $env.kustoClusterResourceId = $deploymetResult.Outputs.kustoClusterResourceId.value
#    $env.kustoFollowerClusterResourceId = $deploymetResult.Outputs.kustoFollowerClusterResourceId.value
#    $env.kustoMigrationClusterResourceId = $deploymetResult.Outputs.kustoMigrationClusterResourceId.value
#    $env.eventHubNameSpaceResourceId = $deploymetResult.Outputs.eventHubNameSpaceResourceId.value
#    $env.eventHubResourceId = $deploymetResult.Outputs.eventHubResourceId.value
#    $env.iotHubResourceId = $deploymetResult.Outputs.iotHubResourceId.value
#    $env.cosmosDbResourceId = $deploymetResult.Outputs.cosmosDbResourceId.value
#    $env.storageAccountResourceId = $deploymetResult.Outputs.storageAccountResourceId.value
#    $env.userAssignedManagedIdentityResourceId = $deploymetResult.Outputs.userAssignedManagedIdentityResourceId.value
#    $env.keyVaultUrl = $deploymetResult.Outputs.keyVaultUrl.value
#    $env.keyVersion = $deploymetResult.Outputs.keyVersion.value
#
#    # copy $env to env.json file
#    $envFile = 'env.json'
#    if ($TestMode -eq 'live') {
#        $envFile = 'localEnv.json'
#    }
#    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function cleanupEnv() {
    # If you want to keep the resources after recording - disable remove of RG
    #Remove-AzResourceGroup -Name $env.resourceGroupName #TODO - uncomment this line
}

function Update-Parameter
{
    param (
        [string]$propertyName,
        [string]$propertyValue,
        [PSCustomObject]$params
    )

    # Check if the 'parameters' property exists in the PSCustomObject
    if (-not $params.parameters)
    {
        $params | Add-Member -MemberType NoteProperty -Name "parameters" -Value @{}
    }

    Write-Host "Update-Parameter" $propertyName "with value" $propertyValue -ForegroundColor Green
    $params.parameters | Add-Member -MemberType NoteProperty -Name $propertyName -Value @{
        "value" = $propertyValue
    } -Force
}
