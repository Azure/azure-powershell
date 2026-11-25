### Example 1: Remove a Microsoft Entra ID user from a mongo cluster
```powershell
Remove-AzDocumentDBUser -Name 00000000-0000-0000-0000-000000000000 -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

Remove a Microsoft Entra ID user's data-plane access from a mongo cluster by object
id.
