---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Get-AzsProductPackage

## SYNOPSIS
Lists product packages or gets a product package properties.

## SYNTAX

```
Get-AzsProductPackage [[-PackageId] <String>] [[-ApiVersion] <String>] [-AsJson] [<CommonParameters>]
```

## DESCRIPTION
Lists product packages or gets a product package properties.

## EXAMPLES

### EXAMPLE 1
```
Get-AzsProductPackage
```

Lists all the product packages in the subscription.

### EXAMPLE 2
```
Get-AzsProductPackage -PackageId $PackageId
```

Gets the product package properties of the product with Id.

## PARAMETERS

### -PackageId
Product package Id to get the properties for.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApiVersion
{{ Fill ApiVersion Description }}

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: 2019-01-01
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
