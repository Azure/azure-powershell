---
external help file:
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/update-azstoragemoveraznfsfileshareendpoint
schema: 2.0.0
---

# Update-AzStorageMoverAzNfsFileShareEndpoint

## SYNOPSIS
Updates properties for a Nfs File Share endpoint resource.
Properties not specified in the request body will be unchanged.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageMoverAzNfsFileShareEndpoint -Name <String> -ResourceGroupName <String>
 -StorageMoverName <String> [-SubscriptionId <String>] [-Description <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageMoverAzNfsFileShareEndpoint -InputObject <IStorageMoverIdentity> [-Description <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates properties for a Nfs File Share endpoint resource.
Properties not specified in the request body will be unchanged.

## EXAMPLES

### Example 1: Update an NFS endpoint
```powershell
Update-AzStorageMoverAzNfsFileShareEndpoint -Name "my-nfs-endpoint" -ResourceGroupName "my-resource-group" -StorageMoverName "my-storage-mover" -Description "My updated NFS endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.StorageMover/storageMovers/my-storage-mover/endpoints/my-nfs-endpoint
Name                         : my-nfs-endpoint
Property                     : {
                                 "endpointType": "AzureNFSFileShare",
                                 "description": "My updated NFS endpoint",
                                 "provisioningState": "Succeeded",
                                 "host": "10.0.0.1",
                                 "export": "my-export"
                               }
SystemDataCreatedAt          : 6/27/2023 4:30:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/14/2023 8:00:00 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates the description of an Azure NFS file share endpoint.

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IEndpoint

## NOTES

## RELATED LINKS

