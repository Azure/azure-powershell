---
external help file: Az.StorageMover-help.xml
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/new-azstoragemoverazstoragecontainerendpoint
schema: 2.0.0
---

# New-AzStorageMoverAzStorageContainerEndpoint

## SYNOPSIS
Creates an AzStorageContainer endpoint resource, which represents a data transfer source or destination.

## SYNTAX

```
New-AzStorageMoverAzStorageContainerEndpoint -Name <String> -ResourceGroupName <String>
 -StorageMoverName <String> [-SubscriptionId <String>] -BlobContainerName <String>
 -StorageAccountResourceId <String> [-Description <String>] [-EndpointKind <String>]
 [-EnableCrossTenantTransfer] [-AllowedStorageAccount <String[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates an AzStorageContainer endpoint resource, which represents a data transfer source or destination.

## EXAMPLES

### Example 1: Create a AzStorageContainer endpoint
```powershell
New-AzStorageMoverAzStorageContainerEndpoint -Name myEndpoint -ResourceGroupName myResourceGroup -BlobContainerName myContainer -StorageMoverName myStorageMover -StorageAccountResourceId myAccountResourceId
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint
Name                         : myEndpoint
Property                     : {
                                 "endpointType": "AzureStorageBlobContainer",
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

This command creates a AzStorageContainer endpoint for a Storage mover.

### Example 2: Create an AzStorageContainer endpoint for cross-tenant data transfer
```powershell
New-AzStorageMoverAzStorageContainerEndpoint -Name myEndpoint -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -BlobContainerName myContainer -StorageAccountResourceId myAccountResourceId -EndpointKind Target -EnableCrossTenantTransfer -AllowedStorageAccount "/subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.Storage/storageAccounts/partnerStorageAccount"
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
                                 "allowedStorageAccounts": [ "/subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.Storage/storageAccounts/partnerStorageAccount" ]
                               }
ResourceGroupName            : myResourceGroup
SystemDataCreatedAt          : 10/19/2026 10:43:52 AM
SystemDataCreatedBy          : xxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/19/2026 10:43:52 AM
SystemDataLastModifiedBy     : xxxxxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command creates an AzStorageContainer target endpoint that can be used as one side of a cross-tenant data transfer with the listed partner-tenant storage account.

## PARAMETERS

### -AllowedStorageAccount
The Azure Resource Manager resource IDs of partner-tenant storage accounts that are allowed to be the other side of a cross-tenant data transfer with this endpoint.

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

### -BlobContainerName
The name of the Storage blob container that is the target destination.

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
Enables this endpoint to be used as one side of a cross-tenant data transfer.
Defaults to false.

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

### -EndpointKind
The kind of the endpoint, either Source or Target.
Cannot be changed after the endpoint is created.

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

### -Name
The name of the endpoint resource.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountResourceId
The Azure Resource ID of the storage account that is the target destination.

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

### -StorageMoverName
The name of the Storage Mover resource.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IEndpoint

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IEndpoint

## NOTES

## RELATED LINKS
