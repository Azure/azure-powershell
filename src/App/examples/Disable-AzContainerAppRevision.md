### Example 1: Deactivates a revision for a Container App
```powershell
Disable-AzContainerAppRevision -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp -RevisionName azps-containerapp--ksjb6f1

Get-AzContainerAppRevision -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp
```

```output
Name                       Active TrafficWeight ProvisioningState ResourceGroupName
----                       ------ ------------- ----------------- -----------------
azps-containerapp--ksjb6f1 False  100           Provisioned       azpstest_gp
```

Deactivates a revision for a Container App