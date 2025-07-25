---
external help file: Az.Sphere-help.xml
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/get-azsphereimage
schema: 2.0.0
---

# Get-AzSphereImage

## SYNOPSIS
Get a Image

## SYNTAX

### List (Default)
```
Get-AzSphereImage -CatalogName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-Maxpagesize <Int32>] [-Skip <Int32>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSphereImage -CatalogName <String> -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCatalog
```
Get-AzSphereImage -Name <String> -CatalogInputObject <ISphereIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSphereImage -InputObject <ISphereIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Image

## EXAMPLES

### Example 1: List images for specific catalog with specified resource group
```powershell
Get-AzSphereImage -CatalogName MyCatalog1 -ResourceGroupName ResourceGroup1
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDa 
                                                                                                                                                       taLastMo 
                                                                                                                                                       difiedBy 
                                                                                                                                                       Type     
----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ -------- 
11111111-2222-3333-4444-123456789104
11111111-2222-3333-4444-123456789105
```

This command lists images.

### Example 2: Get specific image with specified catalog and resource group
```powershell
Get-AzSphereImage -CatalogName anotherCatalog -Name 11111111-2222-3333-4444-123456789104 -ResourceGroupName Sphere-test
```

```output
ComponentId                  : 42257ad6-382d-405f-b7cc-e110fbda2d0b
Description                  : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/Sphere-test/providers/Microsoft.AzureSphere/catalogs/anotherCatalog/images/11111111-2222-3333-4444-123456789104
ImageId                      : 11111111-2222-3333-4444-123456789104
ImageName                    : 
ImageType                    : Applications
Name                         : 11111111-2222-3333-4444-123456789104
PropertiesImage              : AzureSphereBlink1
ProvisioningState            : Succeeded
RegionalDataBoundary         : None
ResourceGroupName            : Sphere-test
RetryAfter                   : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/images
Uri                          : ****************
```

This command get specific image.

## PARAMETERS

### -CatalogInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentityCatalog
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CatalogName
Name of catalog

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Filter
Filter the result list using the given expression

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Maxpagesize
The maximum number of result items per page.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Image name.
Use an image GUID for GA versions of the API.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCatalog
Aliases: ImageName

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The number of result items to return.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
The number of result items to skip.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.IImage

## NOTES

## RELATED LINKS
