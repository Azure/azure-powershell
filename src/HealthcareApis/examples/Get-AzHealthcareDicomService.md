### Example 1: List
```powershell
PS C:\> Get-AzHealthcareDicomService -ResourceGroupName azps_test_group -WorkspaceName azpshcws

Location Name               ResourceGroupName
-------- ----               -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

Gets the properties of the specified DICOM Service.

### Example 2: Get
```powershell
PS C:\> Get-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws

Location Name               ResourceGroupName
-------- ----               -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

Gets the properties of the specified DICOM Service.