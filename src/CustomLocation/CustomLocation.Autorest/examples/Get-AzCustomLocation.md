### Example 1: List the details of the customLocation.
```powershell
Get-AzCustomLocation
```

```output
Location Name                Namespace      ResourceGroupName
-------- ----                ---------      -----------------
eastus   azps-customlocation azps-namespace azps_test_cluster
```

List the details of the customLocation.

### Example 2: List the details of the customLocation with a specified resource group.
```powershell
Get-AzCustomLocation -ResourceGroupName azps_test_cluster
```

```output
Location Name                Namespace      ResourceGroupName
-------- ----                ---------      -----------------
eastus   azps-customlocation azps-namespace azps_test_cluster
```

List the details of the customLocation with a specified resource group.

### Example 3: Gets the details of the customLocation with a specified resource group and name.
```powershell
Get-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation
```

```output
Location Name                Namespace      ResourceGroupName
-------- ----                ---------      -----------------
eastus   azps-customlocation azps-namespace azps_test_cluster
```

Gets the details of the customLocation with a specified resource group and name.