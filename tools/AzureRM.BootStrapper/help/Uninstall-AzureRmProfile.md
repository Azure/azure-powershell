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
Uninstall-AzureRmProfile [-WhatIf] [-Confirm] [-Profile] <String> [-Force]
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

### -Confirm
Request confirmation for any change made by the cmdlet

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: 
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Automatically remove all given modules without propmpting.

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

### -Profile
The profile version to load in the current PowerShell session.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: 2016-09, 2017-03-09-profile, <others>

Required: True
Position: 0
Default value: 
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
Default value: 
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### None

## NOTES

## RELATED LINKS

