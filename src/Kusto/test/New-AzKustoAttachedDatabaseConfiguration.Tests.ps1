$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoAttachedDatabaseConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzKustoAttachedDatabaseConfiguration' {
    It 'CreateExpanded' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $attachedDatabaseConfigurationName = $env.attachedDatabaseConfigurationName
        $followerClusterName = $env.followerClusterName
        $defaultPrincipalsModificationKind = $env.defaultPrincipalsModificationKind
        $clusterResourceId= "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Kusto/Clusters/$clusterName"
        $attachedDatabaseConfigurationFullName = $followerClusterName + "/" + $attachedDatabaseConfigurationName

        $attachedDatabaseConfigurationCreated = New-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName -Location $location -ClusterResourceId $clusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $defaultPrincipalsModificationKind
        Validate_AttachedDatabaseConfiguration $attachedDatabaseConfigurationCreated $attachedDatabaseConfigurationFullName  $location $clusterResourceId $databaseName $defaultPrincipalsModificationKind
    }
}
