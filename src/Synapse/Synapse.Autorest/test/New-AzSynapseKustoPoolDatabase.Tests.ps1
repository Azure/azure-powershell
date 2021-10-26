Describe 'New-AzSynapseKustoPoolDatabase' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSynapseKustoPoolDatabase.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }

    It 'CreateExpanded' {
        $hotCachePeriodInDays = Get-Hot-Cache-Period-In-Days
        $name = "testdatabase" + $env.rstr4
        $databaseFullName = $env.workspaceName + "/" + $env.kustoPoolName + "/" + $name

        $databaseCreated = New-AzSynapseKustoPoolDatabase -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -KustoPoolName $env.kustoPoolName -Name $name -Location $env.location -Kind ReadWrite -HotCachePeriod $hotCachePeriodInDays
        Validate_Database $databaseCreated $databaseFullName $env.location $env.databaseType $null $hotCachePeriodInDays
        { Remove-AzSynapseKustoPoolDatabase -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -KustoPoolName $env.kustoPoolName -Name $name } | Should -Not -Throw
    }
}
