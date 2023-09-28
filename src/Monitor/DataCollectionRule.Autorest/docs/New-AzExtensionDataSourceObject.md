---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azextensiondatasourceobject
schema: 2.0.0
---

# New-AzExtensionDataSourceObject

## SYNOPSIS
Create an in-memory object for ExtensionDataSource.

## SYNTAX

```
New-AzExtensionDataSourceObject -ExtensionName <String> [-ExtensionSetting <IAny>]
 [-InputDataSource <String[]>] [-Name <String>] [-Stream <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ExtensionDataSource.

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

### -ExtensionName
The name of the VM extension.

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

### -ExtensionSetting
The extension settings.
The format is specific for particular extension.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IAny
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputDataSource
The list of data sources this extension needs data from.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
A friendly name for the data source.
        This name should be unique across all data sources (regardless of type) within the data collection rule.

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

### -Stream
List of streams that this data source will be sent to.
        A stream indicates what schema will be used for this data and usually what table in Log Analytics the data will be sent to.

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.ExtensionDataSource

## NOTES

## RELATED LINKS

