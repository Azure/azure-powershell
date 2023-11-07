### Example 1: Get auth token for a container app.
```powershell
Get-AzContainerAppAuthToken -ContainerAppName azps-containerapp-2 -ResourceGroupName azps_test_group_app
```

```output
Location Name                ResourceGroupName
-------- ----                -----------------
East US  azps-containerapp-1 azps_test_group_app
```

Get auth token for a container app.

### Example 2: Get auth token for a container app.
```powershell
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1
Get-AzContainerAppAuthToken -InputObject $containerapp
```

```output
Location Name                ResourceGroupName
-------- ----                -----------------
East US  azps-containerapp-1 azps_test_group_app
```

Get auth token for a container app.