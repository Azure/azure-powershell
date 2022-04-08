---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://docs.microsoft.com/powershell/module/az.stackhci/get-azstackhciremotesupportaccess
schema: 2.0.0
---

# Get-AzStackHCIRemoteSupportAccess

## SYNOPSIS
Gets Remote Support Access.

## SYNTAX

```
Get-AzStackHCIRemoteSupportAccess [-Cluster] [-IncludeExpired] [<CommonParameters>]
```

## DESCRIPTION
Gets remote support access.

## EXAMPLES

### EXAMPLE 1
```powershell
Get-AzStackHCIRemoteSupportAccess -Cluster
```

### EXAMPLE 2
```powershell
Get-AzStackHCIRemoteSupportAccess -Cluster -IncludeExpired
```

## PARAMETERS

### -Cluster
Indicates whether to show remote support sessions across cluster.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeExpired
Indicates whether to include past expired entries.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
