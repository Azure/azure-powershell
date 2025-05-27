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

    $storageCacheAmlFileSystemName = "azps-" + (RandomString -allChars $false -len 6)
    $storageCacheAmlFileSystemName2 = "azps-" + (RandomString -allChars $false -len 6)

    $env.Add("storageCacheAmlFileSystemName", $storageCacheAmlFileSystemName)
    $env.Add("storageCacheAmlFileSystemName2", $storageCacheAmlFileSystemName2)

    $managementIdentityName = "azps-management-identity" # "azps-" + (RandomString -allChars $false -len 6)
    $keyVaultName = "azps-keyvault-0704" # "azps-" + (RandomString -allChars $false -len 6)
    $keyVaultKeyName = "az-kv-0703" # "azps-" + (RandomString -allChars $false -len 6)
    $virtualNetworkName = "azps-virtual-network" # "azps-" + (RandomString -allChars $false -len 6)
    $storageAccountName = "azpssa0706" # "azps-" + (RandomString -allChars $false -len 6)
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
    # New-AzResourceGroup -Name $env.resourceGroup -Location $env.location #New-AzResourceGroup -Location eastus -Name azps_test_gp_storagecache

    # Need Create VirtualNetwork
    # New-AzVirtualNetwork -Name azps-virtual-network -ResourceGroupName azps_test_gp_storagecache -Location eastus -AddressPrefix "10.0.0.0/16"

    # Need Create KeyVault
    # New-AzKeyVault -ResourceGroupName azps_test_gp_storagecache -VaultName azps-keyvault-0704 -Location eastus -Sku 'Premium' -EnablePurgeProtection
    # $UserObjectId = (Get-AzAdUser -SignedIn).Id
    # New-AzRoleAssignment -ObjectId $UserObjectId -RoleDefinitionName 'Key Vault Administrator' -Scope /subscriptions/28d194e0-fa92-40ee-b3e7-2e76df62f16b/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.KeyVault/vaults/azps-keyvault-0704
    # Add-AzKeyVaultKey -VaultName azps-keyvault-0704 -Name az-kv-0703 -Destination "Software" -KeyType "RSA" -Size 2048

    # Need Create ManagementIdentity.
    # $MI = New-AzUserAssignedIdentity -ResourceGroupName azps_test_gp_storagecache -Name azps-management-identity -Location eastus

    # Need Assignment of Permissions. HPC Cache Resource Provider ObjectId is 24dee0b1-300e-400d-b6e5-8af3e4ba3545
    # Need Create StorageAccount and create sas key.
    # New-AzStorageAccount -SkuName "Standard_LRS" -Kind StorageV2 -ResourceGroupName azps_test_gp_storagecache -Name azpssa0706 -Location eastus
    # $ctx = New-AzStorageContext -StorageAccountName azpssa0706 -UseConnectedAccount
    # New-AzStorageContainer -Name "az-blob" -Context $ctx
    # New-AzStorageContainer -Name "az-blob-login" -Context $ctx
    # New-AzRoleAssignment -ObjectId 24dee0b1-300e-400d-b6e5-8af3e4ba3545 -RoleDefinitionName 'Storage Account Contributor' -Scope /subscriptions/28d194e0-fa92-40ee-b3e7-2e76df62f16b/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.Storage/storageAccounts/azpssa0706
    # New-AzRoleAssignment -ObjectId 24dee0b1-300e-400d-b6e5-8af3e4ba3545 -RoleDefinitionName 'Storage Blob Data Contributor' -Scope /subscriptions/28d194e0-fa92-40ee-b3e7-2e76df62f16b/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.Storage/storageAccounts/azpssa0706

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

