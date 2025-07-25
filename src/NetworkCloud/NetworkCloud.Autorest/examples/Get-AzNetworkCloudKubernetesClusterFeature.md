### Example 1: List Kubernetes cluster's features
```powershell
Get-AzNetworkCloudKubernetesClusterFeature -KubernetesClusterName kubernetesClusterName -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName
```

```output
Location Name                                  SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------- ----                                  ------------------- -------------------      ----------------------- ---------------------
uksouth  naks-1cac110b-csi-volume              11/14/2024 22:32:15 <identity>  				 Application             11/14/2024 22:46:27  
uksouth  naks-1cac110b-calico                  11/14/2024 22:32:16 <identity>  				 Application             11/14/2024 22:46:28  
uksouth  naks-1cac110b-node-local-dns          11/14/2024 22:32:16 <identity>  				 Application             11/14/2024 22:46:27  
uksouth  naks-1cac110b-csi-nfs                 11/14/2024 22:32:16 <identity>  				 Application             11/14/2024 22:46:28  
uksouth  naks-1cac110b-azure-arc-servers       11/14/2024 22:32:16 <identity>  				 Application             11/15/2024 07:04:25  
uksouth  naks-1cac110b-metrics-server          11/14/2024 22:32:16 <identity>  				 Application             11/14/2024 22:46:27  
uksouth  naks-1cac110b-cloud-provider-kubevirt 11/14/2024 22:32:17 <identity>  				 Application             11/14/2024 22:46:27  
uksouth  naks-1cac110b-multus                  11/14/2024 22:32:17 <identity>  				 Application             11/14/2024 22:46:28  
uksouth  naks-1cac110b-ipam-cni-plugin         11/14/2024 22:32:17 <identity>  				 Application             11/14/2024 22:46:27  
uksouth  naks-1cac110b-metallb                 11/14/2024 22:32:17 <identity>  				 Application             11/14/2024 22:46:28  
uksouth  naks-1cac110b-azure-arc-k8sagents     11/14/2024 22:32:17 <identity>  				 Application             11/14/2024 22:46:28  
uksouth  naks-1cac110b-sriov-dp                11/14/2024 22:32:18 <identity>  				 Application             11/14/2024 22:46:28  

```

This command lists all features of kubernetes cluster.

### Example 2: Get Kubernetes cluster's feature
```powershell
Get-AzNetworkCloudKubernetesClusterFeature -KubernetesClusterName kubernetesClusterName -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName -FeatureName featureName
```

```output
Location Name                                  SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------- ----                                  ------------------- -------------------      ----------------------- ---------------------
uksouth  naks-1cac110b-csi-volume              11/14/2024 22:32:15 <identity>  				 Application             11/14/2024 22:46:27  
```

This command gets details of an Kubernetes cluster feature.

