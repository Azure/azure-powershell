### Example 1: Deactivates a revision for a Container App.
```powershell
Disable-AzContainerAppRevision -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Name azps-containerapp-1--6a9svx2 -PassThru
```

```output
True
```

Deactivates a revision for a Container App.

### Example 2: Deactivates a revision for a Container App.
```powershell
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1
Disable-AzContainerAppRevision -ContainerAppInputObject $containerapp -Name azps-containerapp-1--6a9svx2 -PassThru
```

```output
True
```

Deactivates a revision for a Container App.