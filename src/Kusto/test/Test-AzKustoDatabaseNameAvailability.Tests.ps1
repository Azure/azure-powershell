Describe 'Test-AzKustoDatabaseNameAvailability' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzKustoDatabaseNameAvailability.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'CheckExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $databaseResourceType = "Microsoft.Kusto/Clusters/Databases"

        $availability = Test-AzKustoDatabaseNameAvailability -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Type $databaseResourceType
        $availability.NameAvailable | Should -Be $false
        $availability.Name | Should -Be $databaseName
    }

    It 'CheckViaIdentityExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = "checkNameAvialbleDB"
        $databaseResourceType = "Microsoft.Kusto/Clusters/Databases"

        $cluster = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -ClusterName $clusterName
        $availability = Test-AzKustoDatabaseNameAvailability -InputObject $cluster -Name $databaseName -Type $databaseResourceType
        $availability.NameAvailable | Should -Be $true
        $availability.Name | Should -Be $databaseName
    }
}
