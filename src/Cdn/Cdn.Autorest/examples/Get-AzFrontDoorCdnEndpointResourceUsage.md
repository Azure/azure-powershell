### Example 1: List resource usages of an AzureFrontDoor endpoint under the profile
```powershell
Get-AzFrontDoorCdnEndpointResourceUsage -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001
```

```output
CurrentValue Limit Unit
------------ ----- ----
1            100   count
```

List resource usages of an AzureFrontDoor endpoint under the profile
