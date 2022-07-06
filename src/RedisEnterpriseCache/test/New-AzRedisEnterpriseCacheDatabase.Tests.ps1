$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRedisEnterpriseCacheDatabase.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzRedisEnterpriseCacheDatabase' {
    It 'Create' {
        $splat = @{
            Name = $env.ClusterName2
            ResourceGroupName = $env.ResourceGroupName
            SubscriptionId = $env.SubscriptionId
            ClientProtocol = "Encrypted"
            ClusteringPolicy = "EnterpriseCluster"
            EvictionPolicy = "NoEviction"
            Port = 10000
        }
        $database = New-AzRedisEnterpriseCacheDatabase @splat
        $databaseName = "default"
        $database.Name | Should -Be $databaseName
        $database.Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
        $database.ClientProtocol | Should -Be $splat.ClientProtocol
        $database.ClusteringPolicy | Should -Be $splat.ClusteringPolicy
        $database.EvictionPolicy | Should -Be $splat.EvictionPolicy
        $database.Port | Should -Be $splat.Port
        $database.ProvisioningState | Should -Be "Succeeded"
        $database.ResourceState | Should -Be "Running"
    }
    It 'Create a georeplicated database' {
        $id = "{{id:`"/subscriptions/{0}/resourceGroups/{1}/Microsoft.Cache/redisEnterprise/{2}/databases/default`"}}"
        $splat = @{
            Name = $env.ClusterName3
            ResourceGroupName = $env.ResourceGroupName
            SubscriptionId = $env.SubscriptionId
            ClientProtocol = "Encrypted"
            ClusteringPolicy = "EnterpriseCluster"
            EvictionPolicy = "NoEviction"
            GroupNickname = "GroupName" 
            LinkedDatabase = $id -f $env.SubscriptionId,$env.ResourceGroupName,$env.ClusterName3
        }
        $database = New-AzRedisEnterpriseCacheDatabase @splat
        $databaseName = "default"
        $database.Name | Should -Be $databaseName
        $database.Type | Should -Be "Microsoft.Cache/redisEnterprise/databases"
        $database.ClientProtocol | Should -Be $splat.ClientProtocol
        $database.ClusteringPolicy | Should -Be $splat.ClusteringPolicy
        $database.EvictionPolicy | Should -Be $splat.EvictionPolicy
        $database.ProvisioningState | Should -Be "Succeeded"
        $database.ResourceState | Should -Be "Running"
        $database.GeoReplication.GroupNickname | Should -Be "GroupName"
        $database.GeoReplication.LinkedDatabase | Should -Be "/subscriptions/{0}/resourceGroups/{1}/Microsoft.Cache/redisEnterprise/{2}/databases/default" -f $env.SubscriptionId,$env.ResourceGroupName,$env.ClusterName3
    }
        <#Create another cache with other command for linking*/#>
}
