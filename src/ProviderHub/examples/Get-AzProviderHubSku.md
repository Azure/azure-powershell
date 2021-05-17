### Example 1: Get the resource SKU definition.
```powershell
PS C:\> Get-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default"
```

Name                        Type
----                        ----
testResourceType            Microsoft.ProviderHub/providerRegistrations/skus

Get the resource SKU definition.

