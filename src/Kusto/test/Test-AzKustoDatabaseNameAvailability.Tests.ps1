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

Describe 'Test-AzKustoDatabaseNameAvailability' {
    It 'CheckExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $databaseResourceType = $env.databaseType

        $availability = Test-AzKustoDatabaseNameAvailability -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Type $databaseResourceType
        $availability.NameAvailable | Should Be $false
        $availability.Name | Should Be $databaseName
    }

    It 'CheckViaIdentityExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName + $env.rstr6
        $databaseResourceType = $env.databaseType

        $cluster = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -ClusterName $clusterName
        $availability = Test-AzKustoDatabaseNameAvailability -InputObject $cluster -Name $databaseName -Type $databaseResourceType
        $availability.NameAvailable | Should Be $true
        $availability.Name | Should Be $databaseName
    }
}
