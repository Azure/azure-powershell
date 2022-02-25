### Example 1: Get all image in the lab plan.
```powershell
Get-AzLabServicesPlanImage -LabPlanName "Plan Name" -ResourceGroupName "Group Name"
```

```output
Name
----
128technology.128t_networking_platform.128t_networking_platform
128technology.128technology_conductor_hourly.128technology_conductor_hourly_427
128technology.128technology_conductor_hourly.128technology_conductor_hourly_452
```

Gets all the available images, this is usually a long list of images.

### Example 2: Get specific image in the lab plan.
```powershell
Get-AzLabServicesPlanImage -LabPlanName "Plan Name"  -ResourceGroupName "Group Name" -Name 'canonical.0001-com-ubuntu-server-focal.20_04-lts'
```

```output
Name
----
canonical.0001-com-ubuntu-server-focal.20_04-lts
```

Returns the specific image.

### Example 3: Get specific image using display name.
```powershell
Get-AzLabServicesPlanImage -LabPlanName "Plan Name" -ResourceGroupName "Group Name" -DisplayName 'Ubuntu Server 20.04 LTS'
```

```output
Name
----
canonical.0001-com-ubuntu-server-focal.20_04-lts
```

Returns the specific image with the display name.