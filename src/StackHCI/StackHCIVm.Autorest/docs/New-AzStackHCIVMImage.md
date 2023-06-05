---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/new-azstackhcivmimage
schema: 2.0.0
---

# New-AzStackHCIVMImage

## SYNOPSIS


## SYNTAX

### MarketplaceURN (Default)
```
New-AzStackHCIVMImage -Name <String> -ResourceGroupName <String> -CustomLocationId <String> -Location <String>
 -URN <String> [-SubscriptionId <String>] [-CloudInitDataSource <CloudInitDataSource>]
 [-ContainerName <String>] [-HyperVGeneration <HyperVGeneration>] [-OSType <OperatingSystemTypes>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GalleryImage
```
New-AzStackHCIVMImage -Name <String> -ResourceGroupName <String> -CustomLocationId <String>
 -ImagePath <String> -Location <String> [-SubscriptionId <String>]
 [-CloudInitDataSource <CloudInitDataSource>] [-ContainerName <String>] [-HyperVGeneration <HyperVGeneration>]
 [-OSType <OperatingSystemTypes>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Marketplace
```
New-AzStackHCIVMImage -Name <String> -ResourceGroupName <String> -CustomLocationId <String> -Location <String>
 -Offer <String> -Publisher <String> -Sku <String> -Version <String> [-SubscriptionId <String>]
 [-CloudInitDataSource <CloudInitDataSource>] [-ContainerName <String>] [-HyperVGeneration <HyperVGeneration>]
 [-OSType <OperatingSystemTypes>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -CloudInitDataSource


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CloudInitDataSource
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerName


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

### -CustomLocationId


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

### -HyperVGeneration


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePath


```yaml
Type: System.String
Parameter Sets: GalleryImage
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location


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

### -Name


```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ImageName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Offer


```yaml
Type: System.String
Parameter Sets: Marketplace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSType


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OperatingSystemTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Publisher


```yaml
Type: System.String
Parameter Sets: Marketplace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName


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

### -Sku


```yaml
Type: System.String
Parameter Sets: Marketplace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId


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


```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -URN


```yaml
Type: System.String
Parameter Sets: MarketplaceURN
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version


```yaml
Type: System.String
Parameter Sets: Marketplace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImages

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMarketplaceGalleryImages

## NOTES

ALIASES

## RELATED LINKS

