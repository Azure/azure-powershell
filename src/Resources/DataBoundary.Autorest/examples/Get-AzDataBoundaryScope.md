### Example 1: Get Subscription Scoped Data Boundary

```powershell
$scope = "/subscriptions/11111111-1111-1111-1111-111111111111"
Get-AzDataBoundaryScope -Scope $scope
```

```output
Name                                    Id                                                                                      Properties 
--------                                ----                                                                                    ------------
00000000-0000-0000-0000-000000000000    /providers/Microsoft.Resources/dataBoundaries/00000000-0000-0000-0000-000000000000      dataBoundary: EU, provisioningState: Created
```

Gets the dataBoundary at the subscription scope.

### Example 2: Get Resource Group Scoped Data Boundary

```powershell
$scope =  "/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/my-resource-group"
Get-AzDataBoundaryScope -Scope $scope
```

```output
Name                                    Id                                                                                      Properties 
--------                                ----                                                                                    ------------
00000000-0000-0000-0000-000000000000    /providers/Microsoft.Resources/dataBoundaries/00000000-0000-0000-0000-000000000000      dataBoundary: EU, provisioningState: Created
```

Gets the dataBoundary at the resource group scope.

