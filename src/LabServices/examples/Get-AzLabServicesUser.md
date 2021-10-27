### Example 1: Get all users for a lab.
```powershell
PS C:\> Get-AzLabServicesUser -LabName "Lab Name" -ResourceGroupName "Group Name"

Name
----
testuser
```

Gets all the users for a lab.

### Example 2: Get user using name
```powershell
PS C:\> Get-AzLabServicesUser -LabName "Lab Name" -ResourceGroupName "Group Name" -Name "testuser"

Name
----
testuser
```

Gets a specific user from the lab.

