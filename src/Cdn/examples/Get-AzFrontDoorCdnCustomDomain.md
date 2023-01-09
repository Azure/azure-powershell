### Example 1: List AzureFrontDoor customdomains under the profile
```powershell
Get-AzFrontDoorCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6
```

```output
Name      ResourceGroupName
----      -----------------
domain001 testps-rg-da16jm
domain002 testps-rg-da16jm
```

List AzureFrontDoor customdomains under the profile

### Example 2: Get an AzureFrontDoor customdomain under the profile
```powershell
Get-AzFrontDoorCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -CustomDomainName domain001
```

```output
Name      ResourceGroupName
----      -----------------
domain001 testps-rg-da16jm
```

Get an AzureFrontDoor customdomain under the profile

