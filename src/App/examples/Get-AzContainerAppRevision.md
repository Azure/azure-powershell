### Example 1: List revisions by Resource Group.
```powershell
Get-AzContainerAppRevision -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp
```

```output
Name                       Active TrafficWeight ProvisioningState ResourceGroupName
----                       ------ ------------- ----------------- -----------------
azps-containerapp--ksjb6f1 True   100           Provisioned       azpstest_gp
```

List revisions by Resource Group.

### Example 2: Get a revision of a Container App.
```powershell
Get-AzContainerAppRevision -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp -RevisionName azps-containerapp--ksjb6f1
```

```output
Name                       Active TrafficWeight ProvisioningState ResourceGroupName
----                       ------ ------------- ----------------- -----------------
azps-containerapp--ksjb6f1 True   100           Provisioned       azpstest_gp
```

Get a revision of a Container App.