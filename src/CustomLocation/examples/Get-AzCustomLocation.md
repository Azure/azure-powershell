### Example 1: List the details of the customLocation.
```powershell
PS C:\> Get-AzCustomLocation

Location Name              Type
-------- ----              ----
eastus   azps_test_cluster Microsoft.ExtendedLocation/customLocations
```

List the details of the customLocation.

### Example 2: List the details of the customLocation with a specified resource group.
```powershell
PS C:\> Get-AzCustomLocation -ResourceGroupName azps_test_group

Location Name              Type
-------- ----              ----
eastus   azps_test_cluster Microsoft.ExtendedLocation/customLocations
```

List the details of the customLocation with a specified resource group.

### Example 3: Gets the details of the customLocation with a specified resource group and name.
```powershell
PS C:\> Get-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster

Location Name              Type
-------- ----              ----
eastus   azps_test_cluster Microsoft.ExtendedLocation/customLocations
```

Gets the details of the customLocation with a specified resource group and name.