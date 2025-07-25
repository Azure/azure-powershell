### Example 1: Create Kubernetes cluster's feature
```powershell
New-AzNetworkCloudKubernetesClusterFeature -FeatureName featureName -KubernetesClusterName kubernetesClusterName -ResourceGroupName resourceGroup -SubscriptionId subscriptionId -Location location -Tag @{"key"="value"}
```

```output
Location  Name           SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------  ----          -------------------  -------------------    ----------------------- ------------------------  ------------
uksouth   featureName   12/02/2024 17:44:02	 <identity>             User                     12/02/2024 17:46:45      <identity>
```

This command creates an feature for the given Kubernetes cluster.
