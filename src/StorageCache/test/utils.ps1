function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
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

    $storageCacheName = "azps-storagecache" # "azps-" + (RandomString -allChars $false -len 6)
    $storageCacheName2 = "azps-" + (RandomString -allChars $false -len 6)
    $storageCacheTargetName = "azps-" + (RandomString -allChars $false -len 6)
    $storageCacheAmlFileSystemName = "azps-" + (RandomString -allChars $false -len 6)
    $storageCacheAmlFileSystemName2 = "azps-" + (RandomString -allChars $false -len 6)
    
    $env.Add("storageCacheName", $storageCacheName)
    $env.Add("storageCacheName2", $storageCacheName2)
    $env.Add("storageCacheTargetName", $storageCacheTargetName)
    $env.Add("storageCacheAmlFileSystemName", $storageCacheAmlFileSystemName)
    $env.Add("storageCacheAmlFileSystemName2", $storageCacheAmlFileSystemName2)
    
    $managementIdentityName = "azps-management-identity" # "azps-" + (RandomString -allChars $false -len 6)
    $keyVaultName = "azps-keyvault" # "azps-" + (RandomString -allChars $false -len 6)
    $keyVaultKeyName = "az-kv-0703" # "azps-" + (RandomString -allChars $false -len 6)
    $virtualNetworkName = "azps-virtual-network" # "azps-" + (RandomString -allChars $false -len 6)
    $storageAccountName = "azpssa0703" # "azps-" + (RandomString -allChars $false -len 6)
    $blobContainerName1 = "az-blob" # "azps-" + (RandomString -allChars $false -len 6)
    $blobContainerName2 = "az-blob-login" # "azps-" + (RandomString -allChars $false -len 6)

    $env.Add("managementIdentityName", $managementIdentityName)
    $env.Add("keyVaultName", $keyVaultName)
    $env.Add("keyVaultKeyName", $keyVaultKeyName)
    $env.Add("virtualNetworkName", $virtualNetworkName)
    $env.Add("storageAccountName", $storageAccountName)
    $env.Add("blobContainerName1", $blobContainerName1)
    $env.Add("blobContainerName2", $blobContainerName2)

    # Create the test group
    $env.Add("location", "eastus")
    write-host "start to create test group"
    $resourceGroup = "azps_test_gp_storagecache"
    $env.Add("resourceGroup", $resourceGroup)
    
    # Use mock environment, so we donnot run this cmdlet.
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    # Need Create VirtualNetwork
    # New-AzVirtualNetwork -Name azps-virtual-network -ResourceGroupName azps_test_gp_storagecache -Location eastus -AddressPrefix "10.0.0.0/16" 

    # Need Create KeyVault
    # New-AzKeyVault -ResourceGroupName azps_test_gp_storagecache -VaultName azps-keyvault-0703 -Location eastus -Sku 'Premium' -EnablePurgeProtection

    # Need Create ManagementIdentity.
    # Need Assignment of Permissions.
    # Need Create StorageAccount and create sas key.

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.resourceGroup
}

