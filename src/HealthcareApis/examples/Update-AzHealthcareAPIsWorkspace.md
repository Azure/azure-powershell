### Example 1: Patch workspace details.
```powershell
PS C:\> Update-AzHealthcareAPIsWorkspace -Name azpshcws -ResourceGroupName azps_test_group -Tag @{"abc"="123"}

Location Name     ResourceGroupName
-------- ----     -----------------
eastus2  azpshcws azps_test_group
```

Patch workspace details.

### Example 2: Patch workspace details.
```powershell
PS C:\> Get-AzHealthcareAPIsWorkspace -Name azpshcws -ResourceGroupName azps_test_group | Update-AzHealthcareAPIsWorkspace -Tag @{"abc"="123"}

Location Name     ResourceGroupName
-------- ----     -----------------
eastus2  azpshcws azps_test_group
```

Patch workspace details.