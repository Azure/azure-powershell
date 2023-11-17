### Example 1: Get Cdn prefixes
```powershell
Get-AzPeeringCdnPrefix -PeeringLocation Seattle
```

```output
Prefix          AzureRegion AzureService IsPrimaryRegion BgpCommunity
------          ----------- ------------ --------------- ------------
20.157.110.0/24 West US 2   AzureCompute True            8069:51026
20.157.118.0/24 West US 2   AzureCompute True            8069:51026
20.157.125.0/24 West US 2   AzureCompute True            8069:51026
20.157.180.0/24 West US 2   AzureStorage True            8069:52026
20.157.25.0/24  West US 2   AzureCompute True            8069:51026
20.157.50.0/23  West US 2   AzureStorage True            8069:52026
20.47.120.0/23  West US 2   AzureCompute True            8069:51026
20.47.62.0/23   West US 2   AzureStorage True            8069:52026
```

Get all cdn prefixes for subscription
