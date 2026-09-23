---
external help file: Az.StorageDiscovery-help.xml
Module Name: Az.StorageDiscovery
online version: https://learn.microsoft.com/powershell/module/az.storagediscovery/update-azstoragediscoveryworkspace
schema: 2.0.0
---

# Update-AzStorageDiscoveryWorkspace

## SYNOPSIS
Update a StorageDiscoveryWorkspace

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageDiscoveryWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Description <String>] [-Scope <IStorageDiscoveryScope[]>] [-Sku <String>] [-Tag <Hashtable>]
 [-WorkspaceRoot <String[]>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzStorageDiscoveryWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzStorageDiscoveryWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageDiscoveryWorkspace -InputObject <IStorageDiscoveryIdentity> [-Description <String>]
 [-Scope <IStorageDiscoveryScope[]>] [-Sku <String>] [-Tag <Hashtable>] [-WorkspaceRoot <String[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a StorageDiscoveryWorkspace

## EXAMPLES

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

### -Description
The description of the storage discovery workspace

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the StorageDiscoveryWorkspace

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scopes of the storage discovery workspace.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The storage discovery sku

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceRoot
The view level storage discovery data estate

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
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
