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