### Example 1: Delete an ARO-HCP cluster
```powershell
Remove-AzRedHatOpenShiftHcpCluster -ResourceGroupName myResourceGroup -Name myCluster
```

Deletes the ARO-HCP cluster by resource group and name. This is a long-running operation that blocks until the cluster is deleted; the RP also tears down the managed resource group it created. Add `-NoWait` or `-AsJob` to return immediately, and `-PassThru` to return `$true` on success.
