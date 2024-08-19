### Example 1: Get the Virtual machine assigned to a specific user.
```powershell
Get-AzLabServicesUserVM -ResourceGroupName "Group Name" -LabName "Lab Name" -Email 'user@contoso.com'
```

```output
Name
----
0
```

Returns the specific machine that is assigned to the user in the lab.
