### Example 1: Update an AzureFrontDoor route under the AzureFrontDoor profile
```powershell
Update-AzFrontDoorCdnRoute -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -Name route001 -EnabledState "Enabled"
```

```output
Name     ResourceGroupName
----     -----------------
route001 testps-rg-da16jm
```

Update an AzureFrontDoor route under the AzureFrontDoor profile


### Example 2: Update an AzureFrontDoor route under the AzureFrontDoor profile via identity
```powershell
Get-AzFrontDoorCdnRoute -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -Name route001  | Update-AzFrontDoorCdnRoute -EnabledState "Enabled"
```

```output
Name     ResourceGroupName
----     -----------------
route001 testps-rg-da16jm
```

Update an AzureFrontDoor route under the AzureFrontDoor profile via identity