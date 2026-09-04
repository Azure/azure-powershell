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

    # Shared, scenario-independent settings. Each scenario uses its own resource
    # group and cluster name so a failure in one scenario does not affect the
    # others and a single scenario can be re-recorded on its own (mirrors the
    # Azure CLI documentdb tests).
    $env.location = 'eastus'
    $env.replicaLocation = 'westus2'
    $env.adminUser = 'testadmin'

    $env.crudRg = $env.AddWithCache('crudRg', 'clitest-docdb-crud-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.crudCluster = $env.AddWithCache('crudCluster', 'cli-mc-' + (RandomString $false 6), $UsePreviousConfigForRecord)

    $env.firewallRg = $env.AddWithCache('firewallRg', 'clitest-docdb-fw-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.firewallCluster = $env.AddWithCache('firewallCluster', 'cli-mc-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.firewallRule = 'allow-azure'

    $env.userRg = $env.AddWithCache('userRg', 'clitest-docdb-user-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.userCluster = $env.AddWithCache('userCluster', 'cli-mc-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.userObjectId = '71581c6f-df31-4790-bc49-26c6b38df8bd'

    $env.identityRg = $env.AddWithCache('identityRg', 'clitest-docdb-identity-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.identityCluster = $env.AddWithCache('identityCluster', 'cli-mc-' + (RandomString $false 6), $UsePreviousConfigForRecord)

    $env.cmkRg = $env.AddWithCache('cmkRg', 'clitest-docdb-cmk-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.cmkCluster = $env.AddWithCache('cmkCluster', 'cli-mc-' + (RandomString $false 6), $UsePreviousConfigForRecord)

    # Pre-provisioned shared resources (created once, out of band) that the identity and
    # CMK scenarios reference by id. They live in a dedicated resource group that the
    # tests never create or delete, so those scenarios only call Az.DocumentDB cmdlets
    # (which are wired to the test mock) and replay cleanly on playback. These are assigned
    # directly (not cached) so a re-record always picks up the current shared resources.
    $sharedRg = 'clitest-docdb-shared'
    $miBase = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$sharedRg/providers/Microsoft.ManagedIdentity/userAssignedIdentities"
    $env.sharedMi1Id = "$miBase/docdb-mi1"
    $env.sharedMi2Id = "$miBase/docdb-mi2"
    $env.cmkMiId = "$miBase/docdb-cmk-mi"
    $env.cmkVault = 'docdbcmkedhmy7l019'
    $env.cmkKeyUrl = "https://$($env.cmkVault).vault.azure.net/keys/docdb-cmk-key"

    $env.replicaRg = $env.AddWithCache('replicaRg', 'clitest-docdb-replica-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.replicaCluster = $env.AddWithCache('replicaCluster', 'cli-mc-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.replicaName = $env.AddWithCache('replicaName', 'cli-mc-rep-' + (RandomString $false 6), $UsePreviousConfigForRecord)

    $env.restoreRg = $env.AddWithCache('restoreRg', 'clitest-docdb-restore-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.restoreCluster = $env.AddWithCache('restoreCluster', 'cli-mc-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.restoredCluster = $env.AddWithCache('restoredCluster', 'cli-mc-rst-' + (RandomString $false 6), $UsePreviousConfigForRecord)

    $env.promoteRg = $env.AddWithCache('promoteRg', 'clitest-docdb-promote-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.promoteCluster = $env.AddWithCache('promoteCluster', 'cli-mc-' + (RandomString $false 6), $UsePreviousConfigForRecord)
    $env.promoteReplica = $env.AddWithCache('promoteReplica', 'cli-mc-rep-' + (RandomString $false 6), $UsePreviousConfigForRecord)

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

# Throwaway administrator password used by the test clusters. Kept out of env.json
# so it is never persisted to a recording.
function Get-DocumentDBTestPassword() {
    return ConvertTo-SecureString 'CliTest2026!Pw' -AsPlainText -Force
}

# Create the shared base cluster used by the scenarios and block until it is
# provisioned. 'extra' named parameters append scenario-specific create flags (for
# example Entra auth modes or a user-assigned identity), mirroring the '_create_cluster'
# helper in the Azure CLI documentdb tests.
function New-DocumentDBTestCluster {
    param(
        [string] $ResourceGroupName,
        [string] $Name,
        [string] $Location,
        [string[]] $AuthConfigAllowedMode,
        [string[]] $PreviewFeature,
        [string[]] $UserAssignedIdentity
    )
    $params = @{
        Name                       = $Name
        ResourceGroupName          = $ResourceGroupName
        Location                   = $Location
        AdministratorUserName      = 'testadmin'
        AdministratorPassword      = (Get-DocumentDBTestPassword)
        ComputeTier                = 'M30'
        StorageSizeGb              = 128
        StorageType                = 'PremiumSSD'
        ShardingShardCount         = 1
        HighAvailabilityTargetMode = 'Disabled'
        ServerVersion              = '8.0'
    }
    if ($AuthConfigAllowedMode) { $params['AuthConfigAllowedMode'] = $AuthConfigAllowedMode }
    if ($PreviewFeature) { $params['PreviewFeature'] = $PreviewFeature }
    if ($UserAssignedIdentity) { $params['UserAssignedIdentity'] = $UserAssignedIdentity }
    return New-AzDocumentDBMongoCluster @params
}

# Poll a mongo cluster until it settles back to a terminal 'Succeeded' state. Mutating
# operations (update, reset-password, identity assign/remove) are asynchronous and leave
# the cluster in 'Updating' for a short while; issuing the next mutating call before it
# settles can conflict. Mirrors the '_cmd_retry' wait in the Azure CLI documentdb tests.
# Uses Start-TestSleep so it does not sleep during playback.
function Wait-DocumentDBClusterSucceeded {
    param(
        [string] $ResourceGroupName,
        [string] $Name
    )
    foreach ($attempt in 1..40) {
        $cluster = Get-AzDocumentDBMongoCluster -ResourceGroupName $ResourceGroupName -Name $Name
        if ($cluster.ProvisioningState -eq 'Succeeded') { return $cluster }
        Start-TestSleep -Seconds 20
    }
    return (Get-AzDocumentDBMongoCluster -ResourceGroupName $ResourceGroupName -Name $Name)
}

# Run a mutating command, retrying while the mongo cluster service still reports an
# operation 'in-progress' or a 'conflict'. The service keeps an internal lock for a short
# while even after an operation reports 'Succeeded', so a follow-up mutating call can be
# rejected briefly. Mirrors the '_cmd_retry' helper in the Azure CLI documentdb tests.
# Uses Start-TestSleep so it does not sleep during playback.
function Invoke-DocumentDBMutation {
    param(
        [scriptblock] $ScriptBlock,
        [int] $Retries = 15,
        [int] $DelaySeconds = 30
    )
    $lastError = $null
    for ($attempt = 0; $attempt -lt $Retries; $attempt++) {
        try {
            return & $ScriptBlock
        } catch {
            $message = "$($_.Exception.Message)"
            if ($message -match 'in-progress' -or $message -match '(?i)conflict') {
                $lastError = $_
                Start-TestSleep -Seconds $DelaySeconds
                continue
            }
            throw
        }
    }
    if ($lastError) { throw $lastError }
}
function cleanupEnv() {
    # Clean resources you create for testing
}

