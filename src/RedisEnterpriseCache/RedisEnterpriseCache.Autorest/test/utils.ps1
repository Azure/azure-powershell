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

function Get-MigrationResource {
    param(
        [Parameter(Mandatory)]
        [scriptblock] $Operation
    )

    try {
        return & $Operation
    } catch {
        $statusCode = $_.Exception.Response.StatusCode
        if (($null -ne $statusCode -and [int] $statusCode -eq 404) -or
            $_.Exception.Message -match 'NotFound|could not be found') {
            return $null
        }

        throw
    }
}

function Wait-ForMigrationResources {
    param(
        [Parameter(Mandatory)]
        [string] $ResourceGroupName,

        [Parameter(Mandatory)]
        [string] $OssCacheName,

        [Parameter(Mandatory)]
        [string] $ClusterName
    )

    if ($TestMode -eq 'playback') {
        return
    }

    $deadline = (Get-Date).AddMinutes(30)
    do {
        $ossCache = Get-MigrationResource {
            Get-AzRedisCache -ResourceGroupName $ResourceGroupName -Name $OssCacheName -ErrorAction Stop
        }
        $cluster = Get-MigrationResource {
            Get-AzRedisEnterpriseCache -ResourceGroupName $ResourceGroupName -Name $ClusterName -ErrorAction Stop
        }
        $database = Get-MigrationResource {
            Get-AzRedisEnterpriseCacheDatabase -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName -ErrorAction Stop
        }

        if ($ossCache.ProvisioningState -eq 'Succeeded' -and
            $cluster.ProvisioningState -eq 'Succeeded' -and
            $cluster.ResourceState -eq 'Running' -and
            $database.ProvisioningState -eq 'Succeeded' -and
            $database.ResourceState -eq 'Running') {
            return
        }

        Start-TestSleep -Seconds 30
    } while ((Get-Date) -lt $deadline)

    $ossState = if ($ossCache) { $ossCache.ProvisioningState } else { 'NotFound' }
    $clusterState = if ($cluster) { "$($cluster.ProvisioningState)/$($cluster.ResourceState)" } else { 'NotFound' }
    $databaseState = if ($database) { "$($database.ProvisioningState)/$($database.ResourceState)" } else { 'NotFound' }
    throw "Migration resources did not become ready within 30 minutes. OSS provisioning: $ossState; cluster provisioning/resource: $clusterState; database provisioning/resource: $databaseState."
}

$env = @{}
$scenarioEnvironments = @{
    'AzRedisEnterpriseCacheClusterLifecycle' = @{
        Environment = 'cluster'
        Recording = 'AzRedisEnterpriseCacheClusterLifecycle.Recording.json'
    }
    'AzRedisEnterpriseCacheDatabaseLifecycle' = @{
        Environment = 'database'
        Recording = 'AzRedisEnterpriseCacheDatabaseLifecycle.Recording.json'
    }
    'AzRedisEnterpriseCacheGeoReplication' = @{
        Environment = 'geo'
        Recording = 'AzRedisEnterpriseCacheGeoReplication.Recording.json'
    }
}

function Get-SelectedScenarioEnvironments {
    $selectedTestNames = @($TestName)
    if ($null -eq $TestName) {
        return @($scenarioEnvironments.Values)
    }

    return @(
        $scenarioEnvironments.Keys |
            Where-Object { $selectedTestNames -contains $_ } |
            ForEach-Object { $scenarioEnvironments[$_] }
    )
}

function Invoke-ScenarioRecordingSanitizer {
    $playbackEnvironment = Get-Content (Join-Path $PSScriptRoot 'env.json') -Raw | ConvertFrom-Json
    foreach ($scenarioEnvironment in Get-SelectedScenarioEnvironments) {
        $environmentPath = Join-Path $PSScriptRoot "env.$($scenarioEnvironment.Environment).json"
        $recordingPath = Join-Path $PSScriptRoot $scenarioEnvironment.Recording
        $recordingEnvironment = Get-Content $environmentPath -Raw | ConvertFrom-Json

        foreach ($path in @($environmentPath, $recordingPath)) {
            $content = Get-Content $path -Raw
            $content = $content.Replace($recordingEnvironment.SubscriptionId, $playbackEnvironment.SubscriptionId)
            $content = $content.Replace($recordingEnvironment.Tenant, $playbackEnvironment.Tenant)
            $content = $content -replace '(\\?"(?:primaryKey|secondaryKey)\\?"\s*:\s*\\?")[^"\\]*(\\?")', '${1}[Sanitized]${2}'
            Set-Content -Path $path -Value $content -NoNewline
        }
    }
}

function setupEnv() {
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.ClusterName  = 'ps-cache-test1-' + (RandomString -allChars $false -len 8)
    $env.ClusterName2 = 'ps-cache-test2-' + (RandomString -allChars $false -len 8)
    $env.ClusterName3  = 'ps-cache-test3-' + (RandomString -allChars $false -len 8)
    $env.ClusterName4 = 'ps-cache-test4-' + (RandomString -allChars $false -len 8)
    $env.OssCacheName = 'ps-oss-cache-' + (RandomString -allChars $false -len 8)
    $env.ResourceGroupName = 'ps-redisenterprise-rg-' + (RandomString -allChars $false -len 8)
    $env.Location = 'eastus2euap'
    New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.Location | Out-Null

    $envFilePrefix = 'env'
    if ($TestMode -eq 'live') {
        $envFilePrefix = 'localEnv'
    }

    $selectedTestNames = @($TestName)
    foreach ($scenarioEnvironment in Get-SelectedScenarioEnvironments) {
        Set-Content -Path (Join-Path $PSScriptRoot "$envFilePrefix.$($scenarioEnvironment.Environment).json") -Value (ConvertTo-Json $env)
    }

    $migrationTestNames = @(
        'Test-AzRedisEnterpriseCacheMigration'
        'Start-AzRedisEnterpriseCacheMigration'
        'Invoke-AzRedisEnterpriseCacheUnlinkMigrationMigratedEndpoint'
        'Invoke-AzRedisEnterpriseCacheUnlinkClusterMigratedEndpoint'
    )
    $isMigrationTest = @($selectedTestNames | Where-Object { $migrationTestNames -contains $_ }).Count -gt 0
    if (($null -eq $TestName) -or $isMigrationTest) {
        Set-Content -Path (Join-Path $PSScriptRoot "$envFilePrefix.json") -Value (ConvertTo-Json $env)
    }

    $ossMigrationTestNames = @(
        'Test-AzRedisEnterpriseCacheMigration'
        'Start-AzRedisEnterpriseCacheMigration'
        'Invoke-AzRedisEnterpriseCacheUnlinkMigrationMigratedEndpoint'
    )
    $isTargetedMigrationTest = @($selectedTestNames | Where-Object { $ossMigrationTestNames -contains $_ }).Count -gt 0
    $isClusterUnlinkTest = $selectedTestNames -contains 'Invoke-AzRedisEnterpriseCacheUnlinkClusterMigratedEndpoint'
    $needsOssCache = ($null -eq $TestName) -or $isTargetedMigrationTest

    if ($needsOssCache) {
        $redisCacheModulePath = $env:AZURE_POWERSHELL_REDIS_CACHE_MODULE_PATH
        if ($redisCacheModulePath) {
            Import-Module $redisCacheModulePath -Force -ErrorAction Stop
        } else {
            Import-Module Az.RedisCache -ErrorAction Stop
        }
        New-AzRedisCache -ResourceGroupName $env.ResourceGroupName -Name $env.OssCacheName -Location $env.Location -Sku "Basic" -Size "C0" | Out-Null
    }

    if ($isTargetedMigrationTest) {
        New-AzRedisEnterpriseCache -Name $env.ClusterName -ResourceGroupName $env.ResourceGroupName -Location $env.Location -Sku "Balanced_B1" -ClientProtocol "Encrypted" -ClusteringPolicy "OSSCluster" -EvictionPolicy "VolatileLRU" -PublicNetworkAccess "Enabled" -ErrorAction Stop | Out-Null
        Wait-ForMigrationResources -ResourceGroupName $env.ResourceGroupName -OssCacheName $env.OssCacheName -ClusterName $env.ClusterName
    } elseif ($isClusterUnlinkTest) {
        New-AzRedisEnterpriseCache -Name $env.ClusterName -ResourceGroupName $env.ResourceGroupName -Location $env.Location -Sku "Enterprise_E1" -ClientProtocol "Encrypted" -ClusteringPolicy "EnterpriseCluster" -EvictionPolicy "NoEviction" -PublicNetworkAccess "Enabled" -ErrorAction Stop | Out-Null
    }

}
function cleanupEnv() {
    Az.Resources\Remove-AzResourceGroup -Name $env.ResourceGroupName -Force -ErrorAction SilentlyContinue | Out-Null
    if ($TestMode -eq 'record') {
        Invoke-ScenarioRecordingSanitizer
    }
}
