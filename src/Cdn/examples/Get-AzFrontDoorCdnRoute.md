### Example 1: List AzureFrontDoor routes under the AzureFrontDoor profile
```powershell
Get-AzFrontDoorCdnRoute -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001
```

```output
Name     ResourceGroupName
----     -----------------
route001 testps-rg-da16jm
route002 testps-rg-da16jm
route003 testps-rg-da16jm
route004 testps-rg-da16jm
```

List AzureFrontDoor routes under the AzureFrontDoor profile

### Example 2: Get an AzureFrontDoor route under the AzureFrontDoor profile
```powershell
Get-AzFrontDoorCdnRoute -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -Name route001
```

```output
Name     ResourceGroupName
----     -----------------
route001 testps-rg-da16jm
```

Get an AzureFrontDoor route under the AzureFrontDoor profile
