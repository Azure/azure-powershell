### Example 1: Assign a Microsoft Entra ID user to a mongo cluster
```powershell
New-AzDocumentDBUser -Name 71581c6f-df31-4790-bc49-26c6b38df8bd -MongoClusterName myCluster -ResourceGroupName myResourceGroup `
    -Type User -Role @(@{ Db = 'admin'; Role = 'root' })
```

```output
Name                                  ProvisioningState
----                                  -----------------
71581c6f-df31-4790-bc49-26c6b38df8bd  Succeeded
```

Grant a Microsoft Entra ID principal data-plane access to a mongo cluster. `-Name` is
the object id of the Entra principal, `-Type` is the principal type (`User` or
`ServicePrincipal`), and `-Role` assigns one or more database roles. Microsoft Entra
authentication must be enabled on the cluster (see `-AuthConfigAllowedMode` on
`New-AzDocumentDBMongoCluster`).
