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
    # For any resources you created for test, you should add it to $env here.

    $env.location = 'eastus'
    $env.resourceGroupName = "relay-" + (RandomString -allChars $false -len 6)
    $env.namespaceName01 = "namespace-" + (RandomString -allChars $false -len 6)
    $env.namespaceName02 = "namespace-" + (RandomString -allChars $false -len 6)
    $env.namespaceName03 = "namespace-" + (RandomString -allChars $false -len 6)
    $env.namespaceName04 = "namespace-" + (RandomString -allChars $false -len 6)
    $env.namespaceName05 = "namespace-" + (RandomString -allChars $false -len 6)

    $env.authRuleName01 = "authRule-" + (RandomString -allChars $false -len 6)
    $env.authRuleName02 = "authRule-" + (RandomString -allChars $false -len 6)
    $env.authRuleName03 = "authRule-" + (RandomString -allChars $false -len 6)
    $env.authRuleName04 = "authRule-" + (RandomString -allChars $false -len 6)

    $env.hybridConnectionName01 = "hybridConnection-" + (RandomString -allChars $false -len 6)
    $env.hybridConnectionName02 = "hybridConnection-" + (RandomString -allChars $false -len 6)
    $env.hybridConnectionName03 = "hybridConnection-" + (RandomString -allChars $false -len 6)
    $env.hybridConnectionName04 = "hybridConnection-" + (RandomString -allChars $false -len 6)
    
    $env.wcfRelayName01 = "wcfRelay-" + (RandomString -allChars $false -len 6)
    $env.wcfRelayName02 = "wcfRelay-" + (RandomString -allChars $false -len 6)
    $env.wcfRelayName03 = "wcfRelay-" + (RandomString -allChars $false -len 6)
    $env.wcfRelayName04 = "wcfRelay-" + (RandomString -allChars $false -len 6)

    Write-Host "start to create test group"
    New-AzResourceGroup -Name $env.resourceGroupName -Location $env.location

    Write-Host "Create RelayNamespace, HybridConnection, WcfRelay for testing"
    New-AzRelayNamespace -ResourceGroupName $env.resourceGroupName -Name $env.namespaceName01 -Location $env.location
    New-AzRelayHybridConnection -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.hybridConnectionName01 -UserMetadata "test"
    New-AzWcfRelay -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.wcfRelayName01 -WcfRelayType 'NetTcp' -UserMetadata "test"
    New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.authRuleName01 -Rights 'Listen','Send'
    New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -WcfRelay $env.wcfRelayName01 -Name $env.authRuleName01 -Rights 'Listen','Send'
    New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -HybridConnection $env.hybridConnectionName01 -Name $env.authRuleName01 -Rights 'Listen','Send'

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Write-Host "Delete resource group"
    Remove-AzResourceGroup -Name $env.resourceGroupName
}

