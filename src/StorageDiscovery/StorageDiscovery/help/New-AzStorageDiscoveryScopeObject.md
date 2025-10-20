---
external help file: Az.StorageDiscovery-help.xml
Module Name: Az.StorageDiscovery
online version: https://learn.microsoft.com/powershell/module/Az.StorageDiscovery/new-azstoragediscoveryscopeobject
schema: 2.0.0
---

# New-AzStorageDiscoveryScopeObject

## SYNOPSIS
Create an in-memory object for StorageDiscoveryScope.

## SYNTAX

```
New-AzStorageDiscoveryScopeObject -DisplayName <String> -ResourceType <String[]>
 [-Tag <IStorageDiscoveryScopeTags>] [-TagKeysOnly <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageDiscoveryScope.

## EXAMPLES

### Example 1: Create a workspace with discovery scope object
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

## PARAMETERS

### -DisplayName
Display name of the collection.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
Resource types for the collection.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScopeTags
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TagKeysOnly
The storage account tags keys to filter.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryScope

## NOTES

## RELATED LINKS
