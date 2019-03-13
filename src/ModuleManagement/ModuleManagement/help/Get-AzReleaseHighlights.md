---
external help file: Az.ModuleManagement-help.xml
Module Name: Az.ModuleManagement
online version: https://docs.microsoft.com/en-us/powershell/module/az.modulemanagement/get-azreleasehighlights
schema: 2.0.0
---

# Get-AzReleaseHighlights

## SYNOPSIS
Returns release highlights for the specified release.

## SYNTAX

### Latest
```
Get-AzReleaseHighlights [-Latest] [-Online] [<CommonParameters>]
```

### Version
```
Get-AzReleaseHighlights -Version <Version> [-Online] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet will output the highlights for a specific version of Az. These highlights contain all major change that were added between the given release and the last major version. By default, this cmdlet will return the highlights for the most recent version of Az installed on your machine.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzReleaseHighlights
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/
* Added interactive and username/password authentication for Windows PowerShell 5.1 only
```

Returns the highlights for the latest version of Az currently installed on the machine.

### Example 2
```powershell
PS C:\> Get-AzReleaseHighlights -Latest
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/
* Added interactive and username/password authentication for Windows PowerShell 5.1 only
* Added support for Python 2 runbooks in Az.Automation
* Az.LogicApp: New cmdlets for Integration Account Assemblies and Batch Configuration
```

Returns the highlights for the latest version of Az released to the gallery.

### Example 3
```powershell
PS C:\> Get-AzReleaseHighlights -Version 1.0.0
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/
```

Returns the highlights for the Az 1.0.0

## PARAMETERS

### -Latest
Get highlights for the latest version of Az released to the Gallery

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Latest
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Online
Opens the highlights in a browser window

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Get highlights for the specified version of Az

```yaml
Type: System.Version
Parameter Sets: Version
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
