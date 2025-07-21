### Example 1: List resource usages of an AzureFrontDoor origin group under the profile
```powershell
Get-AzFrontDoorCdnOriginGroupResourceUsage -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001
```

```output
CurrentValue Limit Unit
------------ ----- ----
1            50    count
```

List resource usages of an AzureFrontDoor origin group under the profile


