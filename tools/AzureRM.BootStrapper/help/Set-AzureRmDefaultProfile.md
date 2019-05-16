---
external help file: AzureRM.Bootstrapper-help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmDefaultProfile

## SYNOPSIS
Sets the given profile as a default profile to be used with all API version profile cmdlets.

## SYNTAX

```
Set-AzureRmDefaultProfile [-WhatIf] [-Confirm] [-Profile] <String> [-Force] [-Scope <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Sets the given profile as a default profile to be used with all API version profile cmdlets. Default profile selection is persisted across sessions and shells.

## EXAMPLES

### Example 1 - Using Default Version Profile to Automatically Load Module Versions
```
PS C:\> Set-AzureRmDefaultProfile -Profile '2017-03-09-profile'
PS C:\> Import-Module AzureRM.Compute
```

Sets profile '2017-03-09-profile' as the default profile. 
When importing AzureRM modules like AzureRM.Compute, you will automatically import a version of the module compatible with the default profile setting, 
unless you explicitly specify a RequiredVersion.

### Example 2 - Using Default Version Profile to Set Default Profile for BootStrapper cmdlets
```
PS C:\> Set-AzureRmDefaultProfile -Profile '2017-03-09-profile'
PS c:\> Install-AzureRmProfile
```

Sets the default profile as '2017-03-09-profile'.  After this, BootStrapper cmdlets will automatically use the default profile if no profile is set.
In this case, 'Install-AzureRmProfile'  will install profile '2017-03-09-profile', since this profile was set as the default.

## PARAMETERS

### -Force
Set the given profile as default without prompting for confirmation.

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
The profile version to set as default.  You can get a list of available profile versions using *Get-AzureRmProfile -ListAvailable*

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: 2017-03-09-profile, latest, <others>

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

