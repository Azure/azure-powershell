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
Install-AzureRmProfile [-Profile] <String> [-Scope <String>]
```

## DESCRIPTION
Install all the latest modules associated with a particular AzureRM Profile on the machine.  Modules for a particular profile can be loaded in a new PowerShell session using *Use-AzureRmProfile*.

## EXAMPLES

### Example 1
```
PS C:\> Install-AzureRmProfile -Profile '2016-05'
```

Install all the modules associated with profile '2016-05'

## PARAMETERS

### -Profile
The profile version to install.  You can get a list of available profile versions using *Get-AzureRmProfile -ListAvailable*

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

## INPUTS

### None


## OUTPUTS

### None

## NOTES

## RELATED LINKS

