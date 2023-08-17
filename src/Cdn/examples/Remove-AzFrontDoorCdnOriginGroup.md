### Example 1: Delete an AzureFrontDoor origin group under the profile
```powershell
Remove-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001
```

Delete an AzureFrontDoor origin group under the profile


### Example 2: Delete an AzureFrontDoor origin group under the profile via identity
```powershell
Get-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 | Remove-AzFrontDoorCdnOriginGroup
```

Delete an AzureFrontDoor origin group under the profile via identity