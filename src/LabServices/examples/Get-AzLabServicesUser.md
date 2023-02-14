### Example 1: Get all users for a lab.
```powershell
<<<<<<< HEAD
Get-AzLabServicesUser -LabName "Lab Name" -ResourceGroupName "Group Name"
```

```output
=======
PS C:\> Get-AzLabServicesUser -LabName "Lab Name" -ResourceGroupName "Group Name"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
testuser
```

Gets all the users for a lab.

### Example 2: Get user using name
```powershell
<<<<<<< HEAD
Get-AzLabServicesUser -LabName "Lab Name" -ResourceGroupName "Group Name" -Name "testuser"
```

```output
=======
PS C:\> Get-AzLabServicesUser -LabName "Lab Name" -ResourceGroupName "Group Name" -Name "testuser"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
testuser
```

Gets a specific user from the lab.

