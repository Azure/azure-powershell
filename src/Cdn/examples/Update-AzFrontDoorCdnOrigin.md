### Example 1: Update an AzureFrontDoor origin group under the profile
```powershell
Update-AzFrontDoorCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -OriginName ori001 -Weight 999
```

```output
Name   ResourceGroupName
----   -----------------
ori001 testps-rg-da16jm
```

