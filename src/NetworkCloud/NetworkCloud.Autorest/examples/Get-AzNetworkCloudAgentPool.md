### Example 1: List Kubernetes cluster's agent pools
```powershell
Get-AzNetworkCloudAgentPool -KubernetesClusterName clusterName -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location  Name               SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                     -------------------                -------------------                  -----------------------                   ------------------------                 ------------
westus3  agentpool1       07/11/2023 18:14:59   <identity>                          User                                          07/18/2023 17:46:45           <identity>
westus3  testagentpool1 07/18/2023 17:44:02   <identity>                         User                                          07/18/2023 17:46:45           <identity>
```

This command lists all agent pools of kubernetes cluster.

### Example 2: Get Kubernetes cluster's agent pool
```powershell
Get-AzNetworkCloudAgentPool -Name agentPoolName -KubernetesClusterName clusterName -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location  Name               SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                     -------------------                -------------------                  -----------------------                   ------------------------                 ------------
westus3  testagentpool1 07/18/2023 17:44:02   <identity>                         User                                          07/18/2023 17:46:45           <identity>
```

This command gets details of an agent pool.
