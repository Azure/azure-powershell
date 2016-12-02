---
external help file: AzureRM.Bootstrapper-help.xml
online version: 
schema: 2.0.0
---

# Update-AzureRmProfile
## SYNOPSIS
Update a profile to the latest versions in that profile and import updated modules to the current session. This should always be executed in a new PowerShell session.

## SYNTAX

```
Update-AzureRmProfile [-WhatIf] [-Confirm] [-Profile] <String> [-Force] [-Remove]
```

## DESCRIPTION
Update a profile to the latest versions in that profile and import updated modules to the current session. This should always be executed in a new PowerShell session.

## EXAMPLES

### Example 1
```
PS C:\> Update-AzureRmProfile -Profile '2016-09'
```

Update the modules associated with profile '2016-09' to their latest versions and load in the current session.  This should be executed after opening a new PowerShell session.

### Example 2
```
PS C:\> Update-AzureRmProfile -Profile 'Latest' -Remove -Force
```

Update the modules associated with profile version 'Latest' and load the modules in the current session. It downloads and installs the required modules and removes old versions of the modules without prompting the user. This should be executed after opening a new PowerShell session.

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

### -Remove
Automatically remove old versions of the modules currently installed.

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
Accepted values: 2016-09, 2016-05, Latest, <others>

Required: True
Position: 0
Default value: 
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
