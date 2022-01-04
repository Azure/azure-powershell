---
external help file: Az.Tools.Installer-help.xml
Module Name: Az.Tools.Installer
online version:
schema: 2.0.0
---

# Uninstall-AzModule

## SYNOPSIS
Uninstall Azure PowerShell modules.

## SYNTAX

### Default (Default)
```
Uninstall-AzModule [-ExcludeModule <String[]>] [-PrereleaseOnly] [-RemoveAzureRm] [-Force] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByName
```
Uninstall-AzModule [-Name] <String[]> [-RemoveAzureRm] [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Uninstall Azure PowerShell modules.

## EXAMPLES

### EXAMPLE 1
```
Uninstall-AzModule storage, network
```

### EXAMPLE 2
```
Uninstall-AzModule -ExcludeModule storage, network
```

### EXAMPLE 3
```
Uninstall-AzModule -PrereleaseOnly
```

## PARAMETERS

### -Name
Az modules to uninstall.
Can be the names without Az.
prefix

```yaml
Type: String[]
Parameter Sets: ByName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExcludeModule
Az modules to exclude from uninstallation.

```yaml
Type: String[]
Parameter Sets: Default
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PrereleaseOnly
Specify to uninstall prerelease modules only.

```yaml
Type: SwitchParameter
Parameter Sets: Default
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoveAzureRm
Remove all Azure and AzureRm modules.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Installs modules and overrides the confirmation messages of each step.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
