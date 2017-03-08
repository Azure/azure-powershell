---
external help file: AzureRM.Bootstrapper-help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmModule
## SYNOPSIS
Returns the versions of an AzureRM module that support a given profile.

## SYNTAX

```
Get-AzureRmModule [-Profile] <String> [-Module] <String>
```

## DESCRIPTION
Returns the versions of an AzureRM module that support a given profile.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmModule -Profile 2017-03-09-profile -Module AzureRM.Storage

1.2.4
```

The version of the AzureRM.Storage module that supports profile 2017-03-09-profile is version 1.2.4.

## PARAMETERS

### -Module
The AzureRM module to retreive the version for.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: 
Accept pipeline input: False
Accept wildcard characters: False
```

### -Profile
The profile version to check for the given module.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: 2017-03-09-profile, <others>

Required: True
Position: 0
Default value: 
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

