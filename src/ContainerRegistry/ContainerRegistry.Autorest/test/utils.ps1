function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    # Generate some random strings for use in the test.
    $rstr1 = RandomString -allChars $false -len 6
    $rstr2 = RandomString -allChars $false -len 6
    $rstr3 = RandomString -allChars $false -len 6
    $rstr4 = RandomString -allChars $false -len 6
    $rstr5 = RandomString -allChars $false -len 6
    $rstr6 = RandomString -allChars $false -len 6
    $rstr7 = RandomString -allChars $false -len 6
    $rstr8 = RandomString -allChars $false -len 6
    $webhook = "webhook001"
    $replication = "replication001"
    $null = $env.Add("rstr1", $rstr1)
    $null = $env.Add("rstr2", $rstr2)
    $null = $env.Add("rstr3", $rstr3)
    $null = $env.Add("rstr4", $rstr4)


    # Create the test group
    write-host "start to create test group"
    $resourceGroup = "ContainerTest"
    $null = $env.Add("resourceGroup", $resourceGroup)
    New-AzResourceGroup -Name $resourceGroup -Location "eastus"
    New-AzContainerRegistry -RegistryName $env.rstr1 -sku 'Premium' -ResourceGroupName $env.ResourceGroup -Location "eastus" -EnableAdminUser
    New-AzContainerRegistry -RegistryName $env.rstr3 -sku 'Premium' -ResourceGroupName $env.ResourceGroup -Location "eastus" -EnableAdminUser
    New-AzContainerRegistryReplication -name  $env.rstr1 -RegistryName  $env.rstr1 -ResourceGroupName $env.ResourceGroup -Location "westus"  
    New-AzContainerRegistryReplication -name  $env.rstr3 -RegistryName  $env.rstr1 -ResourceGroupName $env.ResourceGroup -Location "eastus2"  
    New-AzContainerRegistryAgentPool -name $env.rstr1  -RegistryName $env.rstr1 -ResourceGroupName $resourceGroup -Location 'eastus' -Count 1 -Tier S1 -os 'Linux'
    New-AzContainerRegistryAgentPool -name $env.rstr3  -RegistryName $env.rstr1 -ResourceGroupName $resourceGroup -Location 'eastus' -Count 1 -Tier S1 -os 'Linux'
    New-AzContainerRegistryScopeMap  -Name $env.rstr1 -RegistryName  $env.rstr1 -ResourceGroupName $resourceGroup -Action "repositories/busybox/content/read"
    New-AzContainerRegistryScopeMap  -Name $env.rstr3 -RegistryName  $env.rstr1 -ResourceGroupName $resourceGroup -Action "repositories/busybox/content/read"
    New-AzContainerRegistryWebhook -RegistryName $env.rstr1 -ResourceGroupName $env.resourceGroup -Name $env.rstr1 -ServiceUri http://www.bing.com -Action Delete,Push -Location "east us" -Status Enabled -Scope "foo:*" 
    New-AzContainerRegistryWebhook -RegistryName $env.rstr1 -ResourceGroupName $env.resourceGroup -Name $env.rstr3 -ServiceUri http://www.bing.com -Action Delete,Push -Location "east us" -Status Enabled -Scope "foo:*" 
    $keyVaultUri = "https://lnxtestkeyvault.vault.azure.net/secrets/test/de11705d609e48b6a2faf6facc30a9e0"
    $StorageAccount = "https://acrteststorageaccount.blob.core.windows.net/test"
    New-AzContainerRegistryExportPipeline -name $env.rstr1 -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup -IdentityType 'SystemAssigned' -TargetType AzureStorageBlobContainer -TargetUri $StorageAccount -TargetKeyVaultUri $keyVaultUri 
    New-AzContainerRegistryExportPipeline -name $env.rstr3 -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup -IdentityType 'SystemAssigned' -TargetType AzureStorageBlobContainer -TargetUri $StorageAccount -TargetKeyVaultUri $keyVaultUri 
    New-AzContainerRegistryImportPipeline -name $env.rstr1 -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup -IdentityType 'SystemAssigned' -SourceType AzureStorageBlobContainer -SourceUri $StorageAccount -SourceKeyVaultUri $keyVaultUri 
    New-AzContainerRegistryImportPipeline -name $env.rstr3 -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup -IdentityType 'SystemAssigned' -SourceType AzureStorageBlobContainer -SourceUri $StorageAccount -SourceKeyVaultUri $keyVaultUri 
    $map = Get-AzContainerRegistryScopeMap -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup -Name $env.rstr1
    New-AzContainerRegistryToken -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup -Name $env.rstr3 -ScopeMapId $map.Id
    New-AzContainerRegistryToken -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup -Name $env.rstr4 -ScopeMapId $map.Id

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

