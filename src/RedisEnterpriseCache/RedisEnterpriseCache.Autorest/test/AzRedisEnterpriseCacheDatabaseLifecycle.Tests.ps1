$selectedTestNames = Get-SelectedTestNames
if (($selectedTestNames.Count -eq 0) -or ($selectedTestNames -contains 'AzRedisEnterpriseCacheDatabaseLifecycle'))
{
    $TestEnvironmentName = 'database'
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-not (Test-Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . $loadEnvPath
    $TestRecordingFile = Join-Path $PSScriptRoot 'AzRedisEnterpriseCacheDatabaseLifecycle.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzRedisEnterpriseCacheDatabaseLifecycle' {
    It 'Creates a cache without a database' {
        $cache = New-AzRedisEnterpriseCache -Name $env.ClusterName2 -ResourceGroupName $env.ResourceGroupName -Location $env.Location -SubscriptionId $env.SubscriptionId -Sku 'Balanced_B10' -NoDatabase -PublicNetworkAccess 'Enabled'
        $cache.Name | Should -Be $env.ClusterName2
        ($cache.Location.ToLower() -replace '\s', '') | Should -Be $env.Location
        $cache.SkuName | Should -Be 'Balanced_B10'
        $cache.ProvisioningState | Should -Be 'Succeeded'
        $cache.ResourceState | Should -Be 'Running'
        $cache.Database.Count | Should -Be 0
    }

    It 'Creates a database with keyspace notifications' {
        $database = New-AzRedisEnterpriseCacheDatabase -Name $env.ClusterName2 -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -ClientProtocol 'Encrypted' -ClusteringPolicy 'EnterpriseCluster' -EvictionPolicy 'AllKeysLFU' -Port 10000 -AccessKeysAuthentication 'Enabled' -NotifyKeyspaceEvents 'KEA'
        $database.Name | Should -Be 'default'
        $database.Type | Should -Be 'Microsoft.Cache/redisEnterprise/databases'
        $database.ClientProtocol | Should -Be 'Encrypted'
        $database.ClusteringPolicy | Should -Be 'EnterpriseCluster'
        $database.EvictionPolicy | Should -Be 'AllKeysLFU'
        $database.Port | Should -Be 10000
        $database.ProvisioningState | Should -Be 'Succeeded'
        $database.ResourceState | Should -Be 'Running'
        $database.NotifyKeyspaceEvents | Should -Be 'KEA'
    }

    It 'Updates keyspace notifications through PUT' {
        $database = New-AzRedisEnterpriseCacheDatabase -ClusterName $env.ClusterName2 -ResourceGroupName $env.ResourceGroupName -ClusteringPolicy 'EnterpriseCluster' -NotifyKeyspaceEvents 'Kg'
        $database.NotifyKeyspaceEvents | Should -Be 'Kg'
    }

    It 'Gets the database' {
        $databases = @(Get-AzRedisEnterpriseCacheDatabase -Name $env.ClusterName2 -ResourceGroupName $env.ResourceGroupName)
        $databases.Count | Should -Be 1
        $databases[0].Name | Should -Be 'default'
        $databases[0].Type | Should -Be 'Microsoft.Cache/redisEnterprise/databases'
    }

    It 'Deletes the database and cache' {
        {
            Remove-AzRedisEnterpriseCacheDatabase -Name $env.ClusterName2 -ResourceGroupName $env.ResourceGroupName
            Remove-AzRedisEnterpriseCache -Name $env.ClusterName2 -ResourceGroupName $env.ResourceGroupName
        } | Should -Not -Throw
    }
}
