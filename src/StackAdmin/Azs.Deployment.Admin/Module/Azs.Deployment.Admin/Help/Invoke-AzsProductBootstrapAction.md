---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Invoke-AzsProductBootstrapAction

## SYNOPSIS
Invokes 'bootstrap product' action.

## SYNTAX

```
Invoke-AzsProductBootstrapAction [-ProductId] <String> [-Version] <String> [<CommonParameters>]
```

## DESCRIPTION
Invokes 'bootstrap product' action.

## EXAMPLES

### EXAMPLE 1
```
Invoke-AzsProductBootstrapAction -ProductId $ProductId -Version $ProductVersion
```

Starts the bootstrap action for the specified product.

## PARAMETERS

### -ProductId
Product package Id to start the bootstrap action for.

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

### -Version
Product version

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
