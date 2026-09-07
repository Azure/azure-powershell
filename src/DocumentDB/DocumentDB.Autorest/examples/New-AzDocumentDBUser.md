### Example 1: Assign a Microsoft Entra ID user to a mongo cluster
```powershell
New-AzDocumentDBUser -Name 00000000-0000-0000-0000-000000000000 -MongoClusterName myCluster -ResourceGroupName myResourceGroup `
    -Type User -Role @(@{ Db = 'admin'; Role = 'root' })
```

```output
Name                                  ProvisioningState
----                                  -----------------
00000000-0000-0000-0000-000000000000  Succeeded
```

Grant a Microsoft Entra ID principal data-plane access to a mongo cluster. `-Name` is
the object id of the Entra principal, `-Type` is the principal type (`User` or
`ServicePrincipal`), and `-Role` assigns one or more database roles. Microsoft Entra
authentication must be enabled on the cluster (see `-AuthConfigAllowedMode` on
`New-AzDocumentDBMongoCluster`).
