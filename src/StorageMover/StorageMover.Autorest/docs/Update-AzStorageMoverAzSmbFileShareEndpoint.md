---
external help file:
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/update-azstoragemoverazsmbfileshareendpoint
schema: 2.0.0
---

# Update-AzStorageMoverAzSmbFileShareEndpoint

## SYNOPSIS
Updates properties for a SMB file share endpoint resource.
Properties not specified in the request body will be unchanged.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageMoverAzSmbFileShareEndpoint -Name <String> -ResourceGroupName <String>
 -StorageMoverName <String> [-SubscriptionId <String>] [-Description <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageMoverAzSmbFileShareEndpoint -InputObject <IStorageMoverIdentity> [-Description <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates properties for a SMB file share endpoint resource.
Properties not specified in the request body will be unchanged.

## EXAMPLES

### Example 1: Update a Smb file share endpoint 
```powershell
Update-AzStorageMoverAzSmbFileShareEndpoint -Name "myendpoint" -ResourceGroupName "myresourcegroup" -StorageMoverName "mystoragemover" -Description "updated endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/endpoints/myendpoint
Name                         : myendpoint
Property                     : {
                                 "endpointType": "AzureStorageSmbFileShare",
                                 "description": "updated endpoint",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount",
                                 "fileShareName": "testfs"
                               }
SystemDataCreatedAt          : 6/27/2023 4:30:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/13/2023 7:25:59 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates an Azure Storage SMB file share enpdoint's description by manual inputs.

### Example 2: Update a Smb file share endpoint by pipeline
```powershell
Get-AzStorageMoverEndpoint -ResourceGroupName "myresourcegroup" -StorageMoverName "mystoragemover" -Name "myendpoint" | Update-AzStorageMoverAzSmbFileShareEndpoint -Description "updated endpoint again"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/endpoints/myendpoint
Name                         : myendpoint
Property                     : {
                                 "endpointType": "AzureStorageSmbFileShare",
                                 "description": "updated endpoint again",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegorup/providers/Microsoft.Storage/storageAccounts/myaccount",
                                 "fileShareName": "testfs"
                               }
SystemDataCreatedAt          : 6/27/2023 4:30:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/13/2023 8:21:51 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates an Azure Storage SMB file share endpoint's description by pipeline.

## PARAMETERS

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IEndpoint

## NOTES

ALIASES

Update-AzStorageMoverSmbFileShareEndpoint

## RELATED LINKS

