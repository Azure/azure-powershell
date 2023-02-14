### Example 1: List the properties of the specified workspace.
```powershell
<<<<<<< HEAD
Get-AzHealthcareDicomService -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
=======
PS C:\> Get-AzHealthcareDicomService -ResourceGroupName azps_test_group -WorkspaceName azpshcws

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name               ResourceGroupName
-------- ----               -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

List the properties of the specified workspace.

### Example 2: Gets the properties of the specified DICOM Service.
```powershell
<<<<<<< HEAD
Get-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
=======
PS C:\> Get-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name               ResourceGroupName
-------- ----               -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

Gets the properties of the specified DICOM Service.