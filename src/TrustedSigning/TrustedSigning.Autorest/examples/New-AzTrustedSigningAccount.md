### Example 1: Create A New Trusted Signing Account With A Basic Sku
```powershell
New-AzTrustedSigningAccount -AccountName test -ResourceGroupName rg-test -Location eastus -SkuName Basic
```

```output
AccountUri                         Id                                                                                                                                    Location Name   ProvisioningState ResourceGroupName RetryAfter SkuName SystemDataCreatedAt  SystemDataCreatedBy
----------                         --                                                                                                                                    -------- ----   ----------------- ----------------- ---------- ------- -------------------  -------------------
https://eus.codesigning.azure.net/ /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test   eastus   test   Succeeded         rg-test                      Basic   2/3/2025 10:35:58 PM test@example.com
```

This command creates a new trusted signing account with a Basic SKU

### Example 2: Create A New Trusted Signing Account With A Premium Sku
```powershell
New-AzTrustedSigningAccount -AccountName test -ResourceGroupName rg-test -Location eastus -SkuName Premium
```

```output
AccountUri                         Id                                                                                                                                    Location Name   ProvisioningState ResourceGroupName RetryAfter SkuName SystemDataCreatedAt  SystemDataCreatedBy
----------                         --                                                                                                                                    -------- ----   ----------------- ----------------- ---------- ------- -------------------  -------------------
https://eus.codesigning.azure.net/ /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test   eastus   test   Succeeded         rg-test                      Premium 2/3/2025 10:35:58 PM test@example.com
```

This command creates a new trusted signing account with a Premium SKU

