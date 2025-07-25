Describe 'Get-AzSynapseKustoPoolDatabase' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSynapseKustoPoolDatabase.Recording.json'
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
        $databaseFullName = $env.workspaceName + "/" + $env.kustoPoolName + "/" + $env.databaseName

        [array]$databaseGet = Get-AzSynapseKustoPoolDatabase -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -KustoPoolName $env.kustoPoolName
        $databaseGetItem = $databaseGet[0]
        Validate_Database $databaseGetItem $databaseFullName $env.location $env.databaseType $softDeletePeriodInDays $hotCachePeriodInDays
    }

    It 'Get' {
        $softDeletePeriodInDays = Get-Soft-Delete-Period-In-Days
        $hotCachePeriodInDays = Get-Hot-Cache-Period-In-Days
        $databaseFullName = $env.workspaceName + "/" + $env.kustoPoolName + "/" + $env.databaseName

        $databaseGetItem = Get-AzSynapseKustoPoolDatabase -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -KustoPoolName $env.kustoPoolName -Name $env.databaseName
        Validate_Database $databaseGetItem $databaseFullName $env.location $env.databaseType $softDeletePeriodInDays $hotCachePeriodInDays
    }
}