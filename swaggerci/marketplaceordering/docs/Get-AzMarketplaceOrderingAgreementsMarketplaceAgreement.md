---
external help file:
Module Name: Az.MarketplaceOrderingAgreements
online version: https://docs.microsoft.com/en-us/powershell/module/az.marketplaceorderingagreements/get-azmarketplaceorderingagreementsmarketplaceagreement
schema: 2.0.0
---

# Get-AzMarketplaceOrderingAgreementsMarketplaceAgreement

## SYNOPSIS
Get marketplace terms.

## SYNTAX

### List (Default)
```
Get-AzMarketplaceOrderingAgreementsMarketplaceAgreement [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMarketplaceOrderingAgreementsMarketplaceAgreement -OfferId <String> -PlanId <String>
 -PublisherId <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzMarketplaceOrderingAgreementsMarketplaceAgreement -OfferId <String> -PlanId <String>
 -PublisherId <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMarketplaceOrderingAgreementsMarketplaceAgreement -InputObject <IMarketplaceOrderingAgreementsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzMarketplaceOrderingAgreementsMarketplaceAgreement -InputObject <IMarketplaceOrderingAgreementsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get marketplace terms.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrderingAgreements.Models.IMarketplaceOrderingAgreementsIdentity
Parameter Sets: GetViaIdentity, GetViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OfferId
Offer identifier string of image being deployed.

```yaml
Type: System.String
Parameter Sets: Get, Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanId
Plan identifier string of image being deployed.

```yaml
Type: System.String
Parameter Sets: Get, Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublisherId
Publisher identifier string of image being deployed.

```yaml
Type: System.String
Parameter Sets: Get, Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID that identifies an Azure subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, Get1, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrderingAgreements.Models.IMarketplaceOrderingAgreementsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrderingAgreements.Models.Api202101.IAgreementTerms

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IMarketplaceOrderingAgreementsIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[OfferId <String>]`: Offer identifier string of image being deployed.
  - `[OfferType <OfferType?>]`: Offer Type, currently only virtualmachine type is supported.
  - `[PlanId <String>]`: Plan identifier string of image being deployed.
  - `[PublisherId <String>]`: Publisher identifier string of image being deployed.
  - `[SubscriptionId <String>]`: The subscription ID that identifies an Azure subscription.

## RELATED LINKS

