### Example 1: Gets all the Virtual machines in the lab.
```powershell
PS C:\> Get-AzLabServicesVM -LabName "Lab Name" -ResourceGroupName "Group Name"

Name
----
0
1
2
```

Returns all the VMs.

### Example 2: Gets the specific VM in the lab.
```powershell
PS C:\> Get-AzLabServicesVM -LabName "Lab Name" -ResourceGroupName "Group Name" -Name 2

Name
----
2
```

Returns the specific VM.

