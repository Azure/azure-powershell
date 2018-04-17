---
external help file: Azs.Subscriptions-help.xml
Module Name: Azs.Subscriptions
online version: 
schema: 2.0.0
---

# New-AzsSubscription

## SYNOPSIS
Create a subscription.

## SYNTAX

```
New-AzsSubscription -OfferId <String> [-DisplayName <String>] [-TenantId <String>] [-SubscriptionId <String>]
 [-State <String>] [-Location <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a subscription.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
New-AzsSubscription -OfferId /delegatedProviders/default/offers/offer1
```

DisplayName    :
Id             : /subscriptions/d387f779-85d8-40b6-8607-8306295ebff9
OfferId        : /delegatedProviders/default/offers/offer1
State          : Enabled
SubscriptionId : d387f779-85d8-40b6-8607-8306295ebff9
TenantId       : 1e64bce5-9f3b-4add-8be8-e550e05014d0

Create a subscription.

## PARAMETERS

### -DisplayName
Subscription name.

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

### -Location
Location where resource is location.

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

### -OfferId
Identifier of the offer under the scope of a delegated provider.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Subscription state.

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

### -SubscriptionId
Subscription identifier.

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

### -TenantId
Directory tenant identifier.

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

## OUTPUTS

### Microsoft.AzureStack.Management.Subscriptions.Models.Subscription

## NOTES

## RELATED LINKS

