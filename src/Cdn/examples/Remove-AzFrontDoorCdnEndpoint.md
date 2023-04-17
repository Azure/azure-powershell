### Example 1: Delete an AzureFrontDoor endpoint under the profile
```powershell
Remove-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001
```

Delete an AzureFrontDoor endpoint under the profile


### Example 2: Delete an AzureFrontDoor endpoint under the profile via identity
```powershell
Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 | Remove-AzFrontDoorCdnEndpoint
```

Delete an AzureFrontDoor endpoint under the profile via identity