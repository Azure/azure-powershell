$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoClusterFollowerDatabase.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzKustoClusterFollowerDatabase' {
    It 'List' {
        $subscriptionId = $env.SubscriptionId
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $attachedDatabaseConfigurationName = $env.attachedDatabaseConfigurationName
        $followerClusterName = $env.followerClusterName
        $clusterResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Kusto/Clusters/$followerClusterName"

        [array]$clusterFollowerDatabaseGet = Get-AzKustoClusterFollowerDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName
        $clusterFollowerDatabase = $clusterFollowerDatabaseGet[0]
        Validate_ClusterFollowerDatabase $clusterFollowerDatabase $attachedDatabaseConfigurationName $clusterResourceId $databaseName
    }
}
