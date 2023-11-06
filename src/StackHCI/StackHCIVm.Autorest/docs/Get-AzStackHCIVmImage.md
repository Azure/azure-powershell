---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhci/get-azstackhcivmimage
schema: 2.0.0
---

# Get-AzStackHCIVmImage

## SYNOPSIS
Gets a gallery image

## SYNTAX

### BySubscription (Default)
```
Get-AzStackHCIVmImage [-SubscriptionId <String[]>] [<CommonParameters>]
```

### ByName
```
Get-AzStackHCIVmImage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [<CommonParameters>]
```

### ByResourceGroup
```
Get-AzStackHCIVmImage -ResourceGroupName <String> [-SubscriptionId <String[]>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzStackHCIVmImage -ResourceId <String> [-SubscriptionId <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Gets a gallery image

## EXAMPLES

### Example 1:  Get an Image 
```powershell
PS C:\> Get-AzStackHCIVmImage -Name "testimage" -ResourceGroupName "test-rg" 
```

```output
Name            ResourceGroupName
----            -----------------
testImage       test-rg
```

This command gets a specific image in the specified resource group.

### Example 2: List all Images in a Resource Group  
```powershell
PS C:\> Get-AzStackHCIVmImage -ResourceGroupName 'test-rg'
```

```output
Name            ResourceGroupName
----            -----------------
testImage       test-rg
```
This command lists all images in the specified resource group.

## PARAMETERS

### -Name
Name of the image

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
Parameter Sets: ByName, ByResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The ARM Resource Id of the Image

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
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IGalleryImages
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IMarketplaceGalleryImages

## NOTES

ALIASES

## RELATED LINKS

