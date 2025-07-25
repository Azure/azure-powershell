### Example 1: List the properties of the specified workspace.
```powershell
Get-AzHealthcareDicomService -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

List the properties of the specified workspace.

### Example 2: Gets the properties of the specified DICOM Service.
```powershell
Get-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

Gets the properties of the specified DICOM Service.