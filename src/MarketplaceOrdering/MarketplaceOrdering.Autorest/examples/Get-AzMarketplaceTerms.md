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
