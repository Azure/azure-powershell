. ("$PSScriptRoot\helper.ps1")
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
    Write-Warning "Need to use  Az.Resources module, Please check if installed  Az.Resources(1.8.0 or Greater)."
    # Az.KeyVault,, Az.CosmosDB Az.KeyVault(2.0.0 or Greater),  and Az.CosmosDB(0.1.4 or Greater)
    # Import az module
    # Import-Module -Name Az.Resources
    # Import-Module -Name Az.KeyVault
    # Import-Module -Name Az.CosmosDB

    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'eastus'
    $env.location2 = 'eastus2'

    # Resource Group
    $env.resourceGroup = 'springcloud-rg-' + (RandomString -allChars $false -len 6)
    # App Platform
    $env.standardSpringName01 = 'spring-' + (RandomString -allChars $false -len 6)
    $env.enterpriseSpringName01 = 'spring-' + (RandomString -allChars $false -len 6)
    $env.springName01 = 'spring-' + (RandomString -allChars $false -len 6)
    $env.springName02 = 'spring-' + (RandomString -allChars $false -len 6)

    $appGateway = 'gateway'
    $appAccount = 'account'
    $appAuth = 'auth'
    $env.add('appGateway', $appGateway)
    $env.add('appAccount', $appAccount)
    $env.add('appAuth', $appAuth)
    $env.springAppName01 = 'spring-' + (RandomString -allChars $false -len 6)
    $env.springAppName02 = 'spring-' + (RandomString -allChars $false -len 6)
    $env.springAppName03 = 'spring-' + (RandomString -allChars $false -len 6)

    $env.greenDeploymentName = 'green'
    $env.buleDeploymentName = 'bule'
    $env.deploymentName01 = 'spring-' + (RandomString -allChars $false -len 6)
    $env.deploymentName02 = 'spring-' + (RandomString -allChars $false -len 6)
    $env.deploymentName03 = 'spring-' + (RandomString -allChars $false -len 6)

    # Key Vault
    $keyVaultName = 'app-keyvault-' + (RandomString -allChars $false -len 6)
    $env.add('name', $keyVaultName);
    $certificateName20 = 'cert-' + (RandomString -allChars $false -len 6)
    $certificateName21 = 'cert-' + (RandomString -allChars $false -len 6)
    $certificateName22 = 'cert-' + (RandomString -allChars $false -len 6)
    $certificateName23 = 'cert-' + (RandomString -allChars $false -len 6)
    $env.add('certificateName20', $certificateName20);
    $env.add('certificateName21', $certificateName21);
    $env.add('certificateName22', $certificateName22);
    $env.add('certificateName23', $certificateName23);

    $certSubjectName30 = 'CN=' + $env.springName01 + '.com'
    $certSubjectName31 = 'CN=' + $env.springName01 + '.com'
    $certSubjectName32 = 'CN=' + $env.springName02 + '.com'
    $certSubjectName33 = 'CN=' + $env.springName02 + '.com'
    $env.add('certSubjectName30', $certSubjectName30);
    $env.add('certSubjectName31', $certSubjectName31);
    $env.add('certSubjectName32', $certSubjectName32);
    $env.add('certSubjectName33', $certSubjectName33);

    # Cosmos DB
    $cosmosDbName40 = 'cosmosdb-' + (RandomString -allChars $false -len 6)
    $cosmosDbName41 = 'cosmosdb-' + (RandomString -allChars $false -len 6)
    $env.add('cosmosDbName40', $cosmosDbName40);
    $env.add('cosmosDbName41', $cosmosDbName41);

    # Create resource group for test
    Write-Host -ForegroundColor Green "Start to creating resource group for test..."
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location
    Write-Host -ForegroundColor Green "Resource group created successfully."

    # Create spring server for test.
    Write-Host -ForegroundColor Green "Start create app platform for test..."

    New-AzSpringCloud -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01 -Location $env.location
    New-AzSpringCloud -ResourceGroupName $env.resourceGroup -Name $env.enterpriseSpringName01 -Location $env.location -SkuTier "Enterprise" -SkuName "E0"
    $jarSource = New-AzSpringCloudAppDeploymentJarUploadedObject -RuntimeVersion "Java_8"

    New-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name $env.appGateway -Location $env.location `
    -TemporaryDiskMountPath "/mytemporarydisk" -TemporaryDiskSizeInGb 2 -PersistentDiskSizeInGb 2 -PersistentDiskMountPath "/mypersistentdisk"

    New-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -Name $env.greenDeploymentName `
    -Source $jarSource -EnvironmentVariable @{"env" = "test"}

    New-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -Name $env.buleDeploymentName `
    -Source $jarSource -EnvironmentVariable @{"env" = "prod"}

    New-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name $env.appAccount -Location $env.location `
    -TemporaryDiskMountPath "/mytemporarydisk" -TemporaryDiskSizeInGb 2 -PersistentDiskSizeInGb 2 -PersistentDiskMountPath "/mypersistentdisk"

    New-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.greenDeploymentName `
    -Source $jarSource -EnvironmentVariable @{"env" = "test"}
    New-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName `
    -Source $jarSource -EnvironmentVariable @{"env" = "prod"}

    New-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -Name $env.appGateway -Location $env.location `
    -TemporaryDiskMountPath "/mytemporarydisk" -TemporaryDiskSizeInGb 2 -PersistentDiskSizeInGb 2 -PersistentDiskMountPath "/mypersistentdisk"
    $buildSource = New-AzSpringCloudAppDeploymentBuildResultObject

    New-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -AppName $env.appGateway -Name $env.greenDeploymentName `
    -Source $buildSource -EnvironmentVariable @{"env" = "test"}
    New-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -AppName $env.appGateway -Name $env.buleDeploymentName `
    -Source $buildSource -EnvironmentVariable @{"env" = "prod"}

    New-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -Name $env.appAccount -Location $env.location `
    -TemporaryDiskMountPath "/mytemporarydisk" -TemporaryDiskSizeInGb 2 -PersistentDiskSizeInGb 2 -PersistentDiskMountPath "/mypersistentdisk"

    New-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -AppName $env.appAccount -Name $env.greenDeploymentName `
    -Source $buildSource -EnvironmentVariable @{"env" = "test"}
    New-AzSpringCloudAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -AppName $env.appAccount -Name $env.buleDeploymentName `
    -Source $buildSource -EnvironmentVariable @{"env" = "prod"}

    Write-Host -ForegroundColor Green "App platform created successfully."

    <#
    # cmdlet disable service binding and identity.
    # deploy key vault
    Write-Host -ForegroundColor Green "Start deploying key vault for test..."
    $keyVaultPara = Get-Content (Join-Path $PSScriptRoot '.\deployment-templates\key-vault\parameters.json') | ConvertFrom-Json
    $keyVaultPara.parameters.key_vault_name.value = $env.name
    set-content -Path (Join-Path $PSScriptRoot '.\deployment-templates\key-vault\parameters.json') -Value (ConvertTo-Json $keyVaultPara)
    New-AzDeployment -Mode Incremental -TemplateFile (Join-Path $PSScriptRoot '.\deployment-templates\key-vault\template.json') -TemplateParameterFile (Join-Path $PSScriptRoot '.\deployment-templates\key-vault\parameters.json') -ResourceGroupName $env.resourceGroup

    Start-Sleep -Seconds 60 # The keyVault not ready to create certificate
    $keyVault = Get-AzKeyVault -ResourceGroupName $env.resourceGroup -VaultName $env.name
    $env.add('vaultUri', $keyVault.VaultUri);

    CreateKeyVaultCertificate -vaultName $env.name -certName $env.certificateName20 -subjectName $env.certSubjectName30
    CreateKeyVaultCertificate -vaultName $env.name -certName $env.certificateName21 -subjectName $env.certSubjectName31
    CreateKeyVaultCertificate -vaultName $env.name -certName $env.certificateName22 -subjectName $env.certSubjectName32
    CreateKeyVaultCertificate -vaultName $env.name -certName $env.certificateName23 -subjectName $env.certSubjectName33
    Write-Host -ForegroundColor Green "Key vault created successfully."

    #deploy cosmos db
    Write-Host -ForegroundColor Green "Start deploying cosmos db for test..."
    $cosmosdbPara = Get-Content (Join-Path $PSScriptRoot '.\deployment-templates\cosmos-db\parameters-01.json') | ConvertFrom-Json
    $cosmosdbPara.parameters.cosmosdb_name.value = $env.cosmosDbName40
    set-content -Path (Join-Path $PSScriptRoot '.\deployment-templates\cosmos-db\parameters-01.json') -Value (ConvertTo-Json $cosmosdbPara)
    New-AzDeployment -Mode Incremental -TemplateFile (Join-Path $PSScriptRoot '.\deployment-templates\cosmos-db\template-01.json') -TemplateParameterFile (Join-Path $PSScriptRoot '.\deployment-templates\cosmos-db\parameters-01.json') -ResourceGroupName $env.resourceGroup

    $cosmosdbPara = Get-Content (Join-Path $PSScriptRoot '.\deployment-templates\cosmos-db\parameters-02.json') | ConvertFrom-Json
    $cosmosdbPara.parameters.cosmosdb_name.value = $env.cosmosDbName41
    set-content -Path (Join-Path $PSScriptRoot '.\deployment-templates\cosmos-db\parameters-02.json') -Value (ConvertTo-Json $cosmosdbPara)
    New-AzDeployment -Mode Incremental -TemplateFile (Join-Path $PSScriptRoot '.\deployment-templates\cosmos-db\template-02.json') -TemplateParameterFile (Join-Path $PSScriptRoot '.\deployment-templates\cosmos-db\parameters-02.json') -ResourceGroupName $env.resourceGroup
    Start-Sleep -Seconds 60
    $cosmosdb01 = Get-AzCosmosDBAccount -ResourceGroupName $env.resourceGroup -Name $env.cosmosDbName40
    $cosmosdb02 = Get-AzCosmosDBAccount -ResourceGroupName $env.resourceGroup -Name $env.cosmosDbName41
    Write-Host -ForegroundColor Green "Wait for cosmosdb creating..."
    while(($cosmosdb01.ProvisioningState -ne 'Succeeded') -or ($cosmosdb02.ProvisioningState -ne 'Succeeded'))
    {
        $cosmosdb01 = Get-AzCosmosDBAccount -ResourceGroupName $env.resourceGroup -Name $env.cosmosDbName40
        $cosmosdb02 = Get-AzCosmosDBAccount -ResourceGroupName $env.resourceGroup -Name $env.cosmosDbName41
    }
    $cosmosdbKey01 = Get-AzCosmosDBAccountKey -ResourceGroupName $env.resourceGroup -Name $env.cosmosDbName40
    $cosmosdbKey02 = Get-AzCosmosDBAccountKey -ResourceGroupName $env.resourceGroup -Name $env.cosmosDbName41
    $env.add("cosmosDbName40Key", $cosmosdbKey01.Item("PrimaryMasterKey"))
    $env.add("cosmosDbName41Key", $cosmosdbKey02.Item("PrimaryMasterKey"))
    Write-Host -ForegroundColor Green "Cosmos db created successfully."
    #>

    # For any resources you created for test, you should add it to $env here.
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

