### Example 1: Create a workspace
```powershell
$scope1 =  New-AzStorageDiscoveryScopeObject -DisplayName "scope1" -ResourceType "Microsoft.Storage/storageAccounts"  -TagKeysOnly "key1" -Tag @{"tag1" = "value1"; "tag2" = "value2" }
New-AzStorageDiscoveryWorkspace -Name $workSpaceName  -ResourceGroupName $ResourceGroupName -Location $location -WorkspaceRoot $DiscoveryScopeLevel -Sku Standard -Scope $scope1 -Description "test workSpace" 
```

```output
Description                  : test workSpace
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageDiscovery/storageDiscoveryWorkspaces/myworkspace
Location                     : eastus2euap
Name                         : myworkspace
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
Scope                        : {{
                                 "displayName": "scope1",
                                 "resourceTypes": [ "Microsoft.Storage/storageAccounts" ],
                                 "tagKeysOnly": [ "key1" ],
                                 "tags": {
                                   "tag1": "value1",
                                   "tag2": "value2"
                                 }
                               }}
Sku                          : Standard
SystemDataCreatedAt          : 7/24/2025 3:30:02 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 3:30:02 AM
SystemDataLastModifiedBy     : user@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.storagediscovery/storagediscoveryworkspaces
WorkspaceRoot                : {/subscriptions/00000000-0000-0000-0000-000000000000}
```

The first command creates a discovery scope object, then the second command creates a workspace with the discovery scope object.
