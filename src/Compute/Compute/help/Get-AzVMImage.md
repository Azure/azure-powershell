---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
ms.assetid: D5254218-8B3B-4DE2-9480-D65EE5483018
online version: https://learn.microsoft.com/powershell/module/az.compute/get-azvmimage
schema: 2.0.0
---

# Get-AzVMImage

## SYNOPSIS
Gets all the versions of a VMImage.

## SYNTAX

### ListVMImage
```
Get-AzVMImage -Location <String> [-EdgeZone <String>] -PublisherName <String> -Offer <String> -Skus <String>
 [-Top <Int32>] [-OrderBy <String>] [-Expand <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetVMImageDetail
```
Get-AzVMImage -Location <String> [-EdgeZone <String>] -PublisherName <String> -Offer <String> -Skus <String>
 -Version <String> [-Expand <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzVMImage** cmdlet gets all the versions of a VMImage.

## EXAMPLES

### Example 1: List VM Image objects
```powershell
Get-AzVMImage -Location "Central US" -PublisherName "MicrosoftWindowsServer" -Offer "windowsserver" -Skus "2025-datacenter"
```

```output
Version           Location  PublisherName          HyperVGeneration Architecture ImageDeprecationStatus
-------           --------  -------------          ---------------- ------------ ----------------------
26100.2033.241004 centralus MicrosoftWindowsServer
26100.2314.241107 centralus MicrosoftWindowsServer
26100.2605.241207 centralus MicrosoftWindowsServer
26100.2894.250113 centralus MicrosoftWindowsServer
26100.3194.250210 centralus MicrosoftWindowsServer
26100.3476.250306 centralus MicrosoftWindowsServer
26100.3775.250406 centralus MicrosoftWindowsServer
```

This command gets all the versions of VMImage that match the specified values.

### Example 2: List VM Image objects with Image Deprecation Status
```powershell
Get-AzVMImage -Location "Central US" -PublisherName "MicrosoftWindowsServer" -Offer "windowsserver" -Skus "2025-datacenter" -Expand properties/imageDeprecationStatus
```

```output
Version           Location  PublisherName          HyperVGeneration Architecture ImageDeprecationStatus
-------           --------  -------------          ---------------- ------------ ----------------------
26100.2033.241004 centralus MicrosoftWindowsServer V1               x64          Microsoft.Azure.Management.Compute.Mo…
26100.2314.241107 centralus MicrosoftWindowsServer V1               x64          Microsoft.Azure.Management.Compute.Mo…
26100.2605.241207 centralus MicrosoftWindowsServer V1               x64          Microsoft.Azure.Management.Compute.Mo…
26100.2894.250113 centralus MicrosoftWindowsServer V1               x64          Microsoft.Azure.Management.Compute.Mo…
26100.3194.250210 centralus MicrosoftWindowsServer V1               x64          Microsoft.Azure.Management.Compute.Mo…
26100.3476.250306 centralus MicrosoftWindowsServer V1               x64          Microsoft.Azure.Management.Compute.Mo…
26100.3775.250406 centralus MicrosoftWindowsServer V1               x64          Microsoft.Azure.Management.Compute.Mo…
```

This command gets all the versions of VMImage that match the specified values with image deprecation statuses.

### Example 3: Get VMImage object
```powershell
Get-AzVMImage -Location "Central US" -PublisherName "MicrosoftWindowsServer" -Offer "windowsserver" -Skus "2025-datacenter" -Version 26100.2033.241004
```

```output
Id                     : /Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/Providers/Microsoft.Compute/Locations/cent
                         ralus/Publishers/MicrosoftWindowsServer/ArtifactTypes/VMImage/Offers/windowsserver/Skus/2025-d
                         atacenter/Versions/26100.2033.241004
Location               : centralus
PublisherName          : MicrosoftWindowsServer
Offer                  : windowsserver
Skus                   : 2025-datacenter
Version                : 26100.2033.241004
FilterExpression       :
Name                   : 26100.2033.241004
HyperVGeneration       : V1
OSDiskImage            : {
                           "operatingSystem": "Windows"
                         }
PurchasePlan           : null
DataDiskImages         : []
ImageDeprecationStatus : {
                           "imageState": "Active",
                           "scheduledDeprecationTime": null,
                           "alternativeOption": null
                         }
```

This command gets a specific version of VMImage that matches the specified values.

### Example 4: Get VMImage objects
```powershell
Get-AzVMImage -Location "Central US" -PublisherName "MicrosoftWindowsServer" -Offer "windowsserver" -Skus "2025-datacenter" -Version 26100.2* -Expand properties
```

```output
Version           Location  PublisherName          HyperVGeneration Architecture ImageDeprecationStatus
-------           --------  -------------          ---------------- ------------ ----------------------
26100.2033.241004 centralus MicrosoftWindowsServer V1               x64
26100.2314.241107 centralus MicrosoftWindowsServer V1               x64
26100.2605.241207 centralus MicrosoftWindowsServer V1               x64
26100.2894.250113 centralus MicrosoftWindowsServer V1               x64
```

This command gets all the versions of VMImage that match the specified values with filtering over version.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EdgeZone
Set the extended location name for EdgeZone. If not set, VM Image will be queried from Azure main region. Otherwise it will be queried from the specified extended location

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Expand
The expand expression to apply on the operation. Possible values are: 'properties', and 'properties/imageDeprecationStatus'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Specifies the location of a VMImage.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Offer
Specifies the type of VMImage offer.
To obtain an image offer, use the Get-AzVMImageOffer cmdlet.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OrderBy
Specifies the order of the results returned. Formatted as an OData query.

```yaml
Type: System.String
Parameter Sets: ListVMImage
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PublisherName
Specifies the publisher of a VMImage.
To obtain an image publisher, use the Get-AzVMImagePublisher cmdlet.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Skus
Specifies a VMImage SKU.
To obtain an SKU, use the Get-AzVMImageSku cmdlet.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Top
Specifies the maximum number of virtual machine images returned. 

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ListVMImage
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
Specifies the version of the VMImage.

```yaml
Type: System.String
Parameter Sets: GetVMImageDetail
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachineImage

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachineImageDetail

## NOTES

## RELATED LINKS

[Get-AzVMImageOffer](./Get-AzVMImageOffer.md)

[Get-AzVMImagePublisher](./Get-AzVMImagePublisher.md)

[Get-AzVMImageSku](./Get-AzVMImageSku.md)

[Save-AzVMImage](./Save-AzVMImage.md)
