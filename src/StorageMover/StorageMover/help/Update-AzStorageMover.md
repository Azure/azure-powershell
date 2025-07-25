---
external help file: Az.StorageMover-help.xml
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/update-azstoragemover
schema: 2.0.0
---

# Update-AzStorageMover

## SYNOPSIS
Updates properties for a Storage Mover resource.
Properties not specified in the request body will be unchanged.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageMover -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Description <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzStorageMover -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -StorageMover <IStorageMoverUpdateParameters> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageMover -InputObject <IStorageMoverIdentity> [-Description <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzStorageMover -InputObject <IStorageMoverIdentity> -StorageMover <IStorageMoverUpdateParameters>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates properties for a Storage Mover resource.
Properties not specified in the request body will be unchanged.

## EXAMPLES

### Example 1: Update a Storage mover
```powershell
Update-AzStorageMover -ResourceGroupName myResourceGroup -Name myStorageMover -Description "Update description"
```

```output
Description                  : Update description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover
Location                     : eastus
Name                         : myStorageMover
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 3:32:45 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/3/2022 3:10:31 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.storagemover/storagemovers
```

This command updates the description of a Storage mover.

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
A description for the Storage Mover.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Storage Mover resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
Aliases: StorageMoverName

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
Parameter Sets: UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageMover
The Storage Mover resource.
To construct, see NOTES section for STORAGEMOVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IStorageMoverUpdateParameters
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IStorageMoverUpdateParameters

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IStorageMover

## NOTES

## RELATED LINKS
