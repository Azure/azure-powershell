Describe 'Get-AzKustoAttachedDatabaseConfiguration' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoAttachedDatabaseConfiguration.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'List' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $databaseName = $env.kustoDatabaseName
        $attachedDatabaseConfigurationName = "testAttachedDatabaseConfiguration"
        $followerClusterName = $env.kustoFollowerClusterName
        $DefaultPrincipalsModificationKind = "Union"
        $clusterResourceId = $env.kustoClusterResourceId
        $attachedDatabaseConfigurationFullName = $followerClusterName + "/" + $attachedDatabaseConfigurationName

        New-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName -Location $location -ClusterResourceId $clusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $DefaultPrincipalsModificationKind
        
        [array]$attachedDatabaseConfigurationGet = Get-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName
        $attachedDatabaseConfiguration = $attachedDatabaseConfigurationGet[0]
        Validate_AttachedDatabaseConfiguration $attachedDatabaseConfiguration $attachedDatabaseConfigurationFullName  $location $clusterResourceId $databaseName $DefaultPrincipalsModificationKind

        Remove-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName
    }

    It 'Get' {
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $databaseName = $env.kustoDatabaseName
        $attachedDatabaseConfigurationName = "testAttachedDatabaseConfiguration"
        $followerClusterName = $env.kustoFollowerClusterName
        $DefaultPrincipalsModificationKind = "Union"
        $clusterResourceId = $env.kustoClusterResourceId
        $attachedDatabaseConfigurationFullName = $followerClusterName + "/" + $attachedDatabaseConfigurationName

        New-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName -Location $location -ClusterResourceId $clusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $DefaultPrincipalsModificationKind
        
        $attachedDatabaseConfiguration = Get-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName
        Validate_AttachedDatabaseConfiguration $attachedDatabaseConfiguration $attachedDatabaseConfigurationFullName  $location $clusterResourceId $databaseName $DefaultPrincipalsModificationKind

        Remove-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName
    }
}
