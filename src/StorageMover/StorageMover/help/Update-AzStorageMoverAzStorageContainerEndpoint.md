---
external help file: Az.StorageMover-help.xml
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/update-azstoragemoverazstoragecontainerendpoint
schema: 2.0.0
---

# Update-AzStorageMoverAzStorageContainerEndpoint

## SYNOPSIS
Updates properties for an AzStorageContainer endpoint resource.
Properties not specified in the request body will be unchanged.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageMoverAzStorageContainerEndpoint -Name <String> -ResourceGroupName <String>
 -StorageMoverName <String> [-SubscriptionId <String>] [-Description <String>] [-EnableCrossTenantTransfer]
 [-AllowedStorageAccount <String[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageMoverAzStorageContainerEndpoint -InputObject <IStorageMoverIdentity> [-Description <String>]
 [-EnableCrossTenantTransfer] [-AllowedStorageAccount <String[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates properties for an AzStorageContainer endpoint resource.
Properties not specified in the request body will be unchanged.

## EXAMPLES

### Example 1: Update an AzStorageContainer endpoint
```powershell
Update-AzStorageMoverAzStorageContainerEndpoint -Name myEndpoint -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Description "Update Description"
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint1
Name                         : containerEndpointo3q8xlbr
Property                     : {
                                 "endpointType": "AzureStorageBlobContainer",
                                 "description": "Update Description",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myStorageMover/providers/Microsoft.Storage/storageAccounts/myStorageAccount",
                                 "blobContainerName": "myContainer"
                               }
IdentityPrincipalId          : 4a8804ea-a688-4577-89f1-e74cbe3d7c3a
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
SystemDataCreatedAt          : 7/18/2022 7:28:29 AM
SystemDataCreatedBy          : xxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/18/2022 7:28:29 AM
SystemDataLastModifiedBy     : xxxxxxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates the description of an AzStorageContainerEndpoint.

### Example 2: Replace the storage accounts allowed for cross-tenant data transfer
```powershell
Update-AzStorageMoverAzStorageContainerEndpoint -Name myEndpoint -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -AllowedStorageAccount "/subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.Storage/storageAccounts/partnerStorageAccount1", "/subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.Storage/storageAccounts/partnerStorageAccount2"
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint
IdentityPrincipalId          : 00000000-0000-0000-0000-000000000000
IdentityTenantId             : 00000000-0000-0000-0000-000000000000
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
Name                         : myEndpoint
Property                     : {
                                 "endpointType": "AzureStorageBlobContainer",
                                 "endpointKind": "Target",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount",
                                 "blobContainerName": "myContainer",
                                 "enableCrossTenantTransfer": true,
                                 "allowedStorageAccounts": [ "/subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.Storage/storageAccounts/partnerStorageAccount1", "/subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.Storage/storageAccounts/partnerStorageAccount2" ]
                               }
ResourceGroupName            : myResourceGroup
SystemDataCreatedAt          : 10/19/2026 10:43:52 AM
SystemDataCreatedBy          : xxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/19/2026 10:43:53 AM
SystemDataLastModifiedBy     : xxxxxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command replaces the list of partner-tenant storage accounts that are allowed to be the other side of a cross-tenant data transfer with the endpoint.

### Example 3: Disable cross-tenant data transfer for an AzStorageContainer endpoint
```powershell
Update-AzStorageMoverAzStorageContainerEndpoint -Name myEndpoint -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -EnableCrossTenantTransfer:$false -AllowedStorageAccount @()
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint
IdentityPrincipalId          : 00000000-0000-0000-0000-000000000000
IdentityTenantId             : 00000000-0000-0000-0000-000000000000
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
Name                         : myEndpoint
Property                     : {
                                 "endpointType": "AzureStorageBlobContainer",
                                 "endpointKind": "Target",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount",
                                 "blobContainerName": "myContainer",
                                 "enableCrossTenantTransfer": false,
                                 "allowedStorageAccounts": [ ]
                               }
ResourceGroupName            : myResourceGroup
SystemDataCreatedAt          : 10/19/2026 10:43:52 AM
SystemDataCreatedBy          : xxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/19/2026 10:43:55 AM
SystemDataLastModifiedBy     : xxxxxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command disables cross-tenant data transfer for the endpoint and clears its list of allowed partner-tenant storage accounts.

## PARAMETERS

### -AllowedStorageAccount
The Azure Resource Manager resource IDs of partner-tenant storage accounts that are allowed to be the other side of a cross-tenant data transfer with this endpoint.
The specified list replaces the existing list; specify an empty array to clear it.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
A description for the endpoint.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableCrossTenantTransfer
Enables or disables using this endpoint as one side of a cross-tenant data transfer.
To disable, set this switch to false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the endpoint resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: EndpointName

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageMoverName
The name of the Storage Mover resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IEndpoint

## NOTES

## RELATED LINKS
