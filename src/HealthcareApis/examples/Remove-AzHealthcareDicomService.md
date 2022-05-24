### Example 1: Delete
```powershell
PS C:\> Remove-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws

```

Deletes a DICOM Service.

### Example 2: DeleteViaIdentity
```powershell
PS C:\> Get-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Remove-AzHealthcareDicomService

```

Deletes a DICOM Service.