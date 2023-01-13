### Example 1: Activates a revision for a Container App
```powershell
Enable-AzContainerAppRevision -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp -RevisionName azps-containerapp--ksjb6f1

Get-AzContainerAppRevision -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp
```

```output
Name                       Active TrafficWeight ProvisioningState ResourceGroupName
----                       ------ ------------- ----------------- -----------------
azps-containerapp--ksjb6f1 True   100           Provisioned       azpstest_gp
```

Activates a revision for a Container App