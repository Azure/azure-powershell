### Example 1: Get A Trusted Signing Account By Name
```powershell
Get-AzTrustedSigningAccount -AccountName test -ResourceGroupName rg-test
```

```output
AccountUri                         Id                                                                                                                                     Location Name    ProvisioningState ResourceGroupName RetryAfter SkuName SystemDataCreatedAt  SystemDataCreatedBy
----------                         --                                                                                                                                     -------- ----    ----------------- ----------------- ---------- ------- -------------------  -------------------
https://eus.codesigning.azure.net/ /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test    eastus   test    Succeeded         rg-test                      Basic   1/24/2025 9:58:19 PM test@example.com
```

This command get a trusted signing account by name.

### Example 2: List Trusted Signing Accounts In A Resource Group
```powershell
Get-AzTrustedSigningAccount -ResourceGroupName rg-test
```

```output
AccountUri                         Id                                                                                                                                     Location Name    ProvisioningState ResourceGroupName RetryAfter SkuName SystemDataCreatedAt  SystemDataCreatedBy
----------                         --                                                                                                                                     -------- ----    ----------------- ----------------- ---------- ------- -------------------  -------------------
https://eus.codesigning.azure.net/ /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test    eastus   test    Succeeded         rg-test                      Basic   1/24/2025 9:58:19 PM test@example.com
https://eus.codesigning.azure.net/ /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test2   eastus   test2   Succeeded         rg-test                      Basic   1/24/2025 9:58:19 PM test2@example.com
```

This command lists trusted signing accounts in a resource group

