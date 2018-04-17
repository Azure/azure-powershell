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

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsSubscription
```

DisplayName    : Test subscription
Id             : /subscriptions/d387f779-85d8-40b6-8607-8306295ebff9
OfferId        : /delegatedProviders/default/offers/offer1
State          : Enabled
SubscriptionId : d387f779-85d8-40b6-8607-8306295ebff9
TenantId       : 1e64bce5-9f3b-4add-8be8-e550e05014d0

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

### Microsoft.AzureStack.Management.Subscriptions.Models.Subscription

## NOTES

## RELATED LINKS

