### Example 1: Update a service group display name
```powershell
Update-AzServiceGroup -Name "MyServiceGroup" -DisplayName "Updated Display Name"
```

```output
Name              DisplayName            Kind    ParentId
----              -----------            ----    --------
MyServiceGroup    Updated Display Name   Custom  /providers/Microsoft.Management/serviceGroups/ParentGroup
```

Updates the display name of an existing service group.

### Example 2: Update a service group parent
```powershell
Update-AzServiceGroup -Name "MyServiceGroup" -ParentId "/providers/Microsoft.Management/serviceGroups/NewParentGroup"
```

```output
Name              DisplayName       Kind    ParentId
----              -----------       ----    --------
MyServiceGroup    My Service Group  Custom  /providers/Microsoft.Management/serviceGroups/NewParentGroup
```

Moves a service group under a different parent service group.

