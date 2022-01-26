### Example 1: Delete
```powershell
PS C:\> Remove-AzHealthcareDicomService -Name azps_dicom -ResourceGroupName azps_test_group -WorkspaceName azps_healthcare_workspace

```

Deletes a DICOM Service.

### Example 2: DeleteViaIdentity
```powershell
PS C:\> Get-AzHealthcareDicomService -Name azps_dicom -ResourceGroupName azps_test_group -WorkspaceName azps_healthcare_workspace | Remove-AzHealthcareDicomService

```

Deletes a DICOM Service.

