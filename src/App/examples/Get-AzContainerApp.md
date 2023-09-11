### Example 1: List the properties of a Container App.
```powershell
Get-AzContainerApp
```

```output
Location       Name                ResourceGroupName
--------       ----                -----------------
Canada Central azps-containerapp-1 azps_test_group_app
Australia East azps-containerapp   azps_test_group_app
```

List the properties of a Container App.

### Example 2: Get the properties of a Container App by Resource Group.
```powershell
Get-AzContainerApp -ResourceGroupName azps_test_group_app
```

```output
Location       Name                ResourceGroupName
--------       ----                -----------------
Canada Central azps-containerapp-1 azps_test_group_app
Australia East azps-containerapp   azps_test_group_app
```

Get the properties of a Container App by Resource Group.

### Example 3: Get the properties of a Container App by name.
```powershell
Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1
```

```output
Location       Name                ResourceGroupName
--------       ----                -----------------
Canada Central azps-containerapp-1 azps_test_group_app
```

Get the properties of a Container App by name.