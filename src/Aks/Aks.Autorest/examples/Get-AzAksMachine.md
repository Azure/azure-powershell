### Example 1: Get a specific machine in the specified agent pool.
```powershell
Get-AzAksMachine -AgentPoolName 'default' -ResourceGroupName AKS_TEST_RG -ResourceName AKS_Test_Cluster
```

```output
Id                : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.ContainerService/managedClusters/AKS_Test_Cluster/agentPools/default/machines/aks-default-12988240-vmss000000
Name              : aks-default-12988240-vmss000000
NetworkIPAddress  : {{
                      "family": "IPv4",
                      "ip": "10.224.0.4"
                    }}
ResourceGroupName : AKS_TEST_RG
ResourceId        : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/MC_AKS_TEST_RG_AKS_Test_Cluster_eastus/providers/Microsoft.Compute/virtualMachineScaleSets/aks-default-12988240-vmss/virtualMachines/0
Type              : Microsoft.ContainerService/managedClusters/agentPools/machines
Zone              :

```

Get a specific machine in the specified agent pool.

