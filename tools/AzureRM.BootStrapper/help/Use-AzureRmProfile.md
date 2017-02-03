---
external help file: AzureRM.Bootstrapper-help.xml
online version: 
schema: 2.0.0
---

# Use-AzureRmProfile
## SYNOPSIS
Load the modules associates with a particular profile in the current PowerShell session.  This should always be executed in a new PowerShell session.

## SYNTAX

```
Use-AzureRmProfile [-WhatIf] [-Confirm] [-Profile] <String> [-Force]
```

## DESCRIPTION
Load the modules associates with a particular profile in the current PowerShell session.  This should always be executed in a new PowerShell session.

## EXAMPLES

### Example 1
```
PS C:\> Use-AzureRmProfile '2016-09'
```

Load the modules associated with profile version '2016-09' int he current session.  This should be executed after opening a new PowerShell session.

## PARAMETERS

### -Confirm
Request confrimation for any change made by the cmdlet

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: 
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Automatically install modules for the given profile if they are not already installed.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 
Accept pipeline input: False
Accept wildcard characters: False
```

### -Profile
The profile version to load in the current PowerShell session.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: 2016-09, 2016-05, <others>

Required: True
Position: 0
Default value: 
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Specifies the installation scope of the modules. The acceptable values for this parameter are: AllUsers and CurrentUser.
The AllUsers scope lets modules be installed in a location that is accessible to all users of the computer, that is, %systemdrive%:\ProgramFiles\WindowsPowerShell\Modules.
The CurrentUser scope lets modules be installed only to $home\Documents\WindowsPowerShell\Modules, so that the module is available only to the current user.

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

### -WhatIf
Print the changes that would be made in executing the cmdlets, but do not make any changes.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: 
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None

## OUTPUTS

### None

## NOTES

## RELATED LINKS

