### Example 1: Get-AzConnectedNetworkFunctionVendor
```powershell
<<<<<<< HEAD
Get-AzConnectedNetworkFunctionVendor
```

```output
=======
PS C:\> Get-AzConnectedNetworkFunctionVendor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
SkuList                                                                                         VendorName
-------                                                                                         ----------
{vendor-sku, vendor-sku1, vendor-sku2, vendor-sku3, vendor-sku4, vendor-sku4, vendor-sku5...}   myVendor
{vendor1-sku, vendor1-sku2}                                                                     myVendor1
{vendor2-sku1}                                                                                  myVendor2
```

Getting information about the vendors and their skus

### Example 2: Get-AzConnectedNetworkFunctionVendor via Subscription Id
```powershell
<<<<<<< HEAD
Get-AzConnectedNetworkFunctionVendor -SubscriptionId "xxxxx-00000-xxxxx-00000"
```

```output
=======
PS C:\> Get-AzConnectedNetworkFunctionVendor -SubscriptionId "xxxxx-00000-xxxxx-00000"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
SkuList                                                                                         VendorName
-------                                                                                         ----------
{vendor1-sku, vendor1-sku2}                                                                     myVendor1
{vendor2-sku1}                                                                                  myVendor2
```

Gets information about the vendors and their skus in the given subscription.