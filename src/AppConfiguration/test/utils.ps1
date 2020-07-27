function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    Write-Host -ForegroundColor Yellow "WARNING: Need to use Az.KeyVault and Az.ManagedServiceIdentity modules, Please check if installed Az.KeyVault(2.0.0 or greater version) and Az.ManagedServiceIdentity(0.7.3 or greater version)."
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'eastus'

    $appconfName00 = 'appconf-' + (RandomString -allChars $false -len 6)
    $appconfName01 = 'appconf-' + (RandomString -allChars $false -len 6)
    $appconfName02 = 'appconf-' + (RandomString -allChars $false -len 6)
    $appconfName03 = 'appconf-' + (RandomString -allChars $false -len 6)
    $appconfName04 = 'appconf-' + (RandomString -allChars $false -len 6)
    $appconfName05 = 'appconf-' + (RandomString -allChars $false -len 6)
    $appconfName06 = 'appconf-' + (RandomString -allChars $false -len 6)
    $appconfName07 = 'appconf-' + (RandomString -allChars $false -len 6)
    $env.Add('appconfName00', $appconfName00)
    $env.Add('appconfName01', $appconfName01)
    $env.Add('appconfName02', $appconfName02)
    $env.Add('appconfName03', $appconfName03)
    $env.Add('appconfName04', $appconfName04)
    $env.Add('appconfName05', $appconfName05)
    $env.Add('appconfName06', $appconfName06)
    $env.Add('appconfName07', $appconfName07)

    # Create resource group
    Write-Host -ForegroundColor Green 'Start creating Resource Group for test...'
    $env.resourceGroup = 'appconfstore-rg-' + (RandomString -allChars $false -len 6)
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location
    Write-Host -ForegroundColor Green 'Resource Group created successfully.'

    # Deployment Key Vault for test.
    Write-Host -ForegroundColor Green "Deloying Key Vault..." 
    $kvName = 'kv-' + (RandomString -allChars $false -len 6)
    $keyName = 'key-' + (RandomString -allChars $false -len 6)
    $kvParamaters = Get-Content -Path (Join-Path $PSScriptRoot \deployment-templates\key-vault\parameters.json) | ConvertFrom-Json
    $kvParamaters.parameters.keyvault_name.value = $kvName
    Set-Content -Path (Join-Path $PSScriptRoot \deployment-templates\key-vault\parameters.json) -Value (ConvertTo-Json $kvParamaters)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\key-vault\template.json -TemplateParameterFile .\test\deployment-templates\key-vault\parameters.json -ResourceGroupName $env.resourceGroup
    Start-Sleep -Seconds 60 # Waiting create completed.
    # Create key in Key Vault
    $key = Add-AzKeyVaultKey -VaultName $kvName -Name $keyName -Destination 'Software'
    $env.encryptionKeyIdentifier = $key.Id
    Write-Host -ForegroundColor Green "Key Vault deploy completed." 

    # Create managed mdentity for test.
    Write-Host -ForegroundColor Green "Creating Managed Identity..."
    $assignedIdentityName = 'managedidentity-' + (RandomString -allChars $false -len 6)
    # The managed identity cannot be exported in azure portal so use az modules.
    $assignedIdentity = New-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup -Name $assignedIdentityName
    $env.assignedIdentityId = $assignedIdentity.Id
    $env.assignedIdentityPrincipalId = $assignedIdentity.PrincipalId
    $env.assignedIdentityClinetId = $assignedIdentity.ClientId
    Write-Host -ForegroundColor Green "Managed Identity created completed"

    Write-Host -ForegroundColor Green '--------------------------------------------'
    Write-Host -ForegroundColor Green 'Start creating App Configuration Store for test...'

    New-AzAppConfigurationStore -Name $env.appconfName00 -ResourceGroupName $env.resourceGroup -Location $env.location `
    -Sku 'free' -IdentityType "UserAssigned" `
    -UserAssignedIdentity $env.assignedIdentityId

    $systemAssignedAppStore = New-AzAppConfigurationStore -Name $env.appconfName01 -ResourceGroupName $env.resourceGroup -Location $env.location `
    -Sku 'standard' -IdentityType "SystemAssigned"
    
    Write-Host -ForegroundColor Green 'App Configuration Store created successfully.'

    Start-Sleep -Seconds 60 # Waiting app configuration store registered in the current subscription's Azure Active directory.
    
    # Enable Managed Identity and app configuration access to key valult.
    Write-Host -ForegroundColor Green "Enable Managed Identity and App Configuration Store access to Key Vault"
    Set-AzKeyVaultAccessPolicy -VaultName $kvName -ObjectId $systemAssignedAppStore.IdentityPrincipalId -PermissionsToKeys get,unwrapKey,wrapKey -PassThru
    Set-AzKeyVaultAccessPolicy -VaultName $kvName -ObjectId $assignedIdentity.PrincipalId -PermissionsToKeys get,unwrapKey,wrapKey -PassThru

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

