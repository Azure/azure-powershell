---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version:
schema: 2.0.0
---

# Uninstall-AzBicep

## SYNOPSIS
Removes the Bicep installation at Azure PowerShell's single managed Bicep installation location, matching `az bicep uninstall` semantics.

## SYNTAX

```
Uninstall-AzBicep [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The `Uninstall-AzBicep` cmdlet removes the Bicep CLI installed at Azure PowerShell's single, default managed installation location, if one is present. Subsequent operations that rely on this location (for example, `Install-AzBicep` or `Get-AzBicepVersion`) will no longer find a version installed there until `Install-AzBicep` is run again.

This cmdlet does not affect the separate, internal versioned cache that Azure PowerShell automatically manages to satisfy `bicep.version` constraints in `bicepconfig.json` files; that cache is not exposed or manageable through this cmdlet, and compiling pinned Bicep files will continue to work unaffected.

## EXAMPLES

### Example 1: Remove the installed Bicep version
```powershell
PS C:\> Uninstall-AzBicep
```

This command removes the Bicep installation at Azure PowerShell's default managed location.

### Example 2: Remove the installed Bicep version and confirm the result
```powershell
PS C:\> Uninstall-AzBicep -PassThru
True
```

This command removes the Bicep installation at the default managed location and, because `-PassThru` is specified, returns `$true` if a version was removed, or `$false` if there was no installation to remove.

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
