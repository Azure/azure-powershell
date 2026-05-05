### Example 1: Create cluster
```powershell
$storageapplianceconfigurationdata = @()
$baremetalmachineconfigurationdata = @()
$computerackdefinition = @(@{IRackDefinition = "The list of rack definitions for the compute racks in a multi-rack cluster, or an empty list in a single-rack cluster."})
$tagHash = @{
    tag = "tag"
}
$securePassword = ConvertTo-SecureString "password" -asplaintext -force

New-AzNetworkCloudCluster -ResourceGroupName resourceGroup -Name clusterName -AggregatorOrSingleRackDefinitionNetworkRackId rackId -AggregatorOrSingleRackDefinitionRackSerialNumber sr1234 -AggregatorOrSingleRackDefinitionRackSkuId rackSku -ClusterType clustertype -ClusterVersion clusterversion -ExtendedLocationName CmExtendedLocation -ExtendedLocationType CustomLocation -Location location -NetworkFabricId networkFabricId -SubscriptionId subscriptionId -AggregatorOrSingleRackDefinitionAvailabilityZone availabilityzone -AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration $baremetalmachineconfigurationdata -AggregatorOrSingleRackDefinitionRackLocation rackLocation -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration $storageapplianceconfigurationdata -AnalyticsWorkspaceId analyticsWorkSpaceId -ClusterServicePrincipalApplicationId clusterServicePrincipalAppId -ClusterServicePrincipalId ClusterServicePrincipalId -ClusterServicePrincipalPassword $securePassword -ClusterServicePrincipalTenantId tenantId -ComputeRackDefinition $computerackdefinition -Tag $tagHash
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType  SystemDataLastModifiedAt SystemDataLastModifiedBy         SystemDataLastModifiedByType ResourceGroupName
--------  ---------        -------------------   -------------------       -----------------------  ------------------------ ------------------------         ---------------------------- -----------
eastus    clusterName      08/09/2023 18:33:54   user                    User                       08/09/2023 19:45:35      user                             User                         RGName
```

This command creates a new cluster.

### Example 2: Create cluster with Identity
```powershell
$storageapplianceconfigurationdata = @()
$baremetalmachineconfigurationdata = @()
$computerackdefinition = @(@{IRackDefinition = "The list of rack definitions for the compute racks in a multi-rack cluster, or an empty list in a single-rack cluster."})
$tagHash = @{
    tag = "tag"
}
$securePassword = ConvertTo-SecureString "password" -asplaintext -force
$userAssignedIdentityResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myManagedIdentity"


New-AzNetworkCloudCluster -ResourceGroupName resourceGroup -Name clusterName -AggregatorOrSingleRackDefinitionNetworkRackId rackId -AggregatorOrSingleRackDefinitionRackSerialNumber sr1234 -AggregatorOrSingleRackDefinitionRackSkuId rackSku -ClusterType clustertype -UserAssignedIdentity $userAssignedIdentityResourceId -ClusterVersion clusterversion -ExtendedLocationName CmExtendedLocation -ExtendedLocationType CustomLocation -Location location -NetworkFabricId networkFabricId -SubscriptionId subscriptionId -AggregatorOrSingleRackDefinitionAvailabilityZone availabilityZone -AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration $baremetalmachineconfigurationdata -AggregatorOrSingleRackDefinitionRackLocation rackLocation -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration $storageapplianceconfigurationdata -AnalyticOutputSettingAnalyticsWorkspaceId analyticsWorkspaceId -AnalyticsOutputSettingsAssociatedIdentityType identityType -AnalyticsOutputSettingsAssociatedIdentityUserAssignedIdentityResourceId userAssignedIdentityResourceId -AnalyticsWorkspaceId analyticsWorkspaceId -CommandOutputSettingContainerUrl containerUrl -AssociatedIdentityType commandOutputSettingsIdentityType -AssociatedIdentityUserAssignedIdentityResourceId commandOutputSettingsUserAssignedIdentityResourceId -ClusterServicePrincipalApplicationId clusterServicePrincipalAppId -ClusterServicePrincipalId ClusterServicePrincipalId -ClusterServicePrincipalPassword $securePassword -ClusterServicePrincipalTenantId tenantId -ComputeRackDefinition $computerackdefinition -SecretArchiveKeyVaultId keyVaultId -SecretArchiveSettingVaultUri keyVaultUri -SecretArchiveSettingsAssociatedIdentityType identityType -SecretArchiveSettingsAssociatedIdentityUserAssignedIdentityResourceId userAssignedIdentityResourceId -SecretArchiveUseKeyVault useKeyVault -UpdateStrategyThresholdType updateStrategyThresholdType -UpdateStrategyThresholdValue updateStrategyThresholdValue -UpdateStrategyType updateStrategyType -UpdateStrategyWaitTimeMinute updateStrategyWaitTimeMinutes -VulnerabilityScanningSettingContainerScan vulnerabilityScanningSettingContainerScan -ComputeDeploymentThresholdGrouping computeDeploymentThresholdGrouping -ComputeDeploymentThresholdType computeDeploymentThresholdType -ComputeDeploymentThresholdValue computeDeploymentThresholdValue -Tag $tagHash
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType  SystemDataLastModifiedAt SystemDataLastModifiedBy         SystemDataLastModifiedByType ResourceGroupName
--------  ---------        -------------------   -------------------       -----------------------  ------------------------ ------------------------         ---------------------------- -----------
uksouth    clusterName      04/10/2025 18:14:18   user                    User                       04/10/2025 18:16:10      user                             User                         RGName
```

This command creates a new cluster with Identity.
