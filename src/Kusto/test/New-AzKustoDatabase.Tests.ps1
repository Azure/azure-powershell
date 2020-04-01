$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoDatabase.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzKustoDatabase' {
    It 'CreateExpanded' {
        $location = Get-Location
        $resourceGroupName = Get-RG-Name
        $clusterName = Get-Cluster-Name
        $databaseName = Get-Database-Name
        $resourceType =  Get-Database-Type
        $databaseFullName = "$clusterName/$databaseName"

        $databaseCreated = New-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $location
        Validate_Database $databaseCreated $databaseFullName $location $resourceType $null $null
    }

    It 'Create' {
        $location = Get-Location
        $resourceGroupName = Get-RG-Name
        $clusterName = Get-Cluster-Name
        $databaseName = Get-Database-Name
        $resourceType =  Get-Database-Type
        $softDeletePeriodInDays =  Get-Soft-Delete-Period-In-Days
        $hotCachePeriodInDays =  Get-Hot-Cache-Period-In-Days
        $databaseFullName = "$clusterName/$databaseName"

        $databaseCreated = New-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Parameter @{Location=$location; SoftDeletePeriod=$softDeletePeriodInDays; HotCachePeriod=$hotCachePeriodInDays}
        Validate_Database $databaseCreated $databaseFullName $location $resourceType $softDeletePeriodInDays $hotCachePeriodInDays

    }
}
