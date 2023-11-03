### Example 1: Get resource usages of an AzureFrontDoor profile
```powershell
Get-AzFrontDoorCdnProfileResourceUsage -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6
```

```output
CurrentValue Limit Unit
------------ ----- ----
2            10    count
0            100   count
2            100   count
0            100   count
0            100   count
0            100   count
```

Get resource usages of an AzureFrontDoor profile

