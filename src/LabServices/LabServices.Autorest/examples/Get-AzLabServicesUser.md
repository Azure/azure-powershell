### Example 1: Get all users for a lab.
```powershell
Get-AzLabServicesUser -LabName "Lab Name" -ResourceGroupName "Group Name"
```

```output
Name
----
testuser
```

Gets all the users for a lab.

### Example 2: Get user using name
```powershell
Get-AzLabServicesUser -LabName "Lab Name" -ResourceGroupName "Group Name" -Name "testuser"
```

```output
Name
----
testuser
```

Gets a specific user from the lab.

