### Example 1: Get the user kubeconfig for the provisioned cluster. 
```powershell
Get-AzAksArcClusterUserKubeconfig -ClusterName azps_test_cluster -ResourceGroupName azps_test_group
```

This command retrieves the user kubeconfig for the provisioned cluster. 

### Example 2: Get the user kubeconfig for the provisioned cluster and saves to the specified file. 
```powershell
Get-AzAksArcClusterUserKubeconfig -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -FilePath "C:\Users\sampleuser\samplekubeconfig"
```

This command retrieves the user kubeconfig for the provisioned cluster and saves to the specified file. 


