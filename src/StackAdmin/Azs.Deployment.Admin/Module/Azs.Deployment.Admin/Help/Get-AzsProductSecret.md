---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Get-AzsProductSecret

## SYNOPSIS
Lists product secrets or gets a product secret properties.

## SYNTAX

```
Get-AzsProductSecret [-PackageId] <String> [[-SecretName] <String>] [-AsJson] [<CommonParameters>]
```

## DESCRIPTION
Lists product secrets or gets a product secret properties.

## EXAMPLES

### EXAMPLE 1
```
Get-AzsProductSecret -PackageId $PackageId -AsJson
```

Lists all external secrets from package with Id $PackageId.
Outputs in Json format.

### EXAMPLE 2
```
Get-AzsProductSecret -PackageId $PackageId -SecretName AdHoc
```

Gets the product secret called 'AdHoc'

## PARAMETERS

### -PackageId
Product package Id to get the product secret properties for.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretName
Name of the secret to be retrieved.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJson
Outputs the result in Json format.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
