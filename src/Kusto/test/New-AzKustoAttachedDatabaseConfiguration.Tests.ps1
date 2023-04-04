Describe 'New-AzKustoAttachedDatabaseConfiguration' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoAttachedDatabaseConfiguration.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'CreateExpanded' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = "testdatabase" + $env.rstr4
        $attachedDatabaseConfigurationName = "testdbconf" + $env.rstr4
        $followerClusterName = $env.kustoFollowerClusterName
        $DefaultPrincipalsModificationKind = "Union"
        $clusterResourceId = $env.kustoClusterResourceId
        $followerClusterResourceId = $env.kustoFolowerClusterResourceId
        $attachedDatabaseConfigurationFullName = $followerClusterName + "/" + $attachedDatabaseConfigurationName

        New-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $location
        $attachedDatabaseConfigurationCreated = New-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName -Location $location -ClusterResourceId $clusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $DefaultPrincipalsModificationKind
        Validate_AttachedDatabaseConfiguration $attachedDatabaseConfigurationCreated $attachedDatabaseConfigurationFullName  $location $clusterResourceId $databaseName DefaultPrincipalsModificationKind
        { Invoke-AzKustoDetachClusterFollowerDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName -ClusterResourceId $followerClusterResourceId } | Should -Not -Throw
        Remove-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
    }
}
