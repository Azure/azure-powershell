### Example 1: Updates the AzureFrontDoor customdomain validation token

```powershell
Update-AzFrontDoorCdnCustomDomainValidationToken -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -CustomDomainName domain001
```

Updates the AzureFrontDoor customdomain validation token


### Example 2: Updates the AzureFrontDoor customdomain validation token via identity

```powershell
Get-AzFrontDoorCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -CustomDomainName domain001 | Update-AzFrontDoorCdnCustomDomainValidationToken
```

Updates the AzureFrontDoor customdomain validation token via identity

