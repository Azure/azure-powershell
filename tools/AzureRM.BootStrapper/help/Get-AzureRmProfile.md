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
Get-AzureRmProfile [-ListAvailable]
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
Default value: 
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

