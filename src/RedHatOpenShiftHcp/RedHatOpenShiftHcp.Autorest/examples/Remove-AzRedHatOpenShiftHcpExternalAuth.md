### Example 1: Delete an external auth
```powershell
Remove-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName myResourceGroup `
  -HcpOpenShiftClusterName myCluster -Name myExternalAuth
```

Deletes the `ExternalAuth` from the cluster, removing the external OIDC login configuration. Delete the external auth (like node pools) before deleting the parent cluster.

### Example 2: Delete an external auth and confirm success with -PassThru
```powershell
Remove-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName myResourceGroup `
  -HcpOpenShiftClusterName myCluster -Name myExternalAuth -PassThru
```

Deletes the external auth and returns `$true` when the operation completes. Use `-PassThru` when you want a boolean result to branch on in a script.
