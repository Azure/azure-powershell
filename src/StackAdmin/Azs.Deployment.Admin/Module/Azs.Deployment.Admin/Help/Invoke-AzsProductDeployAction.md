---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Invoke-AzsProductDeployAction

## SYNOPSIS
Invokes 'deploy product' action.

## SYNTAX

```
Invoke-AzsProductDeployAction [-ProductId] <String> [-Version] <String> [-Parameters] <PSObject>
 [<CommonParameters>]
```

## DESCRIPTION
Invokes 'deploy product' action.

## EXAMPLES

### EXAMPLE 1
```
Invoke-AzsProductDeployAction -ProductId $ProductId -Version $ProductVersion -Parameters $Parameters
```

Starts the product deploy action for the specified product.

## PARAMETERS

### -ProductId
Product package Id to start the deploy action for.

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
Product Version.

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

### -Parameters
Deployment parameters, value in JToken

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
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
