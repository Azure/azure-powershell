Describe 'New-AzKustoDatabase' {
    
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoDatabase.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }

    It 'CreateExpanded' {
        $name = "testdatabase" + $env.rstr4
        $databaseFullName = $env.kustoClusterName + "/" + $name

        $databaseCreated = New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name -Kind ReadWrite -Location $env.location
        Validate_Database $databaseCreated $databaseFullName $env.location "Microsoft.Kusto/Clusters/Databases" $null $null
        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name } | Should -Not -Throw
    }

    It 'Create' {
        $hotCachePeriodInDays = Get-Hot-Cache-Period-In-Days
        $name = "testdatabase" + $env.rstr5
        $databaseFullName = $env.kustoClusterName + "/" + $name

        $databaseCreated = New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name -Location $env.location -Kind ReadWrite -HotCachePeriod $hotCachePeriodInDays
        Validate_Database $databaseCreated $databaseFullName $env.location "Microsoft.Kusto/Clusters/Databases" $null $hotCachePeriodInDays
        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name } | Should -Not -Throw
    }
}
