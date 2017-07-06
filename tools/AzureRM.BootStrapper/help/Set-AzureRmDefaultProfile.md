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
Set-AzureRmDefaultProfile [-Profile] <String> [-Scope <String>] [-Force]
```

## DESCRIPTION
Sets the given profile as a default profile to be used with all API version profile cmdlets. Default profile selection is persisted across sessions and shells.

## EXAMPLES

### Example 1
```
PS C:\> Set-AzureRmDefaultProfile -Profile '2017-03-09-profile'
```

Set profile '2017-03-09-profile' as a default profile. After setting, any API Version profile cmdlet can be executed without providing a profile parameter as follows:
```
Install-AzureRmProfile
```
This will install profile '2017-03-09-profile'.  Additionally, when importing AzureRM modules, you will import the version of the module associated with the default profile setting, unless you explicitly specify a RequiredVersion.

```
Import-Module AzureRM.Compute
```
Imports a version of the Compute module compatible with the ```2017-03-09-profile``` profile.


## PARAMETERS

### -Profile
The profile version to set as default.  You can get a list of available profile versions using *Get-AzureRmProfile -ListAvailable*

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: 2017-03-09-profile, latest, <others>

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
Set the given profile as default without prompting for confirmation.

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

