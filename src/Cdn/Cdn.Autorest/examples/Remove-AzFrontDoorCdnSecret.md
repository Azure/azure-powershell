### Example 1: Delete an AzureFrontDoor secret under the profile
```powershell
Remove-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001
```

Delete an AzureFrontDoor secret under the profile


### Example 2: Delete an AzureFrontDoor secret under the profile via identity
```powershell
Get-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001 | Remove-AzFrontDoorCdnSecret
```

Delete an AzureFrontDoor secret under the profile via identity