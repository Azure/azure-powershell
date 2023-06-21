---
external help file:
Module Name: Az.ImageBuilder
online version: https://learn.microsoft.com/powershell/module/az.ImageBuilder/new-azimagebuildertemplatesourceobject
schema: 2.0.0
---

# New-AzImageBuilderTemplateSourceObject

## SYNOPSIS
Create an in-memory object for ImageTemplateSource.

## SYNTAX

### PlatformImageSource (Default)
```
New-AzImageBuilderTemplateSourceObject -PlatformImageSource [-Offer <String>] [-PlanInfoPlanName <String>]
 [-PlanInfoPlanProduct <String>] [-PlanInfoPlanPublisher <String>] [-Publisher <String>] [-Sku <String>]
 [-Version <String>] [<CommonParameters>]
```

### ManagedImageSource
```
New-AzImageBuilderTemplateSourceObject -ImageId <String> -ManagedImageSource [<CommonParameters>]
```

### SharedImageVersionSource
```
New-AzImageBuilderTemplateSourceObject -ImageVersionId <String> -SharedImageVersionSource [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ImageTemplateSource.

## EXAMPLES

### Example 1: Create a managed image source
```powershell
$imageid = '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/images/test-linux-image'
New-AzImageBuilderTemplateSourceObject -ManagedImageSource -ImageId $imageid
```

```output
ImageId
-------
/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/images/test-linux-…
```

This command creates a managed image source.

### Example 2: Create a shared image source
```powershell
New-AzImageBuilderTemplateSourceObject -SharedImageVersionSource -ImageVersionId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/galleries/lucasimagegallery/images/myimagedefinition/versions/1.0.0 
```

```output
ImageVersionId
--------------
/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/gallerie…
```

This command creates a shared image source.

### Example 3: Create a platfrom image source
```powershell
New-AzImageBuilderTemplateSourceObject -PlatformImageSource -Publisher 'Canonical' -Offer 'UbuntuServer' -Sku '18.04-LTS' -Version 'latest'
```

```output
ExactVersion Offer        Publisher Sku       Version
------------ -----        --------- ---       -------
             UbuntuServer Canonical 18.04-LTS latest
```

This command creates a platfrom image source.

## PARAMETERS

### -ImageId
ARM resource id of the managed image in customer subscription.

```yaml
Type: System.String
Parameter Sets: ManagedImageSource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageVersionId
ARM resource id of the image version in the shared image gallery.

```yaml
Type: System.String
Parameter Sets: SharedImageVersionSource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedImageSource
Describes an image source that is a managed image in customer subscription.
This image must reside in the same subscription and region as the Image Builder template.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ManagedImageSource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Offer
Image offer from the [Azure Gallery Images](https://learn.microsoft.com/en-us/rest/api/compute/virtualmachineimages).

```yaml
Type: System.String
Parameter Sets: PlatformImageSource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanInfoPlanName
Name of the purchase plan.

```yaml
Type: System.String
Parameter Sets: PlatformImageSource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanInfoPlanProduct
Product of the purchase plan.

```yaml
Type: System.String
Parameter Sets: PlatformImageSource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanInfoPlanPublisher
Publisher of the purchase plan.

```yaml
Type: System.String
Parameter Sets: PlatformImageSource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlatformImageSource
Describes an image source from [Azure Gallery Images](https://learn.microsoft.com/en-us/rest/api/compute/virtualmachineimages).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PlatformImageSource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Publisher
Image Publisher in [Azure Gallery Images](https://learn.microsoft.com/en-us/rest/api/compute/virtualmachineimages).

```yaml
Type: System.String
Parameter Sets: PlatformImageSource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedImageVersionSource
Describes an image source that is an image version in a shared image gallery.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SharedImageVersionSource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
Image sku from the [Azure Gallery Images](https://learn.microsoft.com/en-us/rest/api/compute/virtualmachineimages).

```yaml
Type: System.String
Parameter Sets: PlatformImageSource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Image version from the [Azure Gallery Images](https://learn.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
If 'latest' is specified here, the version is evaluated when the image build takes place, not when the template is submitted.

```yaml
Type: System.String
Parameter Sets: PlatformImageSource
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.ImageTemplateManagedImageSource

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.ImageTemplatePlatformImageSource

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.ImageTemplateSharedImageVersionSource

## NOTES

ALIASES

## RELATED LINKS

