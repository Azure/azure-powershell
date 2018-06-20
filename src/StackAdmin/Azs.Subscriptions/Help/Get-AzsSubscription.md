---
external help file: Azs.Subscriptions-help.xml
Module Name: Azs.Subscriptions
online version:
schema: 2.0.0
---

# Get-AzsSubscription

## SYNOPSIS
Get the list of subscriptions.

## SYNTAX

### List (Default)
```
Get-AzsSubscription [<CommonParameters>]
```

### Get
```
Get-AzsSubscription [-SubscriptionId] <String> [<CommonParameters>]
```

## DESCRIPTION
Get the list of subscriptions.

## EXAMPLES

### EXAMPLE 1
```
Get-AzsSubscription
```

Get the list of subscriptions.

## PARAMETERS

### -SubscriptionId
Id of the subscription.

```yaml
Type: String
Parameter Sets: Get
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Subscription.Models.SubscriptionModel

## NOTES

## RELATED LINKS
