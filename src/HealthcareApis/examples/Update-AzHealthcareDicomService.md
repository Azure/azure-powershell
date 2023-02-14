### Example 1: Patch DICOM Service details.
```powershell
<<<<<<< HEAD
Update-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Tag @{"123"="abc"}
```

```output
=======
PS C:\> Update-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Tag @{"123"="abc"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name               ResourceGroupName
-------- ----               -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

Patch DICOM Service details.

### Example 2: Patch DICOM Service details.
```powershell
<<<<<<< HEAD
Get-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Update-AzHealthcareDicomService -Tag @{"123"="abc"}
```

```output
=======
PS C:\> Get-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Update-AzHealthcareDicomService -Tag @{"123"="abc"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name               ResourceGroupName
-------- ----               -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

Patch DICOM Service details.