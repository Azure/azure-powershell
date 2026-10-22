### Example 1: Update cluster tags
```powershell
Update-AzRedHatOpenShiftHcpCluster -ResourceGroupName myResourceGroup -Name myCluster `
  -Tag @{ env = 'dev'; owner = 'platform-team' }
```

```output
Name      Location   ResourceGroupName  VersionId ProvisioningState ApiUrl
----      --------   -----------------  --------- ----------------- ------
myCluster westeurope myResourceGroup    4.22      Succeeded         https://api.mycluster.32z5.westeurope.aroapp-hcp.io:443
```

Patches a non-identity field (resource tags) on an existing cluster. Because no operator-identity parameters are supplied, the request is forwarded unchanged with no GET-merge.

### Example 2: Rotate a single control-plane operator identity
```powershell
Update-AzRedHatOpenShiftHcpCluster -ResourceGroupName myResourceGroup -Name myCluster `
  -UserAssignedIdentityControlPlaneOperator @{ kms = 'myCluster-cp-kms-rotated' }
```

```output
Name      Location   ResourceGroupName  VersionId ProvisioningState ApiUrl
----      --------   -----------------  --------- ----------------- ------
myCluster westeurope myResourceGroup    4.22      Succeeded         https://api.mycluster.32z5.westeurope.aroapp-hcp.io:443
```

Rotates only the `kms` control-plane operator identity. The cmdlet GETs the current cluster, merges this override into the existing operator maps so the other 8 control-plane operators and the service MI are preserved, resolves the bare identity name to a full resource ID via the cluster's subnet, and recomputes the flat identity list (control-plane operators plus the service MI).
