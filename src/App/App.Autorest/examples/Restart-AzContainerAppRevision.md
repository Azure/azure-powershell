### Example 1: Restarts a revision for a Container App.
```powershell
Restart-AzContainerAppRevision -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Name azps-containerapp-1--6a9svx2 -PassThru
```

```output
True
```

Restarts a revision for a Container App.

### Example 2: Restarts a revision for a Container App.
```powershell
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1
Restart-AzContainerAppRevision -ContainerAppInputObject $containerapp -Name azps-containerapp-1--6a9svx2 -PassThru
```

```output
True
```

Restarts a revision for a Container App.