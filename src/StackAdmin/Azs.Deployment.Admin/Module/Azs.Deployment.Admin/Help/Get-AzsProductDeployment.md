---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Get-AzsProductDeployment

## SYNOPSIS
Lists product deployments or gets a product deployment properties.

## SYNTAX

```
Get-AzsProductDeployment [[-ProductId] <String>] [-AsJson] [<CommonParameters>]
```

## DESCRIPTION
Lists product deployments or gets a product deployment properties.

## EXAMPLES

### EXAMPLE 1
```
Get-AzsProductDeployment
```

Lists all the product package deployments in the subscription.

### EXAMPLE 2
```
Get-AzsProductDeployment -ProductId $ProductId
```

Gets the product package deployment with the specified product Id.

## PARAMETERS

### -ProductId
Product package Id to get the product deployment properties for.

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
