---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecurityawsenvironmentobject
schema: 2.0.0
---

# New-AzSecurityAwsEnvironmentObject

## SYNOPSIS
Create an in-memory object for AwsEnvironment.

## SYNTAX

```
New-AzSecurityAwsEnvironmentObject [-OrganizationalData <IAwsOrganizationalData>] [-Region <String[]>]
 [-ScanInterval <Int64>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AwsEnvironment.

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

### -OrganizationalData
The AWS account's organizational data.
To construct, see NOTES section for ORGANIZATIONALDATA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAwsOrganizationalData
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Region
list of regions to scan.

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

### -ScanInterval
Scan interval in hours (value should be between 1-hour to 24-hours).

```yaml
Type: System.Int64
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.AwsEnvironment

## NOTES

## RELATED LINKS

