### Example 1: Update Kubernetes cluster's feature
```powershell
Update-AzNetworkCloudKubernetesClusterFeature -FeatureName featureName -KubernetesClusterName kubernetesClusterName -ResourceGroupName resourceGroup -SubscriptionId subscriptionId -Tag $tagUpdatedHash
```

```output
Location  Name           SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------  ----          -------------------  -------------------    ----------------------- ------------------------  ------------
uksouth   featureName   12/02/2024 17:44:02	 <identity>             User                     12/02/2024 17:46:45      <identity>
```

This command updates a Kubernetes cluster feature's properties.
