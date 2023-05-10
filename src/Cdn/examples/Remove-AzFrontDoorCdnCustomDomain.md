### Example 1: Delete an AzureFrontDoor customdomain under the profile
```powershell
Remove-AzFrontDoorCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -CustomDomainName domain001
```

Delete an AzureFrontDoor customdomain under the profile


### Example 2: Delete an AzureFrontDoor customdomain under the profile via identity
```powershell
Get-AzFrontDoorCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -CustomDomainName domain001 | Remove-AzFrontDoorCdnCustomDomain
```

Delete an AzureFrontDoor customdomain under the profile via identity