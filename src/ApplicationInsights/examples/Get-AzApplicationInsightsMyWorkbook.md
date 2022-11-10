### Example 1: List private workbook by category
```powershell
Get-AzApplicationInsightsMyWorkbook -Category 'workbook'
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind   Category
-----------------       ----                                 -----------                                  -------- ----   --------
appinsights-hkrs2v-test 7d195dcc-7d02-459f-a181-5b46662e4060 Workbook01                                   westus2  shared workbook
appinsights-hkrs2v-test c65b3461-9270-45b7-b6ad-ddd644458b0e                                              westus2  user   workbook
appinsights-hkrs2v-test 2e47417f-c136-44c0-b78f-7a4ca35fd9d1 Workbook02-display                           westus2  user   workbook
appinsights-hkrs2v-test 842437e8-8ef1-4ce7-b1a7-4cebf6c10188 Workbook03-display                           westus2  user   workbook
appinsights-hkrs2v-test aac4bf14-0f25-4ac3-a4d4-76c63bf7312e Workbook03-display                           westus2  user   workbook
appinsights-hkrs2v-test 74446cb1-d125-4c1f-ab84-e57fd93101d2 Workbook03-display                           westus2  shared workbook
appinsights-hkrs2v-test 5df8625f-fae4-4a38-9f43-62a40a2e99d1 5df8625f-fae4-4a38-9f43-62a40a2e99d1-display westus2  user   workbook
```

This command lists my workbook by category.

### Example 2: Get a single private workbook by its resourceName 
```powershell
Get-AzApplicationInsightsMyWorkbook -ResourceGroupName appinsights-hkrs2v-test -Name 5df8625f-fae4-4a38-9f43-62a40a2e99d1
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind Category
-----------------       ----                                 -----------                                  -------- ---- --------
appinsights-hkrs2v-test 5df8625f-fae4-4a38-9f43-62a40a2e99d1 5df8625f-fae4-4a38-9f43-62a40a2e99d1-display westus2  user workbook
```

This command gets a single private workbook by its resourceName.

### Example 3: List private workbook by resource group
```powershell
Get-AzApplicationInsightsMyWorkbook -ResourceGroupName appinsights-hkrs2v-test -Category 'workbook'
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind   Category
-----------------       ----                                 -----------                                  -------- ----   --------
appinsights-hkrs2v-test 7d195dcc-7d02-459f-a181-5b46662e4060 Workbook01                                   westus2  shared workbook
appinsights-hkrs2v-test c65b3461-9270-45b7-b6ad-ddd644458b0e                                              westus2  user   workbook
appinsights-hkrs2v-test 2e47417f-c136-44c0-b78f-7a4ca35fd9d1 Workbook02-display                           westus2  user   workbook
appinsights-hkrs2v-test 842437e8-8ef1-4ce7-b1a7-4cebf6c10188 Workbook03-display                           westus2  user   workbook
appinsights-hkrs2v-test aac4bf14-0f25-4ac3-a4d4-76c63bf7312e Workbook03-display                           westus2  user   workbook
appinsights-hkrs2v-test 74446cb1-d125-4c1f-ab84-e57fd93101d2 Workbook03-display                           westus2  shared workbook
appinsights-hkrs2v-test 5df8625f-fae4-4a38-9f43-62a40a2e99d1 5df8625f-fae4-4a38-9f43-62a40a2e99d1-display westus2  user   workbook
```

This command lists private workbook by resource group.