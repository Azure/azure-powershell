---
external help file: AzureRM.Bootstrapper-help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmProfile

## SYNOPSIS
List the supported AzureRM profiles.

## SYNTAX

```
Get-AzureRmProfile [-ListAvailable] [-Update] [<CommonParameters>]
```

## DESCRIPTION
Lists the supported AzureRM profiles.  If no parameters are given, returns the profile version supported by modules on the current machine.  If *-ListAvailable* is specified, lists all profiles that could be installed on the machine.

## EXAMPLES

### Example 2
```
PS C:\> Get-AzureRmProfile -ListAvailable

2015-06
2015-09
```

List all ARM profiles available to be installed.

## PARAMETERS

### -ListAvailable
If specified, list all available profiles, not just the profiles currently installed.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Update
If specified, updates Profiles available by querying Azure Endpoint

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

