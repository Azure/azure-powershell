### Example 1: Create a connected kubernetes
```powershell
New-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus
```

```output
I confirm I have an eligible Windows Server license with Azure Hybrid Benefit to apply this benefit to AKS on Azure Stack HCI or Windows Server. Visit https://aka.ms/ahb-aks for details.
[Y] Yes  [N] No  (default is "N"): Y

Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command creates a connected kubernetes.

### Example 2: Create a connected kubernetes with parameters kubeConfig and kubeContext
```powershell
New-AzConnectedKubernetes -ClusterName azps_test_cluster1 -ResourceGroupName azps_test_group -Location eastus -KubeConfig $HOME\.kube\config -KubeContext azps_aks_t01
```

```output
I confirm I have an eligible Windows Server license with Azure Hybrid Benefit to apply this benefit to AKS on Azure Stack HCI or Windows Server. Visit https://aka.ms/ahb-aks for details.
[Y] Yes  [N] No  (default is "N"): Y

Location Name               ResourceGroupName
-------- ----               -----------------
eastus   azps_test_cluster1 azps_test_group
```

This command creates a connected kubernetes with parameters kubeConfig and kubeContext.

### Example 3: Create a connected kubernetes with parameters kubeConfig and kubeContext
```powershell
New-AzConnectedKubernetes -ClusterName azps_test_cluster1 -ResourceGroupName azps_test_group -Location eastus -KubeConfig $HOME\.kube\config -KubeContext azps_aks_t01 -AzureHybridBenefit 'True' -PrivateLinkState 'Enabled' -Distribution "AKS_Management" -DistributionVersion "1.0" -PrivateLinkScopeResourceId "/subscriptions/{subscriptionId}/resourceGroups/azps_test_group/providers/Microsoft.HybridCompute/privateLinkScopes/azps-privatelinkscope" -infrastructure "azure_stack_hci" -ProvisioningState 'Succeeded'
```

```output
I confirm I have an eligible Windows Server license with Azure Hybrid Benefit to apply this benefit to AKS on Azure Stack HCI or Windows Server. Visit https://aka.ms/ahb-aks for details.
[Y] Yes  [N] No  (default is "N"): Y

Location Name               ResourceGroupName
-------- ----               -----------------
eastus   azps_test_cluster1 azps_test_group
```

This command creates a connected kubernetes with parameters kubeConfig and kubeContext.