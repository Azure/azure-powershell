### Example 1: List the properties.
```powershell
<<<<<<< HEAD
Get-AzHealthcareApisWorkspace
```

```output
=======
PS C:\> Get-AzHealthcareApisWorkspace

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name       ResourceGroupName
-------- ----       -----------------
eastus2  azpshcws   azps_test_group
eastus2  azpshcws02 azps_test_group
```

List the properties.

### Example 2: Gets the properties of the specified workspace.
```powershell
<<<<<<< HEAD
Get-AzHealthcareApisWorkspace -Name azpshcws -ResourceGroupName azps_test_group
```

```output
=======
PS C:\> Get-AzHealthcareApisWorkspace -Name azpshcws -ResourceGroupName azps_test_group

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name     ResourceGroupName
-------- ----     -----------------
eastus2  azpshcws azps_test_group
```

Gets the properties of the specified workspace.

### Example 3: List the properties of the resource group.
```powershell
<<<<<<< HEAD
Get-AzHealthcareApisWorkspace -ResourceGroupName azps_test_group
```

```output
=======
PS C:\> Get-AzHealthcareApisWorkspace -ResourceGroupName azps_test_group

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name       ResourceGroupName
-------- ----       -----------------
eastus2  azpshcws   azps_test_group
eastus2  azpshcws02 azps_test_group
```

List the properties of the specified resource group.