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

### Update (Default)
```
Update-AzGalleryImageVersion -GalleryImageDefinitionName <String> -GalleryName <String> -Name <String>
 -ResourceGroupName <String> -SubscriptionId <String> [-GalleryImageVersion <IGalleryImageVersion>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzGalleryImageVersion -GalleryImageDefinitionName <String> -GalleryName <String> -Name <String>
 -ResourceGroupName <String> -SubscriptionId <String> -Location <String> -ManagedImageId <String>
 [-EndOfLifeDate <DateTime>] [-ExcludeFromLatest] [-ReplicaCount <Int32>]
 [-StorageAccountType <StorageAccountType>] [-Tag <IResourceTags>] [-TargetRegion <ITargetRegion[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzGalleryImageVersion -InputObject <IComputeIdentity> -Location <String> -ManagedImageId <String>
 [-EndOfLifeDate <DateTime>] [-ExcludeFromLatest] [-ReplicaCount <Int32>]
 [-StorageAccountType <StorageAccountType>] [-Tag <IResourceTags>] [-TargetRegion <ITargetRegion[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzGalleryImageVersion -InputObject <IComputeIdentity> [-GalleryImageVersion <IGalleryImageVersion>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Default value: False
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases: PublishingProfileExcludeFromLatest

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GalleryImageDefinitionName
The name of the gallery Image Definition in which the Image Version is to be created.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GalleryImageVersion
Specifies information about the gallery Image Version that you want to create or update.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IGalleryImageVersion
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -GalleryName
The name of the Shared Image Gallery in which the Image Definition resides.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases: SourceImageId

Required: True
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
Format: <MajorVersion>.<MinorVersion>.<Patch>

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: GalleryImageVersionName

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20170330.IResourceTags
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.ITargetRegion[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IGalleryImageVersion

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IGalleryImageVersion

## ALIASES

## RELATED LINKS

