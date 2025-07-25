### Example 1: Get the admin kubeconfig for the provisioned cluster. 
```powershell
Get-AzAksArcClusterAdminKubeconfig -ClusterName azps_test_cluster -ResourceGroupName azps_test_group
```

This command retrieves the admin kubeconfig for the provisioned cluster and prints it. 

### Example 2: Get the admin kubeconfig for the provisioned cluster and saves to the specified file. 
```powershell
Get-AzAksArcClusterAdminKubeconfig -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -FilePath "C:\Users\sampleuser\samplekubeconfig"
```

This command retrieves the admin kubeconfig for the provisioned cluster and saves to the specified file. 


