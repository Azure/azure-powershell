### Example 1: Cancel marketplace terms
```powershell
Stop-AzMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016"
```

```output
Name        Product Publisher     Accepted Signature PrivacyPolicyLink
----        ------- ---------     -------- --------- -----------------
windows2016         microsoft-ads
```

This command cancel marketplace terms.

### Example 2: Cancel marketplace terms by pipeline
```powershell
Get-AzMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" | Stop-AzMarketplaceTerms
```

```output
Name        Product Publisher     Accepted Signature PrivacyPolicyLink
----        ------- ---------     -------- --------- -----------------
windows2016         microsoft-ads
```

This command cancel marketplace terms by pipeline.