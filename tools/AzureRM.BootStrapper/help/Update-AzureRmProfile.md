---
external help file: AzureRM.Bootstrapper-help.xml
online version: 
schema: 2.0.0
---

# Update-AzureRmProfile

## SYNOPSIS
Update modules to the latest versions consitent with the given profile and import updated modules to the current session. This should always be executed in a new PowerShell session.

## SYNTAX

```
Update-AzureRmProfile [-WhatIf] [-Confirm] [-Profile] <String> [-Force] [-RemovePreviousVersions]
 [[-Module] <Array>] [-Scope <String>] [<CommonParameters>]
```

## DESCRIPTION
Update modules to the latest versions consitent with the given profile and import updated modules to the current session. This should always be executed in a new PowerShell session.

## EXAMPLES

### Example 1
```
PS C:\> Update-AzureRmProfile -Profile '2017-03-09-profile'
```

Update the modules associated with profile '2017-03-09-profile' to their latest versions and load in the current session.  This should be executed after opening a new PowerShell session.

### Example 2
```
PS C:\> Update-AzureRmProfile -Profile 'Latest' -RemovePreviousVersions -Force
```

Update the modules associated with profile version 'Latest' and load the modules in the current session. It downloads and installs the required modules and removes old versions of the modules without prompting the user. This should be executed after opening a new PowerShell session.

### Example 3
```
PS C:\> Update-AzureRmProfile -Profile 'Latest' -Module 'AzureRM', 'Azure.Storage' -Scope 'CurrentUser'
```

Update the modules 'AzureRM', 'Azure.Storage'  with profile version 'Latest' and load the modules in the current session. It downloads and installs the required modules in the CurrentUser scope. This should be executed after opening a new PowerShell session.

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
The module name to be updated.

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
Accepted values: 2017-03-09-profile, Latest, <others>

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RemovePreviousVersions
Automatically remove old versions of the modules currently installed.

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

