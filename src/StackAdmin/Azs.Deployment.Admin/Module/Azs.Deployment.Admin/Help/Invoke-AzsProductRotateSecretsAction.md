---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Invoke-AzsProductRotateSecretsAction

## SYNOPSIS
Invokes 'rotate secrets' action.

## SYNTAX

```
Invoke-AzsProductRotateSecretsAction [-ProductId] <String> [<CommonParameters>]
```

## DESCRIPTION
Invokes 'rotate secrets' action.

## EXAMPLES

### EXAMPLE 1
```
Invoke-AzsProductRotateSecretsAction -ProductId $ProductId
```

Starts the product rotate secrets action for the specified product.

## PARAMETERS

### -ProductId
Product package Id to start the product rotate secrets action for.

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
