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
Install-AzureRmProfile [-Profile] <String>
```

## DESCRIPTION
Install all the latest modules associated with a particular AzureRM Profile on the machine.  Modules for a particular profile can be loaded in a new PowerShell session using *Load-AzureRmProfile*.

## EXAMPLES

### Example 1
```
PS C:\> Install-AzureRmProfile -Profile '2016-05'
```

Install all the modules associated with profile '2016-05'

## PARAMETERS

### -Profile
The profile version top install.  You can get a list of available profile versions using *Get-AzureRmProfile -ListAvailable*

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

## INPUTS

### None


## OUTPUTS

### None

## NOTES

## RELATED LINKS

