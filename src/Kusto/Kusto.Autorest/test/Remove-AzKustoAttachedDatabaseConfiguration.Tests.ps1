Describe 'Remove-AzKustoAttachedDatabaseConfiguration' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKustoAttachedDatabaseConfiguration.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Delete' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = "testdatabase" + $env.rstr5
        $attachedDatabaseConfigurationName = "testdbconf" + $env.rstr5
        $followerClusterName = $env.kustoFollowerClusterName
        $DefaultPrincipalsModificationKind = "Union"
        $clusterResourceId = $env.kustoClusterResourceId

        New-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $location
        New-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName -Location $location -ClusterResourceId $clusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $DefaultPrincipalsModificationKind
        { Remove-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName } | Should -Not -Throw
        Remove-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
    }
}
