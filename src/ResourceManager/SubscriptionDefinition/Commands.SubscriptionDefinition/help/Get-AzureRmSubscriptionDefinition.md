---
external help file: Microsoft.Azure.Commands.SubscriptionDefinition.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmSubscriptionDefinition

## SYNOPSIS
Get a subscription definition.

## SYNTAX

### Get subscription definitions.
```
Get-AzureRmSubscriptionDefinition
```

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmSubscriptionDefinition
```

Gets all subscription definitions.

### Example 2
```
PS C:\> Get-AzureRmSubscriptionDefinition -Name MySubDef
```

Gets a subscription definition with the name MySubDef.

## PARAMETERS

### -Name
The name of the subscription definition to retrieve.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.SubscriptionDefinition.Models.PSSubscriptionDefinition, Microsoft.Azure.Commands.SubscriptionDefinition, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

