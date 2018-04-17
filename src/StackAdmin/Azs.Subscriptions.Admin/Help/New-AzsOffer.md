---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version: 
schema: 2.0.0
---

# New-AzsOffer

## SYNOPSIS
Creates a new offer.

## SYNTAX

```
New-AzsOffer -Name <String> -DisplayName <String> -ResourceGroupName <String> [-BasePlanIds <String[]>]
 [-Description <String>] [-ExternalReferenceId <String>] [-State <String>] [-Location <String>]
 [-MaxSubscriptionsPerAccount <Int64>] [-SubscriptionCount <Int64>]
 [-AddonPlanDefinition <AddonPlanDefinition[]>] [<CommonParameters>]
```

## DESCRIPTION
Create or update the offer.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
New-AzsOffer -Name offer1 -ResourceGroupName rg1 -State Public -DisplayName "offer1" -BasePlanIds "/subscriptions/0a823c45-d9e7-4812-a138-74e22213693a/resourceGroups/rg1/providers/Microsoft.Subscriptions.Admin/plans/plan1"
```

OfferName                  : offer1
DisplayName                : offer1
Description                :
State                      : Public
SubscriptionCount          : 1
MaxSubscriptionsPerAccount : 0
BasePlanIds                : {/subscriptions/0a823c45-d9e7-4812-a138-74e22213693a/resourceGroups/rg1/providers/Microsoft.Subscriptions.Admin/plans/plan1}
AddonPlanDefinition        :
Id                         : /subscriptions/0a823c45-d9e7-4812-a138-74e22213693a/resourceGroups/rg1/providers/Microsoft.Subscriptions.Admin/offers/offer1
Name                       : offer1
Type                       : Microsoft.Subscriptions.Admin/offers
Location                   : local
Tags                       :

Creates a new offer.

## PARAMETERS

### -AddonPlanDefinition
References to add-on plans that a tenant can optionally acquire as a part of the offer.

```yaml
Type: AddonPlanDefinition[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BasePlanIds
Identifiers of the base plans that become available to the tenant immediately when a tenant subscribes to the offer.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Description of offer.

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

### -DisplayName
Display name of offer.

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

### -ExternalReferenceId
External reference identifier.

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

### -MaxSubscriptionsPerAccount
Maximum subscriptions per account.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of an offer.

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

### -ResourceGroupName
{{Fill ResourceGroupName Description}}

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
Offer accessibility state.

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

### -SubscriptionCount
Current subscription count.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Offer

## NOTES

## RELATED LINKS

