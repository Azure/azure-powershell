### Example 1: UpdateExpanded
```powershell
PS C:\> Update-AzHealthcareAPIsWorkspace -Name azps_healthcare_workspace -ResourceGroupName azps_test_group -Tag @{"abc"="123"}

Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus2  azps_healthcare_workspace azps_test_group
```

Patch workspace details.

### Example 2: UpdateViaIdentityExpanded
```powershell
PS C:\> Get-AzHealthcareAPIsWorkspace -Name azps_healthcare_workspace -ResourceGroupName azps_test_group | Update-AzHealthcareAPIsWorkspace -Tag @{"abc"="123"}

Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus2  azps_healthcare_workspace azps_test_group
```

Patch workspace details.

