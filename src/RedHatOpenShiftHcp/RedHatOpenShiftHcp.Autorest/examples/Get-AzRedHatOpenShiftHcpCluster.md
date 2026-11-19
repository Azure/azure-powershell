### Example 1: List clusters in a resource group
```powershell
Get-AzRedHatOpenShiftHcpCluster -ResourceGroupName myResourceGroup
```

```output
Name       Location   ResourceGroupName  VersionId ProvisioningState ApiUrl
----       --------   -----------------  --------- ----------------- ------
myCluster  westeurope myResourceGroup    4.22      Succeeded         https://api.mycluster.32z5.westeurope.aroapp-hcp.io:443
myCluster2 westeurope myResourceGroup    4.22      Succeeded         https://api.mycluster2.4k8p.westeurope.aroapp-hcp.io:443
```

Lists all ARO-HCP clusters in the specified resource group. Omit `-ResourceGroupName` to list every cluster in the subscription.

### Example 2: Get a single cluster by name
```powershell
Get-AzRedHatOpenShiftHcpCluster -ResourceGroupName myResourceGroup -Name myCluster
```

```output
Name      Location   ResourceGroupName  VersionId ProvisioningState ApiUrl
----      --------   -----------------  --------- ----------------- ------
myCluster westeurope myResourceGroup    4.22      Succeeded         https://api.mycluster.32z5.westeurope.aroapp-hcp.io:443
```

Gets a single ARO-HCP cluster by resource group and name. The returned object exposes flattened properties such as `ProvisioningState`, `VersionId`, `NetworkType`, and the operator-identity maps under `UserAssignedIdentityControlPlaneOperator` / `UserAssignedIdentityDataPlaneOperator`.
