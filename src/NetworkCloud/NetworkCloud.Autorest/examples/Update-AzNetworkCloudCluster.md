### Example 1: Update cluster
```powershell
$storageapplianceconfigurationdata = @()
$baremetalmachineconfigurationdata = @()
$computerackdefinition = @(@{IRackDefinition = "The list of rack definitions for the compute racks in a multi-rack cluster, or an empty list in a single-rack cluster."})
$tagHash = @{
    tag = "tag"
    tagUpdate = "tagUpdate"
}
$securePassword = ConvertTo-SecureString "password" -asplaintext -force

Update-AzNetworkCloudCluster -ResourceGroupName resourceGroup -Name clusterName -SubscriptionId subscriptionId -AggregatorOrSingleRackDefinitionNetworkRackId rackId -AggregatorOrSingleRackDefinitionRackSerialNumber sr1234 -AggregatorOrSingleRackDefinitionRackSkuId rackSku -AggregatorOrSingleRackDefinitionAvailabilityZone availabilityzone -AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration $baremetalmachineconfigurationdata -AggregatorOrSingleRackDefinitionRackLocation rackLocation -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration $storageapplianceconfigurationdata -ClusterServicePrincipalApplicationId clusterServicePrincipalAppId -ClusterServicePrincipalId ClusterServicePrincipalId -ClusterServicePrincipalPassword $securePassword -ClusterServicePrincipalTenantId tenantId -ComputeRackDefinition $computerackdefinition -Tag $tagHash
```

```output
Location Name             SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGro
                                                                                                                                                                                           upName
-------- ----             ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- -----------
eastus   clusterName        08/09/2023 18:33:54   user                          User             08/09/2023 19:45:35           user                                       User              RGName
```

Patch the properties of the provided cluster, or update the tags associated with the cluster. Properties and tag updates can be done independently.

### Example 2: Update cluster with Identity
```powershell
$storageapplianceconfigurationdata = @()
$baremetalmachineconfigurationdata = @()
$computerackdefinition = @(@{IRackDefinition = "The list of rack definitions for the compute racks in a multi-rack cluster, or an empty list in a single-rack cluster."})
$tagHash = @{
    tag = "tag"
    tagUpdate = "tagUpdate"
}
$securePassword = ConvertTo-SecureString "password" -asplaintext -force
$userAssignedIdentityResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myManagedIdentity"


Update-AzNetworkCloudCluster -ResourceGroupName resourceGroup -Name clusterName -AggregatorOrSingleRackDefinitionNetworkRackId rackId -AggregatorOrSingleRackDefinitionRackSerialNumber sr1234 -AggregatorOrSingleRackDefinitionRackSkuId rackSku -UserAssignedIdentity $userAssignedIdentityResourceId -SubscriptionId subscriptionId -AggregatorOrSingleRackDefinitionAvailabilityZone availabilityZone -AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration $baremetalmachineconfigurationdata -AggregatorOrSingleRackDefinitionRackLocation rackLocation -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration $storageapplianceconfigurationdata -AnalyticsOutputSettingsAssociatedIdentityType identityType -AnalyticsOutputSettingsAssociatedIdentityUserAssignedIdentityResourceId userAssignedIdentityResourceId -AnalyticOutputSettingAnalyticsWorkspaceId analyticsWorkspaceId -CommandOutputSettingContainerUrl containerUrl -AssociatedIdentityType commandOutputSettingsIdentityType -AssociatedIdentityUserAssignedIdentityResourceId commandOutputSettingsUserAssignedIdentityResourceId -ClusterServicePrincipalApplicationId clusterServicePrincipalAppId -ClusterServicePrincipalId ClusterServicePrincipalId -ClusterServicePrincipalPassword $securePassword -ClusterServicePrincipalTenantId tenantId -ComputeRackDefinition $computerackdefinition -SecretArchiveKeyVaultId keyVaultId -SecretArchiveSettingVaultUri keyVaultUri -SecretArchiveSettingsAssociatedIdentityType identityType -SecretArchiveSettingsAssociatedIdentityUserAssignedIdentityResourceId userAssignedIdentityResourceId -SecretArchiveUseKeyVault useKeyVault -UpdateStrategyThresholdType updateStrategyThresholdType -UpdateStrategyThresholdValue updateStrategyThresholdValue -UpdateStrategyType updateStrategyType -UpdateStrategyWaitTimeMinute updateStrategyWaitTimeMinutes -VulnerabilityScanningSettingContainerScan vulnerabilityScanningSettingContainerScan -ComputeDeploymentThresholdGrouping computeDeploymentThresholdGrouping -ComputeDeploymentThresholdType computeDeploymentThresholdType -ComputeDeploymentThresholdValue computeDeploymentThresholdValue -Tag $tagHash
```

```output
Location Name             SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGro
                                                                                                                                                                                           upName
-------- ----             ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- -----------
uksouth   clusterName        04/10/2025 18:14:18   user                          User             04/10/2025 18:35:38           user                                       User              RGName
```

This command updates the properties of the specified cluster or updates its tags, command output settings, analytics output settings, and archive output settings using the User Assigned Identity (UAI) associated with the cluster. Property updates and tag updates can be performed independently.
