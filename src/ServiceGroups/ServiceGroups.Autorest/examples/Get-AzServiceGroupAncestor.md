### Example 1: List all ancestors of a service group
```powershell
Get-AzServiceGroupAncestor -ServiceGroupName "ContosoChild"
```

```output
DisplayName   : Contoso Group
Id            : /providers/Microsoft.Management/serviceGroups/Contoso
Name          : Contoso

DisplayName   : Root Service Group
Id            : /providers/Microsoft.Management/serviceGroups/00000000-0000-0000-0000-000000000000
Name          : 00000000-0000-0000-0000-000000000000
```

Returns all ancestor service groups in the hierarchy for 'ContosoChild', from its immediate parent up to the root service group. The root service group ID is always the tenant ID.

