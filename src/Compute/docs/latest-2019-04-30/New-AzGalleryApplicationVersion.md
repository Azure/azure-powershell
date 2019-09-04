---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/new-azgalleryapplicationversion
schema: 2.0.0
---

# New-AzGalleryApplicationVersion

## SYNOPSIS
Create or update a gallery Application Version.

## SYNTAX

```
New-AzGalleryApplicationVersion -GalleryApplicationName <String> -GalleryName <String> -Name <String>
 -ResourceGroupName <String> -SubscriptionId <String> -Location <String>
 [-PublishingProfileContentType <String>] [-PublishingProfileEnableHealthCheck]
 [-PublishingProfileEndOfLifeDate <DateTime>] [-PublishingProfileExcludeFromLatest]
 [-PublishingProfileReplicaCount <Int32>] [-PublishingProfileStorageAccountType <StorageAccountType>]
 [-PublishingProfileTargetRegion <ITargetRegion[]>] [-SourceFileName <String>] [-SourceMediaLink <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a gallery Application Version.

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

### -GalleryApplicationName
The name of the gallery Application Definition in which the Application Version is to be created.

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

### -GalleryName
The name of the Shared Application Gallery in which the Application Definition resides.

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

### -Name
The name of the gallery Application Version to be created.
Needs to follow semantic version name pattern: The allowed characters are digit and period.
Digits must be within the range of a 32-bit integer.
Format: \<MajorVersion\>.\<MinorVersion\>.\<Patch\>

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: GalleryApplicationVersionName

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

### -PublishingProfileContentType
Optional.
May be used to help process this file.
The type of file contained in the source, e.g.
zip, json, etc.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PublishingProfileEnableHealthCheck
Optional.
Whether or not this application reports health.

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

### -PublishingProfileEndOfLifeDate
The end of life date of the gallery Image Version.
This property can be used for decommissioning purposes.
This property is updatable.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PublishingProfileExcludeFromLatest
If set to true, Virtual Machines deployed from the latest version of the Image Definition won't use this Image Version.

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

### -PublishingProfileReplicaCount
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

### -PublishingProfileStorageAccountType
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

### -PublishingProfileTargetRegion
The target regions where the Image Version is going to be replicated to.
This property is updatable.
To construct, see NOTES section for PUBLISHINGPROFILETARGETREGION properties and create a hash table.

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

### -ResourceGroupName
The name of the resource group.

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

### -SourceFileName
Required.
The fileName of the artifact.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SourceMediaLink
Required.
The mediaLink of the artifact, must be a readable storage blob.

```yaml
Type: System.String
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IGalleryApplicationVersion

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### PUBLISHINGPROFILETARGETREGION <ITargetRegion[]>: The target regions where the Image Version is going to be replicated to. This property is updatable.
  - `Name <String>`: The name of the region.
  - `[RegionalReplicaCount <Int32?>]`: The number of replicas of the Image Version to be created per region. This property is updatable.
  - `[StorageAccountType <StorageAccountType?>]`: Specifies the storage account type to be used to store the image. This property is not updatable.

## RELATED LINKS

