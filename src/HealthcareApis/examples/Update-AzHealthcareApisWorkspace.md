### Example 1: Patch workspace details.
```powershell
<<<<<<< HEAD
Update-AzHealthcareApisWorkspace -Name azpshcws -ResourceGroupName azps_test_group -Tag @{"abc"="123"}
```

```output
=======
PS C:\> Update-AzHealthcareApisWorkspace -Name azpshcws -ResourceGroupName azps_test_group -Tag @{"abc"="123"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name     ResourceGroupName
-------- ----     -----------------
eastus2  azpshcws azps_test_group
```

Patch workspace details.

### Example 2: Patch workspace details.
```powershell
<<<<<<< HEAD
Get-AzHealthcareApisWorkspace -Name azpshcws -ResourceGroupName azps_test_group | Update-AzHealthcareApisWorkspace -Tag @{"abc"="123"}
```

```output
=======
PS C:\> Get-AzHealthcareApisWorkspace -Name azpshcws -ResourceGroupName azps_test_group | Update-AzHealthcareApisWorkspace -Tag @{"abc"="123"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name     ResourceGroupName
-------- ----     -----------------
eastus2  azpshcws azps_test_group
```

Patch workspace details.