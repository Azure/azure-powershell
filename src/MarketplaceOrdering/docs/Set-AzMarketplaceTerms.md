---
external help file:
Module Name: Az.MarketplaceOrdering
online version: https://learn.microsoft.com/powershell/module/az.marketplaceordering/set-azmarketplaceterms
schema: 2.0.0
---

# Set-AzMarketplaceTerms

## SYNOPSIS
Accept or reject terms for a given publisher id(Publisher), offer id(Product) and plan id(Name).

## SYNTAX

### TermsAccept (Default)
```
Set-AzMarketplaceTerms -Name <String> -Product <String> -Publisher <String> -Accept [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TermsAcceptViaIdentity
```
Set-AzMarketplaceTerms -Accept -Terms <IAgreementTerms> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### TermsReject
```
Set-AzMarketplaceTerms -Name <String> -Product <String> -Publisher <String> -Reject [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TermsRejectViaIdentity
```
Set-AzMarketplaceTerms -Reject -Terms <IAgreementTerms> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Accept or reject terms for a given publisher id(Publisher), offer id(Product) and plan id(Name).

## EXAMPLES

### Example 1: Accept terms for a given publisher id(Publisher), offer id(Product) and plan id(Name)
```powershell
Set-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -Accept
```

```output
Name        Product                 Publisher     Accepted Signature                                                                                               PrivacyPolicyLink
----        -------                 ---------     -------- ---------                                                                                               -----------------
windows2016 windows-data-science-vm microsoft-ads True     523GN576A2S5OTTOGVFEZWYIWCUIQN2VE3I4WW3H2MER3ERJGDXZESHHQF5ZB2II2VUYXLRK6NE2A7EPF7GH6LWMQ6ECSYSPOD2SHFQ https://www.microsoft.com/EN-US/privacystatement/OnlineS
```

This command accept terms for a given publisher id(Publisher), offer id(Product) and plan id(Name).

### Example 2: Accept terms for a given publisher id(Publisher), offer id(Product) and plan id(Name) by pipeline
```powershell
Get-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -OfferType 'virtualmachine' | Set-AzMarketplaceTerms -Accept
```

```output
Name        Product                 Publisher     Accepted Signature                                                                                               PrivacyPolicyLink
----        -------                 ---------     -------- ---------                                                                                               -----------------
windows2016 windows-data-science-vm microsoft-ads True     523GN576A2S5OTTOGVFEZWYIWCUIQN2VE3I4WW3H2MER3ERJGDXZESHHQF5ZB2II2VUYXLRK6NE2A7EPF7GH6LWMQ6ECSYSPOD2SHFQ https://www.microsoft.com/EN-US/privacystatement/OnlineS
```

This command accept terms for a given publisher id(Publisher), offer id(Product) and plan id(Name) by pipeline.

### Example 3: Reject terms for a given publisher id(Publisher), offer id(Product) and plan id(Name)
```powershell
Set-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -Reject
```

```output
Name        Product                 Publisher     Accepted Signature                                                                                               PrivacyPolicyLink
----        -------                 ---------     -------- ---------                                                                                               -----------------
windows2016 windows-data-science-vm microsoft-ads False     523GN576A2S5OTTOGVFEZWYIWCUIQN2VE3I4WW3H2MER3ERJGDXZESHHQF5ZB2II2VUYXLRK6NE2A7EPF7GH6LWMQ6ECSYSPOD2SHFQ https://www.microsoft.com/EN-US/privacystatement/OnlineS
```

This command reject terms for a given publisher id(Publisher), offer id(Product) and plan id(Name).

### Example 4: Reject terms for a given publisher id(Publisher), offer id(Product) and plan id(Name) by pipeline
```powershell
Get-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -OfferType 'virtualmachine' | Set-AzMarketplaceTerms -Reject
```

```output
Name        Product                 Publisher     Accepted Signature                                                                                               PrivacyPolicyLink
----        -------                 ---------     -------- ---------                                                                                               -----------------
windows2016 windows-data-science-vm microsoft-ads False     523GN576A2S5OTTOGVFEZWYIWCUIQN2VE3I4WW3H2MER3ERJGDXZESHHQF5ZB2II2VUYXLRK6NE2A7EPF7GH6LWMQ6ECSYSPOD2SHFQ https://www.microsoft.com/EN-US/privacystatement/OnlineS
```

This command reject terms for a given publisher id(Publisher), offer id(Product) and plan id(Name) by pipeline.

## PARAMETERS

### -Accept
If any version of the terms have been accepted, otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: TermsAccept, TermsAcceptViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Parameter Sets: TermsAccept, TermsReject
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
Parameter Sets: TermsAccept, TermsReject
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
Parameter Sets: TermsAccept, TermsReject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Reject
Pass this to reject the legal terms.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: TermsReject, TermsRejectViaIdentity
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
Type: System.String
Parameter Sets: TermsAccept, TermsReject
Aliases:

Required: True
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Terms
Terms properties for provided Publisher/Offer/Plan tuple
To construct, see NOTES section for PARAMETER properties and create a hash table.
To construct, see NOTES section for TERMS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Models.Api202101.IAgreementTerms
Parameter Sets: TermsAcceptViaIdentity, TermsRejectViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Models.Api202101.IAgreementTerms

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Models.Api202101.IAgreementTerms

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`TERMS <IAgreementTerms>`: Terms properties for provided Publisher/Offer/Plan tuple To construct, see NOTES section for PARAMETER properties and create a hash table.
  - `[Accepted <Boolean?>]`: If any version of the terms have been accepted, otherwise false.
  - `[LicenseTextLink <String>]`: Link to HTML with Microsoft and Publisher terms.
  - `[MarketplaceTermsLink <String>]`: Link to HTML with Azure Marketplace terms.
  - `[Plan <String>]`: Plan identifier string of image being deployed.
  - `[PrivacyPolicyLink <String>]`: Link to the privacy policy of the publisher.
  - `[Product <String>]`: Offer identifier string of image being deployed.
  - `[Publisher <String>]`: Publisher identifier string of image being deployed.
  - `[RetrieveDatetime <DateTime?>]`: Date and time in UTC of when the terms were accepted. This is empty if Accepted is false.
  - `[Signature <String>]`: Terms signature.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.

## RELATED LINKS

