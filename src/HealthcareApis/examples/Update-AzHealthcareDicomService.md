### Example 1: UpdateExpanded
```powershell
PS C:\> Update-AzHealthcareDicomService -Name azps_dicom -ResourceGroupName azps_test_group -WorkspaceName azps_healthcare_workspace -Tag @{"123"="abc"}

Location Name                                 ResourceGroupName
-------- ----                                 -----------------
eastus2  azps_healthcare_workspace/azps_dicom azps_test_group
```

Patch DICOM Service details.

### Example 2: UpdateViaIdentityExpanded
```powershell
PS C:\> Get-AzHealthcareDicomService -Name azps_dicom -ResourceGroupName azps_test_group -WorkspaceName azps_healthcare_workspace | Update-AzHealthcareDicomService -Tag @{"123"="abc"}

Location Name                                 ResourceGroupName
-------- ----                                 -----------------
eastus2  azps_healthcare_workspace/azps_dicom azps_test_group
```

Patch DICOM Service details.