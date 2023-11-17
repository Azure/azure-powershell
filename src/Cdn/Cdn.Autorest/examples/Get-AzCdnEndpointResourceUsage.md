### Example 1: List resource useages of an AzureCDN Endpoint under the AzureCDN profile
```powershell
Get-AzCdnEndpointResourceUsage -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001
```

```output
CurrentValue Limit ResourceType          Unit
------------ ----- ------------          ----
0            25    customdomain          count
0            25    geofilter             count
0            25    deliveryrule          count
0            10    deliveryrulecondition count
0            5     deliveryruleaction    count
1            10    origin                count
1            10    origingroup           count
1            10    originsPerOriginGroup count
```

List resource useages of an AzureCDN Endpoint under the AzureCDN profile

