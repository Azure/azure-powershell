### Example 1: Update a workspace
```powershell
$scope2 =  New-AzStorageDiscoveryScopeObject -DisplayName "scope2" -ResourceType "Microsoft.Storage/storageAccounts"  -TagKeysOnly "test2" -Tag @{"tag3" = "value3" }
Update-AzStorageDiscoveryWorkspace -Name $workSpaceName  -ResourceGroupName $RGName -Description "test workSpace2" -Sku Free -Scope $scope2 -WorkspaceRoot $DiscoveryScopeLevel1,$DiscoveryScopeLevel2 -Tag @{"tag4" = "value4"} 
```

```output
Description                  : test workSpace2
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageDiscovery/storageDiscoveryWorkspaces/myworkspace
Location                     : eastus2euap
Name                         : myworkspace
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
Scope                        : {{
                                 "displayName": "scope2",
                                 "resourceTypes": [ "Microsoft.Storage/storageAccounts" ],
                                 "tagKeysOnly": [ "test2" ],
                                 "tags": {
                                   "tag3": "value3"
                                 }
                               }}
Sku                          : Free
SystemDataCreatedAt          : 7/24/2025 3:30:02 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 3:30:02 AM
SystemDataLastModifiedBy     : user@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "tag4": "value4"
                               }
Type                         : microsoft.storagediscovery/storagediscoveryworkspaces
WorkspaceRoot                : {/subscriptions/00000000-0000-0000-0000-000000000000,/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup}
```

The first command creates a discovery scope object, then the second command updates a workSpace properties.

