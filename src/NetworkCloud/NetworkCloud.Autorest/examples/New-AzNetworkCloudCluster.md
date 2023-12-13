### Example 1: Create cluster
```powershell
$storageapplianceconfigurationdata = @()
$baremetalmachineconfigurationdata = @()
$computerackdefinition = @(@{IRackDefinition = "The list of rack definitions for the compute racks in a multi-rackcluster, or an empty list in a single-rack cluster."})
$tagHash = @{
    tag = "tag"
}
$securePassword = ConvertTo-SecureString "password" -asplaintext -force

New-AzNetworkCloudCluster -ResourceGroupName resourceGroup -Name clusterName -AggregatorOrSingleRackDefinitionNetworkRackId rackId -AggregatorOrSingleRackDefinitionRackSerialNumber sr1234 -AggregatorOrSingleRackDefinitionRackSkuId rackSku -ClusterType clustertype -ClusterVersion clusterversion -ExtendedLocationName CmExtendedLocation -ExtendedLocationType CustomLocation -Location location -NetworkFabricId networkFabricId -SubscriptionId subscriptionId -AggregatorOrSingleRackDefinitionAvailabilityZone avilabilityzone -AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration $baremetalmachineconfigurationdata -AggregatorOrSingleRackDefinitionRackLocation rackLocation -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration $storageapplianceconfigurationdata -AnalyticsWorkspaceId anlyticsWorkSpaceId -ClusterServicePrincipalApplicationId clusterServicePrincipalAppId -ClusterServicePrincipalId ClusterServicePrincipalId -ClusterServicePrincipalPassword $securePassword -ClusterServicePrincipalTenantId tenantId -ComputeRackDefinition $computerackdefinition -Tag $tagHash
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType  SystemDataLastModifiedAt SystemDataLastModifiedBy         SystemDataLastModifiedByType ResourceGroupName
--------  ---------        -------------------   -------------------       -----------------------  ------------------------ ------------------------         ---------------------------- -----------
eastus    clusterName      08/09/2023 18:33:54   user                    User                       08/09/2023 19:45:35      user                             User                         RGName
```

This command creates a new cluster.
