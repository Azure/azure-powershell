### Example 1: Delete an AzureFrontDoor origin under the origin group
```powershell
Remove-AzFrontDoorCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -OriginName ori001
```

Delete an AzureFrontDoor origin under the origin group


### Example 2: Delete an AzureFrontDoor origin under the origin group via identity
```powershell
Get-AzFrontDoorCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -OriginName ori001 | Remove-AzFrontDoorCdnOrigin
```

Delete an AzureFrontDoor origin under the origin group via identity