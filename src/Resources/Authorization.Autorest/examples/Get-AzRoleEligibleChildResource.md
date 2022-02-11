### Example 1: List all child resources
```powershell
PS C:\> $scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
PS C:\> Get-AzRoleEligibleChildResource -Scope $scope                              

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
PS C:\> $scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
PS C:\> $filter = "resoureType eq 'resourcegroup'"
PS C:\> Get-AzRoleEligibleChildResource -Scope $scope -Filter $filter

Name                                               Type
----                                               ----
AnujRG                                             resourcegroup
ARPJ-TESTRG-01                                     resourcegroup
AnujRG2                                            resourcegroup
asghodke-rg                                        resourcegroup
```

You can filter by subscriptions, resourceGroups or any resource type.

