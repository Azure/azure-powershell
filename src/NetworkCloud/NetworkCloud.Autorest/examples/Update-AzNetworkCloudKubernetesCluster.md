### Example 1: Update Kubernetes cluster
```powershell
$tagUpdatedHash = @{
    tag1 = "tags"
    tag2 = "tagsUpdate"
}

Update-AzNetworkCloudKubernetesCluster -KubernetesClusterName kubernetesClusterName -ResourceGroupName resourceGroupName -Tag $tagUpdatedHash -ControlPlaneNodeConfigurationCount controlPlaneNodeConfigurationCount -KubernetesVersion kubernetesVersion -SubscriptionId subscriptionId
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
location default 08/09/2023 20:23:17 <Identity>             User                    08/09/2023 21:44:27      <Identity>                           Application                  resourceGroupName
```

This command updates properties of a Kubernetes cluster.
