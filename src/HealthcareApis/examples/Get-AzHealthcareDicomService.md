### Example 1: List
```powershell
PS C:\> Get-AzHealthcareDicomService -ResourceGroupName azps_test_group -WorkspaceName azps_healthcare_workspace

Location Name                                 ResourceGroupName
-------- ----                                 -----------------
eastus2  azps_healthcare_workspace/azps_dicom azps_test_group
```

Gets the properties of the specified DICOM Service.

### Example 2: Get
```powershell
PS C:\> Get-AzHealthcareDicomService -Name azps_dicom -ResourceGroupName azps_test_group -WorkspaceName azps_healthcare_workspace

Location Name                                 ResourceGroupName
-------- ----                                 -----------------
eastus2  azps_healthcare_workspace/azps_dicom azps_test_group
```

Gets the properties of the specified DICOM Service.