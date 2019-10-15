---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Lock-AzsProductSubscription

## SYNOPSIS
Locks the product subscription.

## SYNTAX

```
Lock-AzsProductSubscription [-ProductId] <String> [<CommonParameters>]
```

## DESCRIPTION
Locks the product subscription.

## EXAMPLES

### EXAMPLE 1
```
Lock-AzsProductSubscription -ProductId $ProductId
```

Locks the product subscription for the product with ID $ProductId

## PARAMETERS

### -ProductId
Product package Id to lock the product subscription for.

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
