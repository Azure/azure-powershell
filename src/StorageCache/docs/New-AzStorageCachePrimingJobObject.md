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

