### Example 1: Get all image in the lab plan.
```powershell
<<<<<<< HEAD
Get-AzLabServicesPlanImage -LabPlanName "Plan Name" -ResourceGroupName "Group Name"
```

```output
=======
PS C:\> Get-AzLabServicesPlanImage -LabPlanName "Plan Name" -ResourceGroupName "Group Name"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
128technology.128t_networking_platform.128t_networking_platform
128technology.128technology_conductor_hourly.128technology_conductor_hourly_427
128technology.128technology_conductor_hourly.128technology_conductor_hourly_452
```

Gets all the available images, this is usually a long list of images.

### Example 2: Get specific image in the lab plan.
```powershell
<<<<<<< HEAD
Get-AzLabServicesPlanImage -LabPlanName "Plan Name"  -ResourceGroupName "Group Name" -Name 'canonical.0001-com-ubuntu-server-focal.20_04-lts'
```

```output
=======
PS C:\> Get-AzLabServicesPlanImage -LabPlanName "Plan Name"  -ResourceGroupName "Group Name" -Name 'canonical.0001-com-ubuntu-server-focal.20_04-lts'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
canonical.0001-com-ubuntu-server-focal.20_04-lts
```

Returns the specific image.

### Example 3: Get specific image using display name.
```powershell
<<<<<<< HEAD
Get-AzLabServicesPlanImage -LabPlanName "Plan Name" -ResourceGroupName "Group Name" -DisplayName 'Ubuntu Server 20.04 LTS'
```

```output
=======
PS C:\> Get-AzLabServicesPlanImage -LabPlanName "Plan Name" -ResourceGroupName "Group Name" -DisplayName 'Ubuntu Server 20.04 LTS'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
canonical.0001-com-ubuntu-server-focal.20_04-lts
```

Returns the specific image with the display name.