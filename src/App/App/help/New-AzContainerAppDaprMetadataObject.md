---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerappdaprmetadataobject
schema: 2.0.0
---

# New-AzContainerAppDaprMetadataObject

## SYNOPSIS
Create an in-memory object for DaprMetadata.

## SYNTAX

```
New-AzContainerAppDaprMetadataObject [-Name <String>] [-SecretRef <String>] [-Value <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DaprMetadata.

## EXAMPLES

### Example 1: Create a DaprMetaData object for ManagedEnvDaprMetadata.
```powershell
New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"
```

```output
Name      SecretRef Value
----      --------- -----
masterkey           masterkey
```

Create a DaprMetaData object for ManagedEnvDaprMetadata.

## PARAMETERS

### -Name
Metadata property name.

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

### -SecretRef
Name of the Dapr Component secret from which to pull the metadata property value.

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

### -Value
Metadata property value.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.DaprMetadata

## NOTES

ALIASES

## RELATED LINKS

