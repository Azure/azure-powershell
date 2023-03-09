Describe 'Get-AzKustoDatabase' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoDatabase.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'List' {
        $softDeletePeriodInDays = Get-Soft-Delete-Period-In-Days
        $hotCachePeriodInDays = Get-Hot-Cache-Period-In-Days
        $databaseFullName = $env.kustoClusterName + "/" + $env.kustoDatabaseName

        [array]$databaseGet = Get-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $env.kustoDatabaseName
        $databaseGetItem = $databaseGet[0]
        Validate_Database $databaseGetItem $databaseFullName $env.location "Microsoft.Kusto/Clusters/Databases" $softDeletePeriodInDays $hotCachePeriodInDays
    }

    It 'Get' {
        $softDeletePeriodInDays = Get-Soft-Delete-Period-In-Days
        $hotCachePeriodInDays = Get-Hot-Cache-Period-In-Days
        $databaseFullName = $env.kustoClusterName + "/" + $env.kustoDatabaseName

        $databaseGetItem = Get-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $env.kustoDatabaseName
        Validate_Database $databaseGetItem $databaseFullName $env.location "Microsoft.Kusto/Clusters/Databases" $softDeletePeriodInDays $hotCachePeriodInDays
    }
}
