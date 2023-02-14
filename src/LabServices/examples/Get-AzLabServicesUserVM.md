### Example 1: Get the Virtual machine assigned to a specific user.
```powershell
<<<<<<< HEAD
Get-AzLabServicesUserVM -ResourceGroupName "Group Name" -LabName "Lab Name" -Email 'user@contoso.com'
```

```output
=======
PS C:\> Get-AzLabServicesUserVM -ResourceGroupName "Group Name" -LabName "Lab Name" -Email 'user@contoso.com'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
0
```

Returns the specific machine that is assigned to the user in the lab.
