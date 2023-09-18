---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/Az.SpringApps/new-azspringbuildpacksgrouppropertiesobject
schema: 2.0.0
---

# New-AzSpringBuildpacksGroupPropertiesObject

## SYNOPSIS
Create an in-memory object for BuildpacksGroupProperties.

## SYNTAX

```
New-AzSpringBuildpacksGroupPropertiesObject [-Buildpack <IBuildpackProperties[]>] [-Name <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BuildpacksGroupProperties.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Buildpack
Buildpacks in the buildpack group.
To construct, see NOTES section for BUILDPACK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IBuildpackProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Buildpack group name.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.BuildpacksGroupProperties

## NOTES

## RELATED LINKS

