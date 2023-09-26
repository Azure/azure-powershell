### Example 1: List Kubernetes clusters by subscription
```powershell
Get-AzNetworkCloudKubernetesCluster -SubscriptionId subscriptionId
```

```output
Location Name                          SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
-------- ----                          ------------------- -------------------                  ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
location kubernetesCluster1            06/30/2023 20:39:44 <Identity>                           User                    08/03/2023 20:26:35      <Identity>                           Application                  resourceGroupName
location kubernetesCluster2            07/11/2023 02:49:35 <Identity>                           User                    08/03/2023 20:26:32      <Identity>                           Application                  resourceGroupName
location kubernetesCluster3            07/15/2023 22:04:00 <Identity>                           Application             07/15/2023 22:18:48      <Identity>                           Application                  resourceGroupName
location kubernetesCluster4            07/25/2023 21:00:31 <Identity>                           User                    08/03/2023 20:26:37      <Identity>                           Application                  resourceGroupName

```

This command lists all Kubernetes clusters under a subscription.

### Example 2: Get Kubernetes cluster
```powershell
Get-AzNetworkCloudKubernetesCluster -KubernetesClusterName kubernetesClusterName -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
location default 08/09/2023 20:23:17 <Identity>             User                    08/09/2023 20:44:27      <Identity>                           Application                  resourceGroupName
```

This command gets a Kubernetes cluster by name.

### Example 3: List Kubernetes cluster by resource group
```powershell
Get-AzNetworkCloudKubernetesCluster -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
location default 08/09/2023 20:23:17 <Identity>             User                    08/09/2023 20:44:27      <Identity>                           Application                  resourceGroupName
```

This command lists all Kubernetes clusters in a resource group.
