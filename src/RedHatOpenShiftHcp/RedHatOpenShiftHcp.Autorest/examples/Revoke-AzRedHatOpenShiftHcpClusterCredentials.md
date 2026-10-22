### Example 1: Revoke all issued admin credentials for a cluster
```powershell
Revoke-AzRedHatOpenShiftHcpClusterCredentials -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster
```

Revokes every admin credential previously issued for the cluster (break-glass reset). Any kubeconfig obtained via `Request-AzRedHatOpenShiftHcpClusterAdminCredential` is immediately invalidated. The operation returns no output; add `-PassThru` to get `$true` on success.
