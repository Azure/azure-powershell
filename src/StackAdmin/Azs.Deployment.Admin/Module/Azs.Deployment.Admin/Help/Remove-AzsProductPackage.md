---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Remove-AzsProductPackage

## SYNOPSIS
Removes an existing product package.

## SYNTAX

```
Remove-AzsProductPackage [-PackageId] <String> [[-ApiVersion] <String>] [<CommonParameters>]
```

## DESCRIPTION
Removes an existing product package.

## EXAMPLES

### EXAMPLE 1
```
Remove-AzsProductPackage -PackageId $PackageId
```

Removes a product package with Id $PackageId.

## PARAMETERS

### -PackageId
ID of the product package to be removed.

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


### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
