---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version:
schema: 2.0.0
---

# Uninstall-AzBicep

## SYNOPSIS
Removes Azure PowerShell's entire managed Bicep installation.

## SYNTAX

```
Uninstall-AzBicep [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The `Uninstall-AzBicep` cmdlet removes the entire managed Bicep installation directory, deleting every Bicep CLI version Azure PowerShell has cached, whether installed automatically to satisfy a `bicep.version` constraint or explicitly via `Install-AzBicep`. Subsequent Bicep operations will automatically re-download and re-cache any Bicep version they need.

## EXAMPLES

### Example 1: Remove all cached Bicep versions
```powershell
PS C:\> Uninstall-AzBicep
```

This command removes Azure PowerShell's entire managed Bicep cache.

### Example 2: Remove all cached Bicep versions and confirm the result
```powershell
PS C:\> Uninstall-AzBicep -PassThru
True
```

This command removes the managed Bicep cache and, because `-PassThru` is specified, returns `$true` if anything was removed, or `$false` if there was no managed installation to remove.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Indicates that this cmdlet returns a boolean result.
By default, this cmdlet does not generate any output.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
