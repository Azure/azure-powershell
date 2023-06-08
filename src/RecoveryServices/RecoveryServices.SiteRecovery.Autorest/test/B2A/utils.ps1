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
    $env.asrSubscriptionId = "7c943c1b-5122-4097-90c8-861411bdd574"
    $env.asrTenant = "72f988bf-86f1-41af-91ab-2d7cd011db47"
    $env.asrResourceGroup = "ASRTesting"
    $env.asrPolicyName = "replicapolicyh2a"
    $env.asrResourceName = "HyperV2AzureVault"
    $env.asrRemovePolicyCreation = "replicapolicy5h2a"
    $env.asrNewPolicyCreation = "replicapolicy4h2a"
    $env.asrNewPolicyUpdation = "replicapolicy4h2a"
    $env.asrMachineName = "IDCLAB-A411.fareast.corp.microsoft.com"
    $env.asrStorageAccountName = "hyperv2azurestorageeus"
    $env.asrMachineId = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015abd5-5788-6477-c69f-bb53618ac3b8"
    $env.asrTestNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/fancy(migrate)/providers/Microsoft.Network/virtualNetworks/Cbtsignoff2105targetnetwork"
    $env.asrJobId = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationJobs/92457265-7eb3-4391-837c-b71e6cce9334"
    $env.asrJobName = "54f4d887-e6b4-4424-8a15-42e452343552"
    $env.asrProjectId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.Migrate/migrateprojects/cbtsignoff2105project"
    $env.asrResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/fancy(migrate)"
    $env.asrVaultName = "signoff2105app1452vault"
    $env.asrProtectionContainerName = "signoff2105app1c36replicationcontainer"
    $env.asrFabricName = "signoff2105app1c36replicationfabric"
    $env.asrMappingName = "containermapping"
    $env.asrProviderName = "signoff2105app1c36dra"
    
    

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

