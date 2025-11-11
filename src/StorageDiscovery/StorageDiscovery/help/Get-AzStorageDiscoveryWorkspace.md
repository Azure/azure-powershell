---
external help file: Az.StorageDiscovery-help.xml
Module Name: Az.StorageDiscovery
online version: https://learn.microsoft.com/powershell/module/az.storagediscovery/get-azstoragediscoveryworkspace
schema: 2.0.0
---

# Get-AzStorageDiscoveryWorkspace

## SYNOPSIS
Get a StorageDiscoveryWorkspace

## SYNTAX

### List1 (Default)
```
Get-AzStorageDiscoveryWorkspace [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzStorageDiscoveryWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzStorageDiscoveryWorkspace -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageDiscoveryWorkspace -InputObject <IStorageDiscoveryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a StorageDiscoveryWorkspace

## EXAMPLES

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

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the StorageDiscoveryWorkspace

```yaml
Type: System.String
Parameter Sets: Get
Aliases: StorageDiscoveryWorkspaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List1, Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspace

## NOTES

## RELATED LINKS
