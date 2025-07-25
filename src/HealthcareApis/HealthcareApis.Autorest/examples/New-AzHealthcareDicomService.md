### Example 1: Creates or updates a DICOM Service resource with the specified parameters.
```powershell
New-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Location eastus2
```

```output
Location Name                 ResourceGroupName
-------- ----                 -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

Creates or updates a DICOM Service resource with the specified parameters.