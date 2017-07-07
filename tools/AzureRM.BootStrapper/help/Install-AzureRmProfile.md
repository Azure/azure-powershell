---
external help file: AzureRM.Bootstrapper-help.xml
online version: 
schema: 2.0.0
---

# Install-AzureRmProfile

## SYNOPSIS
Install all the latest modules associated with a particular AzureRM Profile on the machine.

## SYNTAX

```
Install-AzureRmProfile [-WhatIf] [-Confirm] [-Profile] <String> [-Scope <String>] [-Force] [<CommonParameters>]
```

## DESCRIPTION
Install all the latest modules associated with a particular AzureRM Profile on the machine.  Modules for a particular profile can be loaded in a new PowerShell session using 'Use-AzureRmProfile'.

## EXAMPLES

### Example 1
```
PS C:\> Install-AzureRmProfile -Profile '2017-03-09-profile'
```

Install all the modules associated with profile '2017-03-09-profile'

## PARAMETERS

### -Force
Automatically install modules for the given profile if they are not already installed.

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

### -Profile
The profile version to install.  You can get a list of available profile versions using *Get-AzureRmProfile -ListAvailable*

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: 2017-03-09-profile, <others>

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Scope
Specifies the installation scope of the modules. The acceptable values for this parameter are: AllUsers and CurrentUser.
The AllUsers scope lets modules be installed in a location that is accessible to all users of the computer.
The CurrentUser scope lets modules be installed in a location that is available only to the current user.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: CurrentUser, AllUsers

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### None

## NOTES

## RELATED LINKS

