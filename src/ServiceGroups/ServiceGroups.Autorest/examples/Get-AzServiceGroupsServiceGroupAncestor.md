### Example 1: Get ancestors of a service group
```powershell
Get-AzServiceGroupAncestor -ServiceGroupName "MyServiceGroup"
```

```output
Name              DisplayName       Kind    ParentId
----              -----------       ----    --------
ParentGroup       Parent Group      Custom
GrandParent       Grand Parent      Custom
```

Returns all ancestor service groups in the hierarchy for the specified service group.

