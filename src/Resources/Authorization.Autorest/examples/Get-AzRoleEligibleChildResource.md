### Example 1: List all child resources
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
Get-AzRoleEligibleChildResource -Scope $scope                              
```

```output
Name                                               Type
----                                               ----
AnujRG                                             resourcegroup
ARPJ-TESTRG-01                                     resourcegroup
AnujRG2                                            resourcegroup
asghodke-rg                                        resourcegroup
```

Get all child resources of a resource `scope` that the calling user has eligible assignment(s) on.

### Example 2: List all child resources filtered by resource type
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
$filter = "resoureType eq 'resourcegroup'"
Get-AzRoleEligibleChildResource -Scope $scope -Filter $filter
```

```output
Name                                               Type
----                                               ----
AnujRG                                             resourcegroup
ARPJ-TESTRG-01                                     resourcegroup
AnujRG2                                            resourcegroup
asghodke-rg                                        resourcegroup
```

You can filter by subscriptions, resourceGroups or any resource type.

