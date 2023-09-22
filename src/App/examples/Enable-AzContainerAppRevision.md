### Example 1: Activates a revision for a Container App.
```powershell
Enable-AzContainerAppRevision -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Name azps-containerapp-1--6a9svx2 -PassThru
```

```output
True
```

Activates a revision for a Container App.

### Example 2: Activates a revision for a Container App.
```powershell
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1
Enable-AzContainerAppRevision -ContainerAppInputObject $containerapp -Name azps-containerapp-1--6a9svx2 -PassThru
```

```output
True
```

Activates a revision for a Container App.