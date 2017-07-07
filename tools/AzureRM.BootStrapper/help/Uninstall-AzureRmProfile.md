---
external help file: AzureRM.Bootstrapper-help.xml
online version: 
schema: 2.0.0
---

# Uninstall-AzureRmProfile

## SYNOPSIS
Uninstall all modules associated with the given profile version.

## SYNTAX

```
Uninstall-AzureRmProfile [-WhatIf] [-Confirm] [-Profile] <String> [-Force] [<CommonParameters>]
```

## DESCRIPTION
Uninstall all modules associated with the given profile version.  Note that this may uninstall modules associated with multiple profiles.

## EXAMPLES

### Example 1
```
PS C:\> Uninstall-AzureRmProfile '2017-03-09-profile'
```

Uninstall all modules associated with the '2017-03-09-profile' profile on the machine

## PARAMETERS

### -Force
Automatically remove all given modules without propmpting.

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

### -Profile
The profile version to uninstall.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: 2016-09, 2017-03-09-profile, <others>

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Request confirmation for any change made by the cmdlet

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Print the changes that would be made in executing the cmdlets, but do not make any changes.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### None

## NOTES

## RELATED LINKS

