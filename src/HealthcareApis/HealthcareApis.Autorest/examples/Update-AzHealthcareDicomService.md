### Example 1: Patch DICOM Service details.
```powershell
Update-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Tag @{"123"="abc"}
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

Patch DICOM Service details.

### Example 2: Patch DICOM Service details.
```powershell
Get-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Update-AzHealthcareDicomService -Tag @{"123"="abc"}
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

Patch DICOM Service details.