---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# New-AzsProductPackage

## SYNOPSIS
Create a new product package.

## SYNTAX

```
New-AzsProductPackage [-PackageId] <String> [-FileContainerId] <String> [[-ApiVersion] <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create a new product package.

## EXAMPLES

### EXAMPLE 1
```
New-AzsProductPackage -PackageId $PackageId -FileContainerId $ContainerId
```

Creates a product package with the specified values.

## PARAMETERS

### -PackageId
ID of the product package to be created.

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

### -FileContainerId
File container resource identifier.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
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
