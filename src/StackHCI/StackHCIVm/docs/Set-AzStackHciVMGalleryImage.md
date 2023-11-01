---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/set-azstackhcivmgalleryimage
schema: 2.0.0
---

# Set-AzStackHciVMGalleryImage

## SYNOPSIS
The operation to create or update a gallery image.
Please note some properties can be set only during gallery image creation.

## SYNTAX

```
Set-AzStackHciVMGalleryImage -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-CloudInitDataSource <CloudInitDataSource>] [-ContainerId <String>]
 [-ExtendedLocationName <String>] [-ExtendedLocationType <ExtendedLocationTypes>]
 [-HyperVGeneration <HyperVGeneration>] [-IdentifierOffer <String>] [-IdentifierPublisher <String>]
 [-IdentifierSku <String>] [-ImagePath <String>] [-OSType <OperatingSystemTypes>]
 [-SystemDataCreatedAt <DateTime>] [-SystemDataCreatedBy <String>] [-SystemDataCreatedByType <CreatedByType>]
 [-SystemDataLastModifiedAt <DateTime>] [-SystemDataLastModifiedBy <String>]
 [-SystemDataLastModifiedByType <CreatedByType>] [-Tag <Hashtable>] [-VersionName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a gallery image.
Please note some properties can be set only during gallery image creation.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloudInitDataSource
Datasource for the gallery image when provisioning with cloud-init [NoCloud, Azure]

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

### -ContainerId
Storage ContainerID of the storage container to be used for gallery image

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -ExtendedLocationName
The name of the extended location.

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

### -ExtendedLocationType
The type of the extended location.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HyperVGeneration
The hypervisor generation of the Virtual Machine [V1, V2]

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

### -IdentifierOffer
The name of the gallery image definition offer.

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

### -IdentifierPublisher
The name of the gallery image definition publisher.

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

### -IdentifierSku
The name of the gallery image definition SKU.

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

### -ImagePath
location of the image the gallery image should be created from

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

### -Location
The geo-location where the resource lives

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
Name of the gallery image

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: GalleryImageName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSType
Operating system type that the gallery image uses [Windows, Linux]

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

### -SystemDataCreatedAt
The timestamp of resource creation (UTC).

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataCreatedBy
The identity that created the resource.

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

### -SystemDataCreatedByType
The type of identity that created the resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataLastModifiedAt
The timestamp of resource last modification (UTC)

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataLastModifiedBy
The identity that last modified the resource.

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

### -SystemDataLastModifiedByType
The type of identity that last modified the resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

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

### -VersionName
This is the version of the gallery image.

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

## NOTES

ALIASES

## RELATED LINKS

