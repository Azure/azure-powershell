---
external help file: Microsoft.Azure.Commands.MarketplaceOrdering.dll-Help.xml
Module Name: AzureRM.MarketplaceOrdering
online version: 
schema: 2.0.0
---

# Get-AzureRmMarketplaceTerms

## SYNOPSIS
Get the agreement terms of a given given publisher identifier,offer identifier, plan identifier. The cmdlet can be invoked in the context of the subscription to which customers wish to deploy marketplace offers.

## SYNTAX

```
Get-AzureRmMarketplaceTerms -Publisher <String> -Product <String> -Name <String>
```

## DESCRIPTION
The **Get-AzureRmMarketplaceTerms** cmdlet returns terms object for given publisher identifier,offer identifier, plan identifier tuple.

## EXAMPLES

### Example 1
```
PS C:\> $agreementTerms = Get-AzureRmMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016"
```

## PARAMETERS

### -Name
Plan identifier string of image being deployed.

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

### -Product
Offer identifier string of image being deployed.

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

### -Publisher
Publisher identifier string of image being deployed.

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

## INPUTS

### None


## OUTPUTS

### Microsoft.Azure.Management.MarketplaceOrdering.Models.AgreementTerms
Microsoft.Azure.Management.MarketplaceOrdering.Models.AgreementTerms


## NOTES

## RELATED LINKS

