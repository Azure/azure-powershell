### Example 1: List the properties.
```powershell
Get-AzHealthcareApisWorkspace
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus2  azpshcws   azps_test_group
eastus2  azpshcws02 azps_test_group
```

List the properties.

### Example 2: Gets the properties of the specified workspace.
```powershell
Get-AzHealthcareApisWorkspace -Name azpshcws -ResourceGroupName azps_test_group
```

```output
Location Name     ResourceGroupName
-------- ----     -----------------
eastus2  azpshcws azps_test_group
```

Gets the properties of the specified workspace.

### Example 3: List the properties of the resource group.
```powershell
Get-AzHealthcareApisWorkspace -ResourceGroupName azps_test_group
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus2  azpshcws   azps_test_group
eastus2  azpshcws02 azps_test_group
```

List the properties of the specified resource group.