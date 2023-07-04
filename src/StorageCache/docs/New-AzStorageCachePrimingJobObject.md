---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/Az.StorageCache/new-AzStorageCachePrimingJobObject
schema: 2.0.0
---

# New-AzStorageCachePrimingJobObject

## SYNOPSIS
Create an in-memory object for PrimingJob.

## SYNTAX

```
New-AzStorageCachePrimingJobObject -Name <String> -PrimingManifestUrl <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PrimingJob.

## EXAMPLES

### Example 1: Create an in-memory object for PrimingJob.
```powershell
New-AzStorageCachePrimingJobObject -Name azps-primingjob -PrimingManifestUrl "https://contosostorage.blob.core.windows.net/contosoblob/00000000_00000000000000000000000000000000.00000000000.FFFFFFFF.00000000?sp=r&st=2021-08-11T19:33:35Z&se=2021-08-12T03:33:35Z&spr=https&sv=2020-08-04&sr=b&sig=<secret-value-from-key>"
```

```output
Detail Name            PercentComplete PrimingManifestUrl
------ ----            --------------- ------------------
       azps-primingjob                 https://contosostorage.blo...
```

Create an in-memory object for PrimingJob.

## PARAMETERS

### -Name
The priming job name.

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

### -PrimingManifestUrl
The URL for the priming manifest file to download.
This file must be readable from the HPC Cache.
When the file is in Azure blob storage the URL should include a Shared Access Signature (SAS) granting read permissions on the blob.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.PrimingJob

## NOTES

ALIASES

## RELATED LINKS

