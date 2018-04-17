---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version: 
schema: 2.0.0
---

# Set-AzsOffer

## SYNOPSIS
Update the offer.

## SYNTAX

### Update (Default)
```
Set-AzsOffer -Name <String> -ResourceGroupName <String> [-DisplayName <String>] [-BasePlanIds <String[]>]
 [-Description <String>] [-ExternalReferenceId <String>] [-State <String>] [-Location <String>]
 [-SubscriptionCount <Int64>] [-MaxSubscriptionsPerAccount <Int64>]
 [-AddonPlanDefinition <AddonPlanDefinition[]>] [<CommonParameters>]
```

### InputObject
```
Set-AzsOffer [-DisplayName <String>] [-BasePlanIds <String[]>] -InputObject <Offer> [-Description <String>]
 [-ExternalReferenceId <String>] [-State <String>] [-Location <String>] [-SubscriptionCount <Int64>]
 [-MaxSubscriptionsPerAccount <Int64>] [-AddonPlanDefinition <AddonPlanDefinition[]>] [<CommonParameters>]
```

### ResourceId
```
Set-AzsOffer [-DisplayName <String>] [-BasePlanIds <String[]>] [-Description <String>]
 [-ExternalReferenceId <String>] [-State <String>] [-Location <String>] [-SubscriptionCount <Int64>]
 [-MaxSubscriptionsPerAccount <Int64>] [-AddonPlanDefinition <AddonPlanDefinition[]>] -ResourceId <String>
 [<CommonParameters>]
```

## DESCRIPTION
Update the offer.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Set-AzsOffer -Name offer1 -ResourceGroupName rg1 -State Private
```

OfferName                  : offer1
DisplayName                : offer1
Description                :
State                      : Private
SubscriptionCount          : 1
MaxSubscriptionsPerAccount : 0
BasePlanIds                : {/subscriptions/0a823c45-d9e7-4812-a138-74e22213693a/resourceGroups/rg1/providers/Microsoft.Subscriptions.Admin/plans/plan1}
AddonPlanDefinition        :
Id                         : /subscriptions/0a823c45-d9e7-4812-a138-74e22213693a/resourceGroups/rg1/providers/Microsoft.Subscriptions.Admin/offers/offer1
Name                       : offer1
Type                       : Microsoft.Subscriptions.Admin/offers
Location                   : local
Tags                       :

Update the offer.

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

Required: False
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

### -InputObject
The input object of type Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Offer.

```yaml
Type: Offer
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

