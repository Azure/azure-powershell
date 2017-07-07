---
external help file: AzureRM.Bootstrapper-help.xml
online version: 
schema: 2.0.0
---

# Use-AzureRmProfile

## SYNOPSIS
Load the modules associated with a particular profile in the current PowerShell session.  This should always be executed in a new PowerShell session.

## SYNTAX

```
Use-AzureRmProfile [-WhatIf] [-Confirm] [-Profile] <String> [-Force] [-Scope <String>] [[-Module] <Array>]
 [<CommonParameters>]
```

## DESCRIPTION
Load the modules associated with a particular profile in the current PowerShell session.  This should always be executed in a new PowerShell session.

## EXAMPLES

### Example 1
```
PS C:\> Use-AzureRmProfile -Profile '2017-03-09-profile'
```

Load the modules associated with profile version '2017-03-09-profile' in the current session.  This should be executed after opening a new PowerShell session.

### Example 2
```
PS C:\> Use-AzureRmProfile -Profile 'Latest' -Module 'AzureRM' -Scope 'CurrentUser' -Force
```

Load the module 'AzureRM' associated with profile version 'Latest' in the current session. It downloads and installs from online gallery in the 'CurrentUser' scope if not already installed. This should be executed after opening a new PowerShell session.

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

### -Module
The module name to be used.

```yaml
Type: Array
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Profile
The profile version to load in the current PowerShell session.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: 2017-03-09-profile, 2017-03-09-profile, <others>

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
Request confrimation for any change made by the cmdlet

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
Print the changes that would be made in executing the cmdlets, but do not make any changes.

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

