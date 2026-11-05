### Example 1: List dependency relationships for a Service Group
```powershell
Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName "myServiceGroup"
```

Lists dependency relationships whose source is the specified Service Group.

### Example 2: Get a Service Group dependency relationship
```powershell
Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName "myServiceGroup" -Name "myDependency"
```

Gets the named dependency relationship from the Service Group.

