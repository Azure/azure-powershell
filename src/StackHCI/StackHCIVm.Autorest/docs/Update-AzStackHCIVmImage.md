---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhci/update-azstackhcivmimage
schema: 2.0.0
---

# Update-AzStackHCIVmImage

## SYNOPSIS
The operation to update an image.

## SYNTAX

### GalleryImage (Default)
```
Update-AzStackHCIVmImage [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByName
```
Update-AzStackHCIVmImage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByResourceId
```
Update-AzStackHCIVmImage -ResourceId <String> [-SubscriptionId <String>] [-Tag <Hashtable>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to update an image.
Please note some properties can be set only during image creation.

## EXAMPLES

### Example 1: Update an Image.
```powershell
PS C:\> Update-AzStackHCIVmImage  -Name "testImage" -ResourceGroupName "test-rg" -Tag @{TagName = TagValue }
```

```output
Name            ResourceGroupName
----            -----------------
testImage      test-rg
```

This command updates an exisiting image in the specified resource group.

## PARAMETERS

### -Name
Name of the gallery image

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

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
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The ARM Resource ID of the image.

```yaml
Type: System.String
Parameter Sets: ByResourceId
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
Parameter Sets: ByName, ByResourceId
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ByName, ByResourceId
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IGalleryImages

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IMarketplaceGalleryImages

## NOTES

ALIASES

## RELATED LINKS

