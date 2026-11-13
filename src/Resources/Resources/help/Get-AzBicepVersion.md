---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version:
schema: 2.0.0
---

# Get-AzBicepVersion

## SYNOPSIS
Gets the version of the Bicep CLI currently installed at Azure PowerShell's single managed Bicep installation location, matching `az bicep version` semantics.

## SYNTAX

```
Get-AzBicepVersion [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-AzBicepVersion` cmdlet returns the version of the Bicep CLI currently installed at Azure PowerShell's single, default managed installation location, along with the full path to its executable. If no version has been installed there via `Install-AzBicep`, this cmdlet returns nothing.

This cmdlet does not report on the separate, internal versioned cache that Azure PowerShell automatically manages to satisfy `bicep.version` constraints in `bicepconfig.json` files; that cache is not exposed or manageable through this cmdlet.

## EXAMPLES

### Example 1: Get the currently installed Bicep version
```powershell
PS C:\> Get-AzBicepVersion

Version Path
------- ----
0.30.23 C:\Users\contoso\.Azure\bin\bicep.exe
```

This command returns the version of Bicep currently installed at the default managed location, along with its executable path.

## PARAMETERS

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Bicep.PSBicepVersion

## NOTES

## RELATED LINKS
