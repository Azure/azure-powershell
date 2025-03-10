### Example 1: Update Trusted Signing Account Sku
```powershell
Update-AzTrustedSigningAccount -AccountName test -ResourceGroupName rg-test -SkuName Premium
```

```output
Id                                                                                                                                                                        Name                                                                                                 
--                                                                                                                                                                        ----                                                                                                 
/providers/Microsoft.CodeSigning/locations/EASTUS/operationStatuses/cab939ec-10a3-4124-af3c-c397df55d47e*Z22C1223C3C1B39A1567AFE8DFC3B53EE92659D0E69A961E9DF977A4B1AD4686 cab939ec-10a3-4124-af3c-c397df55d47e*Z22C1223C3C1B39A1567AFE8DFC3B53EE92659D0E69A961E9DF977A4B1AD4686
```

This command updates a Trusted Signing Account SKU from Basic to Premium

### Example 2: Update Trusted Signing Account Sku
```powershell
Update-AzTrustedSigningAccount -AccountName test -ResourceGroupName rg-test -SkuName Basic
```

```output
Id                                                                                                                                                                        Name                                                                                                 
--                                                                                                                                                                        ----                                                                                                 
/providers/Microsoft.CodeSigning/locations/EASTUS/operationStatuses/bac939ec-10a3-4124-af3c-c397df55d47e*Z22C1223C3C1B39A1567AFE8DFC3B53EE92659D0E69A961E9DF977A4B1AD4686 bac939ec-10a3-4124-af3c-c397df55d47e*Z22C1223C3C1B39A1567AFE8DFC3B53EE92659D0E69A961E9DF977A4B1AD4686
```

This command updates a Trusted Signing Account SKU from Premium to Basic
