### Example 1: Sign marketplace terms
```powershell
Invoke-AzMarketplaceSignTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016"
```

```output
Name        Product Publisher     Accepted Signature PrivacyPolicyLink
----        ------- ---------     -------- --------- -----------------
windows2016         microsoft-ads
```

This command signs marketplace terms.

### Example 2: Sign marketplace terms by pipeline
```powershell
Get-AzMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" | Invoke-AzMarketplaceSignTerms
```

```output
Name        Product Publisher     Accepted Signature PrivacyPolicyLink
----        ------- ---------     -------- --------- -----------------
windows2016         microsoft-ads
```

This command signs marketplace terms by pipeline.

