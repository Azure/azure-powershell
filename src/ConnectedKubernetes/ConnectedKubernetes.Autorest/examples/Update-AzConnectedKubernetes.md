### Example 1: Update a connected kubernetes.
```powershell
Update-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Tag @{'key'='1'}
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command updates a connected kubernetes.

### Example 2: Update a connected kubernetes by object.
```powershell
Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group | Update-AzConnectedKubernetes -Tag @{'key'='2'}
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command updates a connected kubernetes by object.

### Example 3: Update a ConnectedKubernetes's AzureHybridBenefit.
```powershell
Update-AzConnectedKubernetes -ClusterName azps_test_cluster_ahb -ResourceGroupName azps_test_group -Tag @{'key'='1'} -AzureHybridBenefit 'True'
```

```output
I confirm I have an eligible Windows Server license with Azure Hybrid Benefit to apply this benefit to AKS on Azure Stack HCI or Windows Server. Visit https://aka.ms/ahb-aks for details.
[Y] Yes  [N] No  (default is "N"): y

Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps_test_cluster_ahb azps_test_group
```

Update a ConnectedKubernetes's AzureHybridBenefit.

### Example 4: Using [-AcceptEULA] will default to your acceptance of the terms of our legal agreement and update a ConnectedKubernetes's AzureHybridBenefit.
```powershell
Update-AzConnectedKubernetes -ClusterName azps_test_cluster_ahb -ResourceGroupName azps_test_group -Tag @{'key'='1'} -AzureHybridBenefit 'True' -AcceptEULA
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps_test_cluster_ahb azps_test_group
```

Using [-AcceptEULA] will default to your acceptance of the terms of our legal agreement and update a ConnectedKubernetes's AzureHybridBenefit.