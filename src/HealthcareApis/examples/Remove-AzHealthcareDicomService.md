### Example 1: Delete
```powershell
<<<<<<< HEAD
Remove-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws
=======
PS C:\> Remove-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Deletes a DICOM Service.

### Example 2: DeleteViaIdentity
```powershell
<<<<<<< HEAD
Get-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Remove-AzHealthcareDicomService
=======
PS C:\> Get-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Remove-AzHealthcareDicomService

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Deletes a DICOM Service.