### Example 1: List
```powershell
PS C:\> Get-AzHealthcareAPIsWorkspace

Location Name                        ResourceGroupName
-------- ----                        -----------------
eastus2  azps_healthcare_workspace   azps_test_group
eastus2  azps_healthcare_workspace02 azps_test_group
```

Gets the properties of the specified workspace.

### Example 2: Get
```powershell
PS C:\> Get-AzHealthcareAPIsWorkspace -Name azps_healthcare_workspace -ResourceGroupName azps_test_group

Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus2  azps_healthcare_workspace azps_test_group
```

Gets the properties of the specified workspace.

### Example 3: List1
```powershell
PS C:\> Get-AzHealthcareAPIsWorkspace -ResourceGroupName azps_test_group

Location Name                        ResourceGroupName
-------- ----                        -----------------
eastus2  azps_healthcare_workspace   azps_test_group
eastus2  azps_healthcare_workspace02 azps_test_group
```

Gets the properties of the specified workspace.