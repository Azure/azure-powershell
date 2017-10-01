---
external help file: Microsoft.Azure.Commands.MarketplaceOrdering.dll-Help.xml
Module Name: AzureRM.MarketplaceOrdering
online version: 
schema: 2.0.0
---

# Set-AzureRmMarketplaceTerms

## SYNOPSIS
Accept or reject terms for a given publisher id(Publisher), offer id(Product) and plan id(Name). Please use Get-AzureRmMarketplaceTerms to get the agreement term for accepting the agreement.

## SYNTAX

```
Set-AzureRmMarketplaceTerms -Publisher <String> -Product <String> -Name <String> [-Accepted]
 [-InputObject <PSAgreementTerms>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmMarketplaceTerms** cmdlet saves the terms object for given publisher id(Publisher), offer id(Product) and plan id(Name) tuple.

## EXAMPLES

### Example 1
```
PS C:\> Set-AzureRmMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -Terms $agreementTerms -Accepted
```

### Example 2
```
PS C:\> Get-AzureRmMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" | Set-AzureRmMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -Accepted
```

## PARAMETERS

### -Accepted
Boolean which would indicate the status of acceptance of the terms, it should be true if any version of the terms have been accepted.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Terms object returned in Get-AzureRmMarketplaceTerms cmdlet. This is a mandatory parameter if Accepted paramter is true.```yaml
Type: PSAgreementTerms
Parameter Sets: (All)
Aliases: Terms

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.MarketplaceOrdering.Models.PSAgreementTerms
Microsoft.Azure.Commands.MarketplaceOrdering.Models.PSAgreementTerms

## OUTPUTS

### Microsoft.Azure.Commands.MarketplaceOrdering.Models.PSAgreementTerms
Microsoft.Azure.Commands.MarketplaceOrdering.Models.PSAgreementTerms

## NOTES

## RELATED LINKS

