### Example 1: Get a Microsoft Entra ID user of a mongo cluster
```powershell
Get-AzDocumentDBUser -Name 00000000-0000-0000-0000-000000000000 -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

```output
Name                                  ProvisioningState
----                                  -----------------
00000000-0000-0000-0000-000000000000  Succeeded
```

Get a single Microsoft Entra ID user of a mongo cluster by object id.

### Example 2: List the Microsoft Entra ID users of a mongo cluster
```powershell
Get-AzDocumentDBUser -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

```output
Name                                  ProvisioningState
----                                  -----------------
00000000-0000-0000-0000-000000000000  Succeeded
```

List all Microsoft Entra ID users of a mongo cluster.
