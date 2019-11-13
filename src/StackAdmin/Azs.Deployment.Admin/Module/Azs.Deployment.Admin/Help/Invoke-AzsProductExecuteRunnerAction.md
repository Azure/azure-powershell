---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Invoke-AzsProductExecuteRunnerAction

## SYNOPSIS
Invokes 'execute runner' action.

## SYNTAX

```
Invoke-AzsProductExecuteRunnerAction [-ProductId] <String> [-Parameters] <PSObject> [<CommonParameters>]
```

## DESCRIPTION
Invokes 'execute runner' action.

## EXAMPLES

### EXAMPLE 1
```
Invoke-AzsProductExecuteRunnerAction -ProductId $ProductId -Parameters $Parameters
```

Starts the product execute runner action for the specified product.

## PARAMETERS

### -ProductId
Product package Id to start the execute runner action for.

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

### -Parameters
Deployment parameters, value in JToken

```yaml
Type: PSObject
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
