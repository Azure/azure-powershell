---
external help file: Az.StorageMover-help.xml
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/update-azstoragemoverproject
schema: 2.0.0
---

# Update-AzStorageMoverProject

## SYNOPSIS
Updates properties for a Project resource.
Properties not specified in the request body will be unchanged.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageMoverProject -Name <String> -ResourceGroupName <String> -StorageMoverName <String>
 [-SubscriptionId <String>] [-Description <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzStorageMoverProject -Name <String> -ResourceGroupName <String> -StorageMoverName <String>
 [-SubscriptionId <String>] -Project <IProjectUpdateParameters> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageMoverProject -InputObject <IStorageMoverIdentity> [-Description <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzStorageMoverProject -InputObject <IStorageMoverIdentity> -Project <IProjectUpdateParameters>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates properties for a Project resource.
Properties not specified in the request body will be unchanged.

## EXAMPLES

### Example 1: Update a project
```powershell
Update-AzStorageMoverProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Name myProject -Description "Update Description"
```

```output
Description                  : Update description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject
Name                         : myProject
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 5:23:49 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 5:23:49 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/projects
```

This command updates the description of a project.

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
A description for the Project.

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
The name of the Project resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
Aliases: ProjectName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Project
The Project resource.
To construct, see NOTES section for PROJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IProjectUpdateParameters
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -StorageMoverName
The name of the Storage Mover resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IProjectUpdateParameters

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IProject

## NOTES

## RELATED LINKS
