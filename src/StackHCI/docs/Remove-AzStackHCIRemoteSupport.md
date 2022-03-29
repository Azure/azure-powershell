---
external help file:
Module Name: Az.StackHCI
online version: https://docs.microsoft.com/powershell/module/az.stackhci/remove-azstackhciremotesupport
schema: 2.0.0
---

# Remove-AzStackHCIRemoteSupport

## SYNOPSIS
Removes Remote Support.

## SYNTAX

```
Remove-AzStackHCIRemoteSupport [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Remove-AzStackHCIRemoteSupport uninstalls Remote Support Deployment module.

## EXAMPLES

### Example 1: 
```powershell
Remove-AzStackHCIRemoteSupport
```

```output
Microsoft.AzureStack.Deployment.RemoteSupport is loaded already ...
Removing remote support components.
Disabling Remote Support.
Remote Support successfully Disabled.
Uninstalling remote support agent.
[SC] DeleteService SUCCESS
Unregistering and removing JEA configs.
```

Removes Remote Support

## PARAMETERS

### -Confirm
Prompts you for confirmation before running the cmdlet.

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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

## RELATED LINKS

