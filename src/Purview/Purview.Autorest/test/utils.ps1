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
    $env.resourceGroupName = "test-rg" + (RandomString -allChars $false -len 5)
    $env.location = "eastus2"
    $env.accountName = "bez-test-pa"
    $env.accountName1 = "bez-test-pa1"
    $env.accountName2 = "bez-test-pa2"
    $env.accountName3 = "bez-test-pa3"
    $env.skuCapacity = 4
    $env.skuName = "Standard"
    $env.identityType = "SystemAssigned"
    $env.objectId = "2f153a9e-5be9-4f43-abd2-04561777c8b0"
    # For any resources you created for test, you should add it to $env here.
    Write-Debug "Create resource group for test"
    New-AzResourceGroup -Name $env.resourceGroupName -Location $env.location
    
    Write-Debug "Create purview account for test"
    New-AzPurviewAccount -Name $env.accountName -ResourceGroupName $env.resourceGroupName -Location $env.location -IdentityType SystemAssigned -SkuCapacity $env.skuCapacity -SkuName $env.skuName
    New-AzPurviewAccount -Name $env.accountName1 -ResourceGroupName $env.resourceGroupName -Location $env.location -IdentityType SystemAssigned -SkuCapacity $env.skuCapacity -SkuName $env.skuName
    New-AzPurviewAccount -Name $env.accountName2 -ResourceGroupName $env.resourceGroupName -Location $env.location -IdentityType SystemAssigned -SkuCapacity $env.skuCapacity -SkuName $env.skuName
    Set-AzPurviewDefaultAccount -AccountName $env.accountName -ResourceGroupName $env.resourceGroupName -ScopeTenantId $env.Tenant 
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroupName
}

