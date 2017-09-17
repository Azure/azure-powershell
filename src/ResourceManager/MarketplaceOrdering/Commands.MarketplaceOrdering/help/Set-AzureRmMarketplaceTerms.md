---
external help file: Microsoft.Azure.Commands.MarketplaceOrdering.dll-Help.xml
Module Name: AzureRM.MarketplaceOrdering
online version: 
schema: 2.0.0
---

# Set-AzureRmMarketplaceTerms

## SYNOPSIS
Accept or reject agreement terms of a give publisher id, offer id and plan id. Please use Get-AzureRmMarketplaceTerms to get the agreement terms.

## SYNTAX

```
Set-AzureRmMarketplaceTerms -Publisher <String> -Product <String> -Name <String> -Accepted <Boolean>
 [-Terms <AgreementTerms>]
```

## DESCRIPTION
The **Set-AzureRmMarketplaceTerms** cmdlet saves the terms object for given publisher identifier,offer identifier, plan identifier tuple.

## EXAMPLES

### Example 1
```
PS C:\> Set-AzureRmMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -Accepted $true -Terms $agreementTerms
```

{{ Add example description here }}

## PARAMETERS

### -Accepted
Boolean which would indicate the status of acceptance of the terms, it should be true if any version of the terms have been accepted.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Terms
Terms object returned in Get-AzureRmMarketplaceTerm cmdlet.
This is a mandatory parameter if Accepted paramter is true.

```yaml
Type: AgreementTerms
Parameter Sets: (All)
Aliases: 

Required: False
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

