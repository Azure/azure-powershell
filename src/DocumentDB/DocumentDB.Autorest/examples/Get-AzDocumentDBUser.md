### Example 1: Get a Microsoft Entra ID user of a mongo cluster
```powershell
Get-AzDocumentDBUser -Name 71581c6f-df31-4790-bc49-26c6b38df8bd -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

```output
Name                                  ProvisioningState
----                                  -----------------
71581c6f-df31-4790-bc49-26c6b38df8bd  Succeeded
```

Get a single Microsoft Entra ID user of a mongo cluster by object id.

### Example 2: List the Microsoft Entra ID users of a mongo cluster
```powershell
Get-AzDocumentDBUser -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

```output
Name                                  ProvisioningState
----                                  -----------------
71581c6f-df31-4790-bc49-26c6b38df8bd  Succeeded
```

List all Microsoft Entra ID users of a mongo cluster.
