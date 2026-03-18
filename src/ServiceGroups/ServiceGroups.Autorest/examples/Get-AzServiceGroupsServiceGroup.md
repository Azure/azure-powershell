### Example 1: Get a service group by name
```powershell
Get-AzServiceGroup -Name "MyServiceGroup"
```

```output
Name              DisplayName       Kind    ParentId
----              -----------       ----    --------
MyServiceGroup    My Service Group  Custom  /providers/Microsoft.Management/serviceGroups/ParentGroup
```

Gets the details of the specified service group.

### Example 2: Get a service group using pipeline input
```powershell
$sg = @{ServiceGroupName = "MyServiceGroup"}
Get-AzServiceGroup -InputObject $sg
```

```output
Name              DisplayName       Kind    ParentId
----              -----------       ----    --------
MyServiceGroup    My Service Group  Custom  /providers/Microsoft.Management/serviceGroups/ParentGroup
```

Gets the details of a service group using identity input.

