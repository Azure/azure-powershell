---
external help file:
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/new-azstoragemover
schema: 2.0.0
---

# New-AzStorageMover

## SYNOPSIS
Creates or updates a top-level Storage Mover resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageMover -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-Description <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzStorageMover -Name <String> -ResourceGroupName <String> -StorageMover <IStorageMover>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a top-level Storage Mover resource.

## EXAMPLES

### Example 1: Create a Storage mover
```powershell
New-AzStorageMover -ResourceGroupName myResourceGroup -Name myStorageMover -Location eastus -Description "Description"
```

```output
Description                  :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storage
                               Movers/myStorageMover
Location                     : eastus
Name                         : myStorageMover
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 7/26/2022 5:49:02 AM
SystemDataCreatedBy          : xxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/26/2022 5:49:02 AM
SystemDataLastModifiedBy     : xxxxxxxxxx
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.storagemover/storagemovers
```

This command creates a Storage mover for a resource group.

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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Storage Mover resource.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageMover
The Storage Mover resource, which is a container for a group of Agents, Projects, and Endpoints.
To construct, see NOTES section for STORAGEMOVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IStorageMover
Parameter Sets: Create
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IStorageMover

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IStorageMover

## NOTES

## RELATED LINKS

