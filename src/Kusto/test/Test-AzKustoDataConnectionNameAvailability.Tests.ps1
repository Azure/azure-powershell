$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzKustoDataConnectionNameAvailability.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzKustoDataConnectionNameAvailability' {
    It 'CheckExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName
        $dataConnectionResourceType = $env.dataConnectionResourceType

        $availability = Test-AzKustoDataConnectionNameAvailability -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Name $dataConnectionName -Type $dataConnectionResourceType
        $availability.NameAvailable | Should Be $false
    }

    It 'CheckViaIdentityExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $dataConnectionName = $env.dataConnectionName + "a"
        $dataConnectionResourceType = $env.dataConnectionResourceType

        $database = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $availability = Test-AzKustoDataConnectionNameAvailability -InputObject $database -Name $dataConnectionName -Type $dataConnectionResourceType
        $availability.NameAvailable | Should Be $true
    }
}
