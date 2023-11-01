---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/new-azstackhcivmimage
schema: 2.0.0
---

# New-AzStackHciVMImage

## SYNOPSIS


## SYNTAX

### MarketplaceURN (Default)
```
New-AzStackHciVMImage -Name <String> -ResourceGroupName <String> -CustomLocationId <String> -Location <String>
 -URN <String> [-SubscriptionId <String>] [-CloudInitDataSource <CloudInitDataSource>]
 [-OSType <OperatingSystemTypes>] [-StoragePathId <String>] [-StoragePathName <String>]
 [-StoragePathResourceGroup <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GalleryImage
```
New-AzStackHciVMImage -Name <String> -ResourceGroupName <String> -CustomLocationId <String>
 -ImagePath <String> -Location <String> [-SubscriptionId <String>]
 [-CloudInitDataSource <CloudInitDataSource>] [-OSType <OperatingSystemTypes>] [-StoragePathId <String>]
 [-StoragePathName <String>] [-StoragePathResourceGroup <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Marketplace
```
New-AzStackHciVMImage -Name <String> -ResourceGroupName <String> -CustomLocationId <String> -Location <String>
 -Offer <String> -Publisher <String> -Sku <String> -Version <String> [-SubscriptionId <String>]
 [-CloudInitDataSource <CloudInitDataSource>] [-OSType <OperatingSystemTypes>] [-StoragePathId <String>]
 [-StoragePathName <String>] [-StoragePathResourceGroup <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: Createa  Gallery Image 
```powershell
New-AzStackHciVMImage -Name "testImage" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}" -ImagePath "C:\ClusterStorage\Volume1\Ubunut.vhdx" -OSType "Linux" -Location "eastus" 

```

Name            ResourceGroupName
----            -----------------
testImage       test-rg
```
This command creates a gallery image from a local path.

### Example 2:  Create a Marketplace Gallery Image 
```powershell
New-AzStackHCIVMImage -Name "testMarketplaceImage" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}"  -Location "eastus" -Offer "windowsserver" -Publisher "MicrosoftWindowsServer" -Sku "2022-Datacenter" -Version "latest" -OSType "Windows"

```

Name            ResourceGroupName
----            -----------------
testMarketplaceImage       test-rg
```
This command creates a marketplace gallery image using the specified offer , publisher, sku and version.

### Example 3: {Create a  Marketplace Gallery Image From URN 
```powershell
New-AzStackHCIVMImage -Name "testMarketplaceImageURN" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}"  -Location "eastus" -URN  "microsoftwindowsserver:windowsserver:2022-datacenter:latest" -OSType "Windows"

```

Name            ResourceGroupName
----            -----------------
testMarketplaceImageURN       test-rg
```
This command creates a marketplace gallery image using the specified urn.

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

### -StoragePathId


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

### -StoragePathName


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

### -StoragePathResourceGroup


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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMarketplaceGalleryImages

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IGalleryImages

## NOTES

ALIASES

## RELATED LINKS

