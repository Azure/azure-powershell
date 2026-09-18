Describe 'Get-AzKustoClusterFollowerDatabaseGet' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoClusterFollowerDatabaseGet.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'List' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $attachedDatabaseConfigurationName = "testAttachedDatabaseConfiguration"
        $followerClusterName = $env.kustoFollowerClusterName
        $followerClusterResourceId = $env.kustoFollowerClusterResourceId

        New-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName -Location $env.location -ClusterResourceId $env.kustoClusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind "Union"

        [array]$clusterFollowerDatabaseGet = Get-AzKustoClusterFollowerDatabaseGet -ResourceGroupName $resourceGroupName -ClusterName $clusterName
        $clusterFollowerDatabase = $clusterFollowerDatabaseGet[0]
        Validate_ClusterFollowerDatabase $clusterFollowerDatabase $attachedDatabaseConfigurationName $followerClusterResourceId $databaseName

        Remove-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName
    }
}
