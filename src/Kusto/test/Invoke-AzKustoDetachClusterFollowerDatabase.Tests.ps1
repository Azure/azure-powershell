$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzKustoDetachClusterFollowerDatabase.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzKustoDetachClusterFollowerDatabase' {
    It 'DetachExpanded' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $attachedDatabaseConfigurationName = "testdbconf" + $env.rstr4
        $followerClusterName = $env.followerClusterName
        $clusterResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Kusto/Clusters/$clusterName"
        $followerClusterResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Kusto/Clusters/$followerClusterName"
        $databaseName = "testdatabase" + $env.rstr4
        $defaultPrincipalsModificationKind = $env.defaultPrincipalsModificationKind

        New-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $location
        New-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName -Location $location -ClusterResourceId $clusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $defaultPrincipalsModificationKind
        { Invoke-AzKustoDetachClusterFollowerDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName -ClusterResourceId $followerClusterResourceId } | Should -Not -Throw
        Remove-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
    }

    It 'DetachViaIdentityExpanded' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $attachedDatabaseConfigurationName = "testdbconf" + $env.rstr5
        $followerClusterName = $env.followerClusterName
        $clusterResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Kusto/Clusters/$clusterName"
        $followerClusterResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Kusto/Clusters/$followerClusterName"
        $databaseName = "testdatabase" + $env.rstr5
        $defaultPrincipalsModificationKind = $env.defaultPrincipalsModificationKind

        New-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $location
        New-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName -Location $location -ClusterResourceId $clusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $defaultPrincipalsModificationKind
        $cluster = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
        { Invoke-AzKustoDetachClusterFollowerDatabase -InputObject $cluster -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName -ClusterResourceId $followerClusterResourceId } | Should -Not -Throw
        Remove-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
    }
}
