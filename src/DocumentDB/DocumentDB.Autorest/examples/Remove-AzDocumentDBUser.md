### Example 1: Remove a Microsoft Entra ID user from a mongo cluster
```powershell
Remove-AzDocumentDBUser -Name 71581c6f-df31-4790-bc49-26c6b38df8bd -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

Remove a Microsoft Entra ID user's data-plane access from a mongo cluster by object
id.
