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
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name '$env'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $env.a2aSubscriptionId = "7c943c1b-5122-4097-90c8-861411bdd574"
    $env.a2aVaultName = "a2arecoveryvault"
    $env.a2aResourceGroupName = "a2arecoveryrg"
    $env.a2aPolicyName = "demopolicy1"
    $env.a2aCreateRemovePolicy = "a2ademoPolicy"
    $env.a2aFabricName = "A2Aprimaryfabric"
    $env.a2aFabricFriendlyName = "West US 2"
    $env.a2ademofabric = "a2ademofabric"
    $env.a2aProtectionContainerName = "A2AEastUSProtectionContainer2"
    $env.a2apcName = "demoProtectionContainer"
    $env.dela2apcName = "demoProtectionContainer1"
    $env.a2ampfabricname = "A2Ademo-EastUS"
    $env.a2amppcname = "A2AEastUSProtectionContainer"
    $env.mappingName = "demomap"
    $env.delcreatemap = "A2ARecoveryToPrimary"
    $env.getmappingName = "A2AprimaryToRecovery"
    $env.mapPolicy = "A2APolicy"
    $env.replicatedProtectedItem = "replicatedvmtest"
    $env.protectedItemtemp = "replicatedvmtest3"
    $env.protectedItemtest = "replicatedvmtestcheckfail"
    $env.testNetworkType = "VmNetworkAsInput"
    $env.recoverypoint = "fdb30f02-20dd-4499-9b5f-fdcf70a20830"
    $env.unplannedfailvm = "abhinavVmProtected"
    $env.reprotectvm = "replicatedvmtestcheck"
    $env.reversemap = "demoProtectionContainerA2A"
    $env.reversemapname = "reversemapping"

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

