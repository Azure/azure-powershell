---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version:
schema: 2.0.0
---

# Get-AzBicepVersion

## SYNOPSIS
Lists the Bicep CLI versions currently cached by Azure PowerShell's managed Bicep installer.

## SYNTAX

```
Get-AzBicepVersion [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-AzBicepVersion` cmdlet lists the Bicep CLI versions that are currently cached in Azure PowerShell's managed, version-addressed installation directory. Each cached version was previously downloaded either automatically (for example, to satisfy a `bicep.version` constraint in a `bicepconfig.json` file) or explicitly via `Install-AzBicep`. For each cached version, this cmdlet returns the version number and the full path to its Bicep executable.

## EXAMPLES

### Example 1: List all cached Bicep versions
```powershell
PS C:\> Get-AzBicepVersion

Version Path
------- ----
0.29.47 C:\Users\contoso\.Azure\bin\bicep-0.29.47\bicep.exe
0.30.23 C:\Users\contoso\.Azure\bin\bicep-0.30.23\bicep.exe
```

This command lists every Bicep version currently cached by Azure PowerShell's managed installer, along with the executable path for each.

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
