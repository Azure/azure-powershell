### Example 1: List revision of a Container App.
```powershell
Get-AzContainerAppRevision -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app
```

```output
Name                         Active TrafficWeight ProvisioningState ResourceGroupName
----                         ------ ------------- ----------------- -----------------
azps-containerapp-1--6a9svx2 True   100           Provisioned       azps_test_group_app
```

List revision of a Container App.

### Example 2: Get a revision by name.
```powershell
Get-AzContainerAppRevision -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Name azps-containerapp-1--6a9svx2
```

```output
Name                         Active TrafficWeight ProvisioningState ResourceGroupName
----                         ------ ------------- ----------------- -----------------
azps-containerapp-1--6a9svx2 True   100           Provisioned       azps_test_group_app
```

Get a revision by name.

### Example 3: Get a revision by Container App.
```powershell
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1
Get-AzContainerAppRevision -ContainerAppInputObject $containerapp -Name azps-containerapp-1--6a9svx2
```

```output
Name                         Active TrafficWeight ProvisioningState ResourceGroupName
----                         ------ ------------- ----------------- -----------------
azps-containerapp-1--6a9svx2 True   100           Provisioned       azps_test_group_app
```

Get a revision by Container App.