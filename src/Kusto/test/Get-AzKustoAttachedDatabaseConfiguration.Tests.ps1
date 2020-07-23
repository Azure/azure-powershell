$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoAttachedDatabaseConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzKustoAttachedDatabaseConfiguration' {
    It 'List' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $attachedDatabaseConfigurationName = $env.attachedDatabaseConfigurationName
        $followerClusterName = $env.followerClusterName
        $defaultPrincipalsModificationKind = $env.defaultPrincipalsModificationKind
        $clusterResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Kusto/Clusters/$clusterName"
        $attachedDatabaseConfigurationFullName = $followerClusterName + "/" + $attachedDatabaseConfigurationName

        [array]$attachedDatabaseConfigurationGet = Get-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName
        $attachedDatabaseConfiguration = $attachedDatabaseConfigurationGet[0]
        Validate_AttachedDatabaseConfiguration $attachedDatabaseConfiguration $attachedDatabaseConfigurationFullName  $location $clusterResourceId $databaseName $defaultPrincipalsModificationKind
    }

    It 'Get' {
        $subscriptionId = $env.SubscriptionId
        $location = $env.location
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $attachedDatabaseConfigurationName = $env.attachedDatabaseConfigurationName
        $followerClusterName = $env.followerClusterName
        $defaultPrincipalsModificationKind = $env.defaultPrincipalsModificationKind
        $clusterResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Kusto/Clusters/$clusterName"
        $attachedDatabaseConfigurationFullName = $followerClusterName + "/" + $attachedDatabaseConfigurationName

        $attachedDatabaseConfiguration = Get-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -AttachedDatabaseConfigurationName $attachedDatabaseConfigurationName
        Validate_AttachedDatabaseConfiguration $attachedDatabaseConfiguration $attachedDatabaseConfigurationFullName  $location $clusterResourceId $databaseName $defaultPrincipalsModificationKind
    }
}
