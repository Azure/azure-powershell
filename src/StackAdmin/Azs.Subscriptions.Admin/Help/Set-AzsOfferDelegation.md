---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version: 
schema: 2.0.0
---

# Set-AzsOfferDelegation

## SYNOPSIS
Updates the offer delegation.

## SYNTAX

### Update (Default)
```
Set-AzsOfferDelegation -Name <String> -OfferName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Location <String>] [<CommonParameters>]
```

### InputObject
```
Set-AzsOfferDelegation [-SubscriptionId <String>] [-Location <String>] -InputObject <OfferDelegation>
 [<CommonParameters>]
```

### ResourceId
```
Set-AzsOfferDelegation [-SubscriptionId <String>] -ResourceId <String> [-Location <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Updates the offer delegation.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Set-AzsOfferDelegation -Offer offer1 -ResourceGroupName rg1 -Name delegate1 -SubscriptionId "c90173b1-de7a-4b1d-8600-b832b0e65946" -Location "local"
```

SubscriptionId : c90173b1-de7a-4b1d-8600-b832b0e65946
Id             : /subscriptions/0a823c45-d9e7-4812-a138-74e22213693a/resourceGroups/rg1/providers/Microsoft.Subscriptions.Admin/offers/offer1/offerDelegations/delegate1
Name           : offer1/delegate1
Type           : Microsoft.Subscriptions.Admin/offers/offerDelegations
Location       : local
Tags           :

Updates the offer delegation.

## PARAMETERS

### -InputObject
The input object of type Microsoft.AzureStack.Management.Subscriptions.Admin.Models.OfferDelegation.

```yaml
Type: OfferDelegation
Parameter Sets: InputObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Location of the resource.

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

### -Name
Name of a offer delegation.

```yaml
Type: String
Parameter Sets: Update
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferName
Name of an offer.

```yaml
Type: String
Parameter Sets: Update
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
{{Fill ResourceGroupName Description}}

```yaml
Type: String
Parameter Sets: Update
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
Identifier of the subscription receiving the delegated offer.

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

### Microsoft.AzureStack.Management.Subscriptions.Admin.Models.OfferDelegation

## NOTES

## RELATED LINKS

