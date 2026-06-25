### Example 1: Remove a Cluster
```powershell
Remove-AzMongoDBCluster -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -ProjectName test-project-1 -Name test-cluster-free
```

Deletes the MongoDB Atlas cluster. The operation is asynchronous; the underlying partner cluster is also torn down.
