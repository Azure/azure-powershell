---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/update-azgalleryimageversion
schema: 2.0.0
---

# Update-AzGalleryImageVersion

## SYNOPSIS
Create or update a gallery Image Version.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzGalleryImageVersion -GalleryImageDefinitionName <String> -GalleryName <String> -Name <String>
 -ResourceGroupName <String> -SubscriptionId <String> -Location <String> [-EndOfLifeDate <DateTime>]
 [-ExcludeFromLatest] [-ManagedImageId <String>] [-ReplicaCount <Int32>]
 [-StorageAccountType <StorageAccountType>] [-Tag <Hashtable>] [-TargetRegion <ITargetRegion[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzGalleryImageVersion -InputObject <IComputeIdentity> -Location <String> [-EndOfLifeDate <DateTime>]
 [-ExcludeFromLatest] [-ManagedImageId <String>] [-ReplicaCount <Int32>]
 [-StorageAccountType <StorageAccountType>] [-Tag <Hashtable>] [-TargetRegion <ITargetRegion[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a gallery Image Version.

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
Dynamic: False
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
Dynamic: False
```

### -EndOfLifeDate
The end of life date of the gallery Image Version.
This property can be used for decommissioning purposes.
This property is updatable.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases: PublishingProfileEndOfLifeDate

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ExcludeFromLatest
If set to true, Virtual Machines deployed from the latest version of the Image Definition won't use this Image Version.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: PublishingProfileExcludeFromLatest

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GalleryImageDefinitionName
The name of the gallery Image Definition in which the Image Version is to be created.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GalleryName
The name of the Shared Image Gallery in which the Image Definition resides.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ManagedImageId
The managed artifact id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SourceImageId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the gallery Image Version to be created.
Needs to follow semantic version name pattern: The allowed characters are digit and period.
Digits must be within the range of a 32-bit integer.
Format: \<MajorVersion\>.\<MinorVersion\>.\<Patch\>

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: GalleryImageVersionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -ReplicaCount
The number of replicas of the Image Version to be created per region.
This property would take effect for a region when regionalReplicaCount is not specified.
This property is updatable.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StorageAccountType
Specifies the storage account type to be used to store the image.
This property is not updatable.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetRegion
The target regions where the Image Version is going to be replicated to.
This property is updatable.
To construct, see NOTES section for TARGETREGION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.ITargetRegion[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IGalleryImageVersion

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IComputeIdentity>: Identity Parameter
  - `[AvailabilitySetName <String>]`: The name of the availability set.
  - `[CommandId <String>]`: The command id.
  - `[DiskName <String>]`: The name of the managed disk that is being created. The name can't be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters.
  - `[GalleryApplicationName <String>]`: The name of the gallery Application Definition to be created or updated. The allowed characters are alphabets and numbers with dots, dashes, and periods allowed in the middle. The maximum length is 80 characters.
  - `[GalleryApplicationVersionName <String>]`: The name of the gallery Application Version to be created. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: <MajorVersion>.<MinorVersion>.<Patch>
  - `[GalleryImageDefinitionName <String>]`: The name of the gallery Image Definition to be created or updated. The allowed characters are alphabets and numbers with dots, dashes, and periods allowed in the middle. The maximum length is 80 characters.
  - `[GalleryImageVersionName <String>]`: The name of the gallery Image Version to be created. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: <MajorVersion>.<MinorVersion>.<Patch>
  - `[GalleryName <String>]`: The name of the Shared Image Gallery. The allowed characters are alphabets and numbers with dots and periods allowed in the middle. The maximum length is 80 characters.
  - `[Id <String>]`: Resource identity path
  - `[ImageName <String>]`: The name of the image.
  - `[InstanceId <String>]`: The instance ID of the virtual machine.
  - `[Location <String>]`: The name of a supported Azure region.
  - `[Offer <String>]`: A valid image publisher offer.
  - `[ProximityPlacementGroupName <String>]`: The name of the proximity placement group.
  - `[PublisherName <String>]`: 
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[Sku <String>]`: A valid image SKU.
  - `[SnapshotName <String>]`: The name of the snapshot that is being created. The name can't be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[Type <String>]`: 
  - `[VMExtensionName <String>]`: The name of the virtual machine extension.
  - `[VMName <String>]`: The name of the virtual machine.
  - `[VMScaleSetName <String>]`: The name of the VM scale set.
  - `[Version <String>]`: 
  - `[VirtualMachineScaleSetName <String>]`: The name of the VM scale set.
  - `[VmssExtensionName <String>]`: The name of the VM scale set extension.

#### TARGETREGION <ITargetRegion[]>: The target regions where the Image Version is going to be replicated to. This property is updatable.
  - `Name <String>`: The name of the region.
  - `[RegionalReplicaCount <Int32?>]`: The number of replicas of the Image Version to be created per region. This property is updatable.
  - `[StorageAccountType <StorageAccountType?>]`: Specifies the storage account type to be used to store the image. This property is not updatable.

## RELATED LINKS

