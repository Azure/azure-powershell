### Example 1: Create a new service group
```powershell
New-AzServiceGroup -Name "MyServiceGroup" -DisplayName "My Service Group"
```

```output
Name              DisplayName       Kind    ParentId
----              -----------       ----    --------
MyServiceGroup    My Service Group  Custom
```

Creates a new service group with the specified name and display name.

### Example 2: Create a service group under a parent
```powershell
New-AzServiceGroup -Name "ChildGroup" -DisplayName "Child Service Group" -ParentId "/providers/Microsoft.Management/serviceGroups/ParentGroup"
```

```output
Name          DisplayName          Kind    ParentId
----          -----------          ----    --------
ChildGroup    Child Service Group  Custom  /providers/Microsoft.Management/serviceGroups/ParentGroup
```

Creates a new service group nested under an existing parent service group.

