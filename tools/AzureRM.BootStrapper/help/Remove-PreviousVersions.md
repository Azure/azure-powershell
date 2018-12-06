---
external help file: AzureRM.Bootstrapper-help.xml
Module Name: AzureRM.BootStrapper
online version:
schema: 2.0.0
---

# Remove-PreviousVersions

## SYNOPSIS
If there are more than one version of modules in a profile that is installed,
the older versions can be uninstalled using this cmdlet.

## SYNTAX

```
Remove-PreviousVersions [-WhatIf] [-Confirm] -Profile <String> [-Force] [-Module <Array>] [<CommonParameters>]
```

## DESCRIPTION
If there are more than one version of modules in a profile that is installed,
the older versions can be uninstalled using this cmdlet.

## EXAMPLES

### Example 1
```
PS C:\> Remove-PreviousVersions -Profile '2017-03-09-profile'
```

Removes older versions of profile 2017-03-09-profile if they are installed.

### Example 2
```
PS C:\> Remove-PreviousVersions -Profile 'Latest' -Force -Module 'AzureRM.Compute', 'Azure.Storage'
```

Remove older versions of modules 'AzureRM.Compute', 'Azure.Storage' with profile version 'Latest'. 

## PARAMETERS

### -Force
Automatically install modules for the given profile if they are not already installed.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Module
The module name to be updated.

```yaml
Type: System.Array
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Profile
The profile version to load in the current PowerShell session.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Request confrimation for any change made by the cmdlet

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
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
