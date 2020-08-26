function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    Write-Host -ForegroundColor Yellow "WARNING: Need to use Az.KeyVault module, Please check if installed Az.KeyVault(2.0.0 or Greater)."
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    # Generate some random strings for use in the test.
    $rstr1 = RandomString -allChars $false -len 6
    $rstr2 = RandomString -allChars $false -len 6
    $rstr3 = RandomString -allChars $false -len 6
    $rstr6 = RandomString -allChars $false -len 6
    # Follow random strings will be used in the test directly, so add it to $env
    $rstr4 = RandomString -allChars $false -len 6
    $rstr5 = RandomString -allChars $false -len 6
    $null = $env.Add("rstr4", $rstr4)
    $null = $env.Add("rstr5", $rstr5)

    # Create the test group
    write-host "start to create test group"
    $resourceGroup = 'databricks-rg-' + $rstr1
    $null = $env.Add("resourceGroup", $resourceGroup)
    New-AzResourceGroup -Name $resourceGroup -Location eastus

    # create three Databricks workspaces for test
    Write-Host -ForegroundColor Green "Create databricks workspace for test..." 
    $testWorkspace1 = "workspace" + $rstr2
    New-AzDatabricksWorkspace -Name $testWorkspace1 -ResourceGroupName $resourceGroup -Location eastus -Sku standard
    $null = $env.Add("testWorkspace1", $testWorkspace1)
    $testWorkspace2 = "workspace" + $rstr3
    New-AzDatabricksWorkspace -Name $testWorkspace2 -ResourceGroupName $resourceGroup -Location eastus -Sku standard
    $null = $env.Add("testWorkspace2", $testWorkspace2)
    $testWorkspace3 = "workspace" + $rstr6
    $dbr3 = New-AzDatabricksWorkspace -Name $testWorkspace3 -ResourceGroupName $resourceGroup -PrepareEncryption -Location "East US 2 EUAP" -Sku premium
    $null = $env.Add("testWorkspace3", $testWorkspace3)
    Write-Host -ForegroundColor Green "Create completed" 

    # Deploy virtual network and network security group for test
    Write-Host -ForegroundColor Green "Deloying network..." 
    $virtualNetwork = "databricks-test-vn"
    $subscriptionId = $env.SubscriptionId
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\security-network-group\template.json -TemplateParameterFile .\test\deployment-templates\security-network-group\parameters.json -Name nsg -ResourceGroupName $resourceGroup
    $null = $env.Add("virtualNetwork", "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$virtualNetwork")
    $vnPara = Get-Content .\test\deployment-templates\virtual-network\parameters.json | ConvertFrom-Json
    $vnPara.parameters.networkSecurityGroups_dolaulinsg_externalid.value = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.Network/networkSecurityGroups/databricks-test-nsg"
    set-content -Path .\test\deployment-templates\virtual-network\parameters.json -Value (ConvertTo-Json $vnPara)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\virtual-network\template.json -TemplateParameterFile .\test\deployment-templates\virtual-network\parameters.json -Name vn -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Green "Network deploy completed." 
    
    # Deploy keyvault for test
    Write-Host -ForegroundColor Green "Deloying Key Vault..." 
    $kvName = 'keyvalult-' + (RandomString -allChars $false -len 6)
    $kvPara = Get-Content .\test\deployment-templates\key-vault\parameters.json | ConvertFrom-Json
    $kvPara.parameters.keyvault_name.value = $kvName
    $kvPara.parameters.storageaccount_principalid.value = $dbr3.StorageAccountIdentityPrincipalId
    set-content -Path .\test\deployment-templates\key-vault\parameters.json -Value (ConvertTo-Json $kvPara)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\key-vault\template.json -TemplateParameterFile .\test\deployment-templates\key-vault\parameters.json -ResourceGroupName $resourceGroup
    
    $kv = Get-AzKeyVault -ResourceGroupName $resourceGroup -VaultName $kvName
    $null = $env.Add('keyVaultUri', $kv.VaultUri)
    $keyName = 'key-' + (RandomString -allChars $false -len 6)
    $key = Add-AzKeyVaultKey -InputObject $kv -Name $keyName -Destination 'Software'
    $null = $env.Add('keyVaultKeyName', $key.Name)
    $null = $env.Add('keyVaultKeyVersion', $key.Version)
    Write-Host -ForegroundColor Green "key Vault deploy completed." 
    
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Removing resourcegroup will clean all the resources created for testing.
    Remove-AzResourceGroup -Name $env.resourceGroup
}

