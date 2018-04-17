---
external help file: Azs.Subscriptions-help.xml
Module Name: Azs.Subscriptions
online version: 
schema: 2.0.0
---

# Set-AzsSubscription

## SYNOPSIS
Create or updates a subscription.

## SYNTAX

```
Set-AzsSubscription -OfferId <String> [-Id <String>] [-Type <String>]
 [-Tags <System.Collections.Generic.Dictionary`2[System.String,System.String]>] -SubscriptionId <String>
 -State <String> [-TenantId <String>] [-DisplayName <String>] [-Location <String>] [<CommonParameters>]
```

## DESCRIPTION
Create or updates a subscription.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Set-AzsSubscription -SubscriptionId 2d9f5af9-3397-44fb-8700-d98762c2422a -DisplayName MyTestSub -State Enabled -OfferId /delegatedProviders/default/offers/offer1
```

DisplayName    : MyTestSub
Id             : /subscriptions/2d9f5af9-3397-44fb-8700-d98762c2422a
OfferId        : /delegatedProviders/default/offers/offer1
State          : Enabled
SubscriptionId : 2d9f5af9-3397-44fb-8700-d98762c2422a
TenantId       : 1e64bce5-9f3b-4add-8be8-e550e05014d0

Create or updates a subscription.

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

### -Id
Fully qualified identifier.

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

Required: True
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tags
List of key-value pairs.

```yaml
Type: System.Collections.Generic.Dictionary`2[System.String,System.String]
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

### -Type
Type of resource.

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

