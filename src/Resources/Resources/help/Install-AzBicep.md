---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version:
schema: 2.0.0
---

# Install-AzBicep

## SYNOPSIS
Installs a specific, or the latest, version of the Bicep CLI into Azure PowerShell's single managed Bicep installation, matching `az bicep install` semantics.

## SYNTAX

```
Install-AzBicep [-Version <String>] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Install-AzBicep` cmdlet downloads a Bicep CLI release into Azure PowerShell's single, default managed installation location. If `-Version` is specified, that exact release is installed, overwriting whatever version (if any) was previously installed there; if that version is already installed, no download occurs. If `-Version` is omitted, the latest available release is installed, unless it is already installed. Only one version is kept in this location at a time.

This cmdlet does not affect the separate, internal versioned cache that Azure PowerShell automatically manages to satisfy `bicep.version` constraints in `bicepconfig.json` files; that cache is not exposed or manageable through this cmdlet.

## EXAMPLES

### Example 1: Install a specific Bicep version
```powershell
PS C:\> Install-AzBicep -Version 0.30.23
```

This command installs Bicep CLI version 0.30.23 into the default managed location. If that version is already installed there, no download occurs.

### Example 2: Install the latest Bicep version and return the result
```powershell
PS C:\> Install-AzBicep -PassThru

Version Path
------- ----
0.48.1  C:\Users\contoso\.Azure\bin\bicep.exe
```

This command installs the latest available Bicep release into the default managed location and, because `-PassThru` is specified, returns the installed version and its executable path.

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
Indicates that this cmdlet returns the installed version.
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

### -Version
The specific Bicep version to install (e.g.
'0.26.54').
If not specified, the latest available version is installed.
This replaces whatever version is currently installed at the default managed location.

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

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Bicep.PSBicepVersion

## NOTES

## RELATED LINKS
