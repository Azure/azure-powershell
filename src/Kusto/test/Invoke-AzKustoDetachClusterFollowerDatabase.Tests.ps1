$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzKustoDetachClusterFollowerDatabase.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzKustoDetachClusterFollowerDatabase' {
    It 'DetachExpanded' {
        $subscriptionId = $env.SubscriptionId
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $attachedDatabaseConfigurationName = $env.attachedDatabaseConfigurationName
        $followerClusterName = $env.followerClusterName
        $clusterResourceId= "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Kusto/Clusters/$followerClusterName"
        
        { Invoke-AzKustoDetachClusterFollowerDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName -ClusterResourceId $clusterResourceId } | Should -Not -Throw
    }

    It 'DetachViaIdentityExpanded' {
        $subscriptionId = $env.SubscriptionId
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $attachedDatabaseConfigurationName = $env.attachedDatabaseConfigurationName
        $followerClusterName = $env.followerClusterName
        $clusterResourceId= "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Kusto/Clusters/$followerClusterName"
        
        $cluster = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
        { Invoke-AzKustoDetachClusterFollowerDatabase -InputObject $cluster -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName -ClusterResourceId $clusterResourceId } | Should -Not -Throw
    }
}
