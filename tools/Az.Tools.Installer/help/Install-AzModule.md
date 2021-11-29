---
external help file: Az.Tools.Installer-help.xml
Module Name: Az.Tools.Installer
online version:
schema: 2.0.0
---

# Install-AzModule

## SYNOPSIS
Install Azure PowerShell modules.

## SYNTAX

### Default (Default)
```
Install-AzModule [[-Name] <String[]>] [-RequiredAzVersion <String>] [-Repository <String>] [-AllowPrerelease]
 [-UseExactAccountVersion] [-Scope <String>] [-RemovePrevious] [-RemoveAzureRm] [-Force] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByPath
```
Install-AzModule -Path <String> [-Scope <String>] [-RemovePrevious] [-RemoveAzureRm] [-Force] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Install Azure PowerShell modules.

## EXAMPLES

### EXAMPLE 1
```
Install-AzModule -Repository PSGallery
```

### EXAMPLE 2
```
Install-AzModule Storage,Compute,Network -Repository PSGallery -AllowPrerelease
```

### EXAMPLE 3
```
Install-AzModule -Path https://my.repo.com/Az.Accounts.2.5.0.nupkg
```

## PARAMETERS

### -Name
Az modules to install.
Can be the names without Az.
prefix

```yaml
Type: String[]
Parameter Sets: Default
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RequiredAzVersion
Required Az Version.

```yaml
Type: String
Parameter Sets: Default
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Repository
The Registered Repostory.

```yaml
Type: String
Parameter Sets: Default
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowPrerelease
Allow preview modules to be installed.

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

### -UseExactAccountVersion
Use the exact Az.Accounts version that meet the mininum requirement from the Az modules to install.

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

### -Path
The url or local path of a nuget package to install the module from.

```yaml
Type: String
Parameter Sets: ByPath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Scope to install modules.
Accepted values: CurrentUser, AllUser.

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

### -RemovePrevious
Remove the module specified installed previously.

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

### System.Management.Automation.PSObject[]
## NOTES

## RELATED LINKS
