---
external help file:
Module Name: Az.MarketplaceOrdering
online version: https://learn.microsoft.com/powershell/module/az.marketplaceordering/get-azmarketplaceterms
schema: 2.0.0
---

# Get-AzMarketplaceTerms

## SYNOPSIS
Get marketplace terms.

## SYNTAX

### Get1 (Default)
```
Get-AzMarketplaceTerms -Name <String> -Product <String> -Publisher <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMarketplaceTerms -Name <String> -OfferType <OfferType> -Product <String> -Publisher <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get marketplace terms.

## EXAMPLES

### Example 1: Get marketplace terms
```powershell
Get-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016"
```

```output
Name        Product Publisher     Accepted Signature PrivacyPolicyLink
----        ------- ---------     -------- --------- -----------------
windows2016         microsoft-ads
```

This command gets marketplace terms.

### Example 2: Get marketplace terms with offer type
```powershell
Get-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -OfferType 'virtualmachine'
```

```output
Name        Product                 Publisher     Accepted Signature                                                                                               PrivacyPolicyLink
----        -------                 ---------     -------- ---------                                                                                               -----------------
windows2016 windows-data-science-vm microsoft-ads True     523GN576A2S5OTTOGVFEZWYIWCUIQN2VE3I4WW3H2MER3ERJGDXZESHHQF5ZB2II2VUYXLRK6NE2A7EPF7GH6LWMQ6ECSYSPOD2SHFQ https://www.microsoft.com/EN-US/privacystatement/OnlineS
```

This command gets marketplace terms with offer type.

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

### -Name
Plan identifier string of image being deployed.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferType
Publisher identifier string of image being deployed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Support.OfferType
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Product
Offer identifier string of image being deployed.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Publisher
Publisher identifier string of image being deployed.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Models.IMarketplaceOrderingIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Models.Api202101.IAgreementTerms

## NOTES

ALIASES

## RELATED LINKS

