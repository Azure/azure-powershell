$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzKustoDatabase.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzKustoDatabase' {
    It 'Update' {
        $databaseFullName = $env.clusterName + "/" + $env.databaseName
        
        $softDeletePeriodInDaysUpdated = Get-Updated-Soft-Delete-Period-In-Days
        $hotCachePeriodInDaysUpdated = Get-Updated-Hot-Cache-Period-In-Days
        
        $databaseProperties = New-Object -Type Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ReadWriteDatabase -Property @{SoftDeletePeriod= $softDeletePeriodInDaysUpdated; HotCachePeriod=$hotCachePeriodInDaysUpdated}
        $databaseUpdatedWithParameters = Update-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.clusterName -Name $env.databaseName -Parameter $databaseProperties
        Validate_Database $databaseUpdatedWithParameters $databaseFullName $env.location $env.databaseType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated
    }
}
