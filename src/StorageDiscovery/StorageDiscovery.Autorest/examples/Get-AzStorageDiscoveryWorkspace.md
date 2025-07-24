### Example 1: Get a workspace properties
```powershell
Get-AzStorageDiscoveryWorkspace -Name $workSpaceName  -ResourceGroupName $ResourceGroupName
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

The command gets a single workSpace properties with resource group name and workspace name.

### Example 2: List workspace from subscription
```powershell
 Get-AzStorageDiscoveryWorkspace
```

```output
Location Name          SystemDataCreatedAt   SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----          -------------------   -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus2  myworkspace   7/22/2025 10:37:51 AM user@microsoft.com   User                    7/22/2025 10:37:51 AM    user@microsoft.com       User                         myresourcegroup
eastus2  myworkspace2  7/24/2025 3:30:02 AM  user@microsoft.com   User                    7/24/2025 3:42:49 AM     user@microsoft.com       User                         myresourcegroup2
```

The command lists workSpaces from the current subscription.

### Example 3: List workspace from resource group
```powershell
 Get-AzStorageDiscoveryWorkspace -ResourceGroupName $ResourceGroupName |fl
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

Description                  : test workSpace2
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageDiscovery/storageDiscoveryWorkspaces/myworkspace2
Location                     : eastus2euap
Name                         : myworkspace2
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
Scope                        : {{
                                 "displayName": "scope2",
                                 "resourceTypes": [ "Microsoft.Storage/storageAccounts" ],
                                 "tagKeysOnly": [ "key2" ],
                                 "tags": {
                                   "tag1": "value1"
                                 }
                               }}
Sku                          : Standard
SystemDataCreatedAt          : 7/24/2025 3:31:04 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 3:31:04 AM
SystemDataLastModifiedBy     : user@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.storagediscovery/storagediscoveryworkspaces
WorkspaceRoot                : {/subscriptions/00000000-0000-0000-0000-000000000000,/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup}
```

The command lists workSpaces from a resource group, and format the output as list.

