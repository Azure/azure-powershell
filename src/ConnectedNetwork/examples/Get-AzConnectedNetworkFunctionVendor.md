### Example 1: Get-AzConnectedNetworkFunctionVendor
```powershell
Get-AzConnectedNetworkFunctionVendor
```

```output
SkuList                                                                                         VendorName
-------                                                                                         ----------
{vendor-sku, vendor-sku1, vendor-sku2, vendor-sku3, vendor-sku4, vendor-sku4, vendor-sku5...}   myVendor
{vendor1-sku, vendor1-sku2}                                                                     myVendor1
{vendor2-sku1}                                                                                  myVendor2
```

Getting information about the vendors and their skus

### Example 2: Get-AzConnectedNetworkFunctionVendor via Subscription Id
```powershell
Get-AzConnectedNetworkFunctionVendor -SubscriptionId "xxxxx-00000-xxxxx-00000"
```

```output
SkuList                                                                                         VendorName
-------                                                                                         ----------
{vendor1-sku, vendor1-sku2}                                                                     myVendor1
{vendor2-sku1}                                                                                  myVendor2
```

Gets information about the vendors and their skus in the given subscription.