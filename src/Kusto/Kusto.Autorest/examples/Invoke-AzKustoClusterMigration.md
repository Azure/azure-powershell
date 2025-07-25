### Example 1: Migrate one cluster to another
```powershell
Invoke-AzKustoClusterMigration -Name "myCluster" -ResourceGroupName "myResourceGroup" -ClusterResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/xxxx/providers/Microsoft.Kusto/clusters/destinationClusterName"
```

The above command migrates cluster "myCluster" in resource group "myResourceGroup" to a destination cluster using its ARM resource identifier 
